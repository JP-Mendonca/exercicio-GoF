using System;
using System.Collections.Generic;
using myIter;

namespace myDevices
{
    class Device  
    {
        public String name { get; set; }
        public String ip_addr { get; set; }
        public String default_gateway { get; set; }
        public Device(String name, String ip_addr, String def_gat)
        {
            this.name = name;
            this.ip_addr = ip_addr;
            default_gateway = def_gat;
        }
        public virtual String GetAttributes()
        {
            String[] attributes = { name, ip_addr, default_gateway };
            return String.Join(", ", attributes);
        }
    }

    abstract class AbsDeviceList
    {
        public abstract myIterator CreateIterator();
    }

    class DeviceList : AbsDeviceList
    {
        private List<Device> _devices { get; set; }

        public DeviceList()
        {
            _devices = new List<Device>();
        }
        public override myIterator CreateIterator()
        {
            return new myIterator(this);
        }

        public int Count
        {
            get { return _devices.Count; }
        }
        
        public object this[int index]
        {   // adiciona dispositivo em uma posição específica
            get { return _devices[index]; }
            set { _devices.Insert(index, value as Device); }
        }
        public List<Device> GetDevices()
        {
            return _devices;
        }
        public void AddDevice(Device device)
        {   // adiciona dispositivo no final da lista
            _devices.Add(device);
        }
    }

    class iPhoneAdapter : Device
    {
        private iPhone my_iPhone = new iPhone();
        public iPhoneAdapter(String _name, String _ip_addr, String _def_gat) : base(_name, _ip_addr, _def_gat)
        {}
        public override string GetAttributes()
        {
            return String.Join(", ", base.GetAttributes()+", "+my_iPhone.typeOfDevice);
        }
    }
    class iPhone
    {
        public String typeOfDevice = "This device is an iPhone";
        public iPhone()
        {}
    }
    class AndroidAdapter : Device
    {
        private Android my_android = new Android();
        public AndroidAdapter(String _name, String _ip_addr, String _def_gat) : base(_name, _ip_addr, _def_gat)
        {}
        public override string GetAttributes()
        {
            return String.Join(", ", base.GetAttributes()+", "+my_android.typeOfDevice);
        }
    }
    class Android
    {
        public String typeOfDevice = "This device is an android";
        public Android()
        {}
    }
}