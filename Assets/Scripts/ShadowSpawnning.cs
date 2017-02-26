using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadownSpawnning : MonoBehaviour {

    public GameObject shadow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnShadow()
    {
        Instantiate(shadow, this.transform.position + new Vector3(5.0f, 0, 0), Quaternion.identity);
    }
}
