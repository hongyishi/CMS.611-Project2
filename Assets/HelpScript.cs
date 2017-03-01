using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public Sprite EmptySprite;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("H"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = EmptySprite;
        }

    }
}
