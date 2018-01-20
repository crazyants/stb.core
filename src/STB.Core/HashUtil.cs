/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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

        static (string, string) separateIntoCleanDataAndChecksum(string bin)
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

                arrChecksumBits.Add(bin.Substring(arrOffsets[i], 1)); //todo Substr
                start = arrOffsets[i] + 1;
            }

            // add last frag
            if (start < bin.Length)
                arrFrags.Add(bin.Substring(start));
            var binCleanData = string.Join("", arrFrags);
            var binChecksum = string.Join("", arrChecksumBits);
            return (binCleanData, binChecksum);
        }

        string mixChecksumIntoCleanData(string binCleanData, string binChecksum)
        {
            if (binChecksum.Length != 32)
                throw new System.Exception("bad checksum length");
            var len = binCleanData.Length + binChecksum.Length;
            List<int> arrOffsets;
            if (len == 160)
                arrOffsets = arrOffsets160;
            else if (len == 288)
                arrOffsets = arrOffsets288;
            else
                throw new System.Exception("bad length=" + len + ", clean data = " + binCleanData + ", checksum = " +
                                           binChecksum);
            var arrFrags = new List<string>();
            var arrChecksumBits = binChecksum.ToCharArray();
            var start = 0;
            for (var i = 0; i < arrOffsets.Count; i++)
            {
                var end = arrOffsets[i] - i;
                arrFrags.Add(binCleanData.Substring(start, end));
                arrFrags.Add(arrChecksumBits[i].ToString());
                start = end;
            }

            // add last frag
            if (start < binCleanData.Length)
                arrFrags.Add(binCleanData.Substring(start));
            return string.Join("", arrFrags);
        }

        string buffer2bin(byte[] buf)
        {
            var bytes = new List<string>();
            foreach (var number in buf)
            {
                var bin = IntToBin(number);
                bytes.Add(bin.PadLeft(8, '0'));
            }

            return string.Join("", bytes);
        }

        byte[] bin2buffer(string bin)
        {
            var len = bin.Length / 8;
            var buf = new byte[len];
            for (var i = 0; i < len; i++)
                buf[i] = (byte) BinToInt(bin.Substring(i * 8, 8));
            return buf;
        }

        byte[] getChecksum(byte[] cleanData)
        {
            byte[] fullChecksum;
            using (var sha1 = SHA256.Create())
            {
                fullChecksum = sha1.ComputeHash(cleanData);
            }

            var checksum = new[] {fullChecksum[5], fullChecksum[13], fullChecksum[21], fullChecksum[29]};
            return checksum;
        }

        string getChash(string data, int chash_length)
        {
            CheckLength(chash_length);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var hash = createHash((chash_length == 160) ? "ripemd160" : "sha256", dataBytes);
            //console.log("hash", hash);
            var truncated_hash = (chash_length == 160) ? hash.Slice(4) : hash; // drop first 4 bytes if 160
            //console.log("clean data", truncated_hash);
            var checksum = getChecksum(truncated_hash);
            //console.log("checksum", checksum);
            //console.log("checksum", buffer2bin(checksum));

            var binCleanData = buffer2bin(truncated_hash);
            var binChecksum = buffer2bin(checksum);
            var binChash = mixChecksumIntoCleanData(binCleanData, binChecksum);
            //console.log(binCleanData.length, binChecksum.length, binChash.length);
            var chash = bin2buffer(binChash);
            //console.log("chash     ", chash);
            var encoded = (chash_length == 160) ? Base32.Encode(chash) : Convert.ToBase64String(chash);
            //console.log(encoded);

            return encoded;
        }

        public string getChash160(string data)
        {
            return getChash(data, 160);
        }

        public string getChash288(string data)
        {
            return getChash(data, 288);
        }

        public bool isChashValid(string encoded)
        {
            var encoded_len = encoded.Length;
            if (encoded_len != 32 && encoded_len != 48) // 160/5 = 32, 288/6 = 48
                throw new Exception("wrong encoded length: " + encoded_len);
            try
            {
                var chash = (encoded_len == 32) ? Base32.Decode(encoded) : Convert.FromBase64String(encoded);

                var binChash = buffer2bin(chash);
                var separated = separateIntoCleanDataAndChecksum(binChash);
                var clean_data = bin2buffer(separated.Item1);
                //console.log("clean data", clean_data);
                var checksum = bin2buffer(separated.Item2);
                //console.log(checksum);
                //console.log(getChecksum(clean_data));
                return checksum.Equals(getChecksum(clean_data));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        byte[] createHash(string hashAlgorithm, byte[] data)
        {
            if (hashAlgorithm == "sha256")
            {
                using (var sha1 = SHA256.Create())
                {
                    return sha1.ComputeHash(data);
                }
            }

            if (hashAlgorithm == "ripemd160")
            {
                using (var ripemd160 = RIPEMD160.Create())
                {
                    return ripemd160.ComputeHash(data);
                }
            }

            return null;
        }

        private const string binConst = "01";

        public static string IntToBin(int number)
        {

            Stack<char> stack = new Stack<char>();
            while (number != 0)
            {
                stack.Push(binConst[number % 2]);
                number >>= 1;
            }

            return string.Join("", stack);
        }

        public static int BinToInt(string bin)
        {
            int result = 0;
            int f = 1;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                char x = bin[i];
                var num = x - '0';
                if (num != 0 && num != 1) throw new Exception($"{nameof(bin)} is not a bin number:{bin},current:{x}");

                result += num * f;
                f *= 2;
            }

            return result;
        }



    }
}