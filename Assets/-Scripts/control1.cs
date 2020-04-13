using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using VRTK;

public class control1 : MonoBehaviour {


    public Vector3 des = new Vector3(-0.7f, -1.3f, 1f);
    public Vector3 des2 = new Vector3(-6.5f, -1.3f, 1f);
    public float x = 2.8f, y = -1f, z = 2.5f;
	// Use this for initialization
	void Start () {
    }

    public void Button1()
    {
        VRTK_Logger.Info("enter");
        GameObject.Find("startmenu").gameObject.SetActive(false);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu2").gameObject.SetActive(true);
    }

    public void Button12()
    {
        VRTK_Logger.Info("enter");
        GameObject.Find("startmenu").gameObject.SetActive(false);
       
        GameObject.Find("NewRoom").GetComponent<VRTK_BasicTeleport>().ForceTeleport(des, null);
        int ran = 1;
        GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n随机考核第";
        GameObject.Find("0menu-1/inform").GetComponent<Text>().text += ran;
        GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "题:";
        GameObject.Find("System2").transform.localPosition = new Vector3(0f, 1f, 0f);
        GameObject.Find("System").transform.localPosition = new Vector3(0f, -100f, 0f);
        if (ran == 1)
        {
            GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n整个台区无法抄回";
            GameObject.Find("System").transform.localPosition = new Vector3(-1f, 200f, 0f);

            GameObject.Find("Box008").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("Box010").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = true;

            GameObject.Find("main").transform.Find("start").gameObject.SetActive(true);
            GameObject.Find("main").transform.Find("start2").gameObject.SetActive(true);
            GameObject.Find("ICON").transform.Find("ICON2").gameObject.SetActive(true);
            GameObject.Find("ICON").transform.Find("ICON4").gameObject.SetActive(true);
        }
    }

    public void Button2()
    {
        GameObject.Find("startmenu2").gameObject.SetActive(false);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").gameObject.SetActive(true);
        GameObject.Find("System").transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    public void Button3()
    {
        GameObject.Find("startmenu3").gameObject.SetActive(false);
        GameObject.Find("NewRoom").GetComponent<VRTK_BasicTeleport>().ForceTeleport(des, null);
    }

    public void Button21()
    {
        GameObject.Find("startmenu2").gameObject.SetActive(false);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").gameObject.SetActive(true);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").GetComponent<Text>().text = "主站收到故障报告类型如下：\n[某地区全部户表无法抄回]\n点击【OK】前往现场";
        GameObject.Find("System").transform.localPosition = new Vector3(0f, -50f, 0f);
    }

    public void Button22()
    {
        GameObject.Find("startmenu2").gameObject.SetActive(false);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").gameObject.SetActive(true);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").GetComponent<Text>().text = "主站收到故障报告类型如下：\n[某地区部分户表无法抄回]\n点击【OK】前往现场";
        GameObject.Find("System").transform.localPosition = new Vector3(0f, -50f, 0f);
    }

    public void Button23()
    {
        GameObject.Find("startmenu2").gameObject.SetActive(false);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").gameObject.SetActive(true);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").GetComponent<Text>().text = "主站收到故障报告类型如下：\n[某地区个别户表无法抄回]\n点击【OK】前往现场";
        GameObject.Find("System").transform.localPosition = new Vector3(0f, -100f, 0f);
    }

    public void Button24()
    {
        GameObject.Find("startmenu2").gameObject.SetActive(false);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").gameObject.SetActive(true);
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu3").GetComponent<Text>().text = "主站收到故障报告类型如下：\n[某地区抄回数据出入过大]\n点击【OK】前往现场";
        GameObject.Find("System").transform.localPosition = new Vector3(0f, -150f, 0f);
    }

    public void ButtonExit()
    {
        GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu").gameObject.SetActive(true);
        GameObject.Find("NewRoom").GetComponent<VRTK_BasicTeleport>().ForceTeleport(des2, null);
    }




    // Update is called once per frame
    void Update () {
		
	}
}
