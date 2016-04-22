namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a meta event in the MIDI track.
    /// </summary>
    public abstract class MetaEvent : TrackEvent
    {
        #region Properties
        private MetaEventType type;

        /// <summary>
        /// Gets the <see cref="MetaEventType"/> of this <see cref="MetaEvent"/>.
        /// </summary>
        public MetaEventType Type
        {
            get { return type; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Initialises the <see cref="MetaEvent"/> instance.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="type">The type of the event.</param>
        protected void Init(uint track, uint deltaTime, uint absoluteTime, MetaEventType type)
        {
            Init(track, deltaTime, absoluteTime);
            this.type = type;
        }
        #endregion
    }
}
