using ReadMIDI.Events;

namespace ReadMIDI
{
    /// <summary>
    /// Represents a track in a MIDI file.
    /// </summary>
    public class TrackChunk
    {
        #region Properties
        private MetaEvent[] metaEvents;
        private MidiEvent[] midiEvents;

        /// <summary>
        /// Gets the list of meta events in the track.
        /// </summary>
        public MetaEvent[] MetaEvents
        {
            get { return metaEvents; }
        }

        /// <summary>
        /// Gets the list of MIDI events in the track.
        /// </summary>
        public MidiEvent[] MidiEvents
        {
            get { return midiEvents; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="TrackChunk"/> using the specified meta and MIDI events.
        /// </summary>
        /// <param name="metaEvents">The list of meta events in the track.</param>
        /// <param name="midiEvents">The list of MIDI events in the track.</param>
        internal TrackChunk(MetaEvent[] metaEvents, MidiEvent[] midiEvents)
        {
            this.metaEvents = metaEvents;
            this.midiEvents = midiEvents;
        }
        #endregion
    }
}
