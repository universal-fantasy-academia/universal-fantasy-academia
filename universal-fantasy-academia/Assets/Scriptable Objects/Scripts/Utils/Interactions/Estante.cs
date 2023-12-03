using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estante : Interactable
{
    public Animator animator;
    public AudioSource audio;

    void Awake()
    {
        interactDelegate += AbrirEstante;
    }

    void AbrirEstante()
    {
        animator.SetTrigger("Active");
        if(audio != null)
        audio.Play();
    }

    void Disable()
    {
        interactDelegate -= AbrirEstante;
    }

}
