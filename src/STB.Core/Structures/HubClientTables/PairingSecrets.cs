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
	public class PairingSecrets
	{
		public string PairingSecret {get;set;}
		public byte? IsPermanent {get;set;} = 0;
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public DateTime? ExpiryDate {get;set;}
	}
}
