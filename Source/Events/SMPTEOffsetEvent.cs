namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.SMPTEOffset"/> event.
    /// </summary>
    public class SMPTEOffsetEvent : MetaEvent
    {
        #region Properties
        private float frameRate;
        private byte hour;
        private byte minute;
        private byte second;
        private byte frame;
        private byte subFrame;

        /// <summary>
        /// Gets the frame rate.
        /// </summary>
        public float FrameRate
        {
            get { return frameRate; }
        }

        /// <summary>
        /// Gets the hour.
        /// </summary>
        public byte Hour
        {
            get { return hour; }
        }

        /// <summary>
        /// Gets the minute.
        /// </summary>
        public byte Minute
        {
            get { return minute; }
        }

        /// <summary>
        /// Gets the second.
        /// </summary>
        public byte Second
        {
            get { return second; }
        }

        /// <summary>
        /// Gets the frame.
        /// </summary>
        public byte Frame
        {
            get { return frame; }
        }

        /// <summary>
        /// Gets the sub-frame.
        /// </summary>
        public byte SubFrame
        {
            get { return subFrame; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="SMPTEOffsetEvent"/> class using the specified SMPTE values.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="frameRate">The frame rate.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="subFrame">The sub-frame.</param>
        internal SMPTEOffsetEvent(uint track, uint deltaTime, uint absoluteTime, float frameRate, byte hour, byte minute, byte second, byte frame, byte subFrame)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.SMPTEOffset);
            this.frameRate = frameRate;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.frame = frame;
            this.subFrame = subFrame;
        }
        #endregion
    }
}
