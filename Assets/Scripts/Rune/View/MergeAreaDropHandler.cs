using System;
using Rune.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rune.View{
    
    public class MergeAreaDropHandler : MonoBehaviour, IDropHandler{
        
        public GameObject DraggedObject;
        
        public void OnDrop(PointerEventData eventData){
            if(eventData.pointerDrag != null)
            {
                Debug.Log(eventData.ToString());
                
                FindObjectOfType<Manager>().AddToMergeArea(DraggedObject.GetComponent<Rune>());
            }
        }
    }
}