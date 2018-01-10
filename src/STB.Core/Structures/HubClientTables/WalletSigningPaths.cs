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
    public class WalletSigningPaths
    {
        /// <summary>
        ///     no FK because xpubkey may arrive earlier than the wallet is approved by the user and written to the db
        /// </summary>
        public string Wallet { get; set; }

        /// <summary>
        ///     NULL if xpubkey arrived earlier than the wallet was approved by the user
        /// </summary>
        public string SigningPath { get; set; }

        public string DeviceAddress { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}