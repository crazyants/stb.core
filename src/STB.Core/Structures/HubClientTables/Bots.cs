/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.HubClientTables
{
	public class Bots
	{
		public int? Id {get;set;}
		public int? Rank {get;set;} = 0;
		public string Name {get;set;}
		public string PairingCode {get;set;}
		public string Description {get;set;}
	}
}
