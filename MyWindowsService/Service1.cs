using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MulServiceLibrary;
using System.ServiceModel;

namespace MyWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        ServiceHost sh = null;

        protected override void OnStart(string[] args)
        {
            sh = new ServiceHost(typeof(MulService), new Uri("net.tcp://localhost:9002/MyService"));
            sh.Open();
        }

        protected override void OnStop()
        {
            if (sh != null)
            {
                sh.Close();
            }
            sh = null;
        }
    }
}
