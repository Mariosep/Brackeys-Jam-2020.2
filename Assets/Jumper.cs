using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    AudioSource audio_source;
    Animator animator;

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
     {

         if (collision.collider.CompareTag("Player"))
         {
            audio_source.Play();
            animator.SetTrigger("Jump");
         }
     }
}
