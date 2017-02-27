using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    private bool on = true;
    public GameObject[] allCeilingLights;
    public Sprite onSprite;
    public Sprite offSprite;

    // Use this for initialization
    void Start()
    {
        allCeilingLights = GameObject.FindGameObjectsWithTag("CeilingLight");

    }
    public void flipSwitch()
    {
        if(GetComponent<SpriteRenderer>().sprite == onSprite)
        {
            GetComponent<SpriteRenderer>().sprite = offSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = onSprite;
        }

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
