/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System.Security.Cryptography;
using System.Text;

namespace STB.Core
{
    public static class SHA1Extension
    {
        public static string ToSHA1(this string dataStr)
        {
            if (dataStr == null)
                return null;

            using (var sha1 = SHA1.Create())
            {
                var dataBytes = Encoding.UTF8.GetBytes(dataStr);
                var hashCode = sha1.ComputeHash(dataBytes).ToHexStr();
                return hashCode;
            }
        }
    }
}