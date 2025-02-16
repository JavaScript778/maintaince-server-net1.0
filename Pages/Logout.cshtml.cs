using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace maintaince_server_net.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // 清除用户的 Session
            HttpContext.Session.Remove("User");

            // 重定向到登录页面
            return RedirectToPage("/Login");
        }
    }
}
