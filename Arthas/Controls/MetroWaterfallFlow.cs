using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Arthas.Controls
{
    public class MetroWaterfallFlow : Panel
    {
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register(nameof(Size), typeof(double), typeof(MetroWaterfallFlow),
                new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        public double Size
        {
            get => (double)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        static double GetValue(double num, double defVal = 0.0)
        {
            return double.IsNaN(num) || double.IsNegativeInfinity(num) || double.IsPositiveInfinity(num) ? defVal : num;
        }

        int GetColumn(double width)
        {
            var itemSize = GetValue(Size, 100.0);
            var value = GetValue(width);
            var column = value / itemSize;
            return (int)Math.Max(column, 1);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return Layout(constraint, true);
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Layout(arrangeSize, false);
            return arrangeSize;
        }

        void ForEach(int column, Action<int, UIElement[]> action)
        {
            var index = 0;
            var items = new List<UIElement>();

            for (var i = 0; i < InternalChildren.Count; i++)
            {
                var child = InternalChildren[i];

                if (child is Popup)
                    continue;

                if (child.Visibility == Visibility.Collapsed)
                    continue;

                index++;
                items.Add(child);

                if (items.Count != column)
                    continue;

                action(index - items.Count, items.ToArray());

                items.Clear();
            }

            if (items.Count == 0)
                return;

            action(index - items.Count, items.ToArray());
            items.Clear();
        }

        Size Layout(Size size, bool isMeasure)
        {
            var result = default(Size);
            var column = GetColumn(size.Width);
            var itemSize = GetValue(size.Width / column);

            var bottoms = new Dictionary<int, double>();
            for (var i = 0; i < column; i++)
                bottoms[i] = 0.0;

            ForEach(column, (index, items) =>
            {
                for (var i = 0; i < items.Length; i++)
                {
                    var child = items[i];

                    if (isMeasure)
                        child.Measure(new Size(itemSize, double.PositiveInfinity));

                    var newIndex = i;

                    if (!isMeasure)
                        child.Arrange(new Rect(newIndex * itemSize, bottoms[newIndex], itemSize, child.DesiredSize.Height));

                    bottoms[newIndex] += child.DesiredSize.Height;
                }
            });

            result.Width = GetValue(size.Width);
            foreach (var bottom in bottoms)
                result.Height = Math.Max(result.Height, bottom.Value);

            return result;
        }
    }
}