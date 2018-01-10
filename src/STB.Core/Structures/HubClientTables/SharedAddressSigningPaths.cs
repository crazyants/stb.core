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
	public class SharedAddressSigningPaths
	{
		public string SharedAddress {get;set;}
		/// <summary>
		///  full path to signing key which is a member of the member address
		/// </summary>
		public string SigningPath {get;set;}
		/// <summary>
		///  member address
		/// </summary>
		public string Address {get;set;}
		/// <summary>
		///  path to signing key from root of the member address
		/// </summary>
		public string MemberSigningPath {get;set;}
		/// <summary>
		///  where this signing key lives or is reachable through
		/// </summary>
		public string DeviceAddress {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
	}
}
