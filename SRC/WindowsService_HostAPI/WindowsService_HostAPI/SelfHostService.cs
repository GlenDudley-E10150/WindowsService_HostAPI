
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;


namespace WindowsService_HostAPI 
{
    public class SelfHostService : ServiceBase
    {
        private System.ComponentModel.IContainer components = null;

        public SelfHostService()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            var config = new HttpSelfHostConfiguration("Http://LocalHost:4848");
            config.Routes.MapHttpRoute(
                   name: "API",
                   routeTemplate: "{controller}/{action}/{id}",
                   defaults: new { id = RouteParameter.Optional }
                );

            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();

        }

        protected override void OnStop()
        {
            base.OnStop();
        }



        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "SelfHostService";
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
