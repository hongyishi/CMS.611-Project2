using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

    public GameObject Kid;
    public GameObject Monster;
    public Text winText;

    // Use this for initialization
    void Start () {
        winText.text = "";
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Kid"))
        {
            other.gameObject.SetActive(false);
        }
        if (!Kid.activeSelf && !Monster.activeSelf)
        {
            winText.text = "You win!";
        }
    }
}
