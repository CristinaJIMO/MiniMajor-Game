using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Instance : MonoBehaviour
{
    public float multiplicadorGravedad = 20f;
    void Start () 
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / multiplicadorGravedad;
    }
    void Update()
    {
        if (transform.position.y < -2f) 
        {
            Destroy(gameObject);
        }
    }
}
