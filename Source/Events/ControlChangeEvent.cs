namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MidiEventType.ControlChange"/> event.
    /// </summary>
    public class ControlChangeEvent : MidiEvent
    {
        #region Properties
        private byte control;
        private byte value;

        /// <summary>
        /// Gets the control that was changed.
        /// </summary>
        public byte Control
        {
            get { return control; }
        }

        /// <summary>
        /// Gets the new value of the control.
        /// </summary>
        public byte Value
        {
            get { return value; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="ControlChangeEvent"/> class using the specified control and value.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="control">The control that was changed.</param>
        /// <param name="value">The new value of the control.</param>
        internal ControlChangeEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, byte control, byte value)
        {
            Init(channel, track, deltaTime, absoluteTime, MidiEventType.ControlChange);
            this.control = control;
            this.value = value;
        }
        #endregion
    }
}
