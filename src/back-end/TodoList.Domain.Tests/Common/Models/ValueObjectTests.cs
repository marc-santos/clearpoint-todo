using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using TodoList.Domain.Common.Models;

namespace TodoList.Domain.Tests.Common.Models
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class ValueObjectTests
    {
        [Fact]
        public void Given_Constructor_When_Instantiated_Then_ReturnsValue()
        {
            var id = Guid.NewGuid();
            var valueObject = new TestValueObject(id);

            valueObject.Value
                .Should()
                .Be(id);
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreEqual_Then_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var guid1 = new TestValueObject(id);
            var guid2 = new TestValueObject(id);

            guid1.Equals(guid2)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Given_Equals_When_ObjectAreOfDifferentTypes_Then_ReturnsFalse()
        {
            var guid1 = new TestValueObject(Guid.NewGuid());
            var guid2 = new TestValueObject2(Guid.NewGuid());

            guid1.Equals(guid2)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreNotEqual_Then_ReturnsFalse()
        {
            var guid1 = new TestValueObject(Guid.NewGuid());
            var guid2 = new TestValueObject(Guid.NewGuid());

            guid1.Equals(guid2)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreEqual_Then_ReturnsTrueOperator()
        {
            var id = Guid.NewGuid();
            var guid1 = new TestValueObject(id);
            var guid2 = new TestValueObject(id);

            (guid1 == guid2)
                .Should()
                .BeTrue();
        }
        
        [Fact]
        public void Given_Equals_When_ObjectsAreNotEqual_Then_ReturnsFalseOperator()
        {
            var guid1 = new TestValueObject(Guid.NewGuid());
            var guid2 = new TestValueObject(Guid.NewGuid());

            (guid1 != guid2)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Given_GetHashCode_When_ObjectsAreEqual_Then_ReturnsSameHashCode()
        {
            var id = Guid.NewGuid();
            var guid1 = new TestValueObject(id);
            var guid2 = new TestValueObject(id);

            guid1.GetHashCode()
                .Should()
                .Be(guid2.GetHashCode());
        }

        [Fact]
        public void Given_GetHashCode_When_ObjectsAreNotEqual_Then_ReturnsDifferentHashCode()
        {
            var guid1 = new TestValueObject(Guid.NewGuid());
            var guid2 = new TestValueObject(Guid.NewGuid());

            guid1.GetHashCode()
                .Should()
                .NotBe(guid2.GetHashCode());
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class TestValueObject(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public sealed class TestValueObject2(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
