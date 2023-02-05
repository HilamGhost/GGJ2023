using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace CrabNine
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private TimePoint[] TimeLine;
        [SerializeField] private int level;
        [SerializeField] private bool isStarted;
        

        [Header("UI")] 
        [SerializeField] private GameObject narrativeCanvas;
        [SerializeField] private GameObject puzzleCanvas;
        [SerializeField] private PaintingCanva paintingCanva;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private WordData wordData;
        

        public int Level => level;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)&& !isStarted)
            {
                StartAction(TimeLine[level]);
                isStarted = true;
            }   
        }


        public void NextScene()
        {
            if (CameraManager.Instance.LevelIsChanging) return;
            
            CameraManager.Instance.ChangeCamera();
            
            
        }
        public void ChangeLevel()
        {
            EndAction();
            level++;
            if (level>= TimeLine.Length)
            {
                puzzleCanvas.SetActive(true);
                PuzzleManager.Instance.ChangeEndPuzzle();
                PuzzleManager.Instance.GoUp();
                OpenPuzzleBefore();
            }
            else
                StartAction(TimeLine[level]);
        }

        void StartAction(TimePoint _timePoint)
        {
 
            switch (_timePoint.StoryType)
            {
                case StoryType.Narrative: 
                    narrativeCanvas.SetActive(true);
                    DialogueManager.Instance.TakeQuote(_timePoint._narrativePart.Quote);
                    break;
                case StoryType.Puzzle: 
                    puzzleCanvas.SetActive(true);
                    wordData.AssignPuzzle(_timePoint._puzzlePart);
                    paintingCanva.ClearCanvasFull();
                    break;
                case  StoryType.Dialogue:
                    narrativeCanvas.SetActive(true);
                    DialogueManager.Instance.TakeQuote(_timePoint._dialoguePart.Quote,true);;
                    break;
            }
        }

        public void OpenPuzzleBefore()
        {
            if(level+1 >= TimeLine.Length) return;
            
            if (TimeLine[level + 1].StoryType == StoryType.Puzzle)
            {
                StartAction(TimeLine[level + 1]);
                paintingCanva.ClearCanvasFull();
                PuzzleManager.Instance.GoUp();
            }
        }
        public void EndAction()
        {
            DialogueManager.Instance.ClearText();
            narrativeCanvas.SetActive(false);
            puzzleCanvas.SetActive(false);
            
        }


        public void MoveCanvas(Transform _target)
        {
           
            narrativeCanvas.transform.position = _target.position;
            textMeshProUGUI.rectTransform.anchoredPosition = _target.GetComponentInChildren<CameraPlaceManager>().textPosition.localPosition*100;
            puzzleCanvas.transform.position = _target.position;
            
            EndAction();
            ChangeLevel();
        }

    }
}
