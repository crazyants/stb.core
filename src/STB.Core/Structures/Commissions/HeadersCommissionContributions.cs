/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.Commissions
{
    /// <summary>
    ///     updated immediately after main chain is updated
    /// </summary>
    public class HeadersCommissionContributions
    {
        /// <summary>
        ///     child unit that receives (and optionally redistributes) commission from parent units
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        ///     address of the commission receiver: author of child unit or address named in earned_headers_commission_recipients
        /// </summary>
        public string Address { get; set; }

        public long? Amount { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}