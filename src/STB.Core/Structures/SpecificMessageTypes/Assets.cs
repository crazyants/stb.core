/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.SpecificMessageTypes
{
    public class Assets
    {
        public string Unit { get; set; }
        public byte? MessageIndex { get; set; }
        public long Cap { get; set; }
        public byte? IsPrivate { get; set; }
        public byte? IsTransferrable { get; set; }
        public byte? AutoDestroy { get; set; }
        public byte? FixedDenominations { get; set; }
        public byte? IssuedByDefinerOnly { get; set; }
        public byte? CosignedByDefiner { get; set; }

        /// <summary>
        ///     must subsequently publish and update the list of trusted attestors
        /// </summary>
        public byte? SpenderAttested { get; set; }

        public string IssueCondition { get; set; }
        public string TransferCondition { get; set; }
    }
}