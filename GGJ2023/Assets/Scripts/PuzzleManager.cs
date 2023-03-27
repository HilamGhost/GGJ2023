    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    namespace CrabNine
{
    public class PuzzleManager : Singleton<PuzzleManager>
    {
        [SerializeField] private float time;

        [SerializeField] private Vector2 goOffset;
        [SerializeField] private RectTransform canvaTransform;

        [SerializeField] private GameObject puzzleManager;

        protected override void Awake()
        {
            base.Awake();
            canvaTransform = GetComponent<RectTransform>();
            canvaTransform.parent.gameObject.SetActive(false);
        }

        public void GoDown()
        {
            canvaTransform.DOLocalMoveY(goOffset.y,time);
        }

        public void GoUp()
        {
            canvaTransform.localPosition = -goOffset;
            canvaTransform.DOLocalMoveY(0,time);
        }

       
       
    }
}
