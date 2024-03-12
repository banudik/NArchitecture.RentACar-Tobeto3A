using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQueryHandler: IRequestHandler<GetListModelQuery, List<GetListModelResponse>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<List<GetListModelResponse>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(a => a.Brand));
        List<GetListModelResponse> getListModelResponses = _mapper.Map<List<GetListModelResponse>>(models);
        return getListModelResponses;
    }
}

