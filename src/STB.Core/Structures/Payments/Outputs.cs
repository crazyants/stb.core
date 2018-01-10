/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.Payments
{
    public class Outputs
    {
        public int? OutputId { get; set; }
        public string Unit { get; set; }
        public byte? MessageIndex { get; set; }
        public byte? OutputIndex { get; set; }
        public string Asset { get; set; }
        public int? Denomination { get; set; } = 1;

        /// <summary>
        ///     NULL if hidden by output_hash
        /// </summary>
        public string Address { get; set; }

        public long? Amount { get; set; }
        public string Blinding { get; set; }
        public string OutputHash { get; set; }

        /// <summary>
        ///     NULL if not stable yet
        /// </summary>
        public byte IsSerial { get; set; }

        public byte? IsSpent { get; set; } = 0;
    }
}