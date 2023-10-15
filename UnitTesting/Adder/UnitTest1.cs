namespace Adder;

[TestFixture]
public class Tests
{
    Maths operation;

    [SetUp]
    public void Setup()
    {
        operation = new Maths();
    }

    [Test]
    public void IsPlusOk()
    {
        int output = operation.Addition(10, 11);
        Assert.AreEqual(21, output);
    }

    [TestCase(2, 3, 5)]
    [TestCase(10, 12, 22)]
    public void IsPlusOk(int val1, int val2, int result)
    {

        int output = operation.Addition(val1,val2);
        Assert.AreEqual(result,output);

    }

    [TestCase(1.5, 2.5, 4.0)]
    [TestCase(10.5, 20.5, 31.0)]
    public void IsPlusOk(double val1, double val2, double result)
    {

        double output = operation.Addition(val1, val2);
        Assert.AreEqual(result, output);

    }

    [TestCase("Ashik", " Varghese", "Ashik Varghese")]
    [TestCase("Prasath", " K P", "Prasath K P")]
    public void IsPlusOk(string val1, string val2, string result)
    {

        string output = operation.Addition(val1, val2);
        Assert.AreEqual(result, output);

    }

}