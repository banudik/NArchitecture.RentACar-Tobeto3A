using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetListPagination;

public class GetListPaginationModelQueryHandler:IRequestHandler<GetListPaginationModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListPaginationModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListPaginationModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListPaginateAsync(index:request.PageRequest.Page, size: request.PageRequest.PageSize);
        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);
        return modelListModel;
    }
}
