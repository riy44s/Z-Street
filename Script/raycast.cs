using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public GameObject cub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //  RaycastHit hit; 
            if (Physics.Raycast(transform.position, cub.transform.up))
            {
                Debug.Log("hit");
            }
        }
    }
}
