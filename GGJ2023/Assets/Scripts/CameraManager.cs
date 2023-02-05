using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CrabNine
{
    public class CameraManager : Singleton<CameraManager>
    {
        [SerializeField] private GameObject gameCamera;

        [Header("Properties")] 
        [SerializeField] private float time;
        [SerializeField] private Transform[] gameCameraPoses;
        [SerializeField] private bool levelIsChanging;
        public bool LevelIsChanging => levelIsChanging;

      
        
        public void ChangeCamera()
        {
            if(PuzzleManager.Instance.transform.parent.gameObject.activeSelf) PuzzleManager.Instance.GoDown();
            else GameManager.Instance.OpenPuzzleBefore();
            
            var _target = gameCameraPoses[GameManager.Instance.Level];
            levelIsChanging = true;
            gameCamera.transform.DOMoveY(_target.transform.position.y, time).OnComplete(() =>
            {
                levelIsChanging = false;
                GameManager.Instance.MoveCanvas(_target);
            });
        }
    }
}
