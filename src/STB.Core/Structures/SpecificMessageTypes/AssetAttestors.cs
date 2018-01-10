/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.SpecificMessageTypes
{
    public class AssetAttestors
    {
        public string Unit { get; set; }
        public byte? MessageIndex { get; set; }

        /// <summary>
        ///     in the initial attestor list: same as unit
        /// </summary>
        public string Asset { get; set; }

        public string AttestorAddress { get; set; }
    }
}