using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.height + "x" + Screen.width);
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += new Vector3(0 , -500 * Time.deltaTime);

        if (transform.position.y < -1080)
        {
            transform.position = new Vector3(transform.position.x , 1080f);
        }
        
    }
}
