using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 20.0f;
    public Vector3 direction = Vector3.up;
    public System.Action<Projectile> destroyed;
    public new BoxCollider2D collider { get; private set; }

    private void Awake()
    {
        this.collider = GetComponent<BoxCollider2D>();
    }

    private void OnDestroy()
    {
        if (this.destroyed != null) {
            this.destroyed.Invoke(this);
        }
    }

    private void Update()
    {
        if (this.isActiveAndEnabled)
        {
            ShootProjectile();
        }
    }
    private void ShootProjectile()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void CheckCollision(Collider2D other)
    {
        if (other.gameObject.tag == "border")
        {
            Destroy(gameObject);
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
