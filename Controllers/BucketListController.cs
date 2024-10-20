using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BucketListHUB.Models;
using System.Text;




namespace BucketListHUB.Controllers
{
    public class BucketListController : Controller
    {
        // GET: BucketListController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7256/api/destination";
            List<Destination> destination = new List<Destination>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                var result = await response.Content.ReadAsStringAsync();
                destination = JsonConvert.DeserializeObject<List<Destination>>(result);
            }


            return View(destination);
        }

        // GET: BucketListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BucketListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BucketListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Destination destination)
        {
            string apiUrl = "https://localhost:7256/api/destination";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(destination), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(destination);
        }

        // POST: BucketListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BucketListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BucketListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
