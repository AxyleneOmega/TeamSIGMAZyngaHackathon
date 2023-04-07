using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootbutton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public bool shooting = false;

    public void OnPointerDown(PointerEventData eventData)
    {   
        shooting = true;
        FindObjectOfType<basicmove>().Shoot();
    }

      
    public void OnPointerUp(PointerEventData eventData)
    {
        shooting = false;
      

    }
 


}