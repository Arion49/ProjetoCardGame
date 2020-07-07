using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentToReturn = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        parentToReturn = transform.parent;
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentToReturn);
    }
}
