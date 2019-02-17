using Windows.ApplicationModel.Background;
using IoT.Display.UWP.DemoApp.Core;

namespace IoT.Display.UWP.DemoApp
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _defferal;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _defferal = taskInstance.GetDeferral();
            var display = await Ssd1306Factory.CreateAtI2C();
            App.run(display);
        }
    }
}