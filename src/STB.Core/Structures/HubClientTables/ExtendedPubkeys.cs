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
	public class ExtendedPubkeys
	{
		/// <summary>
		///  no FK because xpubkey may arrive earlier than the wallet is approved by the user and written to the db
		/// </summary>
		public string Wallet {get;set;}
		/// <summary>
		///  base58 encoded, see bip32, NULL while pending
		/// </summary>
		public string ExtendedPubkey {get;set;}
		public string DeviceAddress {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public DateTime ApprovalDate {get;set;}
		/// <summary>
		///  when this member notified us that he has collected all member xpubkeys
		/// </summary>
		public DateTime MemberReadyDate {get;set;}
	}
}
