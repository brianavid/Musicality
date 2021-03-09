using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musicality
{
    public class Musicality
    {
        struct NoteName
        {
            public string Name1;
            public int Degree1;
            public string Name2;
            public int Degree2;
            public int Sharps;
        }

        static List<int> currentChord;
        static List<List<int>> currentChords;
        static int startNote;
        static int targetNote;
        static List<List<int>> startChords;
        private static string startChordName1;
        private static string startChordName2;
        static List<List<int>> targetChords;
        static int interval;

        public static string Instructions { get; private set; }
        public static bool IsPlaying { get; private set; }

        static readonly Random random = new Random();

        static Dictionary<int, string> intervalName = new Dictionary<int, string>
        {
            { -12, "octave down"},
            { -7, "perfect 5th down"},
            { -6, "tritone down"},
            { -5, "perfect 4th down"},
            { -4, "major 3rd down"},
            { -3, "minor 3rd down"},
            { -2, "whole tone down"},
            { -1, "semitone down"},
            { 12, "octave up"},
            { 7, "perfect 5th up"},
            { 6, "tritone up"},
            { 5, "perfect 4th up"},
            { 4, "major 3rd up"},
            { 3, "minor 3rd up"},
            { 2, "whole tone up"},
            { 1, "semitone up"},
        };

        //  How many scale degrees for each interval
        static Dictionary<int, int> scaleDegrees = new Dictionary<int, int>
        {
            { -12, 7},
            { -7, 4},
            { -6, 3},
            { -5, 3},
            { -4, 2},
            { -3, 2},
            { -2, 1},
            { -1, 1},
            { 12, 7},
            { 7, 4},
            { 6, 3},
            { 5, 3},
            { 4, 2},
            { 3, 2},
            { 2, 1},
            { 1, 1},
        };

        //  What are the note names, giving enharmonics where needed
        static NoteName[] NoteNames = new NoteName[]
        {
            new NoteName{ Name1="C", Degree1=0, Name2="C", Degree2=0 },
            new NoteName{ Name1="C#", Degree1=0, Name2="D♭", Degree2=1, Sharps=2 },
            new NoteName{ Name1="D", Degree1=1, Name2="D", Degree2=1 },
            new NoteName{ Name1="D#", Degree1=1, Name2="E♭", Degree2=2, Sharps=4 },
            new NoteName{ Name1="E", Degree1=2, Name2="E", Degree2=2 },
            new NoteName{ Name1="F", Degree1=3, Name2="F", Degree2=3 },
            new NoteName{ Name1="F#", Degree1=3, Name2="G♭", Degree2=4, Sharps=1 },
            new NoteName{ Name1="G", Degree1=4, Name2="G", Degree2=4 },
            new NoteName{ Name1="G#", Degree1=4, Name2="A♭", Degree2=5, Sharps=3 },
            new NoteName{ Name1="A", Degree1=5, Name2="A", Degree2=5 },
            new NoteName{ Name1="A#", Degree1=5, Name2="B♭", Degree2=6, Sharps=5 },
            new NoteName{ Name1="B", Degree1=6, Name2="B", Degree2=6 },
        };

        static int[] ShortSequenceNotes = new int[] { 5, 7, 9, 11, 12 }; // F G A B C
        static int[] FullSequenceNotes = new int[] { 0, 2, 4, 5, 7, 9, 11, 12 }; // C D E F G A B C

        static (int, int, int, bool isMajor)[] TriadIntervals = new [] 
        {
            ( 0, 3, 7, true ),
            ( 0, 4, 7, false ),
            ( 8, 0, 3, false ),
            ( 9, 0, 4, true ),
            ( 5, 8, 0, true ),
            ( 5, 9, 0, false ),
        };

        public static void Initialise()
        {
            MidiPlayer.Initialise();
        }

        public static void PickRandomIntervalToSing(int middleNote)
        {
            targetNote = random.Next(middleNote - 6, middleNote + 6);
            interval = random.Next(-7, 9);
            if (interval <= 0) interval--;
            if (interval < -7) interval = -12;
            if (interval > 7) interval = 12;
            startNote = targetNote - interval;
            Instructions = $"Sing a {intervalName[interval]} from ...";
            startChords = new List<List<int>> { new List<int> { startNote } };
            startChordName1 = "";
            startChordName2 = "";
            PlayChords(startChords);
        }

        public static void PickRandomChordIntervalToSing(int middleNote)
        {
            targetNote = random.Next(middleNote - 6, middleNote + 6);
            interval = random.Next(0, 2) * 2 + 5;
            startNote = targetNote - interval;
            Instructions = $"Sing a {intervalName[interval]} from ...";
            var triadIntervals = TriadIntervals[random.Next(0, 6)];
            startChords = new List<List<int>> { new List<int> { 
                startNote + 12 - triadIntervals.Item1,
                startNote + 12 - triadIntervals.Item2,
                startNote + 12 - triadIntervals.Item3 } };
            startChordName1 = MakeChordName(startNote, triadIntervals.Item3, triadIntervals.isMajor, true);
            startChordName2 = MakeChordName(startNote, triadIntervals.Item3, triadIntervals.isMajor, false);
            PlayChords(startChords);
        }

        private static string MakeChordName(int startNote, int intervalToRoot, bool isMajor, bool firstName)
        {
            var root = (startNote + 12 - intervalToRoot) % 12;
            var minorIndicator = isMajor ? "maj" : "min";
            var chordRootName = NoteNames[root];
            return firstName ? $"({chordRootName.Name1}{minorIndicator}) " : $"({chordRootName.Name2}{minorIndicator}) ";
        }

        static List<int> MakeNoteSequence(int lowNote, bool fullOctave, int length)
        {
            var notes = new List<int>();
            int lastNote = 0;
            var sequenceNotes = (fullOctave ? FullSequenceNotes : ShortSequenceNotes).Select(n => n + lowNote).ToArray();
            int lastInSequence = random.Next(0, sequenceNotes.Length);
            bool goingUp = lastInSequence < sequenceNotes.Length / 2;

            while (notes.Count < length)
            {
                int nextNoteInSequence;
                int nextNote;

                if (random.Next(0, 4) == 0)
                {
                    goingUp = !goingUp;
                }
                switch (random.Next(0, 10))
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        nextNoteInSequence = goingUp ? lastInSequence + 1 : lastInSequence - 1;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        nextNoteInSequence = goingUp ? lastInSequence + 2 : lastInSequence - 2;
                        break;
                    case 7:
                    case 8:
                        nextNoteInSequence = goingUp ? lastInSequence + 3 : lastInSequence - 3;
                        break;
                    default:
                        nextNoteInSequence = random.Next(0, sequenceNotes.Length);
                        break;
                }

                if (nextNoteInSequence < 0 || nextNoteInSequence >= sequenceNotes.Length)
                {
                    nextNoteInSequence = random.Next(0, sequenceNotes.Length);
                }

                goingUp = nextNoteInSequence > lastInSequence;
                lastInSequence = nextNoteInSequence;
                nextNote = sequenceNotes[nextNoteInSequence];

                if (nextNote != lastNote)
                {
                    notes.Add(nextNote);
                    lastNote = nextNote;
                }
            }

            return notes;
        }

        public static void BuildSequenceToSing(int lowNote, bool fullOctave, int length=10)
        {
            targetChords = MakeNoteSequence(lowNote, fullOctave, length).Select(n => new List<int> { n }).ToList();

            var lowNoteName = NoteNames[lowNote % 12].Name1;
            var instructionsSB = new StringBuilder($"This is {lowNoteName}. Sing");
            foreach (var note in targetChords)
            {
                instructionsSB.AppendFormat(" {0}{1}", NoteNames[note[0] % 12].Name1,
                                                       note[0] >= lowNote+12 ? "'" : "");
            }
            Instructions = instructionsSB.ToString();

            startNote = 60;
            startChords = new List<List<int>> { new List<int> { lowNote }, new List<int> { lowNote+12 } };
            PlayChords(startChords);
        }

        public static void ReplayStartNotes()
        {
            PlayChords(startChords);
        }

        public static void PlayIntervalSingTarget()
        {
            PlayNote(targetNote);
        }

        public static void PlaySequenceSingTarget()
        {
            PlayChords(targetChords);
        }

        public static string GetIntervalSingNotesText()
        {
            //  Get the note names, flexing the one that has available enharmonics to appear most conventional
            var nnStart = NoteNames[startNote % 12];
            var nnTarget = NoteNames[targetNote % 12];
            string nameStart;
            string nameTarget;
            string startChordName = startChordName1;
            if (nnStart.Degree1 == nnStart.Degree2)
            {
                nameStart = nnStart.Name1;
                nameTarget = nnTarget.Name1;
                if (nnTarget.Degree1 != nnTarget.Degree2)
                {
                    if (startNote > targetNote ?
                        scaleDegrees[interval] == (nnStart.Degree1 + 7 - nnTarget.Degree2) % 7 :
                        scaleDegrees[interval] == (nnTarget.Degree2 + 7 - nnStart.Degree1) % 7)
                    {
                        nameTarget = nnTarget.Name2;
                        startChordName = startChordName2;
                    }
                }
            }
            else if (nnTarget.Degree1 == nnTarget.Degree2)
            {
                nameStart = nnStart.Name1;
                nameTarget = nnTarget.Name1;
                if (startNote > targetNote ?
                    scaleDegrees[interval] == (nnStart.Degree2 + 7 - nnTarget.Degree1) % 7 :
                    scaleDegrees[interval] == (nnTarget.Degree1 + 7 - nnStart.Degree2) % 7)
                {
                    nameStart = nnStart.Name2;
                    startChordName = startChordName2;
                }
            }
            else
            {
                if (nnStart.Sharps + nnTarget.Sharps > 5)
                {
                    nameStart = nnStart.Name2;
                    nameTarget = nnTarget.Name2;
                    startChordName = startChordName2;
                }
                else
                {
                    nameStart = nnStart.Name1;
                    nameTarget = nnTarget.Name1;
                }
            }
            return $"{startChordName}{nameStart} - {nameTarget}";
        }

        public static void PlaySequence(int length)
        {
            startChords = new List<List<int>> { new List<int> { 60, 48 }, null }.
                        Concat(MakeNoteSequence(48, true, length).
                        Select(n => n == 0 ? null : new List<int> { n })).ToList();
            PlayChords(startChords);
        }

        public static string SequenceText()
        {
            var notes = startChords.Skip(2);
            StringBuilder sb = new StringBuilder();
            foreach (var note in notes)
            {
                sb.AppendFormat("{0}{1} ", NoteNames[note[0] % 12].Name1, note[0] >= 60 ? "'" : "");
            }
            return sb.ToString();
        }

        static void PlayNote(int note)
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                currentChord = new List<int> { note };
                MidiPlayer.PlayNote(note);
            }
        }

        public static void PlayNotes(params int[] notes)
        {
            PlayChords(notes.Select(n => new List<int> { n }).ToList());
        }

        static void PlayChords(List<List<int>> chords)
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                currentChords = new List <List<int>> (chords);
                currentChord = currentChords[0];
                currentChords.RemoveAt(0);
                if (currentChord != null && currentChord.Any())
                {
                    foreach (var note in currentChord)
                    {
                        MidiPlayer.PlayNote(note);
                    }
                }
            }
        }

        public static void Tick()
        {
            if (currentChords != null && currentChords.Any())
            {
                if (currentChord != null && currentChord.Any())
                {
                    foreach (var note in currentChord)
                    {
                        MidiPlayer.StopNote(note);
                    }
                }
                currentChord = currentChords[0];
                currentChords.RemoveAt(0);
                if (currentChord != null && currentChord.Any())
                {
                    foreach (var note in currentChord)
                    {
                        MidiPlayer.PlayNote(note);
                    }
                }
            }
            else
            {
                if (currentChord != null && currentChord.Any())
                {
                    foreach (var note in currentChord)
                    {
                        MidiPlayer.StopNote(note);
                    }
                }
                currentChord = null;
                IsPlaying = false;
            }
        }

    }
}
