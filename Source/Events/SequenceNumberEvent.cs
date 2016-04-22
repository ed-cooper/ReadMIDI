namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.SequenceNumber"/> event.
    /// </summary>
    public class SequenceNumberEvent : MetaEvent
    {
        #region Properties
        private ushort sequenceNumber;

        /// <summary>
        /// Gets the sequence number.
        /// </summary>
        public ushort SequenceNumber
        {
            get { return sequenceNumber; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="SequenceNumberEvent"/> class using the specified sequence number.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        internal SequenceNumberEvent(uint track, uint deltaTime, uint absoluteTime, ushort sequenceNumber)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.SequenceNumber);
            this.sequenceNumber = sequenceNumber;
        }
        #endregion
    }
}
