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
	public class Outbox
	{
		public string MessageHash {get;set;}
		/// <summary>
		///  the device this message is addressed to, no FK because of pairing case
		/// </summary>
		public string To {get;set;}
		public string Message {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public string LastError {get;set;}
	}
}
