using Rune.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rune.View{
    public class MergeAreaDropHandler : MonoBehaviour, IDropHandler{
        public GameObject DraggedObject, draggingIcon;
        
        public void OnDrop(PointerEventData eventData) {
            if (eventData.pointerDrag == null) return;
            FindObjectOfType<Manager>().AddToMergeArea(DraggedObject.GetComponent<Rune>());
            Destroy(draggingIcon);
        }
    }
}