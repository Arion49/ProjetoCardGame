using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturn = null;

    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");

        placeholder = new GameObject(); //Criando um placeholder de onde a carta estava, permitindo que ela volte para o mesmo lugar de onde foi tirada
        placeholder.transform.SetParent(transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());


        parentToReturn = transform.parent;
        transform.SetParent(transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false; //Com isso, a carta só receberá os raycasts antes de ser pega, permitindo que o raycast atinja a mesa, fazendo
        //com que o OnDrop da DropZone funcione
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("Dragging");
        transform.position = eventData.position;

        int newSiblingIndex = parentToReturn.childCount; //Dessa forma assumimos que vamos colocar a carta mais a direita possível por padrão, já que o método de olhar
        //a  esquerda não funcionaria na direita máxima

        for (int i = 0; i < parentToReturn.childCount; i++) //Fazendo um loop na mão para ver cada filho dela
        {
            if(transform.position.x < parentToReturn.GetChild(i).position.x) //Se a carta segurada estiver mais a esquerda do que aquele filho
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                
                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex); //O placeholder "troca" de lugar com a carta da mão
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentToReturn);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
