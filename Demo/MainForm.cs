using ReadMIDI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Example
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads a MIDI file.
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // Create open file dialog, only allow *.mid files
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "MIDI Files (*.mid) | *.mid";
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK) // If user has confirmed to load the MIDI file
            {
                LoadLbl.Text = Path.GetFileName(openFile.FileName);

                // Load MIDI file
                MidiFile midi = new MidiFile(openFile.FileName);

                // Create default values
                string name = "-";
                string copyright = "-";
                string length = "-";
                string keySignature = "C Major";
                string timeSignature = "4/4";
                string tempo = "120 bpm";

                // Get general info

                // General meta events (eg. TrackName) are usually in Track 0 so we will only look there
                ReadMIDI.Events.MetaEvent[] MetaEvents0 = midi.Tracks[0].MetaEvents;
                for (int i = 0; i < MetaEvents0.Length; i++)
                {
                    switch (MetaEvents0[i].Type)
                    {
                        case MetaEventType.SequenceName:
                            if (name == "-")
                            {
                                ReadMIDI.Events.TextEvent ev = (ReadMIDI.Events.TextEvent)MetaEvents0[i];
                                name = ev.Text;
                            }
                            break;
                        case MetaEventType.CopyrightNotice:
                            if (copyright == "-")
                            {
                                ReadMIDI.Events.TextEvent ev = (ReadMIDI.Events.TextEvent)MetaEvents0[i];
                                copyright = ev.Text;
                            }
                            break;
                        case MetaEventType.EndOfTrack:
                            if (length == "-")
                            {
                                ReadMIDI.Events.EndOfTrackEvent ev = (ReadMIDI.Events.EndOfTrackEvent)MetaEvents0[i];
                                length = (ev.AbsoluteTime / midi.DeltaTicksPerQuarterNote).ToString() + " Beats";
                            }
                            break;
                        case MetaEventType.KeySignature:
                            if (keySignature == "C Major")
                            {
                                ReadMIDI.Events.KeySignatureEvent ev = (ReadMIDI.Events.KeySignatureEvent)MetaEvents0[i];
                                keySignature = ev.GetDisplayName();
                            }
                            break;
                        case MetaEventType.TimeSignature:
                            if (timeSignature == "4/4")
                            {
                                ReadMIDI.Events.TimeSignatureEvent ev = (ReadMIDI.Events.TimeSignatureEvent)MetaEvents0[i];
                                timeSignature = ev.Numerator.ToString() + "/" + ev.Denominator.ToString();
                            }
                            break;
                        case MetaEventType.SetTempo:
                            if (tempo == "120 bpm")
                            {
                                ReadMIDI.Events.SetTempoEvent ev = (ReadMIDI.Events.SetTempoEvent)MetaEvents0[i];
                                tempo = (60000000 / ev.Tempo).ToString() + " bpm";
                            }
                            break;
                    }
                }

                // Display found values
                TrackLbl.Text = name; // Sequence name
                CopyLbl.Text = copyright; // Copyright notice
                LengthLbl.Text = length; // End of track
                KeySigLbl.Text = keySignature; // Key signature
                TimeSigLbl.Text = timeSignature; // Time signature
                TempoLbl.Text = tempo; // Set tempo
            }
        }
    }
}
