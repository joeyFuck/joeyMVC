using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepZ.Controllers
{
    /// <summary>
    ///  保持
    /// </summary>
    public class KeepZ : Attribute//ActionFilterAttribute
    {
        public string[] Propertys  { get; set; }
        public bool Modes { get; set; }
        public KeepZ(params string[] Property)
        {
            Propertys = Property;
        }
        public KeepZ(bool Mode = true, params string[] Property)
        {
            Propertys = Property;
            Modes = Mode;
        } 
        
    }

    public class KeepZModel  
    {
        public string[] Propertys { get; set; }
        public bool Modes { get; set; } 

    }


}