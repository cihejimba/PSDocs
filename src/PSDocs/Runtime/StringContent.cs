﻿
using System;
using System.Collections.Generic;

namespace PSDocs.Runtime
{
    internal sealed class StringContent
    {
        private readonly string _Input;

        public StringContent(string input)
        {
            _Input = input;
        }

        internal string[] ReadLines()
        {
            if (string.IsNullOrEmpty(_Input))
                return Array.Empty<string>();

            var lines = new List<string>();
            var stream = new StringStream(_Input);
            stream.SkipLineEnding();
            var indent = stream.GetIndent();
            
            while (!stream.EOF)
            {
                stream.SkipIndent(indent);
                if (stream.UntilLineEnding(out string text))
                    lines.Add(text);

                stream.SkipLineEnding();
            }
            return lines.ToArray();
        }
    }
}
