namespace ReadMIDI
{
    /// <summary>
    /// Enumeration of various debug options.
    /// </summary>
    public enum LibraryDebugMode
    {
        /// <summary>
        /// Indicates that no debug text should be outputted.
        /// </summary>
        None,
        /// <summary>
        /// Indicates that debug text should be outputted to the console.
        /// </summary>
        ToConsole,
        /// <summary>
        /// Indicates that debug text should be outputted to the debug window.
        /// </summary>
        ToDebug,
        /// <summary>
        /// Indicates that debug text should be outputted to a file.
        /// </summary>
        ToFile
    }
}
