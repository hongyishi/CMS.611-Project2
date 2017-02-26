using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {
    private bool updownmove = false;
    private bool leftrightmove = false;

    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;

    public GameObject box;
    private Vector3 initialposition;

    // Use this for initialization
	void Start () {
        initialposition = transform.position;
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
        if (lastdir == Direction.Up && !leftrightmove)
            transform.Translate(Vector2.up * Time.deltaTime);
        if (lastdir == Direction.Left && !updownmove)
            transform.Translate(Vector2.left * Time.deltaTime);
        if (lastdir == Direction.Down && !leftrightmove)
            transform.Translate(Vector2.down * Time.deltaTime);
        if (lastdir == Direction.Right && !updownmove)
            transform.Translate(Vector2.right * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && !updownmove && !leftrightmove)
        {
            if (lastdir == Direction.Down || lastdir == Direction.Up)
            {
                updownmove = true;
                box.transform.parent = this.transform;
            }
            else if (lastdir == Direction.Right || lastdir == Direction.Left)
            {
                leftrightmove = true;
                box.transform.parent = this.transform;
            }
        }
        else if (Input.GetKey(KeyCode.Space) && (updownmove || leftrightmove))
        {
            updownmove = false;
            leftrightmove = false;
            box.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WindowLight")
        {
            transform.position = initialposition;
            updownmove = false;
            leftrightmove = false;
            box.transform.parent = null;
        }
    }
}
