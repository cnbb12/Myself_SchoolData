using Dap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolData.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// 检查登录是否成功
        /// </summary>
        /// <param name="userName"></param>g
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public RESULT checkLogin(string userName, string key)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.user.checkLogin(userName, key);
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public RESULT AddUser(Models.User user)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.user.Add(user);
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userID"></param>
        [HttpDelete]
        public void DeleteUser(string userID)
        {
            Dap.user.DeleteUser(userID);
        }

        /// <summary>
        /// 查找特定用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUser(string userID)
        {
            return Json<List<Models.User>>(Dap.user.GetUsers(userID));

        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public void UpdateUser(Models.User user)
        {
            Dap.user.UpdateUser(user);
        }

    }
}
