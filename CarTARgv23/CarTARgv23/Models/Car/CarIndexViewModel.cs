namespace CarTARgv23.Models.Car
{
    public class CarIndexViewModel
    {
        public Guid? Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? Number { get; set; }

        public int? Mileage { get; set; }

        public bool? TechnicalInspection { get; set; }
    }
}
