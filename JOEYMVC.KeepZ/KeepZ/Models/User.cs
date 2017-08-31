using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeepZ.Models
{
    public class User
    {
        [Required]
        [StringLength(16)]
        public string UserName { get; set; }
        [Required]
        [StringLength(16)]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    }
}

//[Required] 限制了必须输入，[Required(ErrorMessage = "请输入用户名")]

//[StringLength]
//限制了规定的长度，[StringLength(10, ErrorMessage = "长度不能超过10个字符")]

//[Range]
//限制了值的范围，[Range(0, 120, ErrorMessage = "年龄范围在0到120岁之间")]

//[RegularExpression]
//限制了必须满足正则表达式，[RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "请输入Email格式")]

//[Compare]
//限制了与之对应的字段相等，[Compare("pwd", ErrorMessage = "两次密码要一致")]  //该特性标注的字段值必须与pwd字段值相等

//.net也就封装了几个，这5个用的最多（当然，也可以自定义这种验证特性，对这块想深入了解的请百度：mvc ValidationAttribute）。