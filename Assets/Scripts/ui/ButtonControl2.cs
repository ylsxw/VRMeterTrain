using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject g;
    int i = 0;
    public GameObject menuprafabs;
    public GameObject mainmenu;
    public GameObject controlbutton;
    private Transform  child;
    public  void ControlDown()
    {
        i++;
        g.transform.GetChild(i).GetComponentInChildren<Toggle>().isOn = true;
        Debug.Log(i);
        //if (i >= 8)
        //{
        //    i=8;
        //}
    }
    public  void ControlUp()
    {
        if (i > 0)
        {
            i--;
            g.transform.GetChild(i).GetComponentInChildren<Toggle>().isOn = true;

            //if (i <= 0)
            //{
            //    i = 0;
            //}
        }
        
    }
    public void ControlRight()
    {

            Vector3 position = new Vector3(90, -4, -50);
            if (i==0)
            {
                GameObject.Instantiate(menuprafabs, position, Quaternion.identity);
                GameObject.Destroy(mainmenu, 0);
                GameObject.Destroy(controlbutton, 0);
        }
        //g.transform.GetChild(i).GetComponent<Text>().text == "测量点数据显示"

    }

}
