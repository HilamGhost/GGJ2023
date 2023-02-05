using System;

using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace CrabNine
{
    public class ImagineObject : DragAndDrop
    {
        [SerializeField] private PaintingData paintingData;
        private Vector2 startPoint;
        private WordSocket connectedWordSocket;
        private WordSocket activeWordSocket;
        public Vector2 StartPoint => startPoint;

        public PaintingData PaintingData
        {
            get
            {
                return paintingData;
            }
            set
            {
                paintingData.abstractText = value.abstractText;
                paintingData.abstractName = value.abstractName;
                paintingData.abstractImage = value.abstractImage;
                
                paintingData.abstractText = this;
                GetComponent<TextMeshProUGUI>().text = paintingData.abstractName;
            }
        }

       
        private void OnEnable()
        {
            if(Mathf.Approximately(startPoint.x,0) && Mathf.Approximately(startPoint.y,0)) startPoint = rectTransform.anchoredPosition;
 
            rectTransform.anchoredPosition = startPoint;
            paintingData.abstractText = this;
            GetComponent<TextMeshProUGUI>().text = paintingData.abstractName;
        }

        private void OnDisable()
        {
            rectTransform.anchoredPosition = startPoint;
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
           base.OnBeginDrag(eventData);
           activeWordSocket = connectedWordSocket;
        }

        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            if (activeWordSocket != null)
            {
                activeWordSocket.ClearPaintCanvas();
                activeWordSocket = null;
                connectedWordSocket = null;
            }
        }


        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            if (eventData.pointerEnter == null)
            {
                rectTransform.anchoredPosition = startPoint;
                
            }
            else
            {
                if (eventData.pointerEnter.TryGetComponent(out TextMeshProUGUI _text))
                {
                    rectTransform.anchoredPosition = startPoint;
                    
                }
            }

            
            
           
        }
        
        public PaintingData DissolveImage(WordSocket _currentWordSocket)
        {
            connectedWordSocket = _currentWordSocket;
            return paintingData;
        }
    }
}
