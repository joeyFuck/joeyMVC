using KeepZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepZ.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
       
        [KeepZ(false, "UserName")]
        [DataCheck]
        public ActionResult Login(User user)
        {
            //校验留给标签头，这里负责逻辑
            #region 逻辑处理，如DB操作
            var msg = string.Format("用户名{0},密码{1},邮箱{2}", user.UserName, user.Password, user.Email);
            #endregion 
            return Content(msg);
        }
    }
}