using System;

namespace ReadMIDI
{
    /// <summary>
    /// Provides fields and methods for displaying human readable labels.
    /// </summary>
    public static class DisplayServices
    {
        #region Fields
        /// <summary>
        /// Array containing the string display names of all the MIDI GM instruments.
        /// </summary>
        public static readonly string[] InstrumentNames = new string[]
        {
            "Acoustic Grand",
            "Bright Acoustic",
            "Electric Grand",
            "Honky-Tonk",
            "Electric Piano 1",
            "Electric Piano 2",
            "Harpsichord",
            "Clav",
            "Celesta",
            "Glockenspiel",
            "Music Box",
            "Vibraphone",
            "Marimba",
            "Xylophone",
            "Tubular Bells",
            "Dulcimer",
            "Drawbar Organ",
            "Percussive Organ",
            "Rock Organ",
            "Church Organ",
            "Reed Organ",
            "Accoridan",
            "Harmonica",
            "Tango Accordian",
            "Nylon Guitar",
            "Steel Guitar",
            "Jazz Guitar",
            "Clean Guitar",
            "Muted Guitar",
            "Overdrive Guitar",
            "Distortion Guitar",
            "Guitar Harmonics",
            "Acoustic Bass",
            "Finger Bass",
            "Pick Bass",
            "Fretless Bass",
            "Slap Bass 1",
            "Slap Bass 2",
            "Synth Bass 1",
            "Synth Bass 2",
            "Violin",
            "Viola",
            "Cello",
            "Contrabass",
            "Tremolo Strings",
            "Pizzicato Strings",
            "Orchestral Strings",
            "Timpani",
            "String Ensemble 1",
            "String Ensemble 2",
            "SynthStrings 1",
            "SynthStrings 2",
            "Choir Aahs",
            "Voice Oohs",
            "Synth Voice",
            "Orchestra Hit",
            "Trumpet",
            "Trombone",
            "Tuba",
            "Muted Trumpet",
            "French Horn",
            "Brass Section",
            "SynthBrass 1",
            "SynthBrass 2",
            "Soprano Sax",
            "Alto Sax",
            "Tenor Sax",
            "Baritone Sax",
            "Oboe",
            "English Horn",
            "Bassoon",
            "Clarinet",
            "Piccolo",
            "Flute",
            "Recorder",
            "Pan Flute",
            "Bottle",
            "Skakuhachi",
            "Whistle",
            "Ocarina",
            "Square Lead",
            "Sawtooth Lead",
            "Calliope Lead",
            "Chiff Lead",
            "Charang Lead",
            "Voice Lead",
            "Fifths Lead",
            "Bass & Lead",
            "New Age Pad",
            "Warm Pad",
            "Polysynth Pad",
            "Choir Pad",
            "Bowed Pad",
            "Metallic Pad",
            "Halo Pad",
            "Sweep Pad",
            "Rain",
            "Soundtrack",
            "Crystal",
            "Atmosphere",
            "Brightness",
            "Goblins",
            "Echoes",
            "Sci-fi",
            "Sitar",
            "Banjo",
            "Shamisen",
            "Koto",
            "Kalimba",
            "Bagpipe",
            "Fiddle",
            "Shanai",
            "Tinkle Bell",
            "Agogo",
            "Steel Drums",
            "Woodblock",
            "Taiko Drum",
            "Melodic Tom",
            "Synth Drum",
            "Reverse Cymbal",
            "Guitar Fret Noise",
            "Breath Noise",
            "Seashore",
            "Bird Tweet",
            "Telephone Ring",
            "Helicopter",
            "Applause",
            "Gunshot"
        };

        /// <summary>
        /// Array containing the display names of all the MIDI GM drums. Note: All indexes are offset by -35.
        /// </summary>
        public static readonly string[] DrumNames = new string[]
        {
            "Acoustic Bass Drum",
            "Bass Drum 1",
            "Side Stick",
            "Acoustic Snare",
            "Hand Clap",
            "Electric Snare",
            "Low Floor Tom",
            "Closed Hi-Hat",
            "High Floor Tom",
            "Pedal Hi-Hat",
            "Low Tom",
            "Open Hi-Hat",
            "Low-Mid Tom",
            "Hi-Mid Tom",
            "Crash Cymbal 1",
            "High Tom",
            "Ride Cymbal 1",
            "Chinese Cymbal",
            "Ride Bell",
            "Tambourine",
            "Splash Cymbal",
            "Cowbell",
            "Crash Cymbal 2",
            "Vibraslap",
            "Ride Cymbal 2",
            "Hi Bongo",
            "Low Bongo",
            "Mute Hi Conga",
            "Open Hi Conga",
            "Low Conga",
            "High Timbale",
            "Low Timbale",
            "High Agogo",
            "Low Agogo",
            "Cabasa",
            "Maracas",
            "Short Whistle",
            "Long Whistle",
            "Short Guiro",
            "Long Guiro",
            "Claves",
            "Hi Wood Block",
            "Low Wood Block",
            "Mute Cuica",
            "Open Cuica",
            "Mute Trianlge",
            "Open Triangle"
        };

        /// <summary>
        /// Array containing the display names of all the notes in an octave, using the sharp symbol where necessary.
        /// </summary>
        public static readonly string[] NoteSharpNames = new string[]
        {
            "C",
            "C♯",
            "D",
            "D♯",
            "E",
            "F",
            "F♯",
            "G",
            "G♯",
            "A",
            "A♯",
            "B"
        };

        /// <summary>
        /// Array containing the display names of all the notes in an octave, using the sharp symbol where necessary.
        /// </summary>
        public static readonly string[] NoteFlatNames = new string[]
        {
            "C",
            "D♭",
            "D",
            "E♭",
            "E",
            "F",
            "G♭",
            "G",
            "A♭",
            "A",
            "B♭",
            "B"
        };

        /// <summary>
        /// Array containing the display names of all major key signatures. Note: All indexes are offset by +7.
        /// </summary>
        public static readonly string[] MajorKeys = new string[]
        {
            "C♭",
            "G♭",
            "D♭",
            "A♭",
            "E♭",
            "B♭",
            "F",
            "C",
            "G",
            "D",
            "A",
            "E",
            "B",
            "F♯",
            "C♯"
        };

        /// <summary>
        /// Array containing the display names of all minor key signatures. Note: All indexes are offset by +7.
        /// </summary>
        public static readonly string[] MinorKeys = new string[]
        {
            "A♭",
            "E♭",
            "B♭",
            "F",
            "C",
            "G",
            "D",
            "A",
            "E",
            "B",
            "F♯",
            "C♯",
            "G♯",
            "D♯",
            "A♯"
        };
        #endregion
        #region Methods
        /// <summary>
        /// Returns the display name of the specified GM drum.
        /// </summary>
        /// <param name="drum">The GM drum index to get the display name of.</param>
        /// <returns>The display name of the specified GM drum.</returns>
        public static string GetDrumName(int drum)
        {
            return DrumNames[drum + 35];
        }

        /// <summary>
        /// Returns the display name of the specified note.
        /// </summary>
        /// <param name="note">The note to get the display name of.</param>
        /// <param name="sharp">Whether to use sharps (true) of flats (false) when necessary.</param>
        /// <returns>The display name of the note.</returns>
        public static string GetNoteName(byte note, bool sharp = true)
        {
            if (note == 60)
            {
                return "Middle C";
            }
            else
            {
                string name = NoteSharpNames[note % 12];
                if (!sharp)
                {
                    name = NoteFlatNames[note % 12];
                }
                int octave = (int)Math.Floor((double)(note / 12));
                return name + octave;
            }
        }

        /// <summary>
        /// Returns the display name for the specified key signature.
        /// </summary>
        /// <param name="key">The key identifier (-7 to 7).</param>
        /// <param name="minor">Whether the key is minor or major.</param>
        /// <returns>The display name for the specified key signature.</returns>
        public static string GetKeySignatureName(sbyte key, bool minor)
        {
            if (minor)
            {
                return MinorKeys[key + 7] + " Minor";
            }
            else
            {
                return MajorKeys[key + 7] + " Major";
            }
        }
        #endregion
    }
}
