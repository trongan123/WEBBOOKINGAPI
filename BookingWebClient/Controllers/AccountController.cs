using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookingWebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient client = null;
        private string AccountAPiUrl = "";
        public AccountController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AccountAPiUrl = "https://localhost:7159/api/Account";


        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {

            HttpResponseMessage response = await client.GetAsync(AccountAPiUrl + "/" + email + "/" + password);
            string strDate = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Account account = JsonSerializer.Deserialize<Account>(strDate, options);

            if (account != null)
            {
                HttpContext.Session.SetString("IdUser", account.Idacc);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Idacc,Mail,Password,FullName,Address,Phone,St")] Account account)
        {


            if (ModelState.IsValid)
            {
                HttpResponseMessage response1 = await client.PostAsJsonAsync(AccountAPiUrl, account);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Home");
            }

         
            return View(account);
        }



    }
}

