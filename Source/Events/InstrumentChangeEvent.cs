namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MidiEventType.InstrumentChange"/> event.
    /// </summary>
    public class InstrumentChangeEvent : MidiEvent
    {
        #region Properties
        private byte patch;

        /// <summary>
        /// Gets the new patch (instrument).
        /// </summary>
        public byte Patch
        {
            get { return patch; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="InstrumentChangeEvent"/> class using the specified patch.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="patch">The new patch (instrument).</param>
        internal InstrumentChangeEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, byte patch)
        {
            Init(channel, track, deltaTime, absoluteTime, MidiEventType.InstrumentChange);
            this.patch = patch;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Returns the display name of the instrument. Shorthand for <see cref="DisplayServices.InstrumentNames"/>.
        /// </summary>
        /// <returns>The display name of the instrument.</returns>
        /// <seealso cref="DisplayServices.InstrumentNames"/>
        public string GetInstrumentName()
        {
            return DisplayServices.InstrumentNames[patch];
        }
        #endregion
    }
}
