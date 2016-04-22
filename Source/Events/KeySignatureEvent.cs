using System;

namespace ReadMIDI.Events
{
    /// <summary>
    /// Represents a <see cref="MetaEventType.KeySignature"/> event.
    /// </summary>
    public class KeySignatureEvent : MetaEvent
    {
        #region Properties
        private sbyte key;
        private bool minor;

        /// <summary>
        /// Gets the id for the key. A positive number indicates the number of sharps, a negative number indicates the number of flats. See <see cref="MajorKeys"/> and <see cref="MinorKeys"/>.
        /// </summary>
        public sbyte Key
        {
            get { return key; }
        }

        /// <summary>
        /// Gets the amount of flats in the key.
        /// </summary>
        public byte Flats
        {
            get
            {
                return (byte)Math.Max((sbyte)0, key);
            }
        }

        /// <summary>
        /// Gets the number of sharps in the key.
        /// </summary>
        public byte Sharps
        {
            get
            {
                return (byte)(Math.Min((sbyte)0, key) * -1);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the key is minor (true) or major (false)
        /// </summary>
        public bool Minor
        {
            get { return minor; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="KeySignatureEvent"/> class using the specified sequence number.
        /// </summary>
        /// <param name="track">The track of the event.</param>
        /// <param name="deltaTime">The delta time of the event.</param>
        /// <param name="absoluteTime">The absolute time of the event.</param>
        /// <param name="key">The key signature id.</param>
        /// <param name="minor">Whether the key is minor or major.</param>
        internal KeySignatureEvent(uint track, uint deltaTime, uint absoluteTime, sbyte key, bool minor)
        {
            Init(track, deltaTime, absoluteTime, MetaEventType.KeySignature);
            this.key = key;
            this.minor = minor;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Returns the display name for this key. Shorthand for <see cref="DisplayServices.GetKeySignatureName(sbyte, bool)"/>.
        /// </summary>
        /// <returns>The display name for this key.</returns>
        public string GetDisplayName()
        {
            return DisplayServices.GetKeySignatureName(key, minor);
        }
        #endregion
    }
}
