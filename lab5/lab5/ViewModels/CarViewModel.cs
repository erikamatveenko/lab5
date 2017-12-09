using lab5.Models;
using lab5.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class CarViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        //Свойство для навигации по страницам
        public PageViewModel PageViewModel { get; set; }
        
        public IEnumerable<CarBrandNameFilter> BrandNames { get; set; }

        public CarBrandNameFilter CurrentBrandName { get; set; }
    }
}