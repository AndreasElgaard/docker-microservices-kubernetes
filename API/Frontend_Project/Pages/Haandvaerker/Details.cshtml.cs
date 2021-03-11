using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Frontend_Project.Datamodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend_Project.Pages.Haandvaerker
{
    public class DetailsModel : PageModel
    {
        public HaandvaerkerModel localModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using (var client = new HttpClient())
            { 
            client.BaseAddress = new Uri("http://localhost:3000");

             var response = client.GetAsync("/API");

             var json = await response.Result.Content.ReadAsStringAsync();

             var result = JsonSerializer.Deserialize<HaandvaerkerModel>(json);

             localModel = result;

             if (localModel == null)
             {
                 return RedirectToPage("/Index");
             }

            }

            return Page();

        }
    }
}
