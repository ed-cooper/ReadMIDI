namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a MIDI event in the MIDI track.
    /// </summary>
    public abstract class MidiEvent : TrackEvent
    {
        #region Properties
        private MidiEventType type;
        private byte channel;

        /// <summary>
        /// Gets the <see cref="MidiEventType"/> of this <see cref="MidiEvent"/>.
        /// </summary>
        public MidiEventType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Gets the channel of this event.
        /// </summary>
        public int Channel
        {
            get { return channel; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Initialises the <see cref="MidiEvent"/>.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="type">The type of the event.</param>
        protected void Init(byte channel, uint track, uint deltaTime, uint absoluteTime, MidiEventType type)
        {
            Init(track, deltaTime, absoluteTime);
            this.channel = channel;
            this.type = type;
        }
        #endregion
    }
}
