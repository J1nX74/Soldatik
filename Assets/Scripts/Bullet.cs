using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody2D rb;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void SetDirection(Vector3 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        rb.linearVelocity = direction.normalized * speed;
        print("kotopes");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health hpScript = collision.GetComponent<Health>();

            if (hpScript != null)
            {
                hpScript.ChangeHP(damage);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletDestroy"))
        {
            Destroy(gameObject);
        }
    }
}
