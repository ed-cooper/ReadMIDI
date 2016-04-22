namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.TextEvent"/> event.
    /// </summary>
    public class TextEvent : MetaEvent
    {
        #region Properties
        private string text;

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text
        {
            get { return text; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="TextEvent"/> class using the specified text.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="text">The text.</param>
        internal TextEvent(uint track, uint deltaTime, uint absoluteTime, string text)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.TextEvent);
            this.text = text;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TextEvent"/> class using the specified text and type.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="text">The text.</param>
        /// <param name="type">The type of the event.</param>
        internal TextEvent(uint track, uint deltaTime, uint absoluteTime, string text, MetaEventType type)
        {
            Init(track, deltaTime, absoluteTime, type);
            this.text = text;
        }
        #endregion
    }
}
