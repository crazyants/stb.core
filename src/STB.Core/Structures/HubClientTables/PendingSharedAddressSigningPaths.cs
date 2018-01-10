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
    public class PendingSharedAddressSigningPaths
    {
        public string DefinitionTemplateChash { get; set; }
        public string DeviceAddress { get; set; }

        /// <summary>
        ///     path from root to member address
        /// </summary>
        public string SigningPath { get; set; }

        /// <summary>
        ///     member address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     json
        /// </summary>
        public string DeviceAddressesByRelativeSigningPaths { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime ApprovalDate { get; set; }
    }
}