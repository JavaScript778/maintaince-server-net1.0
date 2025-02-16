using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace maintaince_server_net.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            // 使用静态的用户名和密码进行验证
            if (Username == "admin" && Password == "123456")
            {
                HttpContext.Session.SetString("User", "admin");
                Console.WriteLine("登录成功，Session 存入：" + HttpContext.Session.GetString("User"));
                return RedirectToPage("/Index");  // 确保跳转
                
            }

            // 如果登录失败，显示错误信息
            ViewData["ErrorMessage"] = "用户名或密码错误！";
            return Page();
        }
    }
}
