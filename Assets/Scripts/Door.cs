using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    private bool isopen = false;
    private bool isready = true;
    private Animator animator;
    private AudioSource source;
    public AudioClip opening;
    public AudioClip closing;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void Using()
    {
        if (isready)
        {
            isready = false;

            if (isopen)
            {
                Closing();
            }
            else
            {
                Opening();
            }

            Invoke("Ready", 0.5f);
        }
    }

    private void Opening()
    {
        animator.SetInteger("state", 1);
        isopen = true;
        source.PlayOneShot(opening);
    }

    private void Closing()
    {
        animator.SetInteger("state", 0);
        isopen = false;
        source.PlayOneShot(closing);
    }

    private void Ready()
    {
        isready = true;
    }
}
