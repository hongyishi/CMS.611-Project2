﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private bool upmove = false;
    private bool downmove = false;
    private bool leftmove = false;
    private bool rightmove = false;

    private bool shouldChangeSprite = true;
    private bool movealt = false;

    public Sprite PushUpIdle;
    public Sprite PushUp1;
    public Sprite PushUp2;

    public Sprite PushDownIdle;
    public Sprite PushDown1;
    public Sprite PushDown2;

    public Sprite PushLeftIdle;
    public Sprite PushLeft1;
    public Sprite PushLeft2;

    public Sprite PushRightIdle;
    public Sprite PushRight1;
    public Sprite PushRight2;

    public Sprite UpIdle;
    public Sprite Up1;
    public Sprite Up2;

    public Sprite DownIdle;
    public Sprite Down1;
    public Sprite Down2;

    public Sprite LeftIdle;
    public Sprite Left1;
    public Sprite Left2;

    public Sprite RightIdle;
    public Sprite Right1;
    public Sprite Right2;

    public GameObject DeadMonster;
    private bool inShadow = false;

    enum Direction { Left, Right, Up, Down, Null };

    private Direction lastdir = Direction.Null;

    Vector3 initialposition;
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
        {
            lastdir = Direction.Up;
        }
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.A))
        { 
            lastdir = Direction.Left;
        }
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.S))
        {
            lastdir = Direction.Down;
        }
        if (lastdir == Direction.Null && Input.GetKey(KeyCode.D))
        {
            lastdir = Direction.Right;
        }
        if (lastdir == Direction.Up && Input.GetKeyUp(KeyCode.W))
            lastdir = Direction.Null;
        if (lastdir == Direction.Left && Input.GetKeyUp(KeyCode.A))
            lastdir = Direction.Null;
        if (lastdir == Direction.Down && Input.GetKeyUp(KeyCode.S))
            lastdir = Direction.Null;
        if (lastdir == Direction.Right && Input.GetKeyUp(KeyCode.D))
            lastdir = Direction.Null;
        if (lastdir == Direction.Up && !leftmove && !rightmove)
        {
            transform.Translate(speed * Vector2.up * Time.deltaTime);
        }
        if (lastdir == Direction.Left && !upmove && !downmove)
        {
            transform.Translate(speed * Vector2.left * Time.deltaTime);
        }
        if (lastdir == Direction.Down && !leftmove && !rightmove)
        {
            transform.Translate(speed * Vector2.down * Time.deltaTime);
        }
        if (lastdir == Direction.Right && !upmove && !downmove)
        {
            transform.Translate(speed * Vector2.right * Time.deltaTime);
        }
        if (box != null && Input.GetKeyDown(KeyCode.Space) && (upmove || downmove || leftmove || rightmove))
        {
            //GetComponent<SpriteRenderer>().sprite = Idle;
            upmove = false;
            downmove = false;
            leftmove = false;
            rightmove = false;
            box.transform.parent = null;
            box = null;
            return;
        }
        inShadow = false;
        foreach (GameObject g in collideList)
        {
            if (box == null && g!= null && (g.tag == "Box"||g.tag == "SmallBox")&& Input.GetKeyDown(KeyCode.Space) && !upmove &&!downmove && !leftmove && !rightmove)
            {
                if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.up)) < 45)
                {
                    upmove = true;
                    //GetComponent<SpriteRenderer>().sprite = pushUp;
                    //GetComponent<Animation>().animation = Idle;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if(Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.down)) < 45)
                {
                    downmove = true;
                    //GetComponent<SpriteRenderer>().sprite = pushDown;
                    //GetComponent<Animation>().animation = Idle;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.left)) < 45)
                {
                    leftmove = true;
                    //GetComponent<SpriteRenderer>().sprite = pushLeft;
                    //GetComponent<Animation>().animation = Idle;
                    g.transform.parent = this.transform;
                    box = g;
                }
                else if (Mathf.Abs(Vector2.Angle((g.transform.position - this.transform.position), Vector2.right)) < 45)
                {
                    rightmove = true;
                    //GetComponent<SpriteRenderer>().sprite = pushRight;
                    //GetComponent<Animation>().animation = Idle;
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
                respawnMonster();
                return;
            }
        }
    }

    void OnGUI()
    {
        if (shouldChangeSprite)
        {
            if (lastdir == Direction.Up)
            {
                if (upmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushUpIdle;
                }
                else if (downmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushDownIdle;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = UpIdle;
                }
            }
            if (lastdir == Direction.Left)
            {
                if (leftmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushLeftIdle;
                }
                else if (rightmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushRightIdle;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = LeftIdle;
                }
            }
            if (lastdir == Direction.Down)
            {
                if (upmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushUpIdle;
                }
                else if (downmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushDownIdle;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = DownIdle;
                }
            }
            if (lastdir == Direction.Right)
            {
                if (leftmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushLeftIdle;
                }
                else if (rightmove)
                {
                    GetComponent<SpriteRenderer>().sprite = PushRightIdle;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = RightIdle;
                }
            }
            if (lastdir == Direction.Up && !leftmove && !rightmove)
            {
                transform.Translate(speed * Vector2.up * Time.deltaTime);
                if (upmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushUp1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushUp2;
                    }
                    movealt = !movealt;
                }
                else if (downmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushDown1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushDown2;
                    }
                    movealt = !movealt;
                }
                else
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = Up1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = Up2;
                    }
                    movealt = !movealt;
                }
            }
            if (lastdir == Direction.Left && !upmove && !downmove)
            {
                transform.Translate(speed * Vector2.left * Time.deltaTime);
                if (leftmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushLeft1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushLeft2;
                    }
                    movealt = !movealt;
                }
                else if (rightmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushRight1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushRight2;
                    }
                    movealt = !movealt;
                }
                else
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = Left1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = Left2;
                    }
                    movealt = !movealt;
                }
            }
            if (lastdir == Direction.Down && !leftmove && !rightmove)
            {
                transform.Translate(speed * Vector2.down * Time.deltaTime);
                if (upmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushUp1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushUp2;
                    }
                    movealt = !movealt;
                }
                else if (downmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushDown1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushDown2;
                    }
                    movealt = !movealt;
                }
                else
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = Down1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = Down2;
                    }
                    movealt = !movealt;
                }
            }
            if (lastdir == Direction.Right && !upmove && !downmove)
            {
                transform.Translate(speed * Vector2.right * Time.deltaTime);
                if (leftmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushLeft1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushLeft2;
                    }
                    movealt = !movealt;
                }
                else if (rightmove)
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = PushRight1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = PushRight2;
                    }
                    movealt = !movealt;
                }
                else
                {
                    if (movealt)
                    {
                        GetComponent<SpriteRenderer>().sprite = Right1;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = Right2;
                    }
                    movealt = !movealt;
                }
            }
            StartCoroutine(animDelay());
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

    void respawnMonster()
    {
        if (box != null)
        {
            //GetComponent<SpriteRenderer>().sprite = Idle;
            //GetComponent<Animation>().animation = Idle;
            upmove = false;
            downmove = false;
            leftmove = false;
            rightmove = false;
            box.transform.parent = null;
            box = null;
        }
        GameObject deadmonster = Instantiate(DeadMonster, transform.position,Quaternion.identity) as GameObject;
        deadmonster.GetComponent<DeadMonsterRespawnScript>().respawnPosition = initialposition;
        Destroy(this.gameObject);
    }

    IEnumerator animDelay()
    {
        shouldChangeSprite = false;
        yield return new WaitForSeconds(0.2f);
        shouldChangeSprite = true;
    }

}
