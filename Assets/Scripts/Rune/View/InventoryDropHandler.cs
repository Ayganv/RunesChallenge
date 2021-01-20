using System;
using Rune.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rune.View{
    
    public class InventoryDropHandler : MonoBehaviour, IDropHandler{
        
        public GameObject DraggedObject, draggingIcon;
        
        public void OnDrop(PointerEventData eventData){
            if(eventData.pointerDrag != null)
            {
                Debug.Log(eventData.ToString());
                
                FindObjectOfType<Manager>().RemoveFromMergeArea(DraggedObject.GetComponent<Rune>());
                Destroy(draggingIcon);
            }
        }
    }
}