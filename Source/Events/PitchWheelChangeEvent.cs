namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MidiEventType.PitchWeelChange"/> event.
    /// </summary>
    public class PitchWheelChangeEvent : MidiEvent
    {
        #region Properties
        private ushort pitch;

        /// <summary>
        /// Gets the new pitch.
        /// </summary>
        public ushort Pitch
        {
            get { return pitch; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="PitchWheelChangeEvent"/> class using the specified pitch.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="pitch">The new pitch.</param>
        internal PitchWheelChangeEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, ushort pitch)
        {
            Init(channel, track, deltaTime, absoluteTime, MidiEventType.PitchWeelChange);
            this.pitch = pitch;
        }
        #endregion
    }
}
