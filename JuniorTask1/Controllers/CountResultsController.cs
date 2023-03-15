using JuniorTask1.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JuniorTask1.Controllers
{
    public class CountResultsController : Controller // Контроллер подсчетов
    {
        private readonly ICountResultsService _countResultsService; // Сервис подсчета

        public CountResultsController(ICountResultsService countResultsService)
        {
            _countResultsService = countResultsService;
        }

        public IActionResult CountResults(string json) // Получает строку в формате JSON, распаковывает и обрабатывает с помощью сервиса
        {
            IEnumerable<int> data = JsonConvert.DeserializeObject<IEnumerable<int>>(json);
            return RedirectToAction("ShowResults", "Display", 
                new { json = GetArrayInJson(_countResultsService.CountTask(data)).Value.ToString() }); //Результат отправляется контроллеру отображений для вывода
        }
        public JsonResult GetArrayInJson(int data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Json(json);
        }
    }
}
