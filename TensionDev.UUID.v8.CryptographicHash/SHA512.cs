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

namespace TensionDev.UUID.v8.CryptographicHash
{
    /// <summary>
    /// Class Library to generate Universally Unique Identifier (UUID) / Globally Unique Identifier (GUID) based on Version 8 using SHA-512 namespace name-based.
    /// </summary>
    public static class SHA512
    {
        private static readonly Type HashType = typeof(System.Security.Cryptography.SHA512);

        /// <summary>
        /// Initialises a new GUID/UUID based on Version 8 using SHA-512 namespace name-based.
        /// </summary>
        /// <param name="nameSpace">The namespace UUID to use for hashing.</param>
        /// <param name="name">The name string to hash with the namespace.</param>
        /// <returns>A new Uuid object</returns>
        public static Uuid NewUUIDv8(Uuid nameSpace, String name) => Uuidv8Builder.Build(nameSpace, name, HashType);

        /// <summary>
        /// Returns true if the Uuid specified is Version 8.
        /// </summary>
        /// <param name="uuid">The Uuid to be tested.</param>
        /// <returns>Returns true if the Uuid specified is Version 8.</returns>
        public static bool IsUUIDv8(Uuid uuid) => TensionDev.UUID.UUIDv8.IsUUIDv8(uuid);
    }
}
