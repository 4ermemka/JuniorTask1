using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace JuniorTask1.Data.Services
{
    public class CountResultsService : ICountResultsService // Сервис подсчета результатов
    {
        public int CountTask(IEnumerable<int> data)
        {
            int x = 0;
            bool flag = true; // Отслеживает порядковый номера входящего нечетного числа. По умолчанию true, т.е. ближайшее нечетное войдет в сумму
            foreach (var item in data)
                if (item % 2 != 0) // При нечетном числе
                {
                    if (flag) x += Math.Abs(item); // Если порядковый номер нечетный, то добавить в сумму (так добавится каждый второй нечетный элемент)
                    flag = !flag; // Переключить порядковый номер
                }
            return x;
        }
    }
}
