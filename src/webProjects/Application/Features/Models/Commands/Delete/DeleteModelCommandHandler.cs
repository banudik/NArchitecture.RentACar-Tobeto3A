using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommandHandler: IRequestHandler<DeleteModelCommand, DeletedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<DeletedModelResponse> Handle(DeleteModelCommand command, CancellationToken cancellationToken)
    {
        Model? model = await _modelRepository.GetAsync(x => x.Id == command.Id);
        _modelBusinessRules.ModelIdShouldExistWhenSelected(model);

        _mapper.Map(command, model);
        Model deletedModel = await _modelRepository.DeleteAsync(model);

        DeletedModelResponse? response = _mapper.Map<DeletedModelResponse>(deletedModel);
        return response;
    }
}
