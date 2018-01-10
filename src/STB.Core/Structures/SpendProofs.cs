/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/
namespace STB.Core.Structures
{
    public class SpendProofs
    {
        public Unit Unit { get; set; }
        public int MessageIndex { get; set; }
        public byte SpendProofIndex { get; set; }
        public string SpendProof { get; set; }
        public string Address { get; set; }

    }
}