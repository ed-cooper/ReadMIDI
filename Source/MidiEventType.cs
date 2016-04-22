namespace ReadMIDI
{
    /// <summary>
    /// Enumeration of all the various midi event types.
    /// </summary>
    public enum MidiEventType : byte
    {
        /// <summary>
        /// Indicates that a note has been released. See <see cref="Events.NoteOffEvent"/>.
        /// </summary>
        NoteOff = 0x8,
        /// <summary>
        /// Indicates that a note has been pressed. See <see cref="Events.NoteOnEvent"/>.
        /// </summary>
        NoteOn = 0x9,
        /// <summary>
        /// (Aftertouch) Indicates that a note has been pressed after it has 'bottomed out'. See <see cref="Events.PolyphonicKeyPressureEvent"/>.
        /// </summary>
        PolyphonicKeyPressure = 0xA,
        /// <summary>
        /// Indicates that a controller value has changed. See <see cref="Events.ControlChangeEvent"/>.
        /// </summary>
        ControlChange = 0xB,
        /// <summary>
        /// Indicates that the channel patch (instrument) has changed. <see cref="Events.InstrumentChangeEvent"/>.
        /// </summary>
        InstrumentChange = 0xC,
        /// <summary>
        /// (Aftertouch) Indicates that a note has been pressed after it has 'bottomed out'. Unlike <see cref="PolyphonicKeyPressure"/>, this message signals the greatest key pressure. See <see cref="Events.ChannelPressureEvent"/>.
        /// </summary>
        /// <remarks>Unlike <see cref="PolyphonicKeyPressure"/>, this message signals the greatest key pressure.</remarks>
        ChannelPressure = 0xD,
        /// <summary>
        /// Indicates a change in the pitch wheel. See <see cref="Events.PitchWheelChangeEvent"/>.
        /// </summary>
        PitchWeelChange = 0xE
    }
}
