using JuniorTask1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace JuniorTask1.Data.Services
{
    public class DisplayService : IDisplayService // Сервис отображений
    {
        IEnumerable<int> _arr;

        public void SetNums(IFormCollection fc) // Получает информацию о форме и формирует из нее массив целых чисел
        {
            _arr = Array.ConvertAll(fc["num"].ToString().Split(','), s => int.Parse(s));
        }

        public IEnumerable<int> GetNums() // Возвращает массив
        {
            return _arr;
        }
    }
}
