namespace Container.Tests.TestStuff
{
    internal class ServiceA : IServiceA
    {
        private static int _instanceCount = 0;

        public ServiceA()
        {
            this.InstanceA = ++_instanceCount;
        }

        public int InstanceA { get; }

        public string AProperty { get; set; }

        public string AMethod(int someValue)
        {
            return someValue.ToString();
        }
    }
}
