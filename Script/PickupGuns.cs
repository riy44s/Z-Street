using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGuns : MonoBehaviour
{

    [Header("Riffle's")]
    public GameObject playerRifle;
    public GameObject playerSniper;
    public GameObject pickupRifle;
    //public PlayerPunch playerPuch;
   // public GameObject pickupUI;
   // public GameObject RifleUI;
   // public GameObject SniperUI;

    [Header("Rilfe Assign Things")]
    public PlayerMovement player;
    private float radious = 2.5f;
    // private float nextTimeToPunch = 0f;
    public float punchCharge = 15f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radious)
        {
          //  pickupUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && !playerSniper.activeInHierarchy)
            {
                playerSniper.SetActive(true);
                pickupRifle.SetActive(false);
               // SniperUI.SetActive(true);

                //sound

            }
            else if (Input.GetKeyDown(KeyCode.F) && playerSniper.activeInHierarchy)
            {
                playerSniper.SetActive(false);
              //  SniperUI.SetActive(false);
                playerRifle.SetActive(true);
                pickupRifle.SetActive(false);
              //  RifleUI.SetActive(true);
            }
        }
        else
        {
          //  pickupUI.SetActive(false);
        }
    }


    /*   public GunShooting gunSript;
       public Rigidbody rb;
       public BoxCollider coll;
       public Transform player, gunContainer, AimPos;

       public float pickUpRange;
       public float dropForwardForce, dropUpwardForce;

       public bool equipped;
       public static bool slotFull;

       private void Update()
       {
           Vector3 distancePlayer = player.position - transform.position;
           if (!equipped && distancePlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull) PickUp();

           if (equipped && Input.GetKeyDown(KeyCode.R)) Drop();
       }

       void PickUp()
       {
           equipped = true;
           slotFull = true;

           rb.isKinematic = true;
           coll.isTrigger = true;

           gunSript.enabled = true;
       }

       void Drop()
       {
           equipped = false;
           slotFull = false;

           rb.isKinematic = false;
           coll.isTrigger = false;

           gunSript.enabled = false;
       }
   */
}
