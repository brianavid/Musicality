using NAudio.Midi;

namespace Musicality
{
    class MidiPlayer
    {
        static MidiOut midiOut;

        public static void Initialise()
        {
            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                if (MidiOut.DeviceInfo(device).ProductName.StartsWith("Microsoft"))
                {
                    midiOut = new MidiOut(device);
                }
            }

        }

        public static void PlayNote(int n)
        {
            var note = new NoteOnEvent(0, 1, n, 96, 1000);
            midiOut.Send(note.GetAsShortMessage());
        }

        public static void StopNote(int n)
        {
            var note = new NoteEvent(0, 1, MidiCommandCode.NoteOff, n, 0);
            midiOut.Send(note.GetAsShortMessage());
        }
    }
}
