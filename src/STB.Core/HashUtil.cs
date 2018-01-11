/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace STB.Core
{
    public class HashUtil
    {
        static string PI = "14159265358979323846264338327950288419716939937510";
        static string zeroString = "00000000";

        static char[] arrRelativeOffsets = PI.ToCharArray();
        static List<int> arrOffsets160 = CalcOffsets(160);
        static List<int> arrOffsets288 = CalcOffsets(288);

        static void CheckLength(int hashLength)
        {
            if (hashLength != 160 && hashLength != 288)
                throw new System.Exception("hashLength error");
        }

        static List<int> CalcOffsets(int hashLength)
        {
            CheckLength(hashLength);
            var arrOffsets = new List<int>();
            var offset = 0;
            var index = 0;

            for (var i = 0; offset < hashLength; i++)
            {
                var relativeOffset = (int) (arrRelativeOffsets[i]);
                if (relativeOffset == 0)
                    continue;
                offset += relativeOffset;
                if (hashLength == 288)
                    offset += 4;
                if (offset >= hashLength)
                    break;
                arrOffsets.Add(offset);
                index++;
            }

            if (index != 32)
                throw new System.Exception("wrong number of checksum bits");

            return arrOffsets;
        }
        static object separateIntoCleanDataAndChecksum(string bin)
        {
            var len = bin.Length;
            List<int> arrOffsets;
            if (len == 160)
                arrOffsets = arrOffsets160;
            else if (len == 288)
                arrOffsets = arrOffsets288;
            else
                throw new System.Exception("bad length=" + len + ", bin = " + bin);
            var arrFrags = new List<string>();
            var arrChecksumBits = new List<string>();
            var start = 0;
            for (var i = 0; i < arrOffsets.Count; i++)
            {
                arrFrags.Add(bin.Substring(start, arrOffsets[i]));
                
                arrChecksumBits.Add(bin.Substring(arrOffsets[i], 1));//Substr
                start = arrOffsets[i] + 1;
            }
            // add last frag
            if (start < bin.Length)
                arrFrags.Add(bin.Substring(start));
            var binCleanData = string.Join("",arrFrags);
            var binChecksum = string.Join("", arrChecksumBits);
            return new { clean_data= binCleanData, checksum= binChecksum};
        }
    }
}