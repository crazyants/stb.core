/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.HubTables
{
	/// <summary>
	///  hub tables
	/// </summary>
	public class Devices
	{
		public string DeviceAddress {get;set;}
		public string Pubkey {get;set;}
		public string TempPubkeyPackage {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
	}
}
