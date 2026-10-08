using System;
using Xunit;

namespace TensionDev.UUID.v8.CryptographicHash.Tests
{
    public class SHA512Tests
    {
        [Fact]
        public void TestNewUUIDv8_DNS()
        {
            Uuid expectedGuid = new Uuid("1f58b34f-76c4-8de7-bde4-153328cbb927");

            String name = "www.contoso.com";
            Uuid guid = SHA512.NewUUIDv8(UUIDNamespace.DNS, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_URL()
        {
            Uuid expectedGuid = new Uuid("f1e5150c-0997-8d69-b643-95dc044a901d");

            String name = "https://www.contoso.com";
            Uuid guid = SHA512.NewUUIDv8(UUIDNamespace.URL, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_OID()
        {
            Uuid expectedGuid = new Uuid("c05c49a2-ae23-83e9-913e-34dfe2751dc5");

            String name = "1.0.3166.1";
            Uuid guid = SHA512.NewUUIDv8(UUIDNamespace.OID, name);

            Assert.Equal(expectedGuid, guid);
        }

        [Fact]
        public void TestNewUUIDv8_X500()
        {
            Uuid expectedGuid = new Uuid("3a1bcb1a-c7b9-86de-afc0-a715e399649c");

            String name = "/c=us/o=Sun/ou=People/cn=Rosanna Lee";
            Uuid guid = SHA512.NewUUIDv8(UUIDNamespace.X500, name);

            Assert.Equal(expectedGuid, guid);
        }
    }
}
