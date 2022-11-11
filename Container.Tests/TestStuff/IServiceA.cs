namespace Container.Tests.TestStuff
{
    internal interface IServiceA
    {
        int InstanceA { get; }

        string AProperty { get; set; }

        string AMethod(int someValue);
    }
}
