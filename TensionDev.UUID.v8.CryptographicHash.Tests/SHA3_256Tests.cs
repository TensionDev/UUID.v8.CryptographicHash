using System;
using Xunit;

namespace TensionDev.UUID.v8.CryptographicHash.Tests
{
    public class SHA3_256Tests
    {
        [Fact]
        public void TestNewUUIDv8_DNS()
        {
            Uuid expectedGuid = new Uuid("72b5258f-3aef-8b28-9dca-2cb430e906d3");

            String name = "www.contoso.com";
            Uuid guid = SHA3_256.NewUUIDv8(UUIDNamespace.DNS, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_URL()
        {
            Uuid expectedGuid = new Uuid("db1531a3-7a1c-872e-ba95-a7846efdfddd");

            String name = "https://www.contoso.com";
            Uuid guid = SHA3_256.NewUUIDv8(UUIDNamespace.URL, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_OID()
        {
            Uuid expectedGuid = new Uuid("68241290-13d2-846d-babf-92f29fa893a2");

            String name = "1.0.3166.1";
            Uuid guid = SHA3_256.NewUUIDv8(UUIDNamespace.OID, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_X500()
        {
            Uuid expectedGuid = new Uuid("db8a3338-da2d-8ffc-b9e7-7fb61aba8a5f");

            String name = "/c=us/o=Sun/ou=People/cn=Rosanna Lee";
            Uuid guid = SHA3_256.NewUUIDv8(UUIDNamespace.X500, name);

            Assert.Equal(expectedGuid, guid);
        }
    }
}
