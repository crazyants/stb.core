/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

namespace STB.Core.Structures.Commissions
{
	public class PaidWitnessEvents
	{
		public string Unit {get;set;}
		/// <summary>
		///  witness address
		/// </summary>
		public string Address {get;set;}
		/// <summary>
		///  NULL if expired
		/// </summary>
		public byte Delay {get;set;}
	}
}
