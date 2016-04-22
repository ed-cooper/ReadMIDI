namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.SetTempo"/> event.
    /// </summary>
    public class SetTempoEvent : MetaEvent
    {
        #region Properties
        private uint tempo;

        /// <summary>
        /// Gets the tempo. To get the tempo in BPM, divide 60,000,000 by this value.
        /// </summary>
        public uint Tempo
        {
            get { return tempo; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="SetTempoEvent"/> class using the specified sequence number.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="tempo">The tempo.</param>
        internal SetTempoEvent(uint track, uint deltaTime, uint absoluteTime, uint tempo)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.SetTempo);
            this.tempo = tempo;
        }
        #endregion
    }
}
