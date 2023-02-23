![](https://github.com/viktor111/DomainModelKit/actions/workflows/dotnet.yml/badge.svg)
# DomainModelKit

## BaseDomainException
`BaseDomainException` is an abstract class representing a base class for domain exceptions. It extends `Exception`.

## Guard
The Guard class provides a set of static methods that are used to check preconditions in a domain model. These methods are used to ensure that a given value meets certain requirements and throw exceptions if the requirements are not met. The class contains a set of methods to check if a given value is empty or null, if it's length is within a specific range, if it's within a specific range of values, if it's a valid URL, if it matches a specific regular expression, if it's null, if it's not equal to a specific value, if it's a valid email address, if it's a valid date range, if it's not a default value, if it's a positive value, and if it's a valid enum value.

## IFactory
The IFactory interface defines a contract for a factory that produces entities that are IAggregateRoot implementations. The interface has a single method, Build(), that returns an instance of the entity produced by the factory.

## IAggregateRoot
The IAggregateRoot interface defines the contract for an aggregate root in the domain model. Aggregate roots are the entities that form the core of the domain model and represent the consistency boundary within which all the other domain entities and value objects exist.

As an empty interface, IAggregateRoot does not provide any implementation or members. Its sole purpose is to serve as a marker interface, indicating that the implementing class is an aggregate root.

## Enumeration
Enumeration class is an abstract base class that provides a way to define types that represent a fixed set of values. This class helps in enforcing the validation rules by creating fixed-value constants that can be used across the application.

```csharp
public class GenderType : Enumeration
{
    public static GenderType Male = new GenderType(1, "Male");
    public static GenderType Female = new GenderType(2, "Female");

    public GenderType(int value, string name)
        : base(value, name)
    {
    }
}
```

Now, you can use the GenderType enumeration in your application to represent the gender of a person.

To get all the values of the GenderType enumeration, use the GetAll method as shown below:

```csharp
var genderTypes = GenderType.GetAll<GenderType>();
```

You can also get the gender type by name or value using the FromName and FromValue methods as shown below:

```csharp
var male = GenderType.FromName<GenderType>("Male");
var female = GenderType.FromValue<GenderType>(2);
```

To get the name of a gender type from its value, use the NameFromValue method as shown below:

```csharp
var genderName = GenderType.NameFromValue<GenderType>(1);
```

You can also check if a gender type has a specific value using the HasValue method as shown below:

```csharp 
var hasMale = GenderType.HasValue<GenderType>(1);
```

## ValueObject

A base class for creating value objects that can be used in DDD (Domain Driven Design) applications. ValueObject provides an implementation of equality checks between two value objects.

To create a value object, create a new class that inherits from ValueObject and define its fields.

```csharp
public class Money : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }
}

```

After creating the value object, the Equals and GetHashCode methods will be automatically implemented using reflection. This will compare the fields of two objects to determine if they are equal.
```csharp
var money1 = new Money(100m, "USD");
var money2 = new Money(100m, "USD");

var areEqual = money1.Equals(money2); // true
var hashCodesEqual = money1.GetHashCode() == money2.GetHashCode(); // true
```

### API

```csharp
public override bool Equals(object? other);
```

```csharp
public override int GetHashCode();
```

```csharp
public static bool operator ==(ValueObject first, ValueObject second);
```

```csharp
public static bool operator !=(ValueObject first, ValueObject second);
```
