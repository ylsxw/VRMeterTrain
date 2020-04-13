using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class 时间控制 : MonoBehaviour {

    public GameObject g;
    Text txt_time;
    private int hour;
    private int minute;
    private int second;
	void Start ()
    {
        txt_time = g.GetComponent<Text>();
	}
	

	void Update ()
    {
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        txt_time.text  = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
	}
}
