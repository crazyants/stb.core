/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.SpecificMessageTypes
{
	public class Votes
	{
		public string Unit {get;set;}
		public byte? MessageIndex {get;set;}
		public string PollUnit {get;set;}
		public string Choice {get;set;}
	}
}
