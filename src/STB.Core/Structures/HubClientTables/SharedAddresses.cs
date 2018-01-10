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
    ///     member addresses live on different devices, member addresses themselves may be composed of several keys
    /// </summary>
    public class SharedAddresses
    {
        public string SharedAddress { get; set; }
        public string Definition { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}