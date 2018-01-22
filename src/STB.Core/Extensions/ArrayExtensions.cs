/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/
namespace STB.Core
{
    public static class ArrayExtensions
    {
        public static T[] Slice<T>(this T[] x, int num)
        {
            var bytes = new T[x.Length - num];
            for (int i = 0; i < x.Length - num; i++)
            {
                bytes[i] = x[num + i];
            }

            return bytes;
        }

    }
}