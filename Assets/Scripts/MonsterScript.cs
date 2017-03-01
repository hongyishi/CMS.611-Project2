using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private bool updownmove = false;
    private bool leftrightmove = false;
    public Sprite Idle;
    public Sprite pushDown;
    public Sprite pushUp;
    public Sprite pushRight;
    public Sprite pushLeft;

    private bool inShadow = false;

    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;

    private Vector3 initialposition;
    private GameObject box = null;

    private List<GameObject> collideList = new List<GameObject>();

    public float speed = 1;

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
            GetComponent<SpriteRenderer>().sprite = Idle;
            updownmove = false;
            leftrightmove = false;
            box.transform.parent = null;
            box = null;
        }
        inShadow = false;
        foreach (GameObject g in collideList)
        {
            if (box == null && g!= null && g.tag == "Box" && Input.GetKeyDown(KeyCode.Space) && !updownmove && !leftrightmove)
            {
                if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.up)) < 45)
                {
                    updownmove = true;
                    GetComponent<SpriteRenderer>().sprite = pushUp;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if(Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.down)) < 45)
                {
                    updownmove = true;
                    GetComponent<SpriteRenderer>().sprite = pushDown;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.left)) < 45)
                {
                    leftrightmove = true;
                    GetComponent<SpriteRenderer>().sprite = pushLeft;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.right)) < 45)
                {
                    leftrightmove = true;
                    GetComponent<SpriteRenderer>().sprite = pushRight;
                    g.transform.parent = this.transform;
                    box = g;
                }
            }
            if (g != null && g.tag == "Shadow")
            {
                inShadow = true;
            }
        }
        foreach (GameObject g in collideList)
        {
            if (!inShadow && g != null && (g.tag == "WindowLight"|| g.tag == "CeilingLight"))
            {
                if (box != null)
                {
                    GetComponent<SpriteRenderer>().sprite = Idle;
                    updownmove = false;
                    leftrightmove = false;
                    box.transform.parent = null;
                    box = null;
                }
                transform.position = initialposition;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collideList.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        collideList.Remove(other.gameObject);
    }

}
