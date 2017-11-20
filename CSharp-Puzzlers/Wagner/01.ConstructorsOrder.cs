using System;

namespace CSharp_Puzzlers.Wagner
{
    public abstract class Device
    {
        public abstract void Initialize();

        protected Device()
        {
            Console.WriteLine("Device.Ctor");
            Initialize();
        }
    }

    public class Phone : Device
    {
        private readonly bool? wifiModuleIsOn = false;
        public Phone()
        {
            Console.WriteLine("Phone.Ctor");
            wifiModuleIsOn = true;
        }

        public override void Initialize()
        {
            Console.WriteLine($"Phone.Initialize. WiFi State = {wifiModuleIsOn}");
        }
    }
}
