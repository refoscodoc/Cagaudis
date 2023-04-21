using Application.Features.Cars.Requests.Queries;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace Application.Features.Cars.Handlers.Queries;

public class GetCarByManufacturerIdQueryHandler : IRequestHandler<GetCarByManufacturerIdQuery, List<CarViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetCarByManufacturerIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CarViewModel>> Handle(GetCarByManufacturerIdQuery request, CancellationToken cancellationToken)
    {
        // what this getAll method does is getting the whole Db and then I filter with parameters here
        // TODO find a more optimized get function
        var cars = await _unitOfWork.CarRepository.GetAllByManufacturerPaginated();
        cars = cars.Where(x => x.ManufacturerId == request.Id).Take(request.Pagination).ToList();
        if (cars is null)
        {
            throw new Exception("We could not find any car.");
        }

        var carsDetails = new List<CarViewModel>();
        foreach (var car in cars)
        {
            var carDetails = new CarViewModel
            {
                DateCreated = car.DateCreated,
                CreatedBy = car.CreatedBy,
                CreatedOn = car.CreatedOn,
                LastModifiedOn = car.LastModifiedOn,
                LastModifiedBy = car.LastModifiedBy,
                IsActive = car.IsActive,
                Id = car.Id,
                Year = car.Year,
                Color = car.Color,
                Manufacturer = await _unitOfWork.ManufacturerRepository.Get(car.ManufacturerId),
                Seller = await _unitOfWork.SellerRepository.Get(car.ManufacturerId),
                ModelName = car.ModelName,
                IsManual = car.IsManual,
                Photo = car.Photo,
                Deadline = car.Deadline,
                PriceStart = car.PriceStart,
                PriceCurrent = car.PriceCurrent,
                Mileage = car.Mileage,
                FuelType = car.FuelType,
                IsModified = car.IsModified,
                ValueModified = car.ValueModified,
                AddressId = new AddressModel
                {
                    Street = "via Ulivi 46",
                    PostalCode = 34070,
                    City = "Fogliano Redipuglia"
                }
            };
            carsDetails.Add(carDetails);
        }
        
        return carsDetails;
    }
}