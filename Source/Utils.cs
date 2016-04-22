using System;
using System.IO;
using System.Diagnostics;

namespace ReadMIDI
{
    /// <summary>
    /// Provides various utilites.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Swaps the byte order of a <see cref="ushort"/> value.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> to swap the byte order of.</param>
        public static ushort SwapBytes(ushort value)
        {
            return (ushort)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        /// <summary>
        /// Swaps the byte order of a <see cref="uint"/> value.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to swap the byte order of.</param>
        public static uint SwapBytes(uint value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        /// <summary>
        /// Corrects a big-endian <see cref="uint"/> value for the current system.
        /// </summary>
        /// <param name="value">The big-endian <see cref="uint"/> value to correct the byte order of.</param>
        public static uint CorrectEndian(uint value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return SwapBytes(value);
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Corrects a big-endian <see cref="ushort"/> value for the current system.
        /// </summary>
        /// <param name="value">The big-endian <see cref="ushort"/> value to correct the byte order of.</param>
        public static ushort CorrectEndian(ushort value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return SwapBytes(value);
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns the next variable length integer in the <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="br">The <see cref="BinaryReader"/> to read the data from.</param>
        public static uint ReadVariableLengthUint(BinaryReader br)
        {
            uint value = 0;
            bool flag = true;
            while (flag)
            {
                byte next = br.ReadByte();
                flag = Convert.ToBoolean((next & 0x80) >> 7);
                value = (value << 7) + (uint)(next & 0x7F);
            }
            return value;
        }

        /// <summary>
        /// Outputs the specified message to the selected output source.
        /// </summary>
        /// <param name="text">The text to output.</param>
        public static void PrintDebug(string text)
        {
            switch (Settings.DebugMode)
            {
                case LibraryDebugMode.None:
                    break;
                case LibraryDebugMode.ToConsole:
                    Console.WriteLine(text);
                    break;
                case LibraryDebugMode.ToDebug:
                    Debug.WriteLine(text);
                    break;
                case LibraryDebugMode.ToFile:
                    StreamWriter sw = File.AppendText(Settings.DebugFilePath);
                    using (sw)
                    {
                        sw.WriteLine(text);
                    }
                    break;
            }
        }

    }
}
