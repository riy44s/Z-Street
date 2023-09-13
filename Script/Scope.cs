using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Scope : MonoBehaviour
{
    public Animator animator;
    private bool isScoped = false;
    public GameObject scopeOverlay;
    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scope", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnScoped();
        }
      
    }
  
    void OnUnScoped()
    {
        fpsCam.fieldOfView = 60;
        scopeOverlay.SetActive(false);       
        fpsCam.cullingMask = fpsCam.cullingMask | (1 << 31);
       
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);

        fpsCam.fieldOfView = 30;
        scopeOverlay.SetActive(true);
        fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 31);
       
    }
}

