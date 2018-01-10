/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.SpecificMessageTypes
{
    public class DataFeeds
    {
        public string Unit { get; set; }
        public byte? MessageIndex { get; set; }
        public string FeedName { get; set; }
        public string Value { get; set; }
        public long IntValue { get; set; }
    }
}