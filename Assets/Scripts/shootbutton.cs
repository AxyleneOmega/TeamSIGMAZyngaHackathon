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
        return this.gameObject.GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(Input.mousePosition);
    }
}