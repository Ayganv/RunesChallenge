using Rune.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rune.Controller
{
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
        public bool dragOnSurfaces = true;

        public GameObject m_DraggingIcon;
        private RectTransform m_DraggingPlane;

        public void OnBeginDrag(PointerEventData eventData){
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        
            var canvas = FindInParents<Canvas>(gameObject);
            if (canvas == null)
                return;

            // We have clicked something that can be dragged.
            // What we want to do is create an icon for this.
            m_DraggingIcon = Instantiate(gameObject, canvas.transform, false);
            m_DraggingIcon.GetComponent<Rune.View.Rune>().QuantityDisplayTextToggle(false);
            m_DraggingIcon.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
            m_DraggingIcon.transform.SetAsLastSibling();
            m_DraggingPlane = transform as RectTransform;

            FindObjectOfType<MergeAreaDropHandler>().DraggedObject = gameObject;
            FindObjectOfType<InventoryDropHandler>().DraggedObject = gameObject;
            FindObjectOfType<InventoryDropHandler>().draggingIcon = m_DraggingIcon;
            FindObjectOfType<MergeAreaDropHandler>().draggingIcon = m_DraggingIcon;
            SetDraggedPosition(eventData);
        }

        public void OnDrag(PointerEventData data){
            if (m_DraggingIcon != null)
                SetDraggedPosition(data);
        }

        private void SetDraggedPosition(PointerEventData data){
            if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
                m_DraggingPlane = data.pointerEnter.transform as RectTransform;

            var rt = m_DraggingIcon.GetComponent<RectTransform>();
            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position,
                data.pressEventCamera, out globalMousePos)){
                rt.position = globalMousePos;
                rt.rotation = m_DraggingPlane.rotation;
            }
        }

        public void OnEndDrag(PointerEventData eventData){

            if (m_DraggingIcon != null)
                Destroy(m_DraggingIcon);

            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        static public T FindInParents<T>(GameObject go) where T : Component{
            if (go == null) return null;
            var comp = go.GetComponent<T>();

            if (comp != null)
                return comp;

            Transform t = go.transform.parent;
            while (t != null && comp == null){
                comp = t.gameObject.GetComponent<T>();
                t = t.parent;
            }

            return comp;
        }
    }
}