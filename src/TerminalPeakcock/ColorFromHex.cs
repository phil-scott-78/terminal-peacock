using System;
using JetBrains.Annotations;
using SixLabors.ImageSharp;

namespace TerminalPeakcock
{
    [UsedImplicitly]
    internal class ColorFromHex
    {
        public Color ParsedColor { get; }

        public ColorFromHex(string hex)
        {
            if (!Color.TryParseHex(hex, out var result))
            {
                throw new Exception($"Invalid hex value for output color - {hex}");
            }
            ParsedColor = result;
        }
    }
}