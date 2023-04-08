using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Projectile laserPrefab;
    public bool laserActive { get; private set; }
    public GameObject button;
    public float firingDelay = 1f;
    float timer;

    private void Start()
    {
    }

    void Update()
    {
        if (this.isActiveAndEnabled && Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                transform.position = new Vector2(touchPos.x, -4f);
            }
        }
    }

    void FixedUpdate(){
        if (this.isActiveAndEnabled)
        {
            /*timer += Time.deltaTime;
            if (timer >= 50 / fireRate)
            {
                Shoot();
                timer = 0;
            }*/
        }
    }
    
    public void startShooting()
    {
        StartCoroutine(Shoot());
    }
    public void stopShooting()
    {
        StopAllCoroutines();
    }

    IEnumerator Shoot()
    {
        bool isShooting = true;

        while (isShooting)
        {
            this.laserActive = true;
            Projectile laser = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            laser.destroyed += OnLaserDestroyed;
            yield return new WaitForSeconds(firingDelay);
        }
    }

    public void OnLaserDestroyed(Projectile laser)
    {
        this.laserActive = false;
    }
}
