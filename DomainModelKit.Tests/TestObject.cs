namespace DomainModelKit.Tests;

public class TestObject : ValueObject
{
    public TestObject(string testProp)
    {
        TestProp = testProp;
    }
    
    public string TestProp { get; set; }
}