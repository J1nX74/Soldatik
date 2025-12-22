using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        rb.linearVelocity = direction.normalized * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletDestroy"))
        {
            Destroy(gameObject);
        }
    }
}
