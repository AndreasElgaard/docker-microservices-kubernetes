using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Frontend_Project.Datamodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend_Project.Pages.Vaerktoej
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public VaerktoejModel localModel { get; set; }
        public HttpClient client { get; set; }

        public DetailsModel(HttpClient client)
        {
            this.client = client;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            client.BaseAddress = new Uri("http://swtdisp-grp10-backend-service:80/");

            string reqq = "api/Vaerktoej/" + id.ToString();

            var response = await client.GetAsync(reqq);

            response.EnsureSuccessStatusCode();
            
            if (response.IsSuccessStatusCode)
            {
                localModel = await response.Content.ReadFromJsonAsync<VaerktoejModel>();
            }

            if (localModel == null)
             {
                 return RedirectToPage("/Vaerktoej/Index");
             }


            return Page();

        }
    }
}
