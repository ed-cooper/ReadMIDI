namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MidiEventType.NoteOn"/> event.
    /// </summary>
    public class NoteOnEvent : NoteEvent
    {
        #region Properties
        private NoteOffEvent offEvent;

        /// <summary>
        /// Gets the <see cref="NoteOffEvent"/> associated with this <see cref="NoteOnEvent"/>.
        /// </summary>
        public NoteOffEvent OffEvent
        {
            get { return OffEvent; }
        }

        /// <summary>
        /// Gets the duration of this note. Note: duration 0 indicates duration unknown.
        /// </summary>
        public uint Duration
        {
            get { return (offEvent != null) ? OffEvent.AbsoluteTime - AbsoluteTime : 0; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="NoteOnEvent"/> class using the specified note number and velocity.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="noteNumber">The number of the note.</param>
        /// <param name="velocity">The velocity of the note.</param>
        internal NoteOnEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, byte noteNumber, byte velocity)
        {
            Init(channel, track, deltaTime, absoluteTime, MidiEventType.NoteOn, noteNumber, velocity);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="NoteOnEvent"/> class using the specified <see cref="NoteOffEvent"/>, note number and velocity.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="noteNumber">The number of the note.</param>
        /// <param name="velocity">The velocity of the note.</param>
        /// <param name="offEvent">The <see cref="NoteOffEvent"/> associated with this event.</param>
        internal NoteOnEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, byte noteNumber, byte velocity, NoteOffEvent offEvent) : this(channel, track, deltaTime, absoluteTime, noteNumber, velocity)
        {
            this.offEvent = offEvent;
        }
        #endregion
    }
}
