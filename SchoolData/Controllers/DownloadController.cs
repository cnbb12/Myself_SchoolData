using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dap;
using Swashbuckle.Swagger;

using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SchoolData.Controllers
{
    /// <summary>
    /// 下载文件
    /// </summary>
    public class DownloadController : ApiController
    {
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public RESULT Download(string name)
        {
            RESULT result = new RESULT();
            try
            {
                //获取url
                List<Models.Resource> resources = Dap.resource.searchResourceAccordingKeyWord(name);
                String uploadId = resources.First().UploadUserID.ToString();
                String extname = resources.First().Suffix.ToString();
                String url = "http://localhost:63676/upload/" + uploadId + "\\" + name + extname;

                string savePath = "D://test/" + name + extname;
                common.Download(url, savePath);

                result.result = url;



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
           
   
