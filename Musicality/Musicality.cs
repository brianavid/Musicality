﻿using System;
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
        static bool displayNotesUsingFlats;

        public static string Instructions { get; private set; }
        public static bool IsPlaying { get; private set; }

        static readonly Random random = new Random();

        static Dictionary<int, string> intervalName = new Dictionary<int, string>
        {
            { 12, "octave"},
            { 11, "major 7th"},
            { 10, "minor 7th"},
            { 9, "major 6th"},
            { 8, "minor 6th"},
            { 7, "perfect 5th"},
            { 6, "tritone"},
            { 5, "perfect 4th"},
            { 4, "major 3rd"},
            { 3, "minor 3rd"},
            { 2, "whole tone"},
            { 1, "semitone"},
            { 0, "note"},
        };

        static Dictionary<int, string> shortIntervalName = new Dictionary<int, string>
        {
            { 12, "Octave"},
            { 11, "Maj 7th"},
            { 10, "Min 7th"},
            { 9, "Maj 6th"},
            { 8, "Min 6th"},
            { 7, "Perf 5th"},
            { 6, "TriTone"},
            { 5, "Perf 4th"},
            { 4, "Maj 3rd"},
            { 3, "Min 3rd"},
            { 2, "Maj 2nd"},
            { 1, "Min 2nd"},
        };

        //  How many scale degrees for each interval
        static Dictionary<int, int> scaleDegrees = new Dictionary<int, int>
        {
            { 12, 7},
            { 11, 6},
            { 10, 6},
            { 9, 5},
            { 8, 5},
            { 7, 4},
            { 6, 3},
            { 5, 3},
            { 4, 2},
            { 3, 2},
            { 2, 1},
            { 1, 1},
            { 0, 0},
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

        public enum ChordIntervalChooser
        {
            TopNote, BottomNote, ThirdsAbove, PerfectAbove, SixthsAbove, ThirdsBelow, PerfectBelow, SixthsBelow, Mixed
        }

        public static void Initialise()
        {
            MidiPlayer.Initialise();
        }

        public static void PickRandomIntervalToSing(int middleNote, bool onlyCloseIntervals)
        {
            targetNote = random.Next(middleNote - 6, middleNote + 6);
            interval = onlyCloseIntervals ? random.Next(-6, 8) : random.Next(-11, 13);
            if (interval <= 0) interval--;
            var direction = interval > 0 ? "above" : "below";
            startNote = targetNote - interval;
            Instructions = $"Sing a {intervalName[Math.Abs(interval)]} {direction} ...";
            startChords = new List<List<int>> { new List<int> { startNote } };
            startChordName1 = "";
            startChordName2 = "";
            PlayChords(startChords);
        }

        static Dictionary<ChordIntervalChooser, int[]> ChordIntervalChoices = new Dictionary<ChordIntervalChooser, int[]>
        {
            { ChordIntervalChooser.TopNote, new int[] { 0 } },
            { ChordIntervalChooser.BottomNote, new int[] { 0 } },
            { ChordIntervalChooser.PerfectAbove, new int[] { 5, 7 } },
            { ChordIntervalChooser.ThirdsAbove, new int[] { 3, 4 } },
            { ChordIntervalChooser.SixthsAbove, new int[] { 8, 9 } },
            { ChordIntervalChooser.PerfectBelow, new int[] { 5, 7 } },
            { ChordIntervalChooser.ThirdsBelow, new int[] { 3, 4 } },
            { ChordIntervalChooser.SixthsBelow, new int[] { 8, 9 } },
            { ChordIntervalChooser.Mixed, new int[] { 3, 4, 5, 7, 8, 9 } },
        };

        public static void PickRandomChordIntervalToSing(int middleNote, ChordIntervalChooser chordIntervalChooser)
        {
            bool isAbove;
            switch (chordIntervalChooser)
            {
                default:
                    isAbove = false;
                    break;
                case ChordIntervalChooser.TopNote:
                case ChordIntervalChooser.PerfectAbove:
                case ChordIntervalChooser.ThirdsAbove:
                case ChordIntervalChooser.SixthsAbove:
                    isAbove = true;
                    break;
                case ChordIntervalChooser.Mixed:
                    isAbove = random.Next(0, 2) == 0;
                    break;
            }
            targetNote = random.Next(middleNote - 6, middleNote + 6);
            var intervalChoices = ChordIntervalChoices[chordIntervalChooser];
            interval = intervalChoices[random.Next(0, intervalChoices.Length)] * (isAbove ? 1 : -1);
            var direction = interval == 0 ?
                                (isAbove ? "top" : "bottom") :
                                (isAbove ? "above top" : "below bottom");
            startNote = targetNote - interval;
            Instructions = interval == 0 ?
                                $"Sing the {direction} note of ..." :
                                $"Sing a {intervalName[Math.Abs(interval)]} {direction} note of ...";
            var triadIntervals = TriadIntervals[random.Next(0, 6)];
            if (isAbove)
            {
                startChords = new List<List<int>> { new List<int> {
                    startNote - triadIntervals.Item1,
                    startNote - triadIntervals.Item2,
                    startNote - triadIntervals.Item3 } };
            }
            else
            {
                startChords = new List<List<int>> { new List<int> {
                    startNote + triadIntervals.Item1,
                    startNote + triadIntervals.Item2,
                    startNote + triadIntervals.Item3 } };
            }
            var intervalToRoot = isAbove ? triadIntervals.Item3 : -triadIntervals.Item1;
            var triadIsMajor = isAbove ? triadIntervals.isMajor : !triadIntervals.isMajor;
            startChordName1 = MakeChordName(startNote, intervalToRoot, triadIsMajor, true);
            startChordName2 = MakeChordName(startNote, intervalToRoot, triadIsMajor, false);
            if (interval == 0)
            {
                //  This should ensure that the target note display is enharmonic with the chord
                startNote += (12 - intervalToRoot);
                interval = intervalToRoot;
            }
            PlayChords(startChords);
        }

        public static void PickRandomNoteToSingfromA(int middleNote)
        {
            targetNote = random.Next(middleNote - 6, middleNote + 6);
            var targetNoteName = NoteNames[targetNote % 12];
            var targetNoteNameName = targetNoteName.Sharps <= 3 ? targetNoteName.Name1 : targetNoteName.Name2;
            startNote = 69;
            interval = ((targetNote%12) - (startNote%12) + 12) % 12;
            if (interval > 6)
            {
                interval = interval - 12;
            }
            Instructions = $"This is A. Sing a {targetNoteNameName}";
            startChords = new List<List<int>> { new List<int> { startNote } };
            startChordName1 = "";
            startChordName2 = "";
            PlayChords(startChords);
        }

        public static void PickRandomIntervalToRecognise(int middleNote)
        {
            interval = random.Next(1, 13);
            startNote = random.Next(middleNote - 6 - interval / 2, middleNote + 6 - interval / 2);
            targetNote = startNote + interval;
            startChords = new List<List<int>> { new List<int> { startNote, targetNote } };
            startChordName1 = shortIntervalName[interval] + " : ";
            startChordName2 = startChordName1;
            PlayChords(startChords);
            targetChords = new List<List<int>> { new List<int> { startNote }, new List<int> { targetNote } };
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
                    if (interval == 6 ? 
                          nnTarget.Sharps >= 3 :
                        interval < 0 ?
                          scaleDegrees[Math.Abs(interval)] == (nnStart.Degree1 + 7 - nnTarget.Degree2) % 7 :
                          scaleDegrees[Math.Abs(interval)] == (nnTarget.Degree2 + 7 - nnStart.Degree1) % 7)
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
                if (interval == 6 ?
                      nnStart.Sharps >= 3 :
                   interval < 0 ?
                     scaleDegrees[Math.Abs(interval)] == (nnStart.Degree2 + 7 - nnTarget.Degree1) % 7 :
                     scaleDegrees[Math.Abs(interval)] == (nnTarget.Degree1 + 7 - nnStart.Degree2) % 7)
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
            return interval == 0 ? $"{startChordName} {nameTarget}" : $"{startChordName}{nameStart} - {nameTarget}";
        }

        public static void PlaySequence(int length, int key, string mode="Major")
        {
            var lowNote = 48 + key;
            displayNotesUsingFlats = true;
            switch (key)
            {
                case 2:
                case 4:
                case 6:
                case 7:
                case 9:
                case 11:
                    displayNotesUsingFlats = false; // To do: take into account the mode
                    break;
            }
            startChords = new List<List<int>> { new List<int> { lowNote+12, lowNote }, null }.
                        Concat(MakeNoteSequence(lowNote, true, length).
                        Select(n => n == 0 ? null : new List<int> { n })).ToList();
            PlayChords(startChords);
        }

        public static string SequenceText()
        {
            var notes = startChords.Skip(2);
            StringBuilder sb = new StringBuilder();
            if (displayNotesUsingFlats)
            {
                foreach (var note in notes)
                {
                    sb.AppendFormat("{0}{1} ", NoteNames[note[0] % 12].Name2, note[0] >= 60 ? "'" : "");
                }
            }
            else
            {
                foreach (var note in notes)
                {
                    sb.AppendFormat("{0}{1} ", NoteNames[note[0] % 12].Name1, note[0] >= 60 ? "'" : "");
                }
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
