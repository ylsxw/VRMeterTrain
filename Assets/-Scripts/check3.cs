namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;


    public class check3 : VRTK_InteractableObject
    {
        public float zbx = -0.194f, zby = 0.449f, zbz = -0.2f;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("check3");
            if ((GameObject.Find("System").transform.localPosition.y) == 0f)
            {

                GameObject.Find("safetyhelmet").SetActive(false);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n您已进入[整个台区无法抄回]故障处理分析部分.";
                GameObject.Find("二级菜单/1menu-1").transform.localPosition=new Vector3(zbx, zby, zbz);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入[整个台区无法抄回]\n故障处理分析部分";
                GameObject.Find("System").transform.localPosition = new Vector3(1f, 200f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -50f)
            {

                GameObject.Find("safetyhelmet").SetActive(false);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n您已进入[全部户表无法抄回]故障处理分析部分.";
                GameObject.Find("二级菜单/1menu-1").transform.localPosition = new Vector3(zbx, zby, zbz);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入[全部户表无法抄回]\n故障处理分析部分";
                GameObject.Find("System").transform.localPosition = new Vector3(101f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.y) == -100f)
            {

                GameObject.Find("safetyhelmet").SetActive(false);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n您已进入[部分户表无法抄回]故障处理分析部分.";
                GameObject.Find("二级菜单/1menu-1").transform.localPosition = new Vector3(zbx, zby, zbz);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入[部分户表无法抄回]\n故障处理分析部分";
                GameObject.Find("System").transform.localPosition = new Vector3(201f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.y) == -150f)
            {

                GameObject.Find("safetyhelmet").SetActive(false);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n您已进入[个别户表无法抄回]故障处理分析部分.";
                GameObject.Find("二级菜单/1menu-1").transform.localPosition = new Vector3(zbx, zby, zbz);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入[个别户表无法抄回]\n故障处理分析部分";
                GameObject.Find("System").transform.localPosition = new Vector3(301f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.y) == -200f)
            {

                GameObject.Find("safetyhelmet").SetActive(false);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n您已进入[抄回数据出入大]故障处理分析部分.";
                GameObject.Find("二级菜单/1menu-1").transform.localPosition = new Vector3(zbx, zby, zbz);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入[抄回数据出入大]\n故障处理分析部分";
                GameObject.Find("System").transform.localPosition = new Vector3(401f, 200f, 0f);
            }



        }

        protected void Start()
        {
            VRTK_Logger.Info("??");
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}