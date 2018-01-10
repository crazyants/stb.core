/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.HubClientTables
{
	/// <summary>
	///  light clients
	/// </summary>
	public class WatchedLightAddresses
	{
		public string Peer {get;set;}
		public string Address {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
	}
}
