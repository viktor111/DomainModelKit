using FluentAssertions;

namespace DomainModelKit.Tests;

public class GuardTests
{
    [Fact]
        public void AgainstEmptyString_WithNullValue_ThrowsArgumentNullException()
        {
            // Arrange
            string value = null;

            // Act
            Action act = () => Guard.AgainstEmptyString<ArgumentNullException>(value, "value");

            // Assert
            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("Value cannot be null or empty.");
        }

        [Fact]
        public void AgainstEmptyString_WithEmptyValue_ThrowsArgumentException()
        {
            // Arrange
            string value = string.Empty;

            // Act
            Action act = () => Guard.AgainstEmptyString<ArgumentException>(value, "value");

            // Assert
            act.Should().ThrowExactly<ArgumentException>().WithMessage("Value cannot be null or empty.");
        }

        [Fact]
        public void ForStringLength_WithValidValue_DoesNotThrowException()
        {
            // Arrange
            string value = "abc";

            // Act
            Action act = () => Guard.ForStringLength<ArgumentOutOfRangeException>(value, 2, 4, "value");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ForStringLength_WithTooShortValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string value = "a";

            // Act
            Action act = () => Guard.ForStringLength<ArgumentOutOfRangeException>(value, 2, 4, "value");

            // Assert
            act.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value must have between 2 and 4 symbols.");
        }

        [Fact]
        public void ForStringLength_WithTooLongValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string value = "abcde";

            // Act
            Action act = () => Guard.ForStringLength<ArgumentOutOfRangeException>(value, 2, 4, "value");

            // Assert
            act.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value must have between 2 and 4 symbols.");
        }

        [Fact]
        public void AgainstOutOfRange_WithValidValue_DoesNotThrowException()
        {
            // Arrange
            int value = 3;

            // Act
            Action act = () => Guard.AgainstOutOfRange<ArgumentOutOfRangeException>(value, 2, 4, "value");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void AgainstOutOfRange_WithTooSmallValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => Guard.AgainstOutOfRange<ArgumentOutOfRangeException>(value, 2, 4, "value");

            // Assert
            act.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value must be between 2 and 4.");
        }

        [Fact]
        public void AgainstOutOfRange_WithTooLargeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int value = 5;

            // Act
            Action act = () => Guard.AgainstOutOfRange<ArgumentOutOfRangeException>(value, 2, 4, "value");

            // Assert
            act.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value must be between 2 and 4.");
        }
}