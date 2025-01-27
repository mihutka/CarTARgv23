using CarTARgv23.Core.Domain;
using CarTARgv23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTARgv23.Core.ServerInterface
{
    public interface ICarServices
    {
        Task<Car> DetailsAsync(Guid id);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> Create(CarDto dto);
    }
}
