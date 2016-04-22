namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a single event in a track chunk.
    /// </summary>
    public abstract class TrackEvent
    {
        #region Properties
        private uint deltaTime;
        private uint absoluteTime;
        private uint track;

        /// <summary>
        /// Gets the delta time of the <see cref="TrackEvent"/>. Measured in delta ticks per quarter note.
        /// </summary>
        public uint DeltaTime
        {
            get { return deltaTime; }
        }

        /// <summary>
        /// Gets the absolute time of the <see cref="TrackEvent"/>. Measured in delta ticks per quarter note.
        /// </summary>
        public uint AbsoluteTime
        {
            get { return absoluteTime; }
        }

        /// <summary>
        /// Gets the track of the <see cref="TrackEvent"/>.
        /// </summary>
        public uint Track
        {
            get { return track; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Initialises the <see cref="TrackEvent"/>.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        protected void Init(uint track, uint deltaTime, uint absoluteTime)
        {
            this.track = track;
            this.deltaTime = deltaTime;
            this.absoluteTime = absoluteTime;
        }
        #endregion
    }
}
