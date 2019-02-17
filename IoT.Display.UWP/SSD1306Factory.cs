using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using IoT.Display.Devices.SSD1306;

namespace IoT.Display.UWP
{
    public static class Ssd1306Factory
    {
        private const string I2CControllerName = "I2C1";
        private const byte Ssd1306Address = 0x3C;

        public static SSD1306 CreateAtI2C(I2cDevice display)
        {
            return new SSD1306(new I2cDisplayDevice(display));
        }

        public static async Task<SSD1306> CreateAtI2C(string i2CControllerName = I2CControllerName, byte ssd1306Address = Ssd1306Address)
        {
            I2cConnectionSettings settings = new I2cConnectionSettings(ssd1306Address) { BusSpeed = I2cBusSpeed.FastMode };
            string aqs = I2cDevice.GetDeviceSelector(I2CControllerName);
            DeviceInformationCollection dis = await DeviceInformation.FindAllAsync(aqs);
            if (dis.Count == 0)
            {
                throw new ArgumentException($"The controller '{i2CControllerName}' yielded no devices.", nameof(i2CControllerName));
            }

            var display = await I2cDevice.FromIdAsync(dis[0].Id, settings);
            if (display == null)
            {
                throw new ArgumentException($"I2C device was not found at address {ssd1306Address}.", nameof(ssd1306Address));
            }

            return CreateAtI2C(display);
        }
    }
}
