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
	///  derivation path is m/44'/0'/account'/is_change/address_index
	/// </summary>
	public class MyAddresses
	{
		public string Address {get;set;}
		public string Wallet {get;set;}
		public byte? IsChange {get;set;}
		public int? AddressIndex {get;set;}
		public string Definition {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
	}
}
