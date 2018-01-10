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
    /// <summary>
    ///     hub client tables
    /// </summary>
    public class CorrespondentDevices
    {
        public string DeviceAddress { get; set; }
        public string Name { get; set; }
        public string Pubkey { get; set; }

        /// <summary>
        ///     domain name of the hub this address is subscribed to
        /// </summary>
        public string Hub { get; set; }

        public byte? IsConfirmed { get; set; } = 0;
        public byte? IsIndirect { get; set; } = 0;
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}