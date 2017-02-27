using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private bool updownmove = false;
    private bool leftrightmove = false;

    private bool inShadow = false;

    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;

    public GameObject box;
    private Vector3 initialposition;

    // Use this for initialization
    void Start()
    {
        initialposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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


        if (Input.GetKeyDown(KeyCode.E) && (updownmove || leftrightmove))
        {
            updownmove = false;
            leftrightmove = false;
            box.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shadow")
        {
            inShadow = true;
        }
        if ((!inShadow && other.tag == "WindowLight") || other.tag == "CeilingLight")
        {
            transform.position = initialposition;
            updownmove = false;
            leftrightmove = false;
            box.transform.parent = null;
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Shadow")
        {
            inShadow = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" && Input.GetKeyDown(KeyCode.Space) && !updownmove && !leftrightmove)
        {
            if (Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.up)) < 45 ||
                Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.down)) < 45)
            {
                updownmove = true;
                collision.gameObject.transform.parent = this.transform;
            }
            else if (Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.left)) < 45 ||
                Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.right)) < 45)
            {
                leftrightmove = true;
                collision.gameObject.transform.parent = this.transform;
            }
        }
    }
}
