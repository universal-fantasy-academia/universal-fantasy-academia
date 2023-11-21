using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObject : Player
{
    public float coolDownTime = 0.1f;
    private float nextFireTime = 0.2f;
    public static int numberOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.3f;


    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            numberOfClicks = 0;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        base.animator.SetBool("hit1", false);
        base.animator.SetBool("hit2", false);
        base.animator.SetBool("hit3", false);
        base.animator.SetBool("hit4", false);
        yield return new WaitForSeconds(coolDownTime);
    }

    public void PlayAttackAnimation()
    {
        if (!base.animator)
        {
            base.UpdateAnimator();
        }
        //base.animator.SetTrigger(attackBoolAnimator);

        lastClickedTime = Time.time;
        numberOfClicks++;

        Debug.Log(numberOfClicks);


        if (numberOfClicks ==  1)
        {
            base.animator.SetBool("hit1", true);
            base.animator.SetBool("hit2", false);
            base.animator.SetBool("hit3", false);
            base.animator.SetBool("hit4", false);
        }
        //numberOfClicks = Mathf.Clamp(numberOfClicks, 0, 3);

        if (numberOfClicks >= 2 && base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            base.animator.SetBool("hit1", false);
            base.animator.SetBool("hit2", true);
            base.animator.SetBool("hit3", false);
            base.animator.SetBool("hit4", false);
        }

        if (numberOfClicks >= 3 && base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            base.animator.SetBool("hit1", false);
            base.animator.SetBool("hit2", false);
            base.animator.SetBool("hit3", true);
            base.animator.SetBool("hit4", false);
        }

        if (numberOfClicks >= 4 && base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            base.animator.SetBool("hit1", false);
            base.animator.SetBool("hit2", false);
            base.animator.SetBool("hit3", false);
            base.animator.SetBool("hit4", true);
            numberOfClicks = 0;
        }

        
    }


    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            // base.selectedPlayerClass = playerSlot.GetComponentInChildren<PlayerClasses>();
            // base.selectedPlayerClass.Attack(context, shot);
            // base.PlayAttackAnimation();

            if (Time.time > nextFireTime)
            {
                Debug.Log("Atacando com a espada");
                PlayAttackAnimation();
                //StartCoroutine(CoolDown());
            }

            // if (base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
            // {
            //     base.animator.SetBool("hit1", false);
            // }

            // if (base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
            // {
            //     base.animator.SetBool("hit2", false);
            // }

            // if (base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
            // {
            //     base.animator.SetBool("hit3", false);
            // }

            // if (base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && base.animator.GetCurrentAnimatorStateInfo(0).IsName("hit4"))
            // {
            //     base.animator.SetBool("hit4", false);
            //     numberOfClicks = 0;
            // }

            if (Time.time - lastClickedTime > maxComboDelay)
            {
                numberOfClicks = 0;
                StartCoroutine(CoolDown());
            }

            

        }
    }

    public void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            base.selectedPlayerClass = playerSlot.GetComponentInChildren<PlayerClasses>();
            base.selectedPlayerClass.Block(context);
        }
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Fantasma"))
    //     {
    //         TakeDamage(5);
    //     }
    // }


}
