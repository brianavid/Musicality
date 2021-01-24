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
        static int currentNote;
        static List<int> currentNotes;
        static readonly Random random = new Random();
        static int startNote;
        static int targetNote;
        List<int> targetNotes;

        public static string Instructions { get; private set; }
        public static bool IsPlaying { get; private set; }

        static int interval;
        static Dictionary<int, string> intervalName = new Dictionary<int, string>
        {
            { -7, "perfect 5th down"},
            { -6, "tritone down"},
            { -5, "perfect 4th down"},
            { -4, "major 3rd down"},
            { -3, "minor 3rd down"},
            { -2, "whole tone down"},
            { -1, "semitone down"},
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
            { -7, 4},
            { -6, 3},
            { -5, 3},
            { -4, 2},
            { -3, 2},
            { -2, 1},
            { -1, 1},
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

        static int[] ShortSequenceNotes = new int[] { 53, 55, 57, 59, 60 }; // F G A B C
        static int[] FullSequenceNotes = new int[] { 48, 50, 52, 53, 55, 57, 59, 60 }; // C D E F G A B C


        public void PickRandomIntervalToSing(int middleNote)
        {
            targetNote = random.Next(middleNote - 6, middleNote + 6);
            interval = random.Next(-6, 8);
            if (interval <= 0) interval--;
            startNote = targetNote - interval;
            Instructions = $"Sing a {intervalName[interval]} from ...";
            PlayNote(startNote);
        }

        public void BuildSequenceToSing(bool fullOctave)
        {
            targetNotes = new List<int>();
            var instructionsSB = new StringBuilder("This is C. Sing");
            int lastNote = 0;
            var sequenceNote = fullOctave ? FullSequenceNotes : ShortSequenceNotes;
            int lastInSequence = random.Next(0, sequenceNote.Length);
            bool goingUp = lastInSequence < sequenceNote.Length / 2;

            for (int i = 0; i < 10; i++)
            {
                int nextSequence;
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
                        nextSequence = goingUp ? lastInSequence + 1 : lastInSequence - 1;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        nextSequence = goingUp ? lastInSequence + 2 : lastInSequence - 2;
                        break;
                    case 7:
                    case 8:
                        nextSequence = goingUp ? lastInSequence + 3 : lastInSequence - 3;
                        break;
                    default:
                        nextSequence = random.Next(0, sequenceNote.Length);
                        break;
                }

                if (nextSequence < 0 || nextSequence >= sequenceNote.Length)
                {
                    nextSequence = random.Next(0, sequenceNote.Length);
                }

                goingUp = nextSequence > lastInSequence;
                lastInSequence = nextSequence;
                nextNote = sequenceNote[nextSequence];

                if (nextNote != lastNote)
                {
                    targetNotes.Add(nextNote);
                    instructionsSB.AppendFormat(" {0}{1}", NoteNames[nextNote % 12].Name1,
                                                           fullOctave && nextNote >= 60 ? "'" : "");
                    lastNote = nextNote;
                }
            }
            Instructions = instructionsSB.ToString();
            startNote = 60;
            PlayNotes(48, 60);
        }

        public void PlayIntervalSingTarget()
        {
            PlayNote(targetNote);
        }

        public void PlaySequenceSingTarget()
        {
            PlayNotes(new List<int>(targetNotes));
        }

        public string GetIntervalSingNotesText()
        {
            //  Get the note names, flexing the one that has available enharmonics to appear most conventional
            var nnStart = NoteNames[startNote % 12];
            var nnTarget = NoteNames[targetNote % 12];
            string nameStart;
            string nameTarget;
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
                }
            }
            else
            {
                if (nnStart.Sharps + nnTarget.Sharps > 5)
                {
                    nameStart = nnStart.Name2;
                    nameTarget = nnTarget.Name2;
                }
                else
                {
                    nameStart = nnStart.Name1;
                    nameTarget = nnTarget.Name1;
                }
            }
            return $"{nameStart} - {nameTarget}";
        }

        public void PlayNote(int note)
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                currentNote = note;
                MidiPlayer.PlayNote(currentNote);
            }
        }

        public void PlayNotes(params int[] notes)
        {
            PlayNotes(notes.ToList());
        }

        public void PlayNotes(List<int> notes)
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                currentNotes = notes;
                currentNote = currentNotes[0];
                currentNotes.RemoveAt(0);
                MidiPlayer.PlayNote(currentNote);
            }
        }

        public void Tick(object sender, EventArgs e)
        {
            if (currentNotes != null && currentNotes.Any())
            {
                MidiPlayer.StopNote(currentNote);
                currentNote = currentNotes[0];
                currentNotes.RemoveAt(0);
                MidiPlayer.PlayNote(currentNote);
            }
            else if (currentNote != 0)
            {
                MidiPlayer.StopNote(currentNote);
                currentNote = 0;
                IsPlaying = false;
            }

        }

    }

}
