using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dap
{
    class common
    {
        public static String conn
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
    }

    public class RESULT
    {
        public bool state { get; set; }
        public dynamic result { get; set; }
        public string msg { get; set; }
        public RESULT(string token = "")
        {
            this.state = true;
            this.msg = "succeed";
            //在这里可以添加有关token等验证操作
        }
    }
}
