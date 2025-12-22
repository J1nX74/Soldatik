using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


public class Player : MonoBehaviour
{
    public float speed = 5;
    Animator animator;
    public GameObject playerSprite;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        Move();
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
