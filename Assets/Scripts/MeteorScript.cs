using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public int MeteorHealth = 1;
    public int scoreAdded = 10;
    public float Speed = 5f;
    bool isAlive = true;
    public System.Action<MeteorScript> destroyed;
    public new CircleCollider2D collider { get; private set; }
    public Animator animator;
    bool killed = false;

    private void Start()
    {
        killed = false;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isAlive", true);
    }

    private void Update()
    {
        if (MeteorHealth <= 0)
        {
            isAlive = false;
        }
    }

    private void FixedUpdate()
    {
        if (this.isActiveAndEnabled)
        {
            move();
            
        }
        if (!isAlive && !killed)
        {
            animator.SetBool("isAlive", false);
            killed = true;
            StartCoroutine(Kill());
        }
    }

    void move()
    {
        if (isAlive)
        {
            transform.position -= new Vector3(0, Speed * 0.1f * Time.deltaTime);
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<PlayerScript>().incrementScore(scoreAdded);
        Destroy(this.gameObject);   
    }
    private void OnDestroy()
    {
        if (this.destroyed != null)
        {
            this.destroyed.Invoke(this);
        }
    }
    private void CheckCollision(Collider2D other)
    {
        if (other.gameObject.tag == "laser")
        {
            MeteorHealth -= 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().reduceHealth();
            animator.SetBool("isAlive", false);
            isAlive = false;
        }
        if (other.gameObject.tag == "bottomBorder")
        {
            FindObjectOfType<PlayerScript>().incrementScore(5);
            isAlive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

}
