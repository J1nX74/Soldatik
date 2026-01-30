using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float damage = 10;
    [SerializeField] float speed = 2;
    GameObject player;
    Animator animator;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) > 1)
        {
            animator.SetBool("IsAttack", false);
            Vector2 direction = player.transform.position - gameObject.transform.position;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsAttack", true);
            print("52");
        }
    }

    public void Attack()
    {
        Health hpScript = player.GetComponent<Health>();

        if (hpScript != null)
        {
            hpScript.ChangeHP(damage);
        }
    }
}
