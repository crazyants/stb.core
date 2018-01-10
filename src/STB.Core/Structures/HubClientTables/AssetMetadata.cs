/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.HubClientTables
{
    public class AssetMetadata
    {
        public string Asset { get; set; }
        public string MetadataUnit { get; set; }

        /// <summary>
        ///     filled only on the hub
        /// </summary>
        public string RegistryAddress { get; set; }

        /// <summary>
        ///     added only if the same name is registered by different registries for different assets, equal to registry name
        /// </summary>
        public string Suffix { get; set; }

        public string Name { get; set; }
        public byte Decimals { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}