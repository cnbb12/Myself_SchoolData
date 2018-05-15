using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Dap
{
    public class user
    {
        /// <summary>
        /// 检测登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Models.User checkLogin(string userName, string key)
        {
            using (DataContext dc = new DataContext(common.conn))
            {
                var user = from x in dc.GetTable<Models.User>()
                           where x.UserName == userName && x.Password == key
                           select x;
                if (user.Count() == 1)
                {
                    return (Models.User)user;
                }
                else throw (new Exception("请输入正确的用户名和口令。"));
            }
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public static Guid Add(Models.User user)
        {
            using (DataContext dc = new DataContext(Dap.common.conn))
            {
                var tb = dc.GetTable<Models.User>();
                tb.InsertOnSubmit(user);
                dc.SubmitChanges();//后台自动生成用户ID
                return user.ID;
            }

        }

        /// <summary>
        /// 删除指定用户
        /// </summary>
        /// <param name="userName"></param>
        public static void DeleteUser(string userName)
        {
            using (DataContext dc = new DataContext(Dap.common.conn))
            {
                var tb = dc.GetTable<Models.User>();
                var _user = (from s in tb
                             where s.UserName == userName
                             select s).First();
                tb.DeleteOnSubmit(_user);
                dc.SubmitChanges();

            }

        }

        /// <summary>
        /// 得到特定用户的信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static List<Models.User> GetUsers(string userName)
        {
            using (DataContext dc = new DataContext(Dap.common.conn))
            {
                if (userName != null)
                {
                    return (from s in dc.GetTable<Models.User>()
                            where s.UserName.Contains(userName)
                            select s).ToList();
                }
                else
                {
                    return (from s in dc.GetTable<Models.User>()
                            select s).ToList();
                }
            }

        }

        /// <summary>
        /// 用户信息更新
        /// </summary>
        /// <param name="user"></param>
        public static void UpdateUser(Models.User user)
        {
            using (DataContext dc = new DataContext(Dap.common.conn))
            {
                var tb = dc.GetTable<Models.User>();
                var _user = (from s in tb
                             where s.ID == user.ID
                             select s).First();
                _user.UserName = user.UserName;
                _user.RealName = user.RealName;
                _user.MobilePhone = user.MobilePhone;
                _user.E_mail = user.E_mail;
                _user.Password = user.Password;
                dc.SubmitChanges();

            }
        }
    }
}
