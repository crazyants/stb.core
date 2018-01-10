/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures
{
    public class Block
    {
        public string BlockData { get; set; }
        public DateTime CreationDate { get; set; }
        public Unit Unit { get; set; }
        public int CountPaidWitnesses { get; set; }
    }
}