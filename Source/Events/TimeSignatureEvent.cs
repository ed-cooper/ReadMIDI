namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.TimeSignature"/> event.
    /// </summary>
    public class TimeSignatureEvent : MetaEvent
    {
        #region Properties
        private byte numerator;
        private byte denominator;
        private byte ticksPerQuarterNote;
        private byte ticksPerQuarter32Note;

        /// <summary>
        /// Gets the numerator of the time signature. Equal to number of beats in a bar.
        /// </summary>
        public byte Numerator
        {
            get { return numerator; }
        }

        /// <summary>
        /// Gets the denominator of the time signature. Equal to the number of quarter notes in a beat.
        /// </summary>
        public byte Denominator
        {
            get { return denominator; }
        }

        /// <summary>
        /// Gets the amount of ticks per quarter note.
        /// </summary>
        public byte TicksPerQuarterNote
        {
            get { return TicksPerQuarterNote; }
        }

        /// <summary>
        /// Gets the amount of 32nd notes per midi quarter note.
        /// </summary>
        public byte TicksPerQuarter32Note
        {
            get { return ticksPerQuarter32Note; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="TimeSignatureEvent"/> class using the specified sequence number.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="numerator">The numerator of the time signature.</param>
        internal TimeSignatureEvent(uint track, uint deltaTime, uint absoluteTime, byte numerator, byte denominator, byte ticksPerQuarterNote, byte ticksPerQuarter32Note)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.TimeSignature);
            this.numerator = numerator;
            this.denominator = denominator;
            this.ticksPerQuarterNote = ticksPerQuarterNote;
            this.ticksPerQuarter32Note = ticksPerQuarter32Note;
        }
        #endregion
    }
}
