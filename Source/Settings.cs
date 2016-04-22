namespace ReadMIDI
{
    /// <summary>
    /// Provides various generic settings for the <see cref="ReadMIDI"/> library.
    /// </summary>
    public static class Settings
    {
        #region Fields
        /// <summary>
        /// The debug mode of the library.
        /// </summary>
        public static LibraryDebugMode DebugMode = LibraryDebugMode.None;

        /// <summary>
        /// The file path to save to when outputting debug text. Only used when <see cref="DebugMode"/> is set to <see cref="LibraryDebugMode.ToFile"/>.
        /// </summary>
        /// <remarks>Only used when <see cref="DebugMode"/> is set to <see cref="LibraryDebugMode.ToFile"/>.</remarks>
        public static string DebugFilePath = "";
        #endregion
    }
}
