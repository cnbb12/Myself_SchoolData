using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using Models;
using System.Data.Linq;

namespace SchoolData.Controllers
{
    public class uploadController : ApiController
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public Dap.RESULT Upload(Guid userId,string grade,string clas,string type,string form,string discipline)
        {
            if (string.IsNullOrEmpty(grade))
            {
                throw new ArgumentException("message", nameof(grade));
            }

            if (string.IsNullOrEmpty(clas))
            {
                throw new ArgumentException("message", nameof(clas));
            }

            if (string.IsNullOrEmpty(form))
            {
                throw new ArgumentException("message", nameof(form));
            }

            if (string.IsNullOrEmpty(discipline))
            {
                throw new ArgumentException("message", nameof(discipline));
            }

            Dap.RESULT result = new Dap.RESULT();
            try
            {
                HttpRequest request = HttpContext.Current.Request;
                HttpFileCollection files = request.Files;

                if (files.Count > 0) {
                    HttpPostedFile hpf = files[0];

                    //资源放入以上传者命名的文件夹
                    string folder = System.Web.HttpContext.Current.Server.MapPath(".\\"+userId.ToString());//文件保存路径
                    string name,fileName, extname = Path.GetExtension(hpf.FileName);//分别为包括后缀名的文件名，不包括后缀名的文件名、后缀名

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    name = hpf.FileName.Substring(hpf.FileName.LastIndexOf("\\") + 1);
                    fileName = hpf.FileName.Substring(hpf.FileName.LastIndexOf("\\") + 1, (hpf.FileName.LastIndexOf(".") - hpf.FileName.LastIndexOf("\\") - 1));
                    //fileName = DateTime.Now.Ticks.ToString() +  extname;

                    hpf.SaveAs(folder + "\\" + name);
                    result.result = fileName;//上传成功返回文件名。
                    using (DataContext dc = new DataContext(Dap.common.conn))
                    {
                        var tb = dc.GetTable<Models.Resource>();
                        Models.Resource _resource = new Models.Resource();
                        _resource.Name = fileName;
                        _resource.Size = (int)Math.Ceiling((hpf.ContentLength) / 1024m);
                        _resource.UploadUserID = userId;
                        _resource.Grades = grade;
                        _resource.Clas = clas;
                        _resource.Type = type;
                        _resource.Form = form;
                        _resource.Suffix = extname;//后缀名
                        _resource.ID = Guid.NewGuid();
                        _resource.Discipline = discipline;
                        _resource.CreateTime = DateTime.Now.ToString("d");//时间以xx-x-x形式显示
                        tb.InsertOnSubmit(_resource);
                        dc.SubmitChanges();
                    }
                    

                }
                else
                {
                    result.state = false;
                    result.msg = "请先选择需要上传的文件。";
                }
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;
        }
    }
}
