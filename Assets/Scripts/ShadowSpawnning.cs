using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawnning : MonoBehaviour {

    public GameObject shadow;

    private GameObject myshadow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        myshadow = Instantiate(shadow, this.transform.position + new Vector3(0.5f*this.transform.lossyScale.x + 0.5f*shadow.transform.lossyScale.x, 0,0), Quaternion.identity);
        myshadow.transform.parent = this.transform;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(myshadow);
    }
}
