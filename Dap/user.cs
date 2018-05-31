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
                if (userName == "" || key == "")
                {
                    throw (new Exception("用户名或密码不能为空"));
                }
                else
                {
                    var user = from x in dc.GetTable<Models.User>()
                               where x.UserName == userName && x.Password == key
                               select x;
                    if (user.Count() == 1)
                    {
                        return user.First();
                    }
                    else throw (new Exception("用户名或密码错误"));
                }
            }
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public static Guid Add(string userName,string phoneNumber,string key)
        {
            if (userName == "" || phoneNumber == "" || key == "")
            {
                throw (new Exception("请将注册信息填写完整"));
            }
            else if (phoneNumber.Length != 11)
            {
                throw (new Exception("请输入正确的手机号"));
            }
            else
            {
                using (DataContext dc = new DataContext(Dap.common.conn))
                {
                    var tb = dc.GetTable<Models.User>();
                    Models.User user = new Models.User();
                    user.UserName = userName;
                    user.MobilePhone = phoneNumber;
                    user.Password = key;
                    user.ID = System.Guid.NewGuid();
                    tb.InsertOnSubmit(user);
                    dc.SubmitChanges();//后台自动生成用户ID
                    return user.ID;
                }
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
        public static Models.User UpdateUser(Models.User user)
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
                if (_user != null)
                {
                    return _user;
                }
                else throw (new Exception("修改失败"));
            }
        }
            
    }
}
