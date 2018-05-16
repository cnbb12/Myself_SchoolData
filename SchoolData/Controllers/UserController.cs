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
        /// <param name="key"></param>
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
        public RESULT DeleteUser(string userID)
        {
            RESULT result = new RESULT();
            try
            {
                Dap.user.DeleteUser(userID);
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;
           
        }

        /// <summary>
        /// 查找特定用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet]
        public RESULT GetUser(string userID)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Json<List<Models.User>>(Dap.user.GetUsers(userID));;
            }
            catch (Exception e)
            {
                result.state = false;
                result.msg = e.Message;
            }
            return result;

        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public RESULT UpdateUser(Models.User user)
        {
            RESULT result = new RESULT();
            try
            {
                result.result = Dap.user.UpdateUser(user);
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
