namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a MIDI note event.
    /// </summary>
    public abstract class NoteEvent : MidiEvent
    {
        #region Properties
        private byte noteNumber;
        private byte velocity;

        /// <summary>
        /// Gets the number of the note.
        /// </summary>
        public byte NoteNumber
        {
            get { return noteNumber; }
        }

        /// <summary>
        /// Gets the velocity (loudness) of the note.
        /// </summary>
        public byte Velocity
        {
            get { return velocity; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Initialises the <see cref="NoteEvent"/>.
        /// </summary>
        /// <param name="channel">The channel of the event.</param>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="type">The type of the event.</param>
        /// <param name="noteNumber">The number of the note.</param>
        /// <param name="velocity">The velocity of the note.</param>
        protected void Init(byte channel, uint track, uint deltaTime, uint absoluteTime, MidiEventType type, byte noteNumber, byte velocity)
        {
            Init(channel, track, deltaTime, absoluteTime, type);
            this.noteNumber = noteNumber;
            this.velocity = velocity;
        }

        /// <summary>
        /// Returns the display name of the note. Shorthand for <see cref="DisplayServices.GetNoteName(byte, bool)"/>.
        /// </summary>
        /// <param name="sharp">Indicates whether to display the note as a sharp or flat if necessary.</param>
        /// <returns>The display name of the note.</returns>
        public string GetNoteName(bool sharp = true)
        {
            return DisplayServices.GetNoteName(noteNumber, sharp);
        }
        #endregion
    }
}
