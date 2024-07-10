using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using TodoList.Domain.Common.Models;

namespace TodoList.Domain.Tests.Common.Models
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class AggregateRootTests
    {
        [Fact]
        public void Given_AggregateRoot_When_Instantiated_Then_IdValuesMatch()
        {
            var aggregateRootTestId = new AggregateRootTestId(Guid.NewGuid());
            var aggregateRootTest = new AggregateRootTest(aggregateRootTestId);

            aggregateRootTest.Id.Value
                .Should()
                .Be(aggregateRootTestId.Value);
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class AggregateRootTest(AggregateRootTestId id) : AggregateRoot<AggregateRootTestId>(id);

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class AggregateRootTestId(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}