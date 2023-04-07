using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basicmove : MonoBehaviour
{

    public Projectile laserPrefab;
    public bool laserActive { get; private set; }
    public GameObject button;
    public int fireRate = 20;
    float timer;

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

    void FixedUpdate(){
        timer += Time.deltaTime;
        if(timer >= 10/fireRate){
            Shoot();
            timer -= 10/fireRate;
        }
    }
    
    public void Shoot()
    {
        // Only one laser can be active at a given time so first check that
        // there is not already an active laser
        if (button.GetComponent<shootbutton>().shooting == true)
        {
            this.laserActive = true;
            Projectile laser = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            laser.destroyed += OnLaserDestroyed;
        }
    }

    public void OnLaserDestroyed(Projectile laser)
    {
        this.laserActive = false;
    }
}
