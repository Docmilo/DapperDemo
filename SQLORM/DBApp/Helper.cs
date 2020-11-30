using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            //Look up the connection string in the app.config and return it
            //Remember to change the connection string in app.config for your PC/SQL Install 
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
