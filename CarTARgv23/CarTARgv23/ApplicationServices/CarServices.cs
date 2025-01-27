using CarTARgv23.Core.Domain;
using CarTARgv23.Core.ServerInterface;
using CarTARgv23.Data;

namespace CarTARgv23.ApplicationServices
{
    public class CarServices : ICarServices
    {
        private readonly CarContext _context;
        


        public KindergartenServices(CarContext context)
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
            Car kindergarten = new Car
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

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

    }
}
