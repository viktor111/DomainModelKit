using FluentAssertions;

namespace DomainModelKit.Tests;

public class ValueObjectTest
{
    [Fact]
    public void ValueObjectsWithEqualPropertiesShouldBeEqual()
    {
        // Arrange
        var first = new TestObject("test");
        var second = new TestObject("test");

        // Act
        var result = first == second;

        // Arrange
        result.Should().BeTrue();
    }

    [Fact]
    public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
    {
        // Arrange
        var first = new TestObject("test");
        var second = new TestObject("test2");

        // Act
        var result = first == second;

        // Arrange
        result.Should().BeFalse();
    }
}