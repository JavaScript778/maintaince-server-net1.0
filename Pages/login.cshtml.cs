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
            // ʹ�þ�̬���û��������������֤
            if (Username == "admin" && Password == "123456")
            {
                HttpContext.Session.SetString("User", "admin");
                Console.WriteLine("��¼�ɹ���Session ���룺" + HttpContext.Session.GetString("User"));
                return RedirectToPage("/Index");  // ȷ����ת
                
            }

            // �����¼ʧ�ܣ���ʾ������Ϣ
            ViewData["ErrorMessage"] = "�û������������";
            return Page();
        }
    }
}
