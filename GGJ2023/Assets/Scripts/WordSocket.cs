using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace CrabNine
{
    public class WordSocket : MonoBehaviour,IDropHandler
    {
        [SerializeField] private int wordSocket;
        [SerializeField] private bool isFull;

        public bool IsFull => isFull;
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
               
                Debug.Log("Is Dropped");
                if (eventData.pointerDrag.TryGetComponent(out ImagineObject _imagineObject))
                {
                    if (!isFull)
                    {
                        PaintingCanva.Instance.ChangePaintingData(wordSocket,_imagineObject.DissolveImage(this));
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                            GetComponent<RectTransform>().anchoredPosition;
                    
                        PaintingCanva.Instance.ApplyImages();
                        isFull = true;
                    }
                    else
                    {
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                            _imagineObject.StartPoint;
                    }
                    
                }
            }
            
            
        }

        public void ClearPaintCanvas()
        {
            Debug.Log("Canvas Deleted");
            PaintingCanva.Instance.ClearCanvas(wordSocket);
            isFull = false;
        }
        
    }
}
