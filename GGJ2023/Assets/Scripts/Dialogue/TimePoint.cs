using UnityEditor;
using UnityEngine;
using System;
using System.Collections;

namespace CrabNine
{
    public enum StoryType
    {
        Narrative,
        Puzzle,
        Dialogue
    }
    
    [Serializable]
    public class TimePoint
    {
        public StoryType StoryType;

        public bool isPuzzle;
        public bool isNarrative;
        public bool isDialogue;
        [ConditionalHide("isNarrative",true)]public NarrativePart _narrativePart;
        [ConditionalHide("isPuzzle",true)] public PuzzlePart _puzzlePart;
        [ConditionalHide("isDialogue", true)] public DialoguePart _dialoguePart;
    }
}
