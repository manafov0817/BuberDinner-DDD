﻿using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace BuberDinner.Api.Common.Errors
{
    public class BubberDinnerProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public BubberDinnerProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string title = null,
            string type = null,
            string detail = null,
            string instance = null)
        {
            statusCode ??= 500;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title ?? ReasonPhrases.GetReasonPhrase(statusCode.Value),
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            ModelStateDictionary modelStateDictionary,
            int? statusCode = null,
            string title = null,
            string type = null,
            string detail = null,
            string instance = null)
        {
            if (modelStateDictionary == null)
            {
                throw new ArgumentNullException(nameof(modelStateDictionary));
            }

            statusCode ??= 400;

            var validationProblemDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            if (title != null)
            {
                validationProblemDetails.Title = title;
            }
            else
            {
                validationProblemDetails.Title = ReasonPhrases.GetReasonPhrase(statusCode.Value);
            }

            ApplyProblemDetailsDefaults(httpContext, validationProblemDetails, statusCode.Value);

            return validationProblemDetails;
        }

        protected virtual void ApplyProblemDetailsDefaults(
            HttpContext httpContext,
            ProblemDetails problemDetails,
            int statusCode)
        {
            problemDetails.Status ??= statusCode;

            // Include trace ID if present
            if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            var traceId = httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }
            var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;

            if (errors is not null)
                problemDetails.Extensions.Add("errorCode", errors.Select(e => e.Code));
        }
    }
}
