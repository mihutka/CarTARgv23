using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarTARgv23.Core.Domain;
using CarTARgv23.Core.ServerInterface;
using CarTARgv23.Data;
using CarTARgv23.Core.Dto;

namespace CarTARgv23.ApplicationServices
{
    public class CarServices : ICarServices
    {
        private readonly CarContext _context;

        public CarServices(CarContext context)
        {
            _context = context;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Create(CarDto dto)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = dto.Brand,
                Model = dto.Model,
                Number = dto.Number,
                Mileage = dto.Mileage,
                TechnicalInspection = dto.TechnicalInspection,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (car == null)
            {
                return null;
            }

            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Number = dto.Number;
            car.Mileage = dto.Mileage;
            car.TechnicalInspection = dto.TechnicalInspection;
            car.UpdatedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                return null;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}