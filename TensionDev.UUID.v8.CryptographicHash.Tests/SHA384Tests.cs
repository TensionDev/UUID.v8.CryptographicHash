using System;
using Xunit;

namespace TensionDev.UUID.v8.CryptographicHash.Tests
{
    public class SHA384Tests
    {
        [Fact]
        public void TestNewUUIDv8_DNS()
        {
            Uuid expectedGuid = new Uuid("57017b32-f32a-8b1a-8353-90371a43ff48");

            String name = "www.contoso.com";
            Uuid guid = SHA384.NewUUIDv8(UUIDNamespace.DNS, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_URL()
        {
            Uuid expectedGuid = new Uuid("1a261a04-809b-8b96-b370-2cdfaa8dfb9c");

            String name = "https://www.contoso.com";
            Uuid guid = SHA384.NewUUIDv8(UUIDNamespace.URL, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_OID()
        {
            Uuid expectedGuid = new Uuid("0cfd5769-6138-888d-8c4f-0f677985e8b1");

            String name = "1.0.3166.1";
            Uuid guid = SHA384.NewUUIDv8(UUIDNamespace.OID, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_X500()
        {
            Uuid expectedGuid = new Uuid("f72b2828-e8ef-8d98-96e5-a6504cf3d31f");

            String name = "/c=us/o=Sun/ou=People/cn=Rosanna Lee";
            Uuid guid = SHA384.NewUUIDv8(UUIDNamespace.X500, name);

            Assert.Equal(expectedGuid, guid);
        }
    }
}
