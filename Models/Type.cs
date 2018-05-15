using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Models
{
    [Table(Name = "Type")]
    public class Type
    {
        [Column]
        public int ID { get; set; }

        [Column]
        public string Name { get; set; }
    }
}
