using System;
using System.Collections.Generic;
using System.Linq;
using devices;

namespace exercicio3
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // inicializar variaveis com a instância do servidor dhcp
            var s1 = DHCP_Server.GetInstance();
            var s2 = DHCP_Server.GetInstance();
            var s3 = DHCP_Server.GetInstance();
            var s4 = DHCP_Server.GetInstance();

            // verifica se as variáveis utilizam a mesma instância
            if (s1 == s2 && s2 == s3 && s3 == s4)
            {
                Console.WriteLine("Mesma instância.");
            }
            
            // coloca as variáveis de servidor numa lista para iterar sobre e listar os dispositivos, mostrando que são a mesma insância 
            // tanto na inicialização como na execução
            var servers = new List<DHCP_Server>(){s1, s2, s3, s4};

            foreach (var server in servers)
            {
                Console.WriteLine(String.Join("\n ", server.GetDevices().Select(x => x.GetAttributes())));
            }
        }
    }

    class DHCP_Server
    {
        private static readonly DHCP_Server _instance = new DHCP_Server();

        private String ip_addr { get; set; }
        private String default_gateway {get; set; }
        private Int64 ip_range { get; set; }
        private List<Device> devices { get; set; }

        private DHCP_Server()
        {
            ip_addr = "192.168.1.1";
            default_gateway = "192.168.1.254";
            ip_range = 252;

            devices = new List<Device>();

            for (int i=0; i<11; i++, ip_range--)
            {   
                if (i%2 == 0)
                // usando adapter aqui
                    devices.Add(new iPhoneAdapter($"Device {i+1}", $"192.168.1.{254-ip_range}", default_gateway));
                else
                    devices.Add(new AndroidAdapter($"Device {i+1}", $"192.168.1.{254-ip_range}", default_gateway));
                // a linha abaixo quando descomentada mostra a inicialização única da instância
                // Console.WriteLine($"Device {i+1}, ip address: 192.168.1.{254-ip_range}, {default_gateway}");
            }
        }

        public static DHCP_Server GetInstance()
        {
            return _instance;
        }

        public List<Device> GetDevices()
        {
            return devices;
        }
    }
}
