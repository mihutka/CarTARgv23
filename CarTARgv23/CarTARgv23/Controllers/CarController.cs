﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarTARgv23.Core.Domain;
using CarTARgv23.Core.ServerInterface;
using CarTARgv23.Data;
using CarTARgv23.Models.Car;
using CarTARgv23.Core.Dto;

namespace CarTARgv23.Controllers
{
    public class CarController : Controller
    {
        private readonly CarContext _context;
        private readonly ICarServices _carServices;

        public CarController(
            CarContext context,
            ICarServices carServices
        )
        {
            _context = context;
            _carServices = carServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Number = x.Number,
                    Mileage = x.Mileage,
                    TechnicalInspection = x.TechnicalInspection,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel car = new();
            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto
            {
                Id = Guid.NewGuid(),
                Brand = vm.Brand,
                Model = vm.Model,
                Number = vm.Number,
                Mileage = vm.Mileage,
                TechnicalInspection = vm.TechnicalInspection
            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number,
                Mileage = car.Mileage,
                TechnicalInspection = car.TechnicalInspection,
                CreatedAt = car.CreatedAt,
                UpdatedAt = car.UpdatedAt
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarCreateUpdateViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number,
                Mileage = car.Mileage,
                TechnicalInspection = car.TechnicalInspection,
                CreatedAt = car.CreatedAt,
                UpdatedAt = car.UpdatedAt
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto
            {
                Id = vm.Id.Value,
                Brand = vm.Brand,
                Model = vm.Model,
                Number = vm.Number,
                Mileage = vm.Mileage,
                TechnicalInspection = vm.TechnicalInspection
            };

            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number,
                Mileage = car.Mileage,
                TechnicalInspection = car.TechnicalInspection,
                CreatedAt = car.CreatedAt,
                UpdatedAt = car.UpdatedAt
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _carServices.Delete(id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}