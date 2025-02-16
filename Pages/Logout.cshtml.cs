using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace maintaince_server_net.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // ����û��� Session
            HttpContext.Session.Remove("User");

            // �ض��򵽵�¼ҳ��
            return RedirectToPage("/Login");
        }
    }
}
