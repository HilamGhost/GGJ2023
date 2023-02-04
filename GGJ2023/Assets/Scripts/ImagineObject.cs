using System.Collections;
using System.Collections.Generic;
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
        

        public override void Awake()
        {
            base.Awake();
            startPoint = rectTransform.anchoredPosition;
            paintingData.abstractText = this;
            paintingData.abstractName = GetComponent<TextMeshProUGUI>().text;

        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
           base.OnBeginDrag(eventData);
           activeWordSocket = connectedWordSocket;
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

            if (activeWordSocket != null)
            {
                activeWordSocket.ClearPaintCanvas();
                activeWordSocket = null;
                connectedWordSocket = null;
            }
            
           
        }
        
        public PaintingData DissolveImage(WordSocket _currentWordSocket)
        {
            connectedWordSocket = _currentWordSocket;
            return paintingData;
        }
    }
}
