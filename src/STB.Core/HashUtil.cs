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
        private static readonly string PI = "14159265358979323846264338327950288419716939937510";


        private static readonly char[] ArrRelativeOffsets = PI.ToCharArray();
        private static readonly List<int> ArrOffsets160 = CalcOffsets(160);
        private static readonly List<int> ArrOffsets288 = CalcOffsets(288);

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private static void CheckLength(int hashLength)
        {
            if (hashLength != 160 && hashLength != 288)
                throw new Exception("hashLength error");
        }

        private static List<int> CalcOffsets(int hashLength)
        {
            CheckLength(hashLength);
            var arrOffsets = new List<int>();
            var offset = 0;
            var index = 0;

            for (var i = 0; offset < hashLength; i++)
            {
                var relativeOffset = (int) ArrRelativeOffsets[i];
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
                throw new Exception("wrong number of checksum bits");

            return arrOffsets;
        }

        private static (string, string) SeparateIntoCleanDataAndChecksum(string bin)
        {
            var len = bin.Length;
            List<int> arrOffsets;
            if (len == 160)
                arrOffsets = ArrOffsets160;
            else if (len == 288)
                arrOffsets = ArrOffsets288;
            else
                throw new Exception("bad length=" + len + ", bin = " + bin);
            var arrFrags = new List<string>();
            var arrChecksumBits = new List<string>();
            var start = 0;
            foreach (var t in arrOffsets)
            {
                arrFrags.Add(bin.Substring(start, t));

                arrChecksumBits.Add(bin.Substring(t, 1)); //todo Substr
                start = t + 1;
            }

            // add last frag
            if (start < bin.Length)
                arrFrags.Add(bin.Substring(start));
            var binCleanData = string.Join("", arrFrags);
            var binChecksum = string.Join("", arrChecksumBits);
            return (binCleanData, binChecksum);
        }

        private string mixChecksumIntoCleanData(string binCleanData, string binChecksum)
        {
            if (binChecksum.Length != 32)
                throw new Exception("bad checksum length");
            var len = binCleanData.Length + binChecksum.Length;
            List<int> arrOffsets;
            if (len == 160)
                arrOffsets = ArrOffsets160;
            else if (len == 288)
                arrOffsets = ArrOffsets288;
            else
                throw new Exception("bad length=" + len + ", clean data = " + binCleanData + ", checksum = " +
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

        private string buffer2bin(byte[] buf)
        {
            var bytes = new List<string>();
            foreach (var number in buf)
            {
                var bin = BinaryUtil.IntToBin(number);
                bytes.Add(bin.PadLeft(8, '0'));
            }

            return string.Join("", bytes);
        }

        private byte[] bin2buffer(string bin)
        {
            var len = bin.Length / 8;
            var buf = new byte[len];
            for (var i = 0; i < len; i++)
                buf[i] = (byte) BinaryUtil.BinToInt(bin.Substring(i * 8, 8));
            return buf;
        }

        private byte[] getChecksum(byte[] cleanData)
        {
            byte[] fullChecksum;
            using (var sha1 = SHA256.Create())
            {
                fullChecksum = sha1.ComputeHash(cleanData);
            }

            var checksum = new[] {fullChecksum[5], fullChecksum[13], fullChecksum[21], fullChecksum[29]};
            return checksum;
        }

        private string GetChash(string data, int chashLength)
        {
            CheckLength(chashLength);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var hash = createHash(chashLength == 160 ? "ripemd160" : "sha256", dataBytes);
            //console.log("hash", hash);
            var truncatedHash = chashLength == 160 ? hash.Slice(4) : hash; // drop first 4 bytes if 160
            //console.log("clean data", truncated_hash);
            var checksum = getChecksum(truncatedHash);
            //console.log("checksum", checksum);
            //console.log("checksum", buffer2bin(checksum));

            var binCleanData = buffer2bin(truncatedHash);
            var binChecksum = buffer2bin(checksum);
            var binChash = mixChecksumIntoCleanData(binCleanData, binChecksum);
            //console.log(binCleanData.length, binChecksum.length, binChash.length);
            var chash = bin2buffer(binChash);
            //console.log("chash     ", chash);
            var encoded = chashLength == 160 ? Base32.Encode(chash) : Convert.ToBase64String(chash);
            //console.log(encoded);

            return encoded;
        }

        public string getChash160(string data)
        {
            return GetChash(data, 160);
        }

        public string getChash288(string data)
        {
            return GetChash(data, 288);
        }

        public bool isChashValid(string encoded)
        {
            var encodedLen = encoded.Length;
            if (encodedLen != 32 && encodedLen != 48) // 160/5 = 32, 288/6 = 48
                throw new Exception("wrong encoded length: " + encodedLen);
            try
            {
                var chash = encodedLen == 32 ? Base32.Decode(encoded) : Convert.FromBase64String(encoded);

                var binChash = buffer2bin(chash);
                var separated = SeparateIntoCleanDataAndChecksum(binChash);
                var cleanData = bin2buffer(separated.Item1);
                var checksum = bin2buffer(separated.Item2);
                return checksum.Equals(getChecksum(cleanData));
            }
            catch
            {
                return false;
            }
        }

        private byte[] createHash(string hashAlgorithm, byte[] data)
        {
            switch (hashAlgorithm)
            {
                case "sha256":
                    using (var sha1 = SHA256.Create())
                    {
                        return sha1.ComputeHash(data);
                    }
                case "ripemd160":
                    using (var ripemd160 = RIPEMD160.Create())
                    {
                        return ripemd160.ComputeHash(data);
                    }
            }

            return null;
        }
    }
}