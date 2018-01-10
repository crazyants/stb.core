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
	///  only inbound peers can advertise their urls
	/// </summary>
	public class PeerHostUrls
	{
		/// <summary>
		///  IP
		/// </summary>
		public string PeerHost {get;set;}
		public string Url {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public byte IsActive {get;set;} = 1;
		public DateTime RevocationDate {get;set;}
	}
}
