using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    private bool on = true;
    public GameObject[] allCeilingLights;

    // Use this for initialization
    void Start () {
        allCeilingLights = GameObject.FindGameObjectsWithTag("CeilingLight");

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            if (on)
            {
                foreach (GameObject ceilingLight in allCeilingLights)
                {
                    ceilingLight.SetActive(false);
                }
                on = false;
            }
            else
            {
                foreach (GameObject ceilingLight in allCeilingLights)
                {
                    ceilingLight.SetActive(true);
                }
                on = true;
            }
        }
	}
}
