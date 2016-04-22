namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MidiEventType.PolyphonicKeyPressure"/> event.
    /// </summary>
    public class PolyphonicKeyPressureEvent : NoteEvent
    {
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="PolyphonicKeyPressureEvent"/> class using the specified note number and velocity.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="noteNumber">The number of the note.</param>
        /// <param name="velocity">The velocity of the note.</param>
        internal PolyphonicKeyPressureEvent(byte channel, uint track, uint deltaTime, uint absoluteTime, byte noteNumber, byte velocity)
        {
            Init(channel, track, deltaTime, absoluteTime, MidiEventType.PolyphonicKeyPressure);
        }
        #endregion
    }
}
