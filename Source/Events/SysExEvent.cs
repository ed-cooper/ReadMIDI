namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.SysEx"/> event.
    /// </summary>
    public class SysExEvent : MetaEvent
    {
        #region Properties
        private byte[] data;

        /// <summary>
        /// Gets the data of the system exclusive event.
        /// </summary>
        public byte[] Data
        {
            get { return data; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="SysExEvent"/> class using the specified data.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="data">The data of the event.</param>
        internal SysExEvent(uint track, uint deltaTime, uint absoluteTime, byte[] data)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.SysEx);
            this.data = data;
        }
        #endregion
    }
}
