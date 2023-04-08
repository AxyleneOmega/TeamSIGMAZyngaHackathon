using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootbutton : MonoBehaviour
{
    public bool isShooting;
    private void Start()
    {
        isShooting = false;
    }
    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && (!isShooting) && isValid())
        {
            FindObjectOfType<PlayerScript>().startShooting();
            isShooting = true;
        }
        if(Input.GetMouseButtonUp(0) && (isShooting) && isValid())
        {
            FindObjectOfType<PlayerScript>().stopShooting();
            isShooting = false;
        }
    }

    private bool isValid()
    {
        int offset = 120;
        if (
        Input.mousePosition.x < this.gameObject.transform.position.x + offset &&
        Input.mousePosition.x > this.gameObject.transform.position.x - offset &&
        Input.mousePosition.y < this.gameObject.transform.position.y + offset &&
        Input.mousePosition.y > this.gameObject.transform.position.y - offset
        ) { return true;}
        else
        {
            return false;
        }

    }
}