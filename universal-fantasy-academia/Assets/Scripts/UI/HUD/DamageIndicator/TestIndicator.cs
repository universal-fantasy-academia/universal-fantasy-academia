using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndicator : MonoBehaviour
{
    [Range(5, 30)]
    [SerializeField] float destroyTimer = 15.0f;

    void Start()
    {
        Invoke("Register", Random.Range(0, 8f));
    }

    void Register()
    {
        if(!DI_System.CheckIfObjectInSight(this.transform))
        {
            DI_System.CreateIndicator(this.transform);
        }
        Destroy(this.gameObject, destroyTimer);
    }
}
