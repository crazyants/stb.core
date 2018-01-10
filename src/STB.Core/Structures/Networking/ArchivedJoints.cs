/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;

namespace STB.Core.Structures.Networking
{
	public class ArchivedJoints
	{
		public string Unit {get;set;}
		public string Reason {get;set;}
		public string Json {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
	}
}
