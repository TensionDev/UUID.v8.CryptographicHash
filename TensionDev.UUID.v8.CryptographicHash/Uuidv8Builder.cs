// SPDX-License-Identifier: Apache-2.0
//
//   Copyright 2021 - 2026 TensionDev <TensionDev@outlook.com>
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Security.Cryptography;
using System.Text;

namespace TensionDev.UUID.v8.CryptographicHash
{
    /// <summary>
    /// Shared, static implementation for building a name-based UUID Version 8 from a supported hashing algorithm.
    /// </summary>
    /// <remarks>
    /// All facade classes (SHA256, SHA384, SHA512, SHA3_256, SHA3_384, SHA3_512) forward to this single source of truth.
    /// The buffer construction, hash selection, version/variant masking, and UUID assembly therefore live in exactly one
    /// place, so there is no duplicated logic to keep in sync and any fix is made once.
    ///
    /// The helper is <see cref="static"/> and holds no state, so no instance is required. The hashing algorithm is passed as
    /// the facade's crypto <see cref="Type"/> (captured in a <c>private static readonly Type</c> field) rather than as a
    /// delegate or a shared enum value, so each facade only names its own algorithm and adding a new algorithm requires one
    /// facade forward and one <c>case</c> arm.
    /// </remarks>
    internal static class Uuidv8Builder
    {
        /// <summary>
        /// Builds a name-based UUID Version 8 using the specified hashing algorithm.
        /// </summary>
        /// <param name="nameSpace">The 16-byte namespace UUID (RFC 9562 namespace).</param>
        /// <param name="name">The name string, concatenated after the namespace and hashed as UTF-8.</param>
        /// <param name="hashType">The hashing algorithm to use.</param>
        /// <returns>A new name-based UUID Version 8 (version bit set to 8 and RFC 9562 variant applied).</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="hashType"/> is not one of the supported hashing algorithms.
        /// </exception>
        public static Uuid Build(Uuid nameSpace, string name, Type hashType)
        {
            byte[] nsArray = nameSpace.ToByteArray();
            byte[] nArray = Encoding.UTF8.GetBytes(name);

            byte[] buffer = new byte[nsArray.Length + nArray.Length];
            Buffer.BlockCopy(nsArray, 0, buffer, 0, nsArray.Length);
            Buffer.BlockCopy(nArray, 0, buffer, nsArray.Length, nArray.Length);

            byte[] hash = Hash(buffer, hashType);

            byte[] hex = new byte[16];

            hex[0] = hash[0];
            hex[1] = hash[1];
            hex[2] = hash[2];
            hex[3] = hash[3];

            hex[4] = hash[4];
            hex[5] = hash[5];

            hex[6] = (byte)((hash[6] & 0x0F) + 0x80);
            hex[7] = hash[7];

            hex[8] = (byte)((hash[8] & 0x3F) + 0x80);
            hex[9] = hash[9];

            hex[10] = hash[10];
            hex[11] = hash[11];
            hex[12] = hash[12];
            hex[13] = hash[13];
            hex[14] = hash[14];
            hex[15] = hash[15];

            return new Uuid(hex);
        }

        /// <summary>
        /// Selects and runs the hash for the requested algorithm, applying the appropriate platform guard.
        /// </summary>
        /// <param name="buffer">The namespace || name buffer to hash.</param>
        /// <param name="hashType">The hashing algorithm to use.</param>
        /// <returns>The hash bytes (32, 48, or 64 bytes depending on the algorithm).</returns>
        /// <exception cref="PlatformNotSupportedException">
        /// Thrown when the requested algorithm is not available on the current runtime (for example, SHA3 on .NET 6 or below).
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="hashType"/> is not one of the supported hashing algorithms.
        /// </exception>
        private static byte[] Hash(byte[] buffer, Type hashType)
        {
            switch (hashType)
            {
                case typeof(SHA256):
#if NET6_0_OR_GREATER
                    return SHA256.HashData(buffer);
#else
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        return sha256.ComputeHash(buffer);
                    }
#endif

                case typeof(SHA384):
#if NET6_0_OR_GREATER
                    return SHA384.HashData(buffer);
#else
                    using (SHA384 sha384 = SHA384.Create())
                    {
                        return sha384.ComputeHash(buffer);
                    }
#endif

                case typeof(SHA512):
#if NET6_0_OR_GREATER
                    return SHA512.HashData(buffer);
#else
                    using (SHA512 sha512 = SHA512.Create())
                    {
                        return sha512.ComputeHash(buffer);
                    }
#endif

                case typeof(SHA3_256):
                case typeof(SHA3_384):
                case typeof(SHA3_512):
#if NET8_0_OR_GREATER
                    return switch (hashType)
                    {
                        typeof(SHA3_256) => SHA3_256.HashData(buffer),
                        typeof(SHA3_384) => SHA3_384.HashData(buffer),
                        typeof(SHA3_512) => SHA3_512.HashData(buffer),
                        _ => throw new ArgumentOutOfRangeException(nameof(hashType), hashType, "Unsupported hashing algorithm."),
                    };
#else
                    throw new PlatformNotSupportedException("SHA3 is not supported on this platform. Please use .NET 8.0 or greater.");
#endif

                default:
                    throw new ArgumentOutOfRangeException(nameof(hashType), hashType, "Unsupported hashing algorithm.");
            }
        }
    }
}
