namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class checkappearance : VRTK_InteractableObject
    {
        public RectTransform image;
        public RectTransform image2;
        public int i = 0;
        AudioSource audio2;

        protected void Start()
        {
            VRTK_Logger.Info("??");
            audio2 = GameObject.Find("逻辑控制/操作正确").GetComponent<AudioSource>();
        }

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("checkappearance");

            if ((GameObject.Find("System").transform.localPosition.x) == 103f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "表号检查完毕\n请检查载波模块";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n检查载波模块信号灯，如不亮进行更换";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(104f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 203f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "否则为集中器故障\n请联系生厂商";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(204f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 304f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "否则为集中器故障\n请联系生厂商";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("掌机").transform.localPosition = new Vector3(0f, 100f, 0f);
                GameObject.Find("System").transform.localPosition = new Vector3(305f, 200f, 0f);

            }

            if ((GameObject.Find("System").transform.localPosition.x) == 3f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "集中器不在线\n请检查是否参数设置错误";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(4f, 200f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 1f)
            {

                GameObject.Find("System").transform.localPosition = new Vector3(0f, 2f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "外观若损坏\n请更换终端";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = false;
            }
            i++;
            if ((GameObject.Find("System").transform.localPosition.y) == 3f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 3.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "不亮\n请重新连接电源线";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请打开工具箱，使用螺丝刀和工具钳进行接线";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = false;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 16f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 16.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "外观若存在问题\n请更换电能表";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = false;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 18f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 18.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "档案错误\n请联系主站人员重新下发档案";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请打开工具箱，联系主站人员";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = false;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 17f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 17.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "电压正常\n请查看档案是否正常";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请在户表终端上按键操作进行档案检查";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = false;

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 19.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 20f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "表内数据修改完成";
                image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("掌机").transform.localPosition = new Vector3(0f, 100f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 22f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 22.5f, 0f);
                GameObject.Find("main/start2/correct").gameObject.SetActive(true);
                audio2.Play();
                if ((GameObject.Find("System2").transform.localPosition.y) == 0f)
                {
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "程序不兼容\n请更换终端";
                    image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);

                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = false;
            }

            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                GameObject.Find("main/start2/correct").gameObject.SetActive(true);
                audio2.Play();


            }
        }

        
        protected override void Update()
        {
            base.Update();
        }
    }
}