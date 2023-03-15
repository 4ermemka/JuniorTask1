using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JuniorTask1.Data.Services
{
    public interface ICountResultsService
    {
        public int CountTask(IEnumerable<int> data);
    }
}
