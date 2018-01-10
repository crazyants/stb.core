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
    public class Peers
    {
        /// <summary>
        ///     wss:// address
        /// </summary>
        public string Peer { get; set; }

        /// <summary>
        ///     domain or IP
        /// </summary>
        public string PeerHost { get; set; }

        /// <summary>
        ///     domain or IP
        /// </summary>
        public string LearntFromPeerHost { get; set; }

        public byte? IsSelf { get; set; } = 0;
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}