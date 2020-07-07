using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        Draggable card = eventData.pointerDrag.GetComponent<Draggable>();
        if(card != null)
        {
            card.parentToReturn = transform; // No nosso caso, a carta vai ser usada e não puxada
        }

    }


}
