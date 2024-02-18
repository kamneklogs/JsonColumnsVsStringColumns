using Application;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(typeof(Program).Assembly);

public class IntroBasic
{
    private NestedObjectsService service;

    [GlobalSetup]
    public void Setup()
    {
        service = new NestedObjectsService();
    }

    [Benchmark(Description = "S1: Find a rule from a serialized json column with OwnedValues")]
    public void B1()
    {
        service.GetObjectA();
    }

    [Benchmark(Description = "S2: Find a rule from a serialized json column with OwnedValues")]
    public void B2()
    {
        service.GetObjectB();
    }
}