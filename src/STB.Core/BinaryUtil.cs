/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace STB.Core
{
    public class BinaryUtil
    {
        private const string BinConst = "01";

        public static string IntToBin(int number)
        {
            var stack = new Stack<char>();
            while (number != 0)
            {
                stack.Push(BinConst[number % 2]);
                number >>= 1;
            }

            return string.Join("", stack);
        }

        public static int BinToInt(string bin)
        {
            var result = 0;
            var f = 1;
            for (var i = bin.Length - 1; i >= 0; i--)
            {
                var x = bin[i];
                var num = x - '0';
                if (num != 0 && num != 1) throw new Exception($"{nameof(bin)} is not a bin number:{bin},current:{x}");
                result += num * f;
                f *= 2;
            }

            return result;
        }
    }
}