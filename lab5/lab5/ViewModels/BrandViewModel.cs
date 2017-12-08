using lab5.Models;
using lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class BrandViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }
        //Свойство для навигации по страницам
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<BrandCountryFilter> BrandCountries { get; set; }

        public BrandCountryFilter CurrentBrandCountry { get; set; }
    }
}
