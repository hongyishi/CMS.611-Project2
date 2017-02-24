using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobility : MonoBehaviour {

    public float speed;

    void FixedUpdate()
    {
        float leftValue;
        float rightValue;
        float upValue;
        float downValue;

        if (Input.GetKey("left"))
        {
            leftValue = left
        }else
        {
            leftValue = Vector3(0,0,0)
        }
        float leftValue = Input.GetKey("left");
        float rightValue = Input.GetKey("right");
        float upValue = Input.GetKey("up");
        float downValue = Input.GetKey("down");
        Quaternion rot = Quaternion.LookRotation()
    }
}
