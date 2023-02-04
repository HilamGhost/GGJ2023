using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrabNine
{
    [CreateAssetMenu(fileName = "Puzzle Part",menuName = "Create New Puzzle Part")]
    public class PuzzlePart :ScriptableObject
    {
        [SerializeField] PaintingData[] ImagineObjects  = new PaintingData[5];

        public void SetPuzzleWords(ImagineObject[] _puzzleTexts)
        {
            for (int i = 0; i < ImagineObjects.Length; i++)
            {
                _puzzleTexts[i].PaintingData= ImagineObjects[i];
            }
        }
    }
}
