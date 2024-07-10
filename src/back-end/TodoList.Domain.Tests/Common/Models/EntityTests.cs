using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using TodoList.Domain.Common.Models;

namespace TodoList.Domain.Tests.Common.Models
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class EntityTests
    {
        [Fact]
        public void Given_Constructor_When_Instantiated_Then_ReturnsValue()
        {
            var entityId = new EntityId(Guid.NewGuid());
            var entity = new EntityTestClass(entityId);

            entity.Id
                .Should()
                .Be(entityId);
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreEqual_Then_ReturnsTrue()
        {
            var entityId = new EntityId(Guid.NewGuid());
            var entity1 = new EntityTestClass(entityId);
            var entity2 = new EntityTestClass(entityId);

            entity1.Equals(entity2)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreNotEqual_Then_ReturnsFalse()
        {
            var entity1 = new EntityTestClass(new EntityId(Guid.NewGuid()));
            var entity2 = new EntityTestClass(new EntityId(Guid.NewGuid()));

            entity1.Equals(entity2)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreEqual_Then_ReturnsTrueOperator()
        {
            var entityId = new EntityId(Guid.NewGuid());
            var entity1 = new EntityTestClass(entityId);
            var entity2 = new EntityTestClass(entityId);

            (entity1 == entity2)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Given_Equals_When_ObjectsAreNotEqual_Then_ReturnsFalseOperator()
        {
            var entity1 = new EntityTestClass(new EntityId(Guid.NewGuid()));
            var entity2 = new EntityTestClass(new EntityId(Guid.NewGuid()));

            (entity1 == entity2)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Given_GetHashCode_When_Called_Then_ReturnsHashCode()
        {
            var entityId = new EntityId(Guid.NewGuid());
            var entity = new EntityTestClass(entityId);

            entity.GetHashCode()
                .Should()
                .Be(entityId.GetHashCode());
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class EntityTestClass(EntityId entityId) : Entity<EntityId>(entityId);

    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class EntityId(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
