using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLvl2Script : MonoBehaviour
{

    public static float timer;

    // Use this for initialization
    void Start()
    {
        timer = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(3);
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Application.Quit();
        }
    }
    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        GUI.Label(new Rect(10, 10, 500, 200), niceTime);
    }
}
