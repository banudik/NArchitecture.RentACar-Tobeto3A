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

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<CreatedModelResponse> Handle(CreateModelCommand command, CancellationToken cancellationToken)
    {
        Model mappedModel = _mapper.Map<Model>(command);
        Model createdModel = await _modelRepository.AddAsync(mappedModel);
        CreatedModelResponse createdModelResponse = _mapper.Map<CreatedModelResponse>(createdModel);
        return createdModelResponse;
    }
}
