using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dap;
using Models;

namespace SchoolData.Controllers
{
    public class ResourceController : ApiController
    {
        /// <summary>
        /// 通过关键字检索资源
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>对应资源数组</returns>
        [HttpGet]
        public RESULT SearchResourcrAccordingKeyWord(string keyword)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.resource.searchResourceAccordingKeyWord(keyword);
            }
            catch(Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 根据资源类型检索资源
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns>对应资源数组</returns>
        public RESULT SearchResourceAccoringType(string typeName)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.resource.searchResourceAccordingType(typeName);
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;

        }

        /// <summary>
        /// 根据学科检索资源
        /// </summary>
        /// <param name="discplineName"></param>
        /// <returns>对应资源数组</returns>
        public RESULT SearchResourceAccoringDiscpline(string discplineName)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.resource.searchResourceAccoringDiscipline(discplineName);
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;

        }

        /// <summary>
        /// 根据班级、年级检索资源
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="clas"></param>
        /// <returns>对应资源数组</returns>
        public RESULT SearchResourceAccoringGrade(string grade, string clas)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.resource.searchResourceAccoringGrade(grade,clas);
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
