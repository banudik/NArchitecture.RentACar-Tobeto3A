using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommandHandler: IRequestHandler<UpdateModelCommand, UpdatedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<UpdatedModelResponse> Handle(UpdateModelCommand command, CancellationToken cancellationToken)
    {
        Model? model = await _modelRepository.GetAsync(x => x.Id == command.Id);
        _modelBusinessRules.ModelIdShouldExistWhenSelected(model);  //Check Model if exist

        _mapper.Map(command, model);

        Model updatedModel = await _modelRepository.UpdateAsync(model);
        UpdatedModelResponse? response = _mapper.Map<UpdatedModelResponse>(updatedModel);
        return response;
    }
}
