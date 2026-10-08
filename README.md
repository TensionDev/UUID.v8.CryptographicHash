# TensionDev.UUID.v8.CryptographicHash

[![.NET](https://github.com/TensionDev/UUID.v8.CryptographicHash/actions/workflows/dotnet.yml/badge.svg)](https://github.com/TensionDev/UUID.v8.CryptographicHash/actions/workflows/dotnet.yml)
[![Package Release](https://github.com/TensionDev/UUID.v8.CryptographicHash/actions/workflows/package-release.yml/badge.svg)](https://github.com/TensionDev/UUID.v8.CryptographicHash/actions/workflows/package-release.yml)
[![CodeQL](https://github.com/TensionDev/UUID.v8.CryptographicHash/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/TensionDev/UUID.v8.CryptographicHash/actions/workflows/github-code-scanning/codeql)

TensionDev.UUID.v8.CryptographicHash is a .NET library extending [TensionDev.UUID](https://github.com/TensionDev/UUID) with support for name-based UUID Version 8 using Cryptographic Hash Algorithms.  
This project references the following documents for implementation.  
- [Universally unique identifier - Wikipedia](https://en.wikipedia.org/wiki/Universally_unique_identifier)  
- [rfc9562](https://datatracker.ietf.org/doc/html/rfc9562)  

---

## Features  

- Support for three SHA-2 hash algorithms:  
  - SHA-256  
  - SHA-384  
  - SHA-512  
- Strict RFC compliance for parsing and validation  

---

## Installation  
```bash
dotnet add package TensionDev.UUID.v8.CryptographicHash
```

---

## Usage Examples

### Generate SHA-256 UUID v8
```csharp
using TensionDev.UUID.v8.CryptographicHash;

// Generate a UUID using DNS namespace with SHA-256
Uuid uuid = SHA256.NewUUIDv8(UUIDNamespace.DNS, "www.contoso.com");
Console.WriteLine(uuid); // Example: 0b3e79a4-6f85-825a-a65d-fc78495c9381
```

### Generate SHA-384 UUID v8
```csharp
using TensionDev.UUID.v8.CryptographicHash;

// Generate a UUID using URL namespace with SHA-384
Uuid uuid = SHA384.NewUUIDv8(UUIDNamespace.URL, "https://www.contoso.com");
Console.WriteLine(uuid); // Example: 1a261a04-809b-8b96-b370-2cdfaa8dfb9c
```

### Generate SHA-512 UUID v8
```csharp
using TensionDev.UUID.v8.CryptographicHash;

// Generate a UUID using OID namespace with SHA-512
Uuid uuid = SHA512.NewUUIDv8(UUIDNamespace.OID, "1.0.3166.1");
Console.WriteLine(uuid); // c05c49a2-ae23-83e9-913e-34dfe2751dc5
```

### Verify UUID Version 8
```csharp
using TensionDev.UUID.v8.CryptographicHash;

Uuid uuid = SHA512.NewUUIDv8(UUIDNamespace.X500, "/c=us/o=Sun/ou=People/cn=Rosanna Lee");
bool isValid = SHA512.IsUUIDv8(uuid);
Console.WriteLine(isValid); // true
```
