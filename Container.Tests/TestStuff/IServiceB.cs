namespace Container.Tests.TestStuff
{
    internal interface IServiceB
    {
        int InstanceB { get; }

        IServiceA ServiceA { get; }

        string SomeMethodB(double value);
    }
}
