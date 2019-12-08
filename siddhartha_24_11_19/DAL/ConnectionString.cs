using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace siddhartha_24_11_19.DAL
{
    public class ConnectionString
    {
        public ConnectionString() { 
        }
        public string connect()
        {   
            // local , Default
            return ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        }
    }
  
}