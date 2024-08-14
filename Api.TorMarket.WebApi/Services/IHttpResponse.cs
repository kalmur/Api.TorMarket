﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Api.TorMarket.WebApi.Services;

public interface IHttpResponse
{
    ObjectResult Forbidden(string? errorMessage = default);
    NotFoundObjectResult NotFound(string? errorMessage = default);
    ObjectResult InternalServerError(string? errorMessage = default);
    BadRequestObjectResult BadRequest(IDictionary<string, string[]> errors, string? errorMessage = default);
    BadRequestObjectResult BadRequest(ModelStateDictionary modelStateDictionary, string? errorMessage = default);
    ObjectResult Conflict(string? errorMessage = default);
    ObjectResult UnprocessableEntity(string? errorMessage = default);
}
