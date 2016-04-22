namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.MidiChannelPrefix"/> event.
    /// </summary>
    public class MidiChannelPrefixEvent : MetaEvent
    {
        #region Properties
        private byte channel;

        /// <summary>
        /// Gets the channel.
        /// </summary>
        public byte Channel
        {
            get { return channel; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="MidiChannelPrefixEvent"/> class using the specified sequence number.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="channel">The channel.</param>
        internal MidiChannelPrefixEvent(uint track, uint deltaTime, uint absoluteTime, byte channel)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.MidiChannelPrefix);
            this.channel = channel;
        }
        #endregion
    }
}
