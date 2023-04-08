using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Screen.height + "x" + Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Scroll();
        }
    }

    private void Scroll()
    {
        transform.position += new Vector3(0, -Screen.width / 2 * Time.deltaTime);

        if (transform.position.y < -Screen.width)
        {
            transform.position = new Vector3(transform.position.x, Screen.width);
        }
    }
}
