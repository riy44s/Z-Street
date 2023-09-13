using UnityEngine;
using System.Collections;
public class GunShooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject shoot;
    public ParticleSystem shootingEffect;
    public float ImpactForce = 30f;

    public AudioSource audio1;

    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineSize = 30;

    public float reloadTime = 2f;
    private bool isReloading;

    public Animator animator;
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }

    void Update()
    {
        if(currentAmmo ==0 && magazineSize == 0)
        {
            return;
        }

        if (isReloading)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audio1.Play();
           
        }

        if(currentAmmo ==0 && magazineSize>0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        shootingEffect.Play();
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(shoot.transform.position, shoot.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            Vector3 hitpoint = hit.point;
            Debug.DrawLine(shoot.transform.position, hitpoint, Color.red);
            if (enemy != null)
            {
                enemy.TakeDamageEnemy(10);
              
            }
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody!= null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("isReloading", false);
        if (magazineSize >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isReloading = false;
    }
}