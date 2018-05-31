using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Models
{
    [Table(Name = "User")]
    public class User
    {
        [Column]
        public string UserName { get; set; }

        [Column]
        public string Password { get; set; }

        [Column]
        public string RealName { get; set; }

        [Column]
        public string E_mail { get; set; }

        [Column]
        public string MobilePhone { get; set; }

        [Column(IsPrimaryKey = true)]
        public  Guid ID { get; set; }
    }
}
