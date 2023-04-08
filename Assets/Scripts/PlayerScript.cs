using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Projectile laserPrefab;
    public TextMeshProUGUI[] score;
    public GameObject gameOverScreen;
    public bool laserActive { get; private set; }
    public float firingDelay = 1f;
    float timer;
    public bool gameRunning = true;
    private int currentScore = 0;
    private int highScore = 0;
    private int health = 3;
    private int difficulty = 0;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        health = 3;
        currentScore = 0;
        gameRunning = true;
        if (!PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
            highScore = currentScore;

        }
        gameRunning = false;
        Time.timeScale = 0;
    }
    void Update()
    {
        if (this.isActiveAndEnabled && Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                transform.position = new Vector2(touchPos.x, transform.position.y);
            }
        }
    }

    public void reduceHealth()
    {
        if(health > 0)
        {
            health -= 1;
        }
    }

    

    void FixedUpdate(){
        if (this.isActiveAndEnabled)
        {
            
            if (health <= 0)
            {
                GameOver();
            }
            float add = Time.fixedDeltaTime;
            difficulty = (int)add;
        }
    }
    
    public void incrementScore(int by)
    {
        currentScore += by;
        foreach(TextMeshProUGUI s in score)
        {
            s.SetText("Score: " + currentScore);
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
