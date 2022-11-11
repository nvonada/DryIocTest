namespace Container.Tests.TestStuff
{
    using System.Globalization;

    internal class ServiceB : IServiceB
    {
        private static int _instanceCounter = 0;

        public ServiceB()
        {
            this.InstanceB = ++_instanceCounter;
        }

        public ServiceB(IServiceA serviceA)
        {
            this.InstanceB = ++_instanceCounter;
            this.ServiceA = serviceA;
        }

        public int InstanceB { get; }

        public IServiceA ServiceA { get; }

        public string SomeMethodB(double value)
        {
            return value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
