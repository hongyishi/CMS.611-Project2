using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {
    private bool updownmove;
    private bool leftrightmove;

    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lastdir == Direction.Null && Input.GetKey(KeyCode.W))
            lastdir = Direction.Up;
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.A))
            lastdir = Direction.Left;
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.S))
            lastdir = Direction.Down;
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.D))
            lastdir = Direction.Right;
        if (lastdir == Direction.Up && Input.GetKeyUp(KeyCode.W))
            lastdir = Direction.Null;
        if (lastdir == Direction.Left && Input.GetKeyUp(KeyCode.A))
            lastdir = Direction.Null;
        if (lastdir == Direction.Down && Input.GetKeyUp(KeyCode.S))
            lastdir = Direction.Null;
        if (lastdir == Direction.Right && Input.GetKeyUp(KeyCode.D))
            lastdir = Direction.Null;
        if (lastdir == Direction.Up)
            transform.Translate(Vector2.up * Time.deltaTime);
        if (lastdir == Direction.Left)
            transform.Translate(Vector2.left * Time.deltaTime);
        if (lastdir == Direction.Down)
            transform.Translate(Vector2.down * Time.deltaTime);
        if (lastdir == Direction.Right)
            transform.Translate(Vector2.right * Time.deltaTime);

    }
}
