namespace ReadMIDI
{
    public enum FileFormat : ushort
    {
        /// <summary>
        /// Indicates a song with only one track.
        /// </summary>
        SingleTrackFile = 0,
        /// <summary>
        /// Indicates a song with multiple tracks.
        /// </summary>
        MultipleTrackFile = 1,
        /// <summary>
        /// Indicates a series of single track files.
        /// </summary>
        MultipleSongFile = 2
    }
}
