using Application.Dtos.Cars;
using Application.Features.Cars.Requests.Queries;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Persistence;
using MediatR;

namespace Application.Features.Cars.Handlers.Queries;

public class GetCarQueryHandler : IRequestHandler<GetCarByIdQuery, CarViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetCarQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CarViewModel> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _unitOfWork.CarRepository.Get(request.Id);
        if (car is null)
        {
            throw new Exception("We could not find this car.");
        }

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
        return carDetails;
    }
}