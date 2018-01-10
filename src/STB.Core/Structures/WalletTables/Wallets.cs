/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.WalletTables
{
	/// <summary>
	///  wallets composed of BIP44 keys, the keys live on different devices, each device knows each other's extended public key
	/// </summary>
	public class Wallets
	{
		public string Wallet {get;set;}
		public int? Account {get;set;}
		public string DefinitionTemplate {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public DateTime FullApprovalDate {get;set;}
		/// <summary>
		///  when all members notified me that they saw the wallet fully approved
		/// </summary>
		public DateTime ReadyDate {get;set;}
	}
}
