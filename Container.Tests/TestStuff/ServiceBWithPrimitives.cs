namespace Container.Tests.TestStuff
{
    internal class ServiceBWithPrimitives : IServiceB
    {
        private static int _instanceCounter = 0;
        private string strVal;

        public ServiceBWithPrimitives(string strVal, IServiceA serviceA)
        {
            this.InstanceB = ++_instanceCounter;
            this.ServiceA = serviceA;
            this.strVal = strVal;
        }

        public int InstanceB { get; }

        public IServiceA ServiceA { get; }

        public string SomeMethodB(double value)
        {
            return this.strVal;
        }
    }
}
