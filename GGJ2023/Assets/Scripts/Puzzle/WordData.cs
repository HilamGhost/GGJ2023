using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrabNine
{
    public class WordData :MonoBehaviour
    {
        [SerializeField] private ImagineObject[] words;

        public void AssignPuzzle(PuzzlePart _puzzlePart)
        {
            _puzzlePart.SetPuzzleWords(words);
        }
    }
}
