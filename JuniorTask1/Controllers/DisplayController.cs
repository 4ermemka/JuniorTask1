using JuniorTask1.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniorTask1.Controllers
{
    public class DisplayController : Controller // Контроллер отображений
    {
        private readonly IDisplayService _displayService;//Сервис отображений
        public DisplayController(IDisplayService displayService)
        {
            _displayService = displayService;
        }

        public IActionResult InputValues() // Отобразить форму ввода
        {
            return View();
        }

        [HttpPost]
        public IActionResult InputValues(IFormCollection fc) // Обработать полученные из формы данные 
        {
            _displayService.SetNums(fc); // Преобразовать в массив
            return RedirectToAction("CountResults", "CountResults", 
                new { json = GetArrayInJson(_displayService.GetNums()).Value.ToString()}); //Отослать контроллеру подсчетов для обработки
        }

        [HttpGet]
        public IActionResult ShowResults(string json) // Получает JSON строку с результатом, распаковывает и отображает
        {
            int data = JsonConvert.DeserializeObject<int>(json);
            return View(data);
        }

        public JsonResult GetArrayInJson(IEnumerable<int> data) // Конвертер в JSON
        {
            var json = JsonConvert.SerializeObject(data);
            return Json(json);
        }
    }
}
