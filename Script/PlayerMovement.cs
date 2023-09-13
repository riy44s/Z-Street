using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController character;
    public float speed=15f;
    public float gravity = -9.81f;
    Vector3 Velocity;
    public Vector3 moveDirection;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHieght = 3f;

    MovementBase currentStates;
    public idle idlee =new idle();
    public Walk walk = new Walk();
    [HideInInspector] public Animator anim;

    public int maxHealth=100 ;
    public int currentHealth=20;
    public HealthBar healthBar;

     GameOver gameOverScreen;

    private int zombiesKilled = 0;
    public int zombiesToWin = 10;

    void Start()
    {       
        anim =GetComponent<Animator>();
        
        healthBar.SetMaxHealth(maxHealth);
        SwitchState(idlee);
    }

  
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        moveDirection = transform.forward * x + transform.right * -z;
        character.Move(moveDirection *speed *Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(jumpHieght * -2f * gravity);
        }
        Velocity.y += gravity * Time.deltaTime;
        character.Move(Velocity * Time.deltaTime);

        anim.SetFloat("x", x);
        anim.SetFloat("z", z);

        currentStates.UpdateState(this);

    }

    public void SwitchState(MovementBase state)
    {
        currentStates = state;
        currentStates.EnterState(this);
    }
  
    public void TakeDamagePlayer(int damage)
    {    
        maxHealth -= damage;
        Debug.Log("Death");
        if (maxHealth <= 0)
        {
            enabled = false;
            character.enabled = false;
            GunShooting gun = GetComponentInChildren<GunShooting>();
            if (gun != null)
            {
                gun.enabled = false;
            }

            /* Target target = GetComponent<Target>();
             if (target != null)
             {
                 target.enabled = false;
             }*/
            anim.SetBool("Death", true);
            GameOverScreen();
        }
        

        healthBar.SetHealth(maxHealth);
        

    }

    public void GameOverScreen()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ZombieKilled()
    {
        zombiesKilled++;
        if (zombiesKilled >= zombiesToWin)
        {
            WinGame();
        }
    }
    private void WinGame()
    {
        SceneManager.LoadScene("LevelComplete"); 
    }

}
