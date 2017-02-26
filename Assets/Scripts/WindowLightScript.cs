using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLightScript : MonoBehaviour {
    public GameObject shadow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        Instantiate(shadow, other.gameObject.transform.position + new Vector3(5.0f, 0, 0), Quaternion.identity);
        if (other.tag == "Object")
        {
            Instantiate(shadow, other.gameObject.transform.position + new Vector3(5.0f, 0, 0), Quaternion.identity);
        }
    }
}
