using CarTARgv23.Core.ServerInterface;
using CarTARgv23.Data;
using CarTARgv23.Models.Car;

namespace CarTARgv23.Controllers
{
    public class CarController : Controllers
    {
        private readonly CarContext _context;
        private readonly ICarServices _carServices;

        public KindergartenController(
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


    }
}
