﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab5.ViewModels;
using lab5.Data;

namespace lab5.Controllers
{
    public class CarsController : Controller
    {
        private UchetContext _db;

        public CarsController(UchetContext db)
        {
            _db = db;
        }

        public IActionResult Cars(int? currentParameterID, int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице
            int currBrandID = currentParameterID ?? 0;

            List<BrandNameFilter> brandNames = _db.Brands.Select(b => new BrandNameFilter { BrandName = b.BrandName, Id = b.BrandID }).ToList();
            brandNames.Insert(0, new BrandNameFilter { BrandName = "Все", Id = 0 });
      
            List<Car> cars = _db.Cars
                .Select(t => new Car
                {
                    CarID = t.CarID,
                    BrandID = t.BrandID,
                    OwnerID = t.OwnerID,
                    CarRegistrationNumber = t.CarRegistrationNumber,
                    CarPhoto = t.CarPhoto,
                    CarNumberOfBody = t.CarNumberOfBody,
                    CarNumberOfMotor = t.CarNumberOfMotor,
                    CarNumberOfPassport = t.CarNumberOfPassport,
                    CarReleaseDate = t.CarReleaseDate,
                    CarRegistrationDate = t.CarRegistrationDate,
                    CarLastCheckupDate = t.CarLastCheckupDate,
                    CarColor = t.CarColor,
                    CarDescription = t.CarDescription,
                    Brand = t.Brand,
                    Owner = t.Owner
                }).OrderBy(s => s.CarID)
                .ToList();
            BrandNameFilter brnf  = brandNames.Where(c => c.Id == currBrandID).ToList()[0];
            if (currBrandID > 0)
            {
                cars = cars.Where(c => c.Brand.BrandID == currBrandID).ToList();             
            }

            PageViewModel pageViewModel = new PageViewModel(cars.Count, page, pageSize, currBrandID);

            CarViewModel carViewModel = new CarViewModel {PageViewModel=pageViewModel, Cars = cars.Skip((page - 1) * pageSize).Take(pageSize).ToList(), BrandNames=brandNames ,CurrentBrandName = brnf };
            return View(carViewModel);
        }


        // GET: Cars/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = getCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["BrandID"] = new SelectList(_db.Brands, "BrandID", "BrandName", car.BrandID);
            ViewData["OwnerID"] = new SelectList(_db.Owners, "OwnerID", "OwnerName", car.OwnerID);
            return View(car);
        }


        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("CarID,BrandID,OwnerID,CarRegistrationNumber," +
            "CarPhoto,CarNumberOfBody,CarNumberOfMotor,CarNumberOfPassport," +
            "CarReleaseDate,CarRegistrationDate," +
            "CarLastCheckupDate,CarColor,CarDescription")] Car car)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(car);
                     _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Cars");
            }
            ViewData["BrandID"] = new SelectList(_db.Brands, "BrandID", "BrandName", car.BrandID);
            ViewData["OwnerID"] = new SelectList(_db.Owners, "OwnerID", "OwnerName", car.OwnerID);
            return View(car);
        }


        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["BrandID"] = new SelectList(_db.Brands, "BrandID", "BrandName");
            ViewData["OwnerID"] = new SelectList(_db.Owners, "OwnerID", "OwnerName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CarID,BrandID,OwnerID,CarRegistrationNumber," +
            "CarPhoto,CarNumberOfBody,CarNumberOfMotor,CarNumberOfPassport," +
            "CarReleaseDate,CarRegistrationDate," +
            "CarLastCheckupDate,CarColor,CarDescription")] Car car)
        {
            if (ModelState.IsValid)
            {
                if (CarExists(car.CarID))
                {
                    return View("Message", "Уже существует автомобиль с данным идентификатором!");

                }
                _db.Add(car);
                _db.SaveChanges();
                return RedirectToAction("Cars");
            }

            ViewData["BrandID"] = new SelectList(_db.Brands, "BrandID", "BrandName", car.BrandID);
            ViewData["OwnerID"] = new SelectList(_db.Owners, "OwnerID", "OwnerName", car.OwnerID);
            return View(car);
        }


        // GET: Cars/Details/5
        public IActionResult More(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = getCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }



        // GET: Cars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = getCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int CarID)
        {
            var car = _db.Cars.Where(c => c.CarID == CarID);
            _db.Cars.RemoveRange(car);
            _db.SaveChanges();
            return RedirectToAction("Cars");
        }

        private bool CarExists(int id)
        {
            return _db.Cars.Any(e => e.CarID == id);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Car getCarById(int? id)
        {
            return _db.Cars.Select(t => new Car
            {
                CarID = t.CarID,
                BrandID = t.BrandID,
                OwnerID = t.OwnerID,
                CarRegistrationNumber = t.CarRegistrationNumber,
                CarPhoto = t.CarPhoto,
                CarNumberOfBody = t.CarNumberOfBody,
                CarNumberOfMotor = t.CarNumberOfMotor,
                CarNumberOfPassport = t.CarNumberOfPassport,
                CarReleaseDate = t.CarReleaseDate,
                CarRegistrationDate = t.CarRegistrationDate,
                CarLastCheckupDate = t.CarLastCheckupDate,
                CarColor = t.CarColor,
                CarDescription = t.CarDescription,
                Brand = t.Brand,
                Owner = t.Owner
            }).Where(c => c.CarID == id).ToList()[0];
        }
    }
}
