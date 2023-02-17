using Ef_using_cascading.Models;
using Ef_using_cascading.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.Controllers
{
    public class HomeController : Controller
    {
        private readonly Iproductservic log;

        public HomeController(Iproductservic _log)
        {
            log = _log;
        }
        public async Task<IActionResult> Index()
        {
            return View(await log.GetAllproduct());
        }
        public async Task<IActionResult> Create()
        {
            List<Category3> pc = new List<Category3>();
            pc = await log.GetAllCategory();
            pc.Insert(0, new Category3 { catid = 0, catname = "Select One" });
            ViewBag.message = pc;
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Product3 p)
        {

            if (ModelState.IsValid)
            {
                await log.Create(p);
                ViewData["msg"] = "inserted";


                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<JsonResult> SubCat_Bind(int catid)
        {
            var subcatList = await log.GetAllSubCategory(catid);
            List<SelectListItem> scalist = new List<SelectListItem>();
            foreach (SubCategory3 dr in subcatList)
            {
                scalist.Add(new SelectListItem { Text = dr.subcatname, Value = dr.subcatid.ToString() });
            }
            var jsonres = JsonConvert.SerializeObject(scalist);
            return Json(jsonres);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.catid = await log.GetAllCategory();
            Product3 prd = await log.GetProductByid(id);
            if(prd!=null)
            {
                ViewBag.subcatid = await log.GetAllSubCategory(prd.catid);
            }
            //var pc = await log.GetAllCategory();
            //pc.Insert(0, new Category3 { catid = 0, catname = "Select One" });
            //ViewBag.message = pc;
            return View(prd);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product3 p)
        {
            //var selectedValue = Request.Form["catid"].ToString();
            //p.catid = Convert.ToInt32(selectedValue);
            await log.Update(p);
            return View("Index", await log.GetAllproduct());
        }
        public async Task<IActionResult> Delete(int id)
        {
            await log.Delete(id);
            return View("Index", await log.GetAllproduct());
        }
        public async Task<IActionResult> Details(int id)
        {

            return View(await log.GetProductByid(id));
        }
    }
}
