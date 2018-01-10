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
    public class Graph
    {
        //public Witnessed Witnessed { get; set; }
        public int WitnessedLevel { get; set; }
        public bool IsOnMainChain { get; set; }
        public int MainChainIndex { get; set; }
        public int Level { get; set; }
        public int LastestIncludedMainChainIndex { get; set; }
        public bool IsFree { get; set; }
        public Unit Unit { get; set; }
        public Author Author { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime CreationDate { get; set; }
        public Unit WitnessListUnit { get; set; }
        public Unit LastBlockUnit
        { get; set; }
        public string ContentHash { get; set; } 

    }
}