﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Logicom_Inventaire_FrontEnd.Startup))]
namespace Logicom_Inventaire_FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
