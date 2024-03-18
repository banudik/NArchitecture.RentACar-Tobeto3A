using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListModelDynamicQueryHandler : IRequestHandler<GetListModelDynamicQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page, size:request.PageRequest.PageSize);
        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);
        return modelListModel;
    }
}
