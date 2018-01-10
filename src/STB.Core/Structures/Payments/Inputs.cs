/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.Payments
{
	/// <summary>
	///  Payments
	/// </summary>
	public class Inputs
	{
		public string Unit {get;set;}
		public byte? MessageIndex {get;set;}
		public byte? InputIndex {get;set;}
		public string Asset {get;set;}
		public int? Denomination {get;set;} = 1;
		public byte IsUnique {get;set;} = 1;
		public string Type {get;set;}
		/// <summary>
		///  transfer
		/// </summary>
		public string SrcUnit {get;set;}
		/// <summary>
		///  transfer
		/// </summary>
		public byte SrcMessageIndex {get;set;}
		/// <summary>
		///  transfer
		/// </summary>
		public byte SrcOutputIndex {get;set;}
		/// <summary>
		///  witnessing/hc
		/// </summary>
		public int FromMainChainIndex {get;set;}
		/// <summary>
		///  witnessing/hc
		/// </summary>
		public int ToMainChainIndex {get;set;}
		/// <summary>
		///  issue
		/// </summary>
		public long SerialNumber {get;set;}
		/// <summary>
		///  issue
		/// </summary>
		public long Amount {get;set;}
		public string Address {get;set;}
	}
}
