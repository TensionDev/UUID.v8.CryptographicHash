using System;
using Xunit;

namespace TensionDev.UUID.v8.CryptographicHash.Tests
{
    public class SHA3_512Tests
    {
        [Fact]
        public void TestNewUUIDv8_DNS()
        {
            Uuid expectedGuid = new Uuid("4d659cf3-c495-81c6-bc43-93ab57e96c5f");

            String name = "www.contoso.com";
            Uuid guid = SHA3_512.NewUUIDv8(UUIDNamespace.DNS, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_URL()
        {
            Uuid expectedGuid = new Uuid("d446b8d7-ea2a-8a98-98a3-46043d922a62");

            String name = "https://www.contoso.com";
            Uuid guid = SHA3_512.NewUUIDv8(UUIDNamespace.URL, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_OID()
        {
            Uuid expectedGuid = new Uuid("ca76c797-18ac-8415-b2b9-0e202316e6c7");

            String name = "1.0.3166.1";
            Uuid guid = SHA3_512.NewUUIDv8(UUIDNamespace.OID, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_X500()
        {
            Uuid expectedGuid = new Uuid("d61cd380-017a-8672-83c4-a9884e237062");

            String name = "/c=us/o=Sun/ou=People/cn=Rosanna Lee";
            Uuid guid = SHA3_512.NewUUIDv8(UUIDNamespace.X500, name);

            Assert.Equal(expectedGuid, guid);
        }
    }
}
