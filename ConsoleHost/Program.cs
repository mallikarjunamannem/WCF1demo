using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using MulServiceLibrary;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri httpbaseAddress = new Uri("http://localhost:6790/MyHttpEndPoint");
            Uri tcpbaseAddress = new Uri("net.tcp://localhost:6789");

            ServiceHost sh = new ServiceHost(typeof(MulService), new Uri[] { httpbaseAddress, tcpbaseAddress });

            ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IMulService), new NetTcpBinding(), tcpbaseAddress);
            ServiceEndpoint httpse = sh.AddServiceEndpoint(typeof(IMulService), new WSHttpBinding(), httpbaseAddress);


            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = false;
            //sh.Description.Behaviors.Add(smb);

            ServiceEndpoint httpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(),
                "http://localhost:6790/MyHttpEndPoint/mex");

            ServiceEndpoint tcpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(),
                "net.tcp://localhost:6789/mex");

            sh.Open();

            Console.WriteLine("Started.....");
            foreach (var item in sh.Description.Endpoints)
            { 
            
            Console.WriteLine("Address: "+item.Address.ToString());
            Console.WriteLine("Binding: "+item.Binding.Name.ToString());
            Console.WriteLine("Contract: "+item.Contract.Name.ToString());
        }

            Console.ReadLine();

            sh.Close();
        }
    }
}
