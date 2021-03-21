using System;
using System.Collections.Generic;
using System.Linq;
using myDevices;
using myIter;

namespace exercicio3
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // inicializar variaveis com a instância do servidor dhcp
            var s1 = DHCP_Server.Instance();
            var s2 = DHCP_Server.Instance();
            var s3 = DHCP_Server.Instance();
            var s4 = DHCP_Server.Instance();

            // verifica se as variáveis utilizam a mesma instância
            if (s1 == s2 && s2 == s3 && s3 == s4)
            {
                Console.WriteLine("Mesma instância.");
            }
            
            // o bloco abaixo coloca as variáveis de servidor numa lista para iterar sobre e listar os dispositivos, mostrando que são a mesma insância 
            // tanto na inicialização como na execução
            //
            // var servers = new List<DHCP_Server>(){s1, s2, s3, s4};
            // foreach (var server in servers)
            // {
            //     Console.WriteLine(String.Join("\n ", server.GetDevices().Select(x => x.GetAttributes())));
            // }

            // usando iterator aqui
            myIterator it = s1._devices_iterator;
            for(Device dev = it.First(); !it.IsOver; dev = it.Next())
            {
                Console.WriteLine(dev.GetAttributes());
            }

        }
    }

    class DHCP_Server
    {
        private static DHCP_Server _instance;
        private String ip_addr { get; set; }
        private String default_gateway {get; set; }
        private Int64 ip_range { get; set; }
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
                if (i%2 == 0)
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
    }
}
