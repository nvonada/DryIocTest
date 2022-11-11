using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Container.Tests
{
    using System;
    using DryIoc;
    using TestStuff;

    [TestClass]
    public class Tests
    {
        private IContainer container;

        [TestCleanup]
        public void TestCleanup()
        {
            this.container.Dispose();
            this.container = null;
        }

        [TestMethod]
        public void SimpleRegistrationViaInterface()
        {
            this.container = new Container();
            this.container.Register<IServiceA, ServiceA>();
            var serviceA = this.container.Resolve<IServiceA>();
            Assert.IsNotNull(serviceA);
            var anotherA = this.container.Resolve<IServiceA>();
            Assert.AreNotSame(serviceA, anotherA);
        }

        [TestMethod]
        public void SimpleRegistrationViaType()
        {
            this.container = new Container();
            this.container.Register<ServiceA>();
            var serviceA = this.container.Resolve<ServiceA>();
            Assert.IsNotNull(serviceA);
            Assert.IsNotNull(serviceA);
            var anotherA = this.container.Resolve<ServiceA>();
            Assert.AreNotSame(serviceA, anotherA);
        }

        [TestMethod]
        public void SingletonRegistrationViaInterface()
        {
            this.container = new Container();
            this.container.Register<IServiceA, ServiceA>(Reuse.Singleton);
            var serviceA = this.container.Resolve<IServiceA>();
            Assert.IsNotNull(serviceA);
            var sameA = this.container.Resolve<IServiceA>();
            Assert.AreSame(serviceA, sameA);
        }

        [TestMethod]
        public void SingletonRegistrationViaType()
        {
            this.container = new Container();
            this.container.Register<ServiceA>(Reuse.Singleton);
            var serviceA = this.container.Resolve<ServiceA>();
            Assert.IsNotNull(serviceA);
            var sameA = this.container.Resolve<ServiceA>();
            Assert.AreSame(serviceA, sameA);
        }

        [TestMethod]
        public void ImplicitFactory()
        {
            this.container = new Container();
            this.container.Register<IServiceA, ServiceA>();
            var factoryA = this.container.Resolve<Func<IServiceA>>();
            var serviceA = factoryA();
            Assert.IsNotNull(serviceA);
            var anotherA = factoryA();
            Assert.AreNotSame(serviceA, anotherA);
        }

        [TestMethod]
        public void DefaultRulesForbidMultipleConstructors()
        {
            this.container = new Container();
            this.container.Register<IServiceA, ServiceA>();
            Assert.ThrowsException<ContainerException>(() => this.container.Register<IServiceB, ServiceB>());
        }
        
        [TestMethod]
        public void RulesChangedToAllowMultipleConstructors()
        {
            this.container = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments));
            this.container.Register<IServiceA, ServiceA>();
            this.container.Register<IServiceB, ServiceB>();
            var serviceA = this.container.Resolve<IServiceA>();
            Assert.IsNotNull(serviceA);
            var serviceB = this.container.Resolve<IServiceB>();
            Assert.IsNotNull(serviceB);
            Assert.AreNotSame(serviceA, serviceB.ServiceA);
        }
    }
}
