using System;
using System.Collections.Generic;
using myDevices;
using myIter;

namespace server
{
    class DHCP_Server
    {
        private static DHCP_Server _instance;
        public String ip_addr { get; set; }
        public String default_gateway {get; set; }
        public int ip_range { get; set; }
        private DeviceList _devices { get; set; }
        public myIterator _devices_iterator;

        private DHCP_Server()
        {
            ip_addr = "192.168.1.1";
            default_gateway = "192.168.1.254";
            ip_range = 252;
            
            _devices = new DeviceList();
            
            // adiciona manualmente alguns dispositivos ao servidor
            for (int i=0; i<11; i++, ip_range--)
            {   
                if (i%2 == 1)
                // usando adapter aqui
                    _devices[i] = new iPhoneAdapter($"Device {i+1}", $"192.168.1.{254-ip_range}", default_gateway);
                else
                    _devices[i] = new AndroidAdapter($"Device {i+1}", $"192.168.1.{254-ip_range}", default_gateway);
                // a linha abaixo demostra a inicialização única da instância
                // Console.WriteLine($"Device {i+1}, ip address: 192.168.1.{254-ip_range}, {default_gateway}");
            }

            _devices_iterator = _devices.CreateIterator();
        }

        public static DHCP_Server Instance()
        {   
            if(_instance == null)
            {
                _instance = new DHCP_Server();
            }
            return _instance;
        }
        public List<Device> GetDevices()
        {   
            return _devices.GetDevices();
        }

        public void AddDevice(Device device)
        {
            _devices.AddDevice(device);
        }

        public void PopDevice(String _ip_addr)
        {
            _devices.PopDevice(_ip_addr);
        }
    }
}