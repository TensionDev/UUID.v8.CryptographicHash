using System;
using Xunit;

namespace TensionDev.UUID.v8.CryptographicHash.Tests
{
    public class SHA256Tests
    {
        [Fact]
        public void TestNewUUIDv8_DNS()
        {
            Uuid expectedGuid = new Uuid("44032eb4-74f7-8141-8763-95bcb31a00fe");

            String name = "www.contoso.com";
            Uuid guid = SHA256.NewUUIDv8(UUIDNamespace.DNS, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_URL()
        {
            Uuid expectedGuid = new Uuid("226d46ea-9b85-8da3-8817-276aca4b261b");

            String name = "https://www.contoso.com";
            Uuid guid = SHA256.NewUUIDv8(UUIDNamespace.URL, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_OID()
        {
            Uuid expectedGuid = new Uuid("10356f08-bb14-84f2-a235-eecb59b45093");

            String name = "1.0.3166.1";
            Uuid guid = SHA256.NewUUIDv8(UUIDNamespace.OID, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_X500()
        {
            Uuid expectedGuid = new Uuid("c507cb8a-ae3d-8fb6-955c-e896f927db96");

            String name = "/c=us/o=Sun/ou=People/cn=Rosanna Lee";
            Uuid guid = SHA256.NewUUIDv8(UUIDNamespace.X500, name);

            Assert.Equal(expectedGuid, guid);
        }
    }
}
