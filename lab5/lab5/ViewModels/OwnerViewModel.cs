using lab5.Models;
using lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class OwnerViewModel
    {
        public IEnumerable<Owner> Owners { get; set; }
        //Свойство для навигации по страницам
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<OwnerBirthDateFilter> OwnerBirthDates { get; set; }

        public OwnerBirthDateFilter CurrentOwnerBirthDate { get; set; }
    }
}
