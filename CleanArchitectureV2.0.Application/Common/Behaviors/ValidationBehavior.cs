using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureV2._0.Application.Common.Exception;
using MediatR;
using FluentValidation;

namespace CleanArchitectureV2._0.Application.Common.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            
            var errors  = _validators
                .Select(x=>x.Validate(context))
                .SelectMany(x=>x.Errors)
                .Where(x=>x is not null)
                .Select(x=>x.ErrorMessage)
                .Distinct()
                .ToArray();

            if (errors.Any())
            {
                throw new BadRequestException(errors);
            }
            return await next();
        }
    }
}
