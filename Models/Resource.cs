using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table(Name = "Resource")]
    public class Resource
    {
        [Column(IsPrimaryKey = true)]
        public Guid ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public DateTime CreateTime { get; set; }

        [Column]
        public int Size { get; set; }

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

        [Column]
        public Guid UploadUserID { get; set; }
    }
}
