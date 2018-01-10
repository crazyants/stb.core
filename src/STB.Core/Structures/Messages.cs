/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures
{
    public class Messages
    {
        public Unit Unit { get; set; }
        public int MessageIndex { get; set; }

        public int App { get; set; }

        public string PayloadLocation { get; set; }
        public string PayloadHash { get; set; }
        public string Payload { get; set; }
        public string PayloadUriHash { get; set; }
        public string PayloadUri { get; set; }
    }
}