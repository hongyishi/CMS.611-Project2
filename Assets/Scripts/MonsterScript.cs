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

    private Vector3 initialposition;
    private GameObject box = null;

    public int speed = 1;

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
            transform.Translate(speed * Vector2.up * Time.deltaTime);
        if (lastdir == Direction.Left && !updownmove)
            transform.Translate(speed * Vector2.left * Time.deltaTime);
        if (lastdir == Direction.Down && !leftrightmove)
            transform.Translate(speed * Vector2.down * Time.deltaTime);
        if (lastdir == Direction.Right && !updownmove)
            transform.Translate(speed * Vector2.right * Time.deltaTime);


        if (box != null && Input.GetKeyDown(KeyCode.E) && (updownmove || leftrightmove))
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
        if ((!inShadow && collision.tag == "WindowLight") || collision.tag == "CeilingLight")
        {
            if (box != null)
            {
                updownmove = false;
                leftrightmove = false;
                box.transform.parent = null;
            }
            transform.position = initialposition;
        }
        if (collision.gameObject.tag == "Box" && Input.GetKeyDown(KeyCode.Space) && !updownmove && !leftrightmove)
        {
            if ((Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.up)) < 45) ||
                (Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.down)) < 45))
            {
                updownmove = true;

                collision.gameObject.transform.parent = this.transform;
                box = collision.gameObject;
            }
            else if ((Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.left)) < 45) ||
               (Mathf.Abs(Vector2.Angle((collision.transform.position - this.transform.position), Vector2.right)) < 45))
            {
                leftrightmove = true;

                collision.gameObject.transform.parent = this.transform;
                box = collision.gameObject;
            }
        }
    }
}
