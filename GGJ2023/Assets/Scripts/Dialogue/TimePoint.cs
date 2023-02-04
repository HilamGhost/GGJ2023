using UnityEditor;
using UnityEngine;
using System;
using System.Collections;

namespace CrabNine
{
    public enum StoryType
    {
        Narrative,
        Puzzle
    }
    
    [Serializable]
    public class TimePoint
    {
        public StoryType StoryType;

        public bool isPuzzle;
        public bool isNarrative;
        [ConditionalHide("isNarrative",true)]public NarrativePart _narrativePart;
        [ConditionalHide("isPuzzle",true)] public PuzzlePart _puzzlePart;
    }
}
