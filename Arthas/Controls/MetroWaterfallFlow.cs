using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls
{
    public class MetroWaterfallFlow : Canvas
    {
        int column;
        double listWidth = 180;

        public double ListWidth
        {
            get => listWidth;
            set
            {
                listWidth = value;
                SetColumn();
            }
        }

        static MetroWaterfallFlow()
        {
            ElementBase.DefaultStyle<MetroWaterfallFlow>(DefaultStyleKeyProperty);
        }

        public MetroWaterfallFlow()
        {
            Loaded += delegate
            {
                SetColumn();
                Margin = new Thickness(Margin.Left);
            };
            SizeChanged += delegate
            {
                SetColumn();
            };
        }

        void SetColumn()
        {
            // MinWidth = listWidth + Margin.Left * 4;
            column = (int)(ActualWidth / listWidth);
            if (column <= 0)
                column = 1;
            Refresh();
        }

        public void Add(FrameworkElement element)
        {
            element.Width = ListWidth;
            if (element is Grid grid)
                if (grid.Children.Count > 0)
                    ((FrameworkElement)grid.Children[0]).Margin = new Thickness(Margin.Left);
            Children.Add(element);
            Refresh();
        }

        public class Point
        {
            public int Index { get; set; }
            public double Buttom { get; set; }
            public double Height { get; set; }

            public Point(int index, double height, double buttom)
            {
                Index = index;
                Height = height;
                Buttom = buttom;
            }
        }

        public void Refresh()
        {
            // 初始化参数
            var maxHeight = 0.0;
            var list = new Dictionary<int, Point>();
            var newList = new Dictionary<int, Dictionary<int, Point>>();
            for (var i = 0; i < Children.Count; i++)
            {
                (Children[i] as FrameworkElement)?.UpdateLayout();
                list.Add(i, new Point(i, ((FrameworkElement)Children[i]).ActualHeight, 0.0));
            }

            for (var i = 0; i < column; i++)
                newList.Add(i, new Dictionary<int, Point>());

            // 智能排序到 nlist
            for (var i = 0; i < list.Count; i++)
                if (i < column)
                {
                    list[i].Buttom = list[i].Height;
                    newList[i].Add(newList[i].Count, list[i]);
                }
                else
                {
                    var b = 0.0;
                    var l = 0;
                    for (var j = 0; j < column; j++)
                    {
                        var jh = newList[j][newList[j].Count - 1].Buttom + list[i].Height;
                        if (b != 0.0 && !(jh < b))
                            continue;
                        b = jh;
                        l = j;
                    }

                    list[i].Buttom = b;
                    newList[l].Add(newList[l].Count, list[i]);
                }

            // 开始布局
            for (var i = 0; i < newList.Count; i++)
            {
                for (var j = 0; j < newList[i].Count; j++)
                {
                    Children[newList[i][j].Index].SetValue(LeftProperty, i * ActualWidth / column);
                    Children[newList[i][j].Index].SetValue(TopProperty, newList[i][j].Buttom - newList[i][j].Height);
                    Children[newList[i][j].Index].SetValue(WidthProperty, ActualWidth / column);

                    if (Children[newList[i][j].Index] is Grid)
                        ((FrameworkElement)(Children[newList[i][j].Index] as Grid)?.Children[0]).Margin = Margin;
                }

                // 不知道为什么如果不写这么一句会出错
                if (newList.ContainsKey(i))
                    if (newList[i].ContainsKey(newList[i].Count - 1))
                    {
                        var mh = newList[i][newList[i].Count - 1].Buttom;
                        maxHeight = mh > maxHeight ? mh : maxHeight;
                    }
            }

            Height = maxHeight;
            list.Clear();
            newList.Clear();
        }

        public void Remove(UIElement element)
        {
            Children.Remove(element);
            Refresh();
        }
    }
}