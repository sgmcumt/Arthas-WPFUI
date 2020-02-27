using System.Threading.Tasks;
using Arthas.Binder;

namespace Arthas.Demo
{
    public class MainWindow_Model : ViewModel
    {
        public string Title
        {
            get => GetValue(() => "Arthas.Demo");
            set => SetValue(value);
        }

        public bool BtnEnabled
        {
            get => GetValue(() => true);
            set => SetValue(value);
        }

        public AsyncCommand<object> CmdSample
        {
            get => GetAsyncCommand<object>(async obj => await Task.Run(async () =>
            {
                Title = "Busy...";
                BtnEnabled = false;
                //do something
                await Task.Delay(2000);
                Title = "Arthas.Demo";
                BtnEnabled = true;
            }));
        }

        public AsyncCommand<string> CmdSampleWithParam
        {
            get => GetAsyncCommand<string>(async str => await Task.Run(async () =>
            {
                Title = $"Hello I'm {str} currently";
                BtnEnabled = false;
                //do something
                await Task.Delay(2000);
                Title = "Arthas.Demo";
                BtnEnabled = true;
            }));
        }
    }
}