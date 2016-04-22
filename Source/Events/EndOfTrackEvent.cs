namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.EndOfTrack"/> event.
    /// </summary>
    public class EndOfTrackEvent : MetaEvent
    {
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="EndOfTrackEvent"/> class.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        internal EndOfTrackEvent(uint track, uint deltaTime, uint absoluteTime)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.EndOfTrack);
        }
        #endregion
    }
}
