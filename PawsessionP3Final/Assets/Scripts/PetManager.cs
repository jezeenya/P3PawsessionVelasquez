using System;
using UnityEngine;

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
        animator.SetBool("IsDead", true);
    }

}
