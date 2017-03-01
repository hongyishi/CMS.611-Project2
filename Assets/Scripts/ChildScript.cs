using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour {
    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;
    private GameObject mySwitch = null;
    private List<GameObject> collideList = new List<GameObject>();
    private GameObject box = null;
    bool leftrightmove = false;
    bool updownmove = false;

    public float speed = 1;

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
        if (lastdir == Direction.Up && !leftrightmove)
            transform.Translate(speed * Vector2.up * Time.deltaTime);
        if (lastdir == Direction.Left && !updownmove)
            transform.Translate(speed * Vector2.left * Time.deltaTime);
        if (lastdir == Direction.Down && !leftrightmove)
            transform.Translate(speed * Vector2.down * Time.deltaTime);
        if (lastdir == Direction.Right && !updownmove)
            transform.Translate(speed * Vector2.right * Time.deltaTime);
        if (box != null && Input.GetKeyDown(KeyCode.Return) && (updownmove || leftrightmove))
        {
            updownmove = false;
            leftrightmove = false;
            box.transform.parent = null;
            box = null;
            return;
        }
        if (mySwitch != null && Input.GetKeyDown(KeyCode.Return))
        {
            mySwitch.GetComponent<SwitchScript>().flipSwitch();
        }
        foreach (GameObject g in collideList)
        {
            if (box == null && g != null && g.tag == "SmallBox" && Input.GetKeyDown(KeyCode.Return) && !updownmove && !leftrightmove)
            {
                if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.up)) < 45)
                {
                    updownmove = true;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.down)) < 45)
                {
                    updownmove = true;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.left)) < 45)
                {
                    leftrightmove = true;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.right)) < 45)
                {
                    leftrightmove = true;
                    g.transform.parent = this.transform;
                    box = g;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Switch")
            mySwitch = other.gameObject;
        collideList.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Switch")
            mySwitch = null;
        collideList.Remove(other.gameObject);
    }

}
