using System;
using server;
using myDevices;
using myIter;


namespace myMemento
{
    class DeviceCareTaker
    {
        public DeviceMemento _memento { get; set; }

        public DeviceCareTaker()
        {}
    }
    class DeviceMemento 
    {
        public String name { get; private set; }
        public String ip_addr { get; private set; }
        public String default_gateway { get; private set; }

        public DeviceMemento(String _name, String _ip_addr, String _def_gat)
        {
            name = _name;
            ip_addr = _ip_addr;
            default_gateway = _def_gat;
        }
    }
}