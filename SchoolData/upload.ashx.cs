using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SchoolData
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string result = "", folder, extname;
            HttpPostedFile hpf;
            hpf = context.Request.Files[0];//获取前端传送的文件
            //string type = context.Request.QueryString["type"], sid = context.Request.QueryString["sid"], taskId = context.Request.QueryString["taskId"];

            folder = System.Web.HttpContext.Current.Server.MapPath(@"upload");//文件保存路径

            extname = hpf.FileName;
            extname = extname.Substring(extname.LastIndexOf(".") + 1, (extname.Length - extname.LastIndexOf(".") - 1));//获取后缀名
            /*
            if (!task.allowFiletypes.Contains(extname))
            {
                result = "{\"success\":false,\"data\":\"Error Files Type\"}";
                break;
            }
            if (hpf.ContentLength > task.maxSize * 1024)
            {
                result = "{\"success\":false,\"data\":\"File Size Error\"}";
                break;
            }
            */
            try
            {
                result = Upload(hpf, folder);
                //上传成功时写入作业提交记录。
                
                result = "{\"success\":true,\"data\":\"Succeed\",\"file\":\"" + result + "\"}";
            }
            catch (Exception e)
            {
                result = "{\"success\":false,\"data\":\"" + e.Message + "\"}";
            }
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.Write(result);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string Upload(HttpPostedFile hpf, string uploadPath, string fileName = null)
        {
            try
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string extname = hpf.FileName;
                extname = extname.Substring(extname.LastIndexOf(".") + 1, (extname.Length - extname.LastIndexOf(".") - 1));
                if (fileName == null)
                    fileName = DateTime.Now.Ticks.ToString() +"."+ extname;
                hpf.SaveAs(uploadPath + "\\" + fileName);
                return fileName;//上传成功返回文件名。
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}