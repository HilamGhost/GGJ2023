using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CrabNine
{
    public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerUpHandler
    {
        [SerializeField] protected Camera mainCam;
        [SerializeField] protected RectTransform rectTransform;
        [SerializeField] protected CanvasGroup canvasGroup;
        protected Canvas mainCanvas;
        public virtual void Awake()
        {
            mainCam = Camera.main;
            rectTransform = GetComponent<RectTransform>();
            mainCanvas = GetComponentInParent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();

        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnDown");
            canvasGroup.blocksRaycasts = false;
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnDragBegin");
            canvasGroup.blocksRaycasts = false;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnDragEnd");
            canvasGroup.blocksRaycasts = true;
            
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta/mainCanvas.scaleFactor;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
        }
    }
}
