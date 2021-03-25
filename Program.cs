using System;
using myDevices;
using myIter;
using server;
using System.Collections.Generic;
using myMemento;

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

            List<DeviceCareTaker> dct_list = new List<DeviceCareTaker>();
            
            int cont = 0;
            for(Device dev = it.First(); !it.IsOver; dev = it.Next())
            {   
                dct_list.Add(new DeviceCareTaker());
                dct_list[cont++]._memento = dev.SaveState();
                dev.default_gateway = "No gateway";
                Console.WriteLine(dev.GetAttributes());
            }
            cont = 0;
            for(Device dev = it.First(); !it.IsOver; dev = it.Next())
            {   
                dev.RestoreState(dct_list[cont++]._memento);
                Console.WriteLine(dev.GetAttributes());
            }

        }
    }

}
