using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


public class Player : MonoBehaviour
{
    public float reloadTime;
    float shotTime = Mathf.Infinity;
    bool canShot = false;

    public Bullet bullet;
    public Transform bulletSpawn;
    public float speed = 5;
    Animator animator;
    public GameObject playerSprite;
    AudioSource audioSource;
    public Transform startPoint;
    public Transform finishPoint;
    public GameManager gameManager;


    void StartMove()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameManager = FindFirstObjectByType<GameManager>();
    }


    void Update()
    {
        Move();
        Shot();
        CanShot();
    }

    void Shot()
    {
        if (Input.GetMouseButton(0) && canShot) 
        {
            canShot = false;
            Bullet bull = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            bull.gameObject.transform.Rotate(bulletSpawn.rotation.eulerAngles, Space.World);
            bull.SetDirection(bulletSpawn.right); 
        }
    }

    void CanShot()
    {
        if (canShot) return;
        shotTime += Time.deltaTime;
        if (shotTime > reloadTime)
        {
            shotTime = 0;
            canShot = true;
        }
    }

    private void Move()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerSprite.transform.position;
        playerSprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, difference);

        float translation = speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0,translation, 0);
            animator.SetBool("IsMove", true);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, -translation, 0);
            animator.SetBool("IsMove", true);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-translation, 0, 0);
            animator.SetBool("IsMove", true);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(translation, 0, 0);
            animator.SetBool("IsMove", true);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        else
        {
            animator.SetBool("IsMove", false);
            audioSource.Stop();
        }
    
    }
}
