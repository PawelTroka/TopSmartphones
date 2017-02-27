using System;
using System.ComponentModel;
using System.Windows;

namespace TopSmartphones
{
    public class Smartphone : INotifyPropertyChanged
    {
        private int m_Cores;
        private double m_DisplaySize;
        private DisplayTechnology m_DisplayType;
        private bool m_HasStorageExpansion;
        private bool m_Is64Bit;
        private string m_Model;
        private OperatingSystems m_OS;
        private double m_OSVersion;
        private string m_PictureLocation, m_Processor;
        private string m_Producer;
        private int m_RAM;
        private Point m_Resolution;

        public Smartphone(string producer, string model)
        {
            m_Producer = producer;
            m_Model = model;
        }

        public Smartphone(Smartphone smartphone)
        {
            Producer = smartphone.Producer;

            Model = smartphone.Model;

            PictureLocation = smartphone.PictureLocation;

            DisplaySize = smartphone.DisplaySize;

            DisplayType = smartphone.DisplayType;

            Resolution = smartphone.Resolution;

            Processor = smartphone.Processor;

            Cores = smartphone.Cores;
            RAM = smartphone.RAM;

            Is64Bit = smartphone.Is64Bit;
            HasStorageExpansion = smartphone.HasStorageExpansion;

            OS = smartphone.OS;
            OSVersion = smartphone.OSVersion;
        }

        public string Producer
        {
            get { return m_Producer; }
            set
            {
                m_Producer = value;
                RaisePropertyChanged("Producer");
            }
        }

        public string Model
        {
            get { return m_Model; }
            set
            {
                m_Model = value;
                RaisePropertyChanged("Model");
            }
        }

        public string Name
        {
            get { return Producer + " " + Model; }
        }

        public string PictureLocation
        {
            get { return m_PictureLocation; }
            set
            {
                m_PictureLocation = value;
                RaisePropertyChanged("PictureLocation");
            }
        }

        public double DisplaySize
        {
            get { return m_DisplaySize; }
            set
            {
                m_DisplaySize = value;
                RaisePropertyChanged("DisplaySize");
            }
        }

        public DisplayTechnology DisplayType
        {
            get { return m_DisplayType; }
            set
            {
                m_DisplayType = value;
                RaisePropertyChanged("DisplayType");
            }
        }


        public Point Resolution
        {
            get { return m_Resolution; }
            set
            {
                m_Resolution = value;
                RaisePropertyChanged("Resolution");
            }
        }

        public double PixelDensity
        {
            get { return Math.Sqrt(Resolution.X*Resolution.X + Resolution.Y*Resolution.Y)/DisplaySize; }
        }

        public string Processor
        {
            get { return m_Processor; }
            set
            {
                m_Processor = value;
                RaisePropertyChanged("Processor");
            }
        }

        public int Cores
        {
            get { return m_Cores; }
            set
            {
                m_Cores = value;
                RaisePropertyChanged("Cores");
            }
        }

        public int RAM
        {
            get { return m_RAM; }
            set
            {
                m_RAM = value;
                RaisePropertyChanged("RAM");
            }
        }


        public bool Is64Bit
        {
            get { return m_Is64Bit; }
            set
            {
                m_Is64Bit = value;
                RaisePropertyChanged("Is64Bit");
            }
        }

        public bool HasStorageExpansion
        {
            get { return m_HasStorageExpansion; }
            set
            {
                m_HasStorageExpansion = value;
                RaisePropertyChanged("HasStorageExpansion");
            }
        }

        public OperatingSystems OS
        {
            get { return m_OS; }
            set
            {
                m_OS = value;
                RaisePropertyChanged("OS");
            }
        }

        public double OSVersion
        {
            get { return m_OSVersion; }
            set
            {
                m_OSVersion = value;
                RaisePropertyChanged("OSVersion");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}