using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Dap
{
    public class grades
    {
        /// <summary>
        /// 通过年级找到对应班级
        /// </summary>
        /// <param name="grade"></param>
        /// <returns> 班级数组</returns>
        public static List<Models.Grades> findClas(string grade)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var clas = from x in dc.GetTable<Models.Grades>()
                           where x.Grade == grade
                           select x;
                if (clas != null)
                {
                    return clas.ToList();
                }
                else throw (new Exception("暂没有该年级的班级信息"));
            }


        }
    }
}
