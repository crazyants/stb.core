/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System.Text;

namespace STB.Core
{
    public static class StringToBytesExtension
    {
        internal static byte[] ToAsciiBytes(this string strKey)
        {
            return Encoding.ASCII.GetBytes(strKey);
        }

        internal static byte[] ToUtf8Bytes(this string strKey)
        {
            return Encoding.UTF8.GetBytes(strKey);
        }
    }
}