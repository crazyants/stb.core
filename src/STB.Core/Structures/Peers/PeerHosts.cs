/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.Peers
{
	/// <summary>
	///  Peers
	/// </summary>
	public class PeerHosts
	{
		/// <summary>
		///  domain or IP
		/// </summary>
		public string PeerHost {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public int? CountNewGoodJoints {get;set;} = 0;
		public int? CountInvalidJoints {get;set;} = 0;
		public int? CountNonserialJoints {get;set;} = 0;
	}
}
