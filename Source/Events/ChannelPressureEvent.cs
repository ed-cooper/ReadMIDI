namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MidiEventType.ChannelPressure"/> event.
    /// </summary>
    public class ChannelPressureEvent : MidiEvent
    {
        #region Properties
        private byte pressure;

        /// <summary>
        /// Gets the pressure.
        /// </summary>
        public byte Pressure
        {
            get { return pressure; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="ChannelPressureEvent"/> class using the specified patch.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        internal ChannelPressureEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, byte pressure)
        {
            Init(channel, track, deltaTime, absoluteTime, MidiEventType.ChannelPressure);
            this.pressure = pressure;
        }
        #endregion
    }
}
