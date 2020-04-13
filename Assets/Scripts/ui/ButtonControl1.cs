using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using VRTK;
using DG.Tweening;

public class ButtonControl1 : MonoBehaviour {

    public GameObject g;
    public  int i ;
    public int j=0;
    public GameObject menuprafabs;
    public GameObject menuprafabs1;
    public GameObject menuprafabs2;
    public GameObject upMenu;
    public GameObject ThisMenu;
    private Transform child;
    Text txt;
    public void ControlDown()
    {
        i++;
        g.transform.GetChild(i).GetComponentInChildren<Toggle>().isOn = true;
       
    }
    public void ControlUp()
    {
        if (i > 0)
        {
            i--;
            g.transform.GetChild(i).GetComponentInChildren<Toggle>().isOn = true;
        }

    }
    public void ControlRight()
    {
        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        GameObject.Destroy((GameObject.Find("start")), 0);
        //Vector3 position = new Vector3(90, -4, -50);
        if (i == 1)
            {

            Destroy(ThisMenu, 0);
            
            ThisMenu = GameObject.Instantiate(menuprafabs1, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
            if ((GameObject.Find("System").transform.localPosition.y) == 11f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 11.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "地址参数错误\n请修改";

            }
            if ((GameObject.Find("System").transform.localPosition.x) == 5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(6f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "主用IP和APN错误\n请修改";

            }
        }
            if (i == 0)
            {
                
                GameObject.Destroy(ThisMenu, 0);
            ThisMenu=GameObject.Instantiate(menuprafabs, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode=RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
            
        }
  
    }
    public void ControlLeft()
    {
        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        GameObject.Destroy(ThisMenu, 0);
        ThisMenu =GameObject.Instantiate(upMenu  , position, rotation);
   
        ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
        ThisMenu.AddComponent<VRTK_UICanvas>();
    }
    public void ControlRight1()
    {
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        if (i == 0)
        {
            GameObject.Destroy(ThisMenu, 0);

            ThisMenu = GameObject.Instantiate(menuprafabs, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
            

        }

    }
    public void ControlRight11()
    {

        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        if (i == 1)
        {
            if ((GameObject.Find("System").transform.localPosition.y) == 20f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 20.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("menu1 (17)").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 21f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 21.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("menu1 (18)").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);

            }
        }
        if (i == 2)
        {
            GameObject.Destroy(ThisMenu, 0);
            ThisMenu = GameObject.Instantiate(menuprafabs1, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
        }
        if (i == 3)
        {
            GameObject.Destroy(ThisMenu, 0);
            ThisMenu = GameObject.Instantiate(menuprafabs, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();

        }
        if (i == 7)
        {
            GameObject.Destroy(ThisMenu, 0);
            ThisMenu = GameObject.Instantiate(menuprafabs2, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();

        }

    }
    public void ControlRight2()
    {
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        if (i == 5)
        {
            GameObject.Destroy(ThisMenu, 0);
            ThisMenu = GameObject.Instantiate(menuprafabs, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();

        }

    }
    public void ControlRight21()
    {

        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        if (i == 1)
        {
            GameObject.Destroy(ThisMenu, 0);
            ThisMenu = GameObject.Instantiate(menuprafabs, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
            if ((GameObject.Find("System").transform.localPosition.y) == 23f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 23.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("menu1 (20)").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);

            }

        }
        if (i == 2)
        {
            GameObject.Destroy(ThisMenu, 0);
            ThisMenu = GameObject.Instantiate(menuprafabs1, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
            if ((GameObject.Find("System").transform.localPosition.y) == 25f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 25.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("menu1 (22)").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);

            }



        }

    }
    public void ControlRight22()
    {

        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);
        Vector3 position = new Vector3(-0.07f, 0.102f, -0.42f);
        if (i == 5)
        {
            GameObject.Destroy(ThisMenu, 0);

            ThisMenu = GameObject.Instantiate(menuprafabs, position, rotation);
            ThisMenu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            ThisMenu.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            ThisMenu.AddComponent<VRTK_UICanvas>();
            if ((GameObject.Find("System").transform.localPosition.x) == 11f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(12f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "若电压不正常\n重新接线";
                GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);

            }
        }
       

    }
    public  void Modify()
    {
        txt = g.transform.GetChild(i).GetComponentInChildren<Text>();
        if (i == 0)
        {
            if ((GameObject.Find("System").transform.localPosition.x) == 7f)
            {
                txt.text = "主用IP：172.16.10.13";
                j++;

                if (j==2) {
                    GameObject.Find("System").transform.localPosition = new Vector3(8f, 200f, 0f);
                    GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "主用端口和行政区码错误\n请修改";
                    GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }

            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                txt.text = "主用IP：172.16.10.13";
            }

            }
        if (i == 1)
        {
            
            if ((GameObject.Find("System").transform.localPosition.x) == 9f)
            {
                txt.text = "主用端口：9010";
                j++;

                if (j == 4)
                {
                    GameObject.Find("System").transform.localPosition = new Vector3(10f, 200f, 0f);
                    GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                    GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "故障未解决\n请检查是否交流电压出入较大";
                    GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }

                if ((GameObject.Find("System").transform.localPosition.x) == -1f)
                {
                    txt.text = "主用端口：9010";
                }
            }
        }
        if (i == 4)
        {
           
            if ((GameObject.Find("System").transform.localPosition.x) == 7f)
            {
                txt.text = "APN：ccsg.jl";
                j++;

                if (j == 2)
                {
                    GameObject.Find("System").transform.localPosition = new Vector3(8f, 200f, 0f);
                    GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                    GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "主用端口和行政区码错误\n请修改";
                    GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }
            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            { txt.text = "APN：ccsg.jl"; }
            }
        if (i == 5)
        {
            if ((GameObject.Find("System").transform.localPosition.x) == 9f)
            {
                txt.text = "行政区码：2201";
                j++;

                if (j == 4)
                {
                    GameObject.Find("System").transform.localPosition = new Vector3(10f, 200f, 0f);
                    GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                    GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "故障未解决\n请检查是否交流电压出入较大";
                    GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }

            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            { txt.text = "行政区码：2201"; }

        }
    }
    public void Modify1()
    {
        i=1;
        txt = g.transform.GetChild(i).GetComponentInChildren<Text>();
        if (i == 1)
        {
            if ((GameObject.Find("System").transform.localPosition.x) == 24f)
            {
                txt.text = "2201-00002222-002";
                GameObject.Find("System").transform.localPosition = new Vector3(25f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                    GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "最后，检查是否主站档案错误";
                GameObject.Find("二级菜单/1menu-1").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            }
            
        }
    }
    public void Modify2()
    {
        i=1;
        txt = g.transform.GetChild(i).GetComponentInChildren<Text>();
        if (i == 1)
        {
            if ((GameObject.Find("System").transform.localPosition.y) == 26f)
            {
                txt.text = "通讯协议：HDLS";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 26.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("menu1 (23)").transform.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            }
            
        }
    }
}
