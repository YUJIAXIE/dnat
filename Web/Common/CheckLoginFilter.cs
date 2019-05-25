using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Common
{
    /// <summary>
    /// pub公开  Pro验证是否登录   Pre验证角色,权限
    /// </summary>
    public enum CheckLoginType { pub, pro, pre };
    public class CheckLoginFilter : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// pub公开  Pro验证是否登录   Pre验证角色,权限
        /// </summary>
        public CheckLoginType nums { get; set; } = CheckLoginType.pre;
        public void OnAuthorization(AuthorizationContext filterContext)//
        {
            if (nums == CheckLoginType.pub)//无需验证
                return;
            if (nums == CheckLoginType.pro)//验证是否登录
            {
                if (filterContext.HttpContext.Session["Id"] == null)//未登录
                    LoginIndex(filterContext);                          //跳转
                return;
            }
            if (nums == CheckLoginType.pre)//验证角色权限
            {
                if (filterContext.HttpContext.Session["Id"] == null)//未登录
                    LoginIndex(filterContext);                          //跳转
                else//已登录
                {
                    //进行权限限制
                    //var role = filterContext.HttpContext.Session["Role"] as Role;//获取Session里的角色  
                    //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;//获取访问控制器的名字
                    //string actionName = filterContext.ActionDescriptor.ActionName;                             //获取访问行为的名字
                   // var module = role.Jurisdictions.FirstOrDefault(u => u.ControllerName == controllerName && u.ActionName == actionName);//判断是否有权限
                    //if (module == null)
                    //{
                    //    //跳转到权限不足页面
                    //    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                    //    string url = urlHelper.Action("GetView", "Account");
                    //    filterContext.Result = new RedirectResult(url);
                    //}
                }
            }
        }
        public void LoginIndex(AuthorizationContext filterContext)//跳转到登录
        {
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            string url = urlHelper.Action("Index", "Login");
            filterContext.Result = new RedirectResult(url);
        }
    }
}