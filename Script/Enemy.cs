using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 Velocity;
    public float gravity = -9.81f;

    public CharacterController character;
   
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public NavMeshAgent enemy;
    public Transform PlayerTarget;

    EnemyFall enemyFall;
    PlayerMovement player;

    Animator anim;

    AudioSource audio1;
    public ParticleSystem particle;
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemy = GetComponent<NavMeshAgent>();
        enemyFall = GetComponent<EnemyFall>();

    }

 
    void Update()
    {
        enemy.SetDestination(PlayerTarget.position);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        Velocity.y += gravity * Time.deltaTime;
        character.Move(Velocity * Time.deltaTime);

        Vector3 moveDirection = (transform.position - transform.forward *moveSpeed).normalized;
        transform.Translate(moveDirection * moveSpeed *Time.deltaTime);
       
    }
   
   
    public void TakeDamageEnemy(int damage)
    {
        particle.Play();
        currentHealth -= damage;
     
   
        if (currentHealth <= 0)
        {
            audio1.Stop();  
            enabled = false;
           this.gameObject.GetComponent<BoxCollider>().enabled = false;
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
           
                player.ZombieKilled();
            
           
           
        }
        if (healthBar != null)
        {
            Destroy(healthBar.gameObject); 
        }
        healthBar.SetHealth(currentHealth);

    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.TakeDamagePlayer(player.currentHealth);
            }
        }
    }

}
