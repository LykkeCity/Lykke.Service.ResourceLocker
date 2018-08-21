using NUnit.Framework;
using Autofac;
using Lykke.Service.ResourceLocker.Client;
using Lykke.Service.ResourceLocker.Client.Models;
using System;

namespace Lykke.Service.ResourceLocker.Tests
{
    [TestFixture]
    public class ClientTest
    {
        private IContainer _container;

        public ClientTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IResourceLockerClient>(new ResourceLockerClient(new ResourceLockerServiceClientSettings() { ServiceUrl = "http://localhost:5000" }));
            _container = builder.Build();
        }

        [Test]
        public void LockResourceTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IResourceLockerClient>(new ResourceLockerClient(new ResourceLockerServiceClientSettings() { ServiceUrl = "http://localhost:5000" }));
            _container = builder.Build();

            var client = _container.Resolve<IResourceLockerClient>();
            var callresult = client.LockResource(
                new LockedResourceRequest()
                {
                    ExpirationTime = DateTime.Now.AddMinutes(-1),
                    Owner = "1",
                    ResourceId = "2",
                    ServiceName = "3"
                });
        }
        [Test]
        public void ReleaseResourceTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IResourceLockerClient>(new ResourceLockerClient(new ResourceLockerServiceClientSettings() { ServiceUrl = "http://localhost:5000" }));
            _container = builder.Build();

            var client = _container.Resolve<IResourceLockerClient>();
            var callresult = client.ReleaseResource(
                new ReleaseResourceRequest()
                {
                    Key = "1",
                    ResourceId = "2"
                });
        }
    }
}
