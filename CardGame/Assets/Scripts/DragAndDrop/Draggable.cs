using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturn = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");

        parentToReturn = transform.parent;
        transform.SetParent(transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false; //Com isso, a carta só receberá os raycasts antes de ser pega, permitindo que o raycast atinja a mesa
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("Dragging");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentToReturn);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
