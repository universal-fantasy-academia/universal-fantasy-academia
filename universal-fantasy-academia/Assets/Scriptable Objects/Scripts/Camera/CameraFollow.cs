using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float time = .3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += player.transform.position - ;
        transform.position = Vector3.Lerp(transform.position, player.transform.position, time);

        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, time);
    }
}
