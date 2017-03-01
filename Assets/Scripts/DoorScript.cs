using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Level2Scene");
        }
    }
}
