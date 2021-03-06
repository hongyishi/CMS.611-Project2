﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawnning : MonoBehaviour {

    public GameObject shadow;

    private GameObject myShadow;
    private bool hasShadow = false;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.parent != null)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        transform.localPosition = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasShadow && collision.tag == "WindowLight")
        {
            hasShadow = true;
            Vector2 dir = collision.gameObject.GetComponent<WindowLightScript>().direction;
            myShadow = Instantiate(shadow, (Vector2)this.transform.position + dir.normalized*(0.5f * this.transform.lossyScale.x + 0.5f * shadow.transform.lossyScale.x), Quaternion.FromToRotation(Vector2.right,dir));
            myShadow.transform.parent = this.transform;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (hasShadow && collision.tag == "WindowLight")
        {
            Destroy(myShadow);
            hasShadow = false;
        }
    }
}
