/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.SpecificMessageTypes
{
    /// <summary>
    ///     Specific message types
    /// </summary>
    public class AddressDefinitionChanges
    {
        public string Unit { get; set; }
        public byte? MessageIndex { get; set; }
        public string Address { get; set; }

        /// <summary>
        ///     might not be defined in definitions yet (almost always, it is not defined)
        /// </summary>
        public string DefinitionChash { get; set; }
    }
}