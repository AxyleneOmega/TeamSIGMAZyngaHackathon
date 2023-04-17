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
    public bool gameRunning = true;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int highScore = 0;
    [SerializeField] private int health = 3;
    private bool canBeHitByMeteor;
    private Animator shipAnimator;
    float timer;
    private bool isAlive=true;

    private void Start()
    {
        shipAnimator = gameObject.GetComponent<Animator>();
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        health = 3;
        isAlive = true;
        currentScore = 0;
        gameRunning = true;
        canBeHitByMeteor = true;
        if (!PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

    IEnumerator GameOver()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        gameRunning = false;
        FindAnyObjectByType<GameplayManager>().StopGame();
        yield return new WaitForSeconds(0.5f);
        gameOverScreen.SetActive(true);
        Debug.Log("game over after");        
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
        if (canBeHitByMeteor) { }
        if(health > 0)
        {
            this.health--;
        }
    }

    

    void FixedUpdate(){
        if (this.isActiveAndEnabled)
        {
            shipAnimator.SetInteger("Health", this.health);
            if (health <= 0 && isAlive)
            {
                StopAllCoroutines();
                StartCoroutine(GameOver());
                isAlive = false;
            }
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
