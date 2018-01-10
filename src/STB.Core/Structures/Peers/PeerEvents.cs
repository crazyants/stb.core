/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.Peers
{
    /// <summary>
    ///     INSERT INTO peers (peer_host, peer) VALUES('127.0.0.1', 'ws://127.0.0.1:8081');
    /// </summary>
    public class PeerEvents
    {
        /// <summary>
        ///     domain or IP
        /// </summary>
        public string PeerHost { get; set; }

        public DateTime? EventDate { get; set; } = DateTime.Now;
        public string Event { get; set; }
    }
}