using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicmove : MonoBehaviour
{

    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        
                        transform.position = new Vector2(touchPos.x , -4f );

                    }

        }

        
    }
}
