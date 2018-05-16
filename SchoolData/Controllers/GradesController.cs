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
    public class GradesController : ApiController
    {
        /// <summary>
        /// 根据年级查找班级
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>对应班级数组</returns>
        [HttpGet]
        public RESULT FindClas(string grade)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.grades.findClas(grade);
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
