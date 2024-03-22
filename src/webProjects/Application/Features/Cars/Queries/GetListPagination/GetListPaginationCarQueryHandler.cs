﻿using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListPaginationCarQueryHandler : IRequestHandler<GetListPaginationCarQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListPaginationCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListPaginationCarQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListPaginateAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, include: x => x.Include(x => x.Model).Include(x => x.Model.Brand));
        CarListModel carListModel = _mapper.Map<CarListModel>(cars);
        return carListModel;
    }
}
