using System;
using System.Collections.Generic;
using System.Windows;

namespace TopSmartphones
{
    internal class SmartphoneFactory : IDisposable
    {
        private bool _disposed;

        public SmartphoneFactory()
        {
            smartphones = new List<Smartphone>();
        }

        public List<Smartphone> smartphones { get; private set; }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        public void produce()
        {
            smartphones.Add(new Smartphone("Samsung", "Galaxy S5")
            {
                PictureLocation = (@"Images\Samsung-Galaxy-S5-0.jpg"),
                OS = OperatingSystems.Android,
                OSVersion = 4.4,
                DisplaySize = 5.1,
                Resolution = new Point(1920, 1080),
                DisplayType = DisplayTechnology.SuperAMOLED,
                Processor = "Qualcomm Snapdragon 801",
                Cores = 4,
                RAM = 2048,
                HasStorageExpansion = true,
                Is64Bit = false
            });


            smartphones.Add(new Smartphone("Samsung", "Galaxy Note 4")
            {
                PictureLocation = (@"Images\Samsung-Galaxy-Note-4-0.jpg"),
                OS = OperatingSystems.Android,
                OSVersion = 4.4,
                DisplaySize = 5.7,
                Resolution = new Point(2560, 1440),
                DisplayType = DisplayTechnology.SuperAMOLED,
                Processor = "Samsung Exynos 7 Octa (5433)",
                Cores = 8,
                RAM = 2048 + 1024,
                HasStorageExpansion = true,
                Is64Bit = true
            });

            smartphones.Add(new Smartphone("Google", "Nexus 6")
            {
                PictureLocation = (@"Images\Google-Nexus-6-0.jpg"),
                OS = OperatingSystems.Android,
                OSVersion = 5.0,
                DisplaySize = 6.0,
                Resolution = new Point(2560, 1440),
                DisplayType = DisplayTechnology.AMOLED,
                Processor = "Qualcomm Snapdragon 805",
                Cores = 4,
                RAM = 2048 + 1024,
                HasStorageExpansion = false,
                Is64Bit = false
            });


            smartphones.Add(new Smartphone("Apple", "iPhone 6")
            {
                PictureLocation = (@"Images\Apple-iPhone-6-0.jpg"),
                OS = OperatingSystems.iOS,
                OSVersion = 8.1,
                DisplaySize = 4.7,
                Resolution = new Point(1334, 750),
                DisplayType = DisplayTechnology.LCD,
                Processor = "Apple A8",
                Cores = 2,
                RAM = 1024,
                HasStorageExpansion = false,
                Is64Bit = true
            });

            smartphones.Add(new Smartphone("Nokia", "Lumia 830")
            {
                PictureLocation = (@"Images\Nokia-Lumia-830-0.jpg"),
                OS = OperatingSystems.WindowsPhone,
                OSVersion = 8.1,
                DisplaySize = 5.0,
                Resolution = new Point(1280, 720),
                DisplayType = DisplayTechnology.IPS,
                Processor = "Qualcomm Snapdragon 400",
                Cores = 4,
                RAM = 1024,
                HasStorageExpansion = true,
                Is64Bit = false
            });
        }
    }
}