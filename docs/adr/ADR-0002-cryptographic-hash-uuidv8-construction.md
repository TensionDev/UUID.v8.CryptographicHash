# ADR-0002 – Cryptographic Hash UUIDv8 Construction

**Status:** Accepted  
**Date:** 2026-10-07

## Context

ADR-0001 defines a name-based UUIDv8 mechanism using cryptographic hash functions.

For deterministic UUID generation, the byte-level construction must be defined precisely. Differences in UUID byte ordering, name encoding, input ordering, hash truncation, or version and variant application would produce different UUID values for the same inputs.

The construction should remain aligned with the established name-based model used by UUIDv3 and UUIDv5 while using UUIDv8 for the resulting identifier.

## Decision

The cryptographic hash input shall consist of the namespace UUID followed immediately by the UTF-8 encoded name.

The namespace UUID shall be represented using its 16-byte UUID representation.

The name shall be encoded as UTF-8 without modification.

No trimming, case conversion, Unicode normalization, delimiter, prefix, salt, or other additional data shall be applied to the input.

The resulting byte sequence shall be hashed using the selected cryptographic hash algorithm.

The leftmost 128 bits of the resulting digest shall be used as the initial UUID value.

The UUID version shall then be set to `8`, and the RFC 9562 variant shall be applied.

The hash algorithm shall not be encoded into the UUID.

## Construction

```text
Namespace UUID
      |
      v
16-byte UUID representation
      |
      +--------------------+
                           |
                           v
Name --> UTF-8 encoding --> Concatenate
                           |
                           v
                     Cryptographic Hash
                           |
                           v
                  Leftmost 128 bits
                           |
                           v
                   Set Version = 8
                   Set RFC Variant
                           |
                           v
                        UUIDv8
```

Conceptually:

```text
HashInput = NamespaceBytes || UTF8(Name)
```

```text
Uuid = Hash(HashInput)[0..15]
Uuid.Version = 8
Uuid.Variant = RFC 9562
```

The exact byte representation of the namespace UUID shall follow the representation used by the `TensionDev.UUID` implementation.

## Consequences

### Positive

- Deterministic generation is precisely defined.
- Implementations can reproduce UUIDs across platforms and languages.
- The construction remains conceptually aligned with UUIDv3 and UUIDv5.
- No algorithm-specific data is introduced into the UUID.
- All supported cryptographic hash algorithms use the same UUID construction.

### Negative

- Changing the byte representation, encoding, or construction rules would produce different UUIDs.
- Names with different UTF-8 representations produce different UUIDs.
- Consumers must know the namespace, name, and hash algorithm to reproduce a UUID.
- Hash digests larger than 128 bits have their remaining bits discarded.

## Related ADRs

- ADR-0001 – Cryptographic Hash Name-Based UUIDv8
