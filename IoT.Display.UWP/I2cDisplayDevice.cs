using System;
using Windows.Devices.I2c;
using IoT.Display.Devices;

namespace IoT.Display.UWP
{
    public class I2cDisplayDevice : IDevice
    {
        private readonly I2cDevice display;

        public I2cDisplayDevice(I2cDevice display)
        {
            this.display = display ?? throw new ArgumentNullException(nameof(display));
        }

        public void Write(byte[] buffer)
        {
            this.display.Write(buffer);
        }

        public void Dispose()
        {
            this.display.Dispose();
        }
    }
}