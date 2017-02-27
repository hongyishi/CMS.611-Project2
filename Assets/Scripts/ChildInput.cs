using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInput : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.left * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.down * Time.deltaTime);
		} 
	}
}
