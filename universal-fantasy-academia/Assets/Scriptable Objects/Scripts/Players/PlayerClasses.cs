using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerClasses : MonoBehaviour
{
    public Transform weaponParent;
    [HideInInspector]
    public GameObject currentWeapon;


    public void ChangeWeapon(GameObject weaponPrefeb)
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        if (weaponPrefeb == null)
        {
            return;
        }

        currentWeapon = Instantiate(weaponPrefeb);
        currentWeapon.transform.parent = weaponParent;
        currentWeapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }


    public abstract void Attack(InputAction.CallbackContext context, ShotController shot);

    public abstract void Block(InputAction.CallbackContext context);

}
