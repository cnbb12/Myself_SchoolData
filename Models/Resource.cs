using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Models
{
    [Table(Name = "Resource")]
    public class Resource
    {
        [Column]
        public int ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public DateTime CreateTime { get; set; }

        [Column]
        public int Size { get; set; }

        [Column]
        public string FTPServerPath { get; set; }

        [Column]
        public string Type { get; set; }

        [Column]
        public string Discipline { get; set; }

        [Column]
        public string Grades { get; set; }

        [Column]
        public string Clas { get; set; }

        [Column]
        public string Form { get; set; }
    }
}
