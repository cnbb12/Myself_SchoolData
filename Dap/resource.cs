using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using Models;

namespace Dap
{
    public class resource
    {
        /// <summary>
        /// 根据关键字检索资源
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>对应资源数组</returns>
        public static List<Models.Resource> searchResourceAccordingKeyWord(string keyword)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var resource = from x in dc.GetTable<Models.Resource>()
                               where x.Name.Contains(keyword)
                               select x;
                if (resource != null)
                {
                    return resource.ToList();
                }
                else
                {
                    throw (new Exception("没有找到对应资源"));
                }

            }
        }


        /// <summary>
        /// 根据资源类型检索对应资源
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns>对应资源数组</returns>
        public static List<Models.Resource> searchResourceAccordingType(string typeName)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var _type = from x in dc.GetTable<Models.Type>()
                            where x.Name == typeName
                            select x;
                int typeID = _type.First().ID;
                var resource = from x in dc.GetTable<Models.Resource>()
                               where x.TypeID == typeID
                               select x;
                if (resource != null)
                {
                    return resource.ToList();
                }
                else throw (new Exception("没有找到对应资源"));

            }
        }

        /// <summary>
        /// 根据学科检索对应资源
        /// </summary>
        /// <param name="disciplineName"></param>
        /// <returns>对应资源数组</returns>
        public static List<Models.Resource> searchResourceAccoringDiscipline(string disciplineName)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var _discipline = from x in dc.GetTable<Models.Discipline>()
                                  where x.Name == disciplineName
                                  select x;
                int discplineID = _discipline.First().ID;
                var resource = from x in dc.GetTable<Models.Resource>()
                               where x.DisciplineID == discplineID
                               select x;
                if (resource != null)
                {
                    return resource.ToList();
                }
                else throw (new Exception("没有找到对应资源"));
            }
        }

        
        /// <summary>
        /// 根据班级、年级查找对应资源
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="clas"></param>
        /// <returns>对应资源数组</returns>
        public static List<Models.Resource> searchResourceAccoringGrade(string grade,string clas)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var _grade_clas = from x in dc.GetTable<Models.Grades>()
                                  where x.Grade == grade && x.Clas == clas
                                  select x;
                int grade_clas_ID = _grade_clas.First().ID;
                var resource = from x in dc.GetTable<Models.Resource>()
                               where x.GradesID == grade_clas_ID
                               select x;
                if (resource != null)
                {
                    return resource.ToList();
                }
                else throw (new Exception("没有找到对应资源"));
            }
        }

    }
}
