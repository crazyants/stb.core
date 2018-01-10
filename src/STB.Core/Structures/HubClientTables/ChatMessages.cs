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
	public class ChatMessages
	{
		public int? Id {get;set;}
		public string CorrespondentAddress {get;set;}
		public string Message {get;set;}
		public DateTime? CreationDate {get;set;} = DateTime.Now;
		public int? IsIncoming {get;set;}
		public string Type {get;set;} = "text";
	}
}
