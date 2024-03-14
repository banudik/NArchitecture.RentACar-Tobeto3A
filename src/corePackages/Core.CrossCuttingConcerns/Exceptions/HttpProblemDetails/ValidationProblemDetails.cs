﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails:ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Detail = "One or more validation errors occured";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "http://tobeto.com/probs/validation";
    }
}
