using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Models
{
    [Table(Name = "Grades")]
    public class Grades
    {
        [Column]
        public int ID { get; set; }

        [Column]
        public string Clas { get; set; }

        [Column]
        public string Grade { get; set; }

        [Column]
        public int ClasID { get; set; }

        [Column]
        public int GradeID { get; set; }
    }
}
