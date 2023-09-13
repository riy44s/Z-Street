
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    EnemyFall enemyFall;
    public GameObject mainCanvas;
    private void Start()
    {
        enemyFall = GetComponent<EnemyFall>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            EnemyDeath();
            mainCanvas.GetComponent<score>().enemyDead();
        }
    }  
    void EnemyDeath()
    {
        enemyFall.TriggerRagdoll(true);
    }

}
