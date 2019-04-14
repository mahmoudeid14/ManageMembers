using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemberWebApp.Models;
using Member.Services;
using Member.Models.InputModels;

namespace MemberWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService memberService;
        public HomeController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        public IActionResult Index()
        {
            var model = memberService.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new MemberIM(); 
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberIM model)
        {
            if (ModelState.IsValid)
            {
               await memberService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                var model = memberService.GetById(id);
                return View(model);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberIM model)
        {
            if (ModelState.IsValid)
            {
                await memberService.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                 await memberService.Delete(id);
            }
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
