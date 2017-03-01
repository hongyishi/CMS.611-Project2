using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScript : MonoBehaviour {

    public Image HelpMenu;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("H"))
        {
            if (HelpMenu.IsActive())
            {
                HelpMenu.gameObject.SetActive(false);
            }
            else
            {
                HelpMenu.gameObject.SetActive(true);
            }
        }

    }
}
