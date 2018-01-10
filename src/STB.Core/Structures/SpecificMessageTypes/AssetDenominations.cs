/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.SpecificMessageTypes
{
    public class AssetDenominations
    {
        public string Asset { get; set; }
        public int? Denomination { get; set; }
        public long CountCoins { get; set; }
        public long? MaxIssuedSerialNumber { get; set; } = 0;
    }
}