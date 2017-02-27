using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour {
    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;
    private GameObject mySwitch = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.UpArrow))
            lastdir = Direction.Up;
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.LeftArrow))
            lastdir = Direction.Left;
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.DownArrow))
            lastdir = Direction.Down;
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.RightArrow))
            lastdir = Direction.Right;
        if (lastdir == Direction.Up && Input.GetKeyUp(KeyCode.UpArrow))
            lastdir = Direction.Null;
        if (lastdir == Direction.Left && Input.GetKeyUp(KeyCode.LeftArrow))
            lastdir = Direction.Null;
        if (lastdir == Direction.Down && Input.GetKeyUp(KeyCode.DownArrow))
            lastdir = Direction.Null;
        if (lastdir == Direction.Right && Input.GetKeyUp(KeyCode.RightArrow))
            lastdir = Direction.Null;
        if (lastdir == Direction.Up)
            transform.Translate(Vector2.up * Time.deltaTime);
        if (lastdir == Direction.Left)
            transform.Translate(Vector2.left * Time.deltaTime);
        if (lastdir == Direction.Down)
            transform.Translate(Vector2.down * Time.deltaTime);
        if (lastdir == Direction.Right)
            transform.Translate(Vector2.right * Time.deltaTime);
        if (mySwitch != null && Input.GetKeyDown(KeyCode.Return))
        {
            mySwitch.GetComponent<SwitchScript>().flipSwitch();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Switch")
            mySwitch = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Switch")
            mySwitch = null;
    }
}
