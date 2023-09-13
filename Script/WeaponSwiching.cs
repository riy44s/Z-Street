
using UnityEngine;
using TMPro;
public class WeaponSwiching : MonoBehaviour
{
    public int selectWeapon = 0;
    public TextMeshProUGUI ammoText;
    void Start()
    {
        SelectWeapon();
    }

   
    void Update()
    {
        GunShooting currentGun = FindAnyObjectByType<GunShooting>();
        ammoText.text = currentGun.currentAmmo + " / " + currentGun.magazineSize;
       
        int previousSelectedWeapon = selectWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectWeapon >= transform.childCount  + 1)
                selectWeapon = 0;
            else
                selectWeapon=+1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectWeapon <= 0)
                selectWeapon = transform.childCount - 1;

            else
                selectWeapon--;
        }

        if(previousSelectedWeapon != selectWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
