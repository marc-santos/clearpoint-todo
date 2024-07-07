using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using FluentValidation;
using MediatR;
using TodoList.Application.Behaviours;

namespace TodoList.Application.Tests.Behaviours
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class TestBehaviour 
    {
        public class Request(Guid id) : IRequest<Result>
        {
            public Guid Id = id;
        }

        public class Result(bool processed)
        {
            public bool Processed = processed;
        }

        public class TestBehaviourValidator : AbstractValidator<Request>
        {
            public TestBehaviourValidator()
            {
                RuleFor(p => p.Id)
                    .NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(new Result(true));
            }
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class ValidationBehaviorTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData( false)]
        public async Task GivenRequest_When_Handle_Then_ShouldThrowValidationExceptionIfValidationFails(bool shouldThrow)
        {
            var validators = new List<TestBehaviour.TestBehaviourValidator>
            {
                new()
            };

            var validationBehavior = new ValidationBehavior<TestBehaviour.Request, TestBehaviour.Result>(validators);
            var guid = shouldThrow ? 
                Guid.Empty : 
                Guid.NewGuid();

            Func<Task<TestBehaviour.Result>> result = async () =>
            {
                return await validationBehavior
                    .Handle(new TestBehaviour.Request(guid), Next,
                        CancellationToken.None);

                Task<TestBehaviour.Result> Next()
                {
                    return Task.FromResult(new TestBehaviour.Result(false));
                }
            };

            if (shouldThrow)
                await result.Should().ThrowAsync<ValidationException>();
            else
                await result.Should().NotThrowAsync<ValidationException>();
        }
    }
}
