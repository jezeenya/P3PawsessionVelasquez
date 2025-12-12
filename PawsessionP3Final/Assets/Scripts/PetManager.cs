using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PetManager : MonoBehaviour
{
    public static PetManager Instance;
    public Animator animator;

    void Awake()
    {
        Instance = this;
    }
    
    
    

    void Update()
    {

    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public void Die()
    {
        Debug.Log("Tama has died :(");
        animator.SetTrigger("IsDead");
        

    }

   
}
