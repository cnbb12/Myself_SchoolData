using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Web;
using System.IO;

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
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   where x.Name.Contains(keyword)
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else
                    {
                        throw (new Exception("没有找到对应资源"));
                    }
                    
                }
                else
                {
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else
                    {
                        throw (new Exception("没有找到对应资源"));
                    }
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
                var resource = from x in dc.GetTable<Models.Resource>()
                               where x.Type == typeName
                               select x;
                if (resource.Count() >= 1)
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
        public static List<Models.Resource> searchResourceAccordingDiscipline(string disciplineName)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var resource = from x in dc.GetTable<Models.Resource>()
                               where x.Discipline == disciplineName
                               select x;
                if (resource.Count() >= 1)
                {
                    return resource.ToList();
                }
                else throw (new Exception("没有找到对应资源"));
            }
        }

        /// <summary>
        /// 根据格式检索对应资源
        /// </summary>
        /// <param name="formName"></param>
        /// <returns>对应资源数组</returns>
        public static List<Models.Resource> searchResourceAccordingForm(string formName)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                if (!string.IsNullOrWhiteSpace(formName))
                {
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   where x.Form== formName
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else throw (new Exception("没有找到对应资源"));
                }
                else
                {
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else throw (new Exception("没有找到对应资源"));
                }
                
            }
        }


        /// <summary>
        /// 根据班级、年级查找对应资源
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="clas"></param>
        /// <returns>对应资源数组</returns>
        public static List<Models.Resource> searchResourceAccordingGrade(string grade,string clas)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                if (string.IsNullOrWhiteSpace(grade) && !(string.IsNullOrWhiteSpace(clas))) {
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   where x.Clas == clas
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else throw (new Exception("没有找到对应资源"));
                }
                else if (!(string.IsNullOrWhiteSpace(grade)) && string.IsNullOrWhiteSpace(clas))
                {
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   where x.Grades == grade
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else throw (new Exception("没有找到对应资源"));
                }
                else if(grade != "" && clas != ""){
                    var resource = from x in dc.GetTable<Models.Resource>()
                                   where x.Grades == grade && x.Clas == clas
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else throw (new Exception("没有找到对应资源"));
                }
                else
                {
                    var resource = from x in dc.GetTable<Models.Resource>()                                
                                   select x;
                    if (resource.Count() >= 1)
                    {
                        return resource.ToList();
                    }
                    else throw (new Exception("没有找到对应资源"));
                }
            }
        }
         
        public static void uploadToSQL(string name,DateTime create_time,int size,string type,string discipline,string form)
        {

        }
        

    }
}
