using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerClasses : MonoBehaviour
{
    public abstract void Attack(InputAction.CallbackContext context, ShotController shot);

    public abstract void Block(InputAction.CallbackContext context);
}
