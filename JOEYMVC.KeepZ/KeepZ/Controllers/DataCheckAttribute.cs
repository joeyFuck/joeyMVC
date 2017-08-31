using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KeepZ.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class DataCheckAttribute : ActionFilterAttribute
    {
        //    public override void OnActionExecuting(ActionExecutingContext filterContext)
        //    {
        //        if (filterContext.ActionDescriptor.ActionName.ToUpper().Contains("LOGIN"))
        //        {
        //            var modelState = filterContext.Controller.ViewData.ModelState;
        //            if (!modelState.IsValid)
        //            {
        //                string error = string.Empty;
        //                foreach (var key in modelState.Keys)
        //                {
        //                    var state = modelState[key];
        //                    if (state.Errors.Any())
        //                    {
        //                        error = state.Errors.First().ErrorMessage;
        //                        break;
        //                    }
        //                }
        //                ContentResult content = new ContentResult();
        //                content.Content = "验证失败:" + error;
        //                filterContext.Result = content;//  { Script = $"$tools.dangerTip('{error}','');" };
        //            }
        //        }
        //        base.OnActionExecuting(filterContext);
        //    }
        //}

        /// <summary>
        /// 字段校验
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelState = actionContext.Controller.ViewData.ModelState;
            if (actionContext.ActionDescriptor.ActionName.ToUpper().Contains("LOGIN"))
            {
                var ia = actionContext.ActionDescriptor.GetCustomAttributes(true);
                if (ia.Count() < 1)
                {
                    goto result;
                }

                foreach (KeyValuePair<string, ModelState> item in modelState.ToArray())
                {
                    var keep = Newtonsoft.Json.JsonConvert.DeserializeObject<KeepZModel>(Newtonsoft.Json.JsonConvert.SerializeObject(ia[0]));
                    if (keep.Modes == false)
                    {
                        foreach (string PropertysValue in keep.Propertys)
                        {
                            if (item.Key.Contains(PropertysValue))
                            {
                                modelState.Remove(item.Key);
                            }
                        }
                    }
                    else
                    {
                        bool re = false;
                        foreach (string PropertysValue in keep.Propertys)
                        {
                            if (item.Key.Contains(PropertysValue))
                            {
                                re = true;
                            }
                        }
                        if (re == false)
                        {
                            modelState.Remove(item.Key);
                        }
                    }
                }
                result: if (!modelState.IsValid)
                {
                    string error = string.Empty;
                    foreach (var key in modelState.Keys)
                    {
                        var state = modelState[key];
                        if (state.Errors.Any())
                        {
                            error = state.Errors.First().ErrorMessage;
                            break;
                        }
                    }
                    ContentResult content = new ContentResult();
                    content.Content = "验证失败:" + error;
                    actionContext.Result = content;//  { Script = $"$tools.dangerTip('{error}','');" };
                    //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                }
            }
            base.OnActionExecuting(actionContext);
        }
    }


}