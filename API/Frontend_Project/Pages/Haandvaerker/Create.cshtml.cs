using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontend_Project.Datamodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Frontend_Project.Pages.Haandvaerker
{
    public class CreateModel : PageModel
    {
        
        public HttpClient client { get; set; }
        [BindProperty]
        public int localID { get; set; }
        public CreateModel(HttpClient client)
        {
            this.client = client;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        
        [BindProperty]
        public HaandvaerkerModel LocalModel { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            if (localID != null)
            {
                client.BaseAddress = new Uri("https://localhost:44376");

                string reqq = "/api/VaerktoejsKasse/" + localID.ToString();

                var responseVKT = await client.GetAsync(reqq);

                responseVKT.EnsureSuccessStatusCode();

                var locVTK = await responseVKT.Content.ReadFromJsonAsync<VaerktoejsKasseModel>();
                
                LocalModel.vaerktoejskasse = new HashSet<VaerktoejsKasseModel>();
                
                LocalModel.vaerktoejskasse.Add(locVTK);
            }

            var msg = "{\"hvAnsaettelsedato\":\"2021-03-19T17:41:54.368Z\",\"hvEfternavn\":\"FUCK\",\"hvFagomraade\": \"string\",\"hvFornavn\":\"FUCK\"}";

            //Lav modellen om til en JSON string
            string jsonObjekt = JsonSerializer.Serialize(LocalModel);
            var content = new StringContent(jsonObjekt, Encoding.UTF8,"application/json");

            //Post modellen til API'et
            //Console.WriteLine(content);
            //client.BaseAddress = new Uri("https://localhost:44376");

             var response = await client.PostAsJsonAsync("/api/Haandvaerker", content);

            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                return Page();
            }
              
            return RedirectToPage("/Haandvaerker/Index");
        }

    }
}
