namespace ReadMIDI
{
    /// <summary>
    /// Enumeration of all the various meta event types.
    /// </summary>
    public enum MetaEventType : byte
    {
        /// <summary>
        /// Indicates an event containing the number of a sequence. See <see cref="Events.SequenceNumberEvent"/>.
        /// </summary>
        SequenceNumber = 0x00,
        /// <summary>
        /// Indicates an event containing a description of anything. See <see cref="Events.TextEvent"/>.
        /// </summary>
        TextEvent = 0x01,
        /// <summary>
        /// Indicates an event containing a copyright notice. See <see cref="Events.TextEvent"/>.
        /// </summary>
        CopyrightNotice = 0x02,
        /// <summary>
        /// Indicates an event containing either the name of the sequence or track. See <see cref="Events.TextEvent"/>.
        /// </summary>
        SequenceName = 0x03,
        /// <summary>
        /// Indicates an event containing the instrument to be used in that track. See <see cref="Events.TextEvent"/>.
        /// </summary>
        InstrumentName = 0x04,
        /// <summary>
        /// Indicates an event containing a lyric to be sung. See <see cref="Events.TextEvent"/>.
        /// </summary>
        LyricText = 0x05,
        /// <summary>
        /// Indicates an event containing a marker in the sequence - eg. "First Verse" See <see cref="Events.TextEvent"/>.
        /// </summary>
        MarkerText = 0x06,
        /// <summary>
        /// Indicates an event containing a description of something happening on a film or performance at that point in the track. See <see cref="Events.TextEvent"/>.
        /// </summary>
        CuePoint = 0x07,
        /// <summary>
        /// Indicates an event containing a MIDI channel to associate with all following events until the next normal MIDI event. See <see cref="Events.MidiChannelPrefixEvent"/>.
        /// </summary>
        MidiChannelPrefix = 0x20,
        /// <summary>
        /// Indicates an event marking the end of a track. See <see cref="Events.EndOfTrackEvent"/>.
        /// </summary>
        EndOfTrack = 0x2F,
        /// <summary>
        /// Indicates an event marking a tempo change. See <see cref="Events.SetTempoEvent"/>.
        /// </summary>
        SetTempo = 0x51,
        /// <summary>
        /// Indicates an event designating the SMPTEtime at which a track is supposed to start. <see cref="Events.SMPTEOffsetEvent"/>.
        /// </summary>
        SMPTEOffset = 0x54,
        /// <summary>
        /// Indicates an event marking a change in time signature. See <see cref="Events.TimeSignatureEvent"/>.
        /// </summary>
        TimeSignature = 0x58,
        /// <summary>
        /// Indicates an event marking a change in key signature. See <see cref="Events.KeySignatureEvent"/>.
        /// </summary>
        KeySignature = 0x59,
        /// <summary>
        /// Indicates a system exclusive event. See <see cref="Events.SysExEvent"/>.
        /// </summary>
        SysEx = 0xF0
    }
}
