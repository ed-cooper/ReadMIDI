using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ReadMIDI.Events;

namespace ReadMIDI
{
    /// <summary>
    /// Represents a loaded MIDI file.
    /// </summary>
    public class MidiFile
    {
        #region Properties
        private ushort deltaTicksPerQuarterNote;
        private ushort trackCount;
        private FileFormat fileFormat;
        private TrackChunk[] tracks;

        /// <summary>
        /// Gets the amount of delta ticks per quarter beat.
        /// </summary>
        public ushort DeltaTicksPerQuarterNote
        {
            get { return deltaTicksPerQuarterNote; }
        }

        /// <summary>
        /// Gets the amount of tracks in the MIDI file.
        /// </summary>
        public ushort TrackCount
        {
            get { return trackCount; }
        }

        /// <summary>
        /// Gets the <see cref="ReadMIDI.FileFormat"/> of this MIDI file.
        /// </summary>
        public FileFormat FileFormat
        {
            get { return fileFormat; }
        }

        /// <summary>
        /// Gets the list of tracks and their data in the MIDI file.
        /// </summary>
        public TrackChunk[] Tracks
        {
            get { return tracks; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Opens a new <see cref="MidiFile"/> from the specified path.
        /// </summary>
        /// <param name="path">The path to load the midi file from.</param>
        public MidiFile(string path)
        {
            Utils.PrintDebug("Loading file: " + path + "\r\n-----------------");
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));
            using (br)
            {
                // Check valid MIDI file
                if (Encoding.ASCII.GetString(br.ReadBytes(4)) == "MThd")
                {
                    if (Utils.CorrectEndian(br.ReadUInt32()) == 6)
                    {
                        // Valid MIDI file

                        // Get MIDI internal file format
                        fileFormat = (FileFormat)Utils.CorrectEndian(br.ReadUInt16());
                        Utils.PrintDebug("HEAD: FileFormat " + fileFormat.ToString());

                        // Get track count
                        trackCount = Utils.CorrectEndian(br.ReadUInt16());
                        Utils.PrintDebug("HEAD: Tracks " + trackCount);

                        // Get MIDI time conversion
                        deltaTicksPerQuarterNote = Utils.CorrectEndian(br.ReadUInt16());
                        Utils.PrintDebug("HEAD: DeltaTicksPerQuarterNote " + deltaTicksPerQuarterNote);

                        // Current track
                        uint track = 0;
                        // Tracks list
                        List<TrackChunk> tracks = new List<TrackChunk>();

                        // Repeat for every track chunk
                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            Utils.PrintDebug("-----------------\r\nTRACK: " + br.BaseStream.Position);
                            if (Encoding.ASCII.GetString(br.ReadBytes(4)) == "MTrk")
                            {
                                // Valid track chunk

                                // Create new track data
                                List<MetaEvent> metaEvents = new List<MetaEvent>();
                                List<MidiEvent> midiEvents = new List<MidiEvent>();

                                // Absolute time
                                uint absTime = 0;

                                // End position in bytes of chunk
                                long targetPosition = br.BaseStream.Position + 4 + Utils.CorrectEndian(br.ReadUInt32());
                                // Used for continous status between MIDI events
                                byte statusOld = 0x00;

                                // Repeat for every event
                                while (br.BaseStream.Position < targetPosition)
                                {
                                    // Get delta time (time since last MIDI event)
                                    uint deltaTime = Utils.ReadVariableLengthUint(br);
                                    // Get first byte of event (used to identify event type)
                                    byte eventHeader = br.ReadByte();

                                    // Update absolute time
                                    absTime += deltaTime;

                                    switch (eventHeader)
                                    {
                                        case 0xFF: // Meta Event
                                            // Get meta event type
                                            MetaEventType metaCode = (MetaEventType)br.ReadByte();
                                            // Get length in bytes of event data
                                            int lenData1 = (int)Utils.ReadVariableLengthUint(br);

                                            switch (metaCode)
                                            {
                                                case MetaEventType.SequenceNumber:
                                                    if (lenData1 == 2)
                                                    {
                                                        ushort sequenceNumber = Utils.CorrectEndian(br.ReadUInt16());
                                                        metaEvents.Add(new SequenceNumberEvent(track, deltaTime, absTime, sequenceNumber));
                                                        Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), sequenceNumber, br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid SequenceNumber meta event");
                                                        throw new FormatException("Could not read MIDI file - invalid SequenceNumber meta event");
                                                    }
                                                    break;
                                                case MetaEventType.TextEvent:
                                                    string text = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, text));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), text, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.CopyrightNotice:
                                                    string copyright = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, copyright, MetaEventType.CopyrightNotice));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), copyright, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.SequenceName:
                                                    string sequenceName = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, sequenceName, MetaEventType.SequenceName));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), sequenceName, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.InstrumentName:
                                                    string instrumentName = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, instrumentName, MetaEventType.InstrumentName));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), instrumentName, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.LyricText:
                                                    string lyric = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, lyric, MetaEventType.LyricText));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), lyric, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.MarkerText:
                                                    string marker = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, marker, MetaEventType.MarkerText));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), marker, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.CuePoint:
                                                    string cuePoint = Encoding.ASCII.GetString(br.ReadBytes(lenData1));
                                                    metaEvents.Add(new TextEvent(track, deltaTime, absTime, cuePoint, MetaEventType.CuePoint));
                                                    Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), cuePoint, br.BaseStream.Position));
                                                    break;
                                                case MetaEventType.MidiChannelPrefix:
                                                    if (lenData1 == 1)
                                                    {
                                                        byte channel = br.ReadByte();
                                                        metaEvents.Add(new MidiChannelPrefixEvent(track, deltaTime, absTime, channel));
                                                        Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), channel, br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid MIDIChannelPrefix meta event (Position: " + br.BaseStream.Position + ")");
                                                        throw new FormatException("Could not read MIDI file - invalid MIDIChannelPrefix meta event (Position: " + br.BaseStream.Position + ")");
                                                    }
                                                    break;
                                                case MetaEventType.EndOfTrack:
                                                    if (lenData1 == 0)
                                                    {
                                                        metaEvents.Add(new EndOfTrackEvent(track, deltaTime, absTime));
                                                        Utils.PrintDebug(string.Format("META: {0} {1}", metaCode.ToString(), br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid EndOfTrack meta event (Position: " + br.BaseStream.Position + ")");
                                                        throw new FormatException("Could not read MIDI file - invalid EndOfTrack meta event (Position: " + br.BaseStream.Position + ")");
                                                    }
                                                    break;
                                                case MetaEventType.SetTempo:
                                                    if (lenData1 == 3)
                                                    {
                                                        uint tempo = (uint)((br.ReadByte() << 16) + (br.ReadByte() << 8) + br.ReadByte());
                                                        metaEvents.Add(new SetTempoEvent(track, deltaTime, absTime, tempo));
                                                        Utils.PrintDebug(string.Format("META: {0} {1} {2}", metaCode.ToString(), tempo, br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid SetTempo meta event (Position: " + br.BaseStream.Position + ")");
                                                        throw new FormatException("Could not read MIDI file - invalid SetTempo meta event (Position: " + br.BaseStream.Position + ")");
                                                    }
                                                    break;
                                                case MetaEventType.SMPTEOffset:
                                                    if (lenData1 == 5)
                                                    {
                                                        byte hour = br.ReadByte();
                                                        byte frameRateCode = (byte)(hour & 0xC0);
                                                        float frameRate = 24F;
                                                        switch (frameRateCode)
                                                        {
                                                            case 0: // 24
                                                                frameRate = 24F;
                                                                break;
                                                            case 1: // 25
                                                                frameRate = 25F;
                                                                break;
                                                            case 2: // 'Drop' 30
                                                                frameRate = 29.97F;
                                                                break;
                                                            case 3: // 30
                                                                frameRate = 30F;
                                                                break;
                                                        }
                                                        hour = (byte)(hour & 0x3F);
                                                        byte minute = br.ReadByte();
                                                        byte second = br.ReadByte();
                                                        byte frame = br.ReadByte();
                                                        byte subFrame = br.ReadByte();
                                                        metaEvents.Add(new SMPTEOffsetEvent(track, deltaTime, absTime, frameRate, hour, minute, second, frame, subFrame));
                                                        Utils.PrintDebug(string.Format("META: SMPTEOffset {0} {1} {2} {3} {4} {5} {6}", frameRate, hour, minute, second, frame, subFrame, br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid SMPTEOffset meta event (Position: " + br.BaseStream.Position + ")");
                                                        throw new FormatException("Could not read MIDI file - invalid SMPTEOffset meta event (Position: " + br.BaseStream.Position + ")");
                                                    }
                                                    break;
                                                case MetaEventType.TimeSignature:
                                                    if (lenData1 == 4)
                                                    {
                                                        byte numerator = br.ReadByte();
                                                        byte denominator = (byte)Math.Pow(br.ReadByte(), 2);
                                                        byte ticksPerQuarterNote = br.ReadByte();
                                                        byte ticksPerQuarter32Note = br.ReadByte();
                                                        metaEvents.Add(new TimeSignatureEvent(track, deltaTime, absTime, numerator, denominator, ticksPerQuarterNote, ticksPerQuarter32Note));
                                                        Utils.PrintDebug(string.Format("META: {0} {1} {2} {3} {4} {5}", metaCode.ToString(), numerator, denominator, ticksPerQuarterNote, ticksPerQuarter32Note, br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid TimeSignature meta event (Position: " + br.BaseStream.Position + ")");
                                                        throw new FormatException("Could not read MIDI file - invalid TimeSignature meta event (Position: " + br.BaseStream.Position + ")");
                                                    }
                                                    break;
                                                case MetaEventType.KeySignature:
                                                    if (lenData1 == 2)
                                                    {
                                                        sbyte key = br.ReadSByte();
                                                        byte flats = (byte)key;
                                                        byte sharps = 0;
                                                        if (key < 0)
                                                        {
                                                            flats = 0;
                                                            sharps = (byte)(key * -1);
                                                        }
                                                        bool minor = Convert.ToBoolean(br.ReadByte());
                                                        metaEvents.Add(new KeySignatureEvent(track, deltaTime, absTime, key, minor));
                                                        Utils.PrintDebug(string.Format("META: {0} {1} {2} {3} {4} {5}", metaCode.ToString(), key, sharps, flats, minor, br.BaseStream.Position));
                                                    }
                                                    else
                                                    {
                                                        Utils.PrintDebug("Could not read MIDI file - invalid KeySignature meta event (Position: " + br.BaseStream.Position + ")");
                                                        throw new FormatException("Could not read MIDI file - invalid KeySignature meta event (Position: " + br.BaseStream.Position + ")");
                                                    }
                                                    break;
                                                default:
                                                    byte[] data = br.ReadBytes(lenData1);
                                                    Utils.PrintDebug(string.Format("META: {0} {1}", metaCode.ToString(), br.BaseStream.Position));
                                                    break;
                                            }
                                            break;
                                        default: // MIDI Event
                                            // Get first half of first byte
                                            byte first = (byte)((eventHeader & 0xF0) >> 4);
                                            // Get second half of first byte
                                            byte last = (byte)(eventHeader & 0x0F);

                                            if (first == 0xF) // System Message
                                            {
                                                if (last == 0x0 || last == 0x7) // Sysex Event
                                                {
                                                    byte[] data = br.ReadBytes((int)Utils.ReadVariableLengthUint(br));
                                                    metaEvents.Add(new SysExEvent(track, deltaTime, absTime, data));
                                                    Utils.PrintDebug(string.Format("SYSEX: {0}", br.BaseStream.Position));
                                                }
                                                else
                                                {
                                                    Utils.PrintDebug("System messages are not supported (Position: " + br.BaseStream.Position + ")");
                                                    throw new NotImplementedException("System messages are not supported (Position: " + br.BaseStream.Position + ")");
                                                }
                                            }
                                            else // Standard Midi Event
                                            {
                                                // Get event data, assume status has been carried for now

                                                // Get type of MIDI event
                                                MidiEventType eventType = (MidiEventType)((statusOld & 0xF0) >> 4);
                                                // Get channel of MIDI event
                                                byte channel = (byte)(eventHeader & 0x0F);
                                                // Indicates that old data is being used
                                                bool usingOld = true;

                                                if (Enum.IsDefined(typeof(MidiEventType), first)) // New status code
                                                {
                                                    // Use new status values
                                                    eventType = (MidiEventType)first;
                                                    channel = last;
                                                    usingOld = false;
                                                    statusOld = eventHeader; // Update temporary status record
                                                }

                                                // Get event specific data
                                                switch (eventType)
                                                {
                                                    case MidiEventType.NoteOff:
                                                        byte key1 = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            key1 = br.ReadByte();
                                                        }
                                                        byte vel1 = br.ReadByte();
                                                        midiEvents.Add(new NoteOffEvent(channel, track, deltaTime, absTime, key1, vel1));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2} {3}", eventType.ToString(), key1, vel1, br.BaseStream.Position));
                                                        break;
                                                    case MidiEventType.NoteOn:
                                                        byte key2 = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            key2 = br.ReadByte();
                                                        }
                                                        byte vel2 = br.ReadByte();
                                                        midiEvents.Add(new NoteOnEvent(channel, track, deltaTime, absTime, key2, vel2));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2} {3}", eventType.ToString(), key2, vel2, br.BaseStream.Position));
                                                        break;
                                                    case MidiEventType.PolyphonicKeyPressure:
                                                        byte key3 = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            key3 = br.ReadByte();
                                                        }
                                                        byte vel3 = br.ReadByte();
                                                        midiEvents.Add(new PolyphonicKeyPressureEvent(channel, track, deltaTime, absTime, key3, vel3));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2} {3}", eventType.ToString(), key3, vel3, br.BaseStream.Position));
                                                        break;
                                                    case MidiEventType.ControlChange:
                                                        byte controller = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            controller = br.ReadByte();
                                                        }
                                                        byte value = br.ReadByte();
                                                        midiEvents.Add(new ControlChangeEvent(channel, track, deltaTime, absTime, controller, value));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2} {3}", eventType.ToString(), controller, value, br.BaseStream.Position));
                                                        break;
                                                    case MidiEventType.InstrumentChange:
                                                        byte patch = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            patch = br.ReadByte();
                                                        }
                                                        midiEvents.Add(new InstrumentChangeEvent(channel, track, deltaTime, absTime, patch));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2}", eventType.ToString(), patch, br.BaseStream.Position));
                                                        break;
                                                    case MidiEventType.ChannelPressure:
                                                        byte pressure = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            pressure = br.ReadByte();
                                                        }
                                                        midiEvents.Add(new ChannelPressureEvent(channel, track, deltaTime, absTime, pressure));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2}", eventType.ToString(), pressure, br.BaseStream.Position));
                                                        break;
                                                    case MidiEventType.PitchWeelChange:
                                                        byte p1 = eventHeader;
                                                        if (!usingOld)
                                                        {
                                                            p1 = br.ReadByte();
                                                        }
                                                        byte p2 = br.ReadByte();
                                                        ushort pitch = (ushort)((p2 << 8) + p1);
                                                        midiEvents.Add(new PitchWheelChangeEvent(channel, track, deltaTime, absTime, pitch));
                                                        Utils.PrintDebug(string.Format("MIDI: {0} {1} {2}", eventType.ToString(), pitch, br.BaseStream.Position));
                                                        break;
                                                }
                                            }
                                            break;
                                    }
                                    track++;
                                }

                                tracks.Add(new TrackChunk(metaEvents.ToArray(), midiEvents.ToArray()));
                            }
                            else
                            {
                                // Unrecognised track chunk
                                Utils.PrintDebug("Could not read MIDI file - invalid chunk");
                                throw new FormatException("Could not read MIDI file - invalid chunk");
                            }
                        }

                        // Update public tracks
                        this.tracks = tracks.ToArray();

                        Utils.PrintDebug("-----------------\r\nLoad Complete\r\n-----------------");
                    }
                    else
                    {
                        // Header chunk was not 6 bytes long
                        Utils.PrintDebug("Could not read MIDI file - unexpected header chunk length");
                        throw new FormatException("Could not read MIDI file - unexpected header chunk length");
                    }
                }
                else
                {
                    // Header cunk missing / corrupted
                    Utils.PrintDebug("Could not read MIDI file - header chunk missing");
                    throw new FormatException("Could not read MIDI file - header chunk missing");
                }
            }
        }
        #endregion
    }
}
