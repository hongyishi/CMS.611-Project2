using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
