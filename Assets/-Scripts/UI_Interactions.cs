namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class UI_Interactions : MonoBehaviour
    {
        //此脚本管理逻辑检查操作等
        AudioSource audio,audio2;
        AudioSource[] audioo= new AudioSource[30];
        int iii;
        public float x = -3f, y = -1f, z = 2.5f;
        void Start()
        {
            audio = GetComponent<AudioSource>();
            audio2 = GameObject.Find("逻辑控制/操作正确").GetComponent<AudioSource>();
            for (iii = 1; iii < 22; iii++) {
                audioo[iii] = GameObject.Find("逻辑控制/操作正确 (" + iii + ")").GetComponent<AudioSource>(); }
        }
      
        private const int EXISTING_CANVAS_COUNT = 4;
        public RectTransform image0;
        public RectTransform imagedianhua;
        public RectTransform image1;
        public RectTransform image2;
        public RectTransform image3;
        public RectTransform image4;
        public RectTransform image5;
        public RectTransform image6;
        public RectTransform image7;
        public RectTransform image8;
        public RectTransform image9;
        public RectTransform image10;
        public RectTransform image11;
        public RectTransform image12;
        public RectTransform image13;
        public RectTransform image14;
        public RectTransform image15;
        public RectTransform image16;
        public RectTransform image17;
        public RectTransform image18;
        public RectTransform image19;
        public RectTransform image20;
        public RectTransform image21;
        public RectTransform image22;
        public RectTransform image23;
        public RectTransform image24;
        public GameObject luosi;
        public GameObject qianzi;
        public GameObject handd;
        public GameObject zhangji;
        public GameObject correct;
        public GameObject help;
        public int xiugai = 0,xiugai2=0;
        public float zbx= -0.194f, zby= 0.449f, zbz= -0.2f;
        public int ran;

        //
        //
        //
        //
        //
        //
        //新旧脚本分割线
        public void NewButton_1()
        {
            VRTK_Logger.Info("整个台区");
            image0.DOMove(new Vector3(zbx,zby,zbz), 0.5f);
            GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入[整个台区无法抄回]\n故障处理分析部分";
            GameObject.Find("System").transform.localPosition = new Vector3(1f, 200f, 0f);
        }

        //新旧脚本分割线
        //
        //
        //
        //
        //
        //
        public void Button_0()
        {
            image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入终端故障处理分析部分";
            audio.Play();
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 0f, 1f);
            GameObject.Find("System2").transform.localPosition = new Vector3(0f, 0f, 0f);
            //进入现场终端故障处理部分
            //image0.DOMove(new Vector3(0,0,-1000), 0.5f);
            //image2.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            //GameObject.Find("Capsule060").GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void Button_01()
        {
            GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入户表故障处理分析部分";
            audioo[5].Play();
            image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 15f, 0f);
            GameObject.Find("System2").transform.localPosition = new Vector3(0f, 0f, 0f);
            //进入现场终端故障处理部分
            //image0.DOMove(new Vector3(0,0,-1000), 0.5f);
            //image2.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            //GameObject.Find("Capsule060").GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void Button_02()
        {
            GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入采集主站处理分析部分";
            audioo[6].Play();
            GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n开始采集主站培训";
            image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, -1f, 0f);
            GameObject.Find("System2").transform.localPosition = new Vector3(0f, 0f, 0f);

            //进入现场终端故障处理部分
            //image0.DOMove(new Vector3(0,0,-1000), 0.5f);
            //image2.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            //GameObject.Find("Capsule060").GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void Button_test()
        {
            //GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "您已进入随机考核部分";
            //image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            //ran=Random.Range(1, 5);
            ran = 1;
            GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n随机考核第";
            GameObject.Find("0menu-1/inform").GetComponent<Text>().text += ran;
            GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "题:";
            GameObject.Find("System2").transform.localPosition = new Vector3(0f, 1f, 0f);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, -100f, 0f);
            if (ran == 1) {
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n整个台区无法抄回";
                GameObject.Find("System").transform.localPosition = new Vector3(1f, 200f, 0f);
            }
            if (ran == 2)
            {
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n电源灯不亮";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4f, 0f);
            }
            if (ran == 3)
            {
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n信号弱";
                GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 10f, 0f);
            }
            if (ran == 4)
            {
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n程序不兼容";
                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 22f, 0f);
            }
            //进入现场终端故障处理部分
            //image0.DOMove(new Vector3(0,0,-1000), 0.5f);
            //image2.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            //GameObject.Find("Capsule060").GetComponent<MeshRenderer>().material.color = Color.red;
        }

        public void chuansong()
        {
            Vector3 des = new Vector3(-6.5f, -1f, 1f);
            GameObject.Find("NewRoom").GetComponent<VRTK_BasicTeleport>().ForceTeleport(des, null);
        }
        public void Button_Enter()
        {
            VRTK_Logger.Info("点击确定");
            GameObject.Find("main/start2/correct").gameObject.SetActive(false);

            //数据出入
            if ((GameObject.Find("System").transform.localPosition.x) == 404f)
            {
                GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu").gameObject.SetActive(true);
                chuansong();
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(405f, 200f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 402f)
            {
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(403f, 200f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 401f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(402f, 200f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "出现施工问题(线接反) 联系内勤人员处理";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n工具箱-电话-联系内勤人员";
            }
            //个别户表
            if ((GameObject.Find("System").transform.localPosition.x) == 305f)
            {
                GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu").gameObject.SetActive(true);
                chuansong();
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(306f, 200f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 302f)
            {
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(303f, 200f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 301f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(302f, 200f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "请用掌机检查是否户表故障";
                audioo[13].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n工具箱-掌机";

            }
            //部分户表
            if ((GameObject.Find("System").transform.localPosition.x) == 204f)
            {
                GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu").gameObject.SetActive(true);
                chuansong();
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(205f, 200f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 202f)
            {
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(203f, 200f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 201f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(202f, 200f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "首先检查户表是否缺相";
                audioo[19].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰户表外观进行检查";

            }
            //全部户表
            if ((GameObject.Find("System").transform.localPosition.x) == 109f)
            {
                GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu").gameObject.SetActive(true);
                chuansong();
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(110f, 200f, 0f);

            }

            if ((GameObject.Find("System").transform.localPosition.x) == 107f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(108f, 200f, 0f);

            }
            if ((GameObject.Find("System").transform.localPosition.x) == 106f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "否则为集中器故障\n联系集中器厂家";
                GameObject.Find("System").transform.localPosition = new Vector3(107f, 200f, 0f);

            }


            if ((GameObject.Find("System").transform.localPosition.x) == 104f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(105f, 200f, 0f);
                GameObject.Find("部件一").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("Box008").GetComponent<BoxCollider>().enabled = true;
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 102f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "第二步检查表号是否与台区一致";
                GameObject.Find("System").transform.localPosition = new Vector3(103f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 101f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "首先检查主站集中器档案";
                GameObject.Find("System").transform.localPosition = new Vector3(102f, 200f, 0f);
                audioo[11].Play();
            }

            //整个台区
            if ((GameObject.Find("System").transform.localPosition.x) == 26f)
            {
                GameObject.Find("[VRTK_SDKManager]/SDKSetups/Simulator/VRSimulatorCameraRig/startmenu").gameObject.SetActive(true);
                chuansong();
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(27f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 25f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "检查完毕\n则整个台区无法抄回部分培训完成";
                GameObject.Find("System").transform.localPosition = new Vector3(26f, 200f, 0f);
            }


            if ((GameObject.Find("System").transform.localPosition.x) == 23f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(24f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 22f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "请检查是否主站地址参数错误";
                GameObject.Find("System").transform.localPosition = new Vector3(23f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 20f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(21f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 19f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "否则为软件或硬件损坏故障\n请联系集中器厂家";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n左手Grip键-工具箱-电话-联系生产商";
                GameObject.Find("System").transform.localPosition = new Vector3(20f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 17f)
            {
                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = true;
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(18f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 16f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "菜单显示信号量低\n请调整天线位置";
                audioo[1].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰天线从而调整位置";
                GameObject.Find("System").transform.localPosition = new Vector3(17f, 200f, 0f);
            }
        

            if ((GameObject.Find("System").transform.localPosition.x) == 14f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰GRPS模块进行更换";
                audioo[16].Play();
                GameObject.Find("Box008").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("Box010").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(15f, 200f, 0f);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 12f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(13f, 200f, 0f);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n左手Grip键-工具箱-螺丝刀 打开终端下方盒盖";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n再使用工具箱-工具钳 重新接上黄色电线";
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 10f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(11f, 200f, 0f);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n测量点数据显示-实时数据-交流采样信息";
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 8f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(9f, 200f, 0f);
                
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 6f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(7f, 200f, 0f);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n参数设置与查看-IP及端口设置";
            }

            if ((GameObject.Find("System").transform.localPosition.x) == 4f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(5f, 200f, 0f);
                audioo[15].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n右侧菜单-参数设置与查看";
                GameObject.Find("main").transform.Find("start").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("start2").gameObject.SetActive(true);
                GameObject.Find("ICON").transform.Find("ICON2").gameObject.SetActive(true);
                GameObject.Find("ICON").transform.Find("ICON4").gameObject.SetActive(true);
            }


            if ((GameObject.Find("System").transform.localPosition.x) == 2f)
            {
                image0.DOMove(new Vector3(zbx, 15f, zbz), 0.5f);
                GameObject.Find("System").transform.localPosition = new Vector3(3f, 200f, 0f);
                GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请靠近触碰从而观察电源灯状态";
                audioo[20].Play();
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 1f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "首先检查集中器是否在线";
                GameObject.Find("System").transform.localPosition = new Vector3(2f, 200f, 0f);
                audioo[21].Play();
            }


            if ((GameObject.Find("System").transform.localPosition.y) == -100f)
            {

                GameObject.Find("System").transform.localPosition = new Vector3(0f, -101f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }


            if ((GameObject.Find("System").transform.localPosition.y) == -100f)
            {

                GameObject.Find("System").transform.localPosition = new Vector3(0f, -101f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            //采集主站部分开始
            if ((GameObject.Find("System").transform.localPosition.y) == -8f)
            {

                GameObject.Find("System").transform.localPosition = new Vector3(0f, -9f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
          
            if ((GameObject.Find("System").transform.localPosition.y) == -7f)
            {

                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "采集主站部分全部完成\n检查是否恢复正常";
                audioo[17].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -8f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -6f)
            {

                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "若无连接\n排查主机前置机（由省公司负责）";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -7f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -5f)
            {

                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "若有连接查看是否档案参数错误\n错误则进行修改";
                audioo[11].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -6f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -4.5f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);

            }
            if ((GameObject.Find("System").transform.localPosition.y) == -4f)
            {

                Test1:
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "若不在线，联系内勤人员\n查询系统有无档案连接";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请打开工具箱，联系内勤人员";
                audioo[10].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -4.5f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -3f)
            {

                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "存在错误\n则重新下发参数";
                audioo[4].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -4f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -2f)
            {

                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "若集中器在线\n召测集中器抄表参数信息";
                audioo[12].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -3f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == -1f)
            {

                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "首先检查集中器是否在线";
                audioo[21].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, -2f, 0f);
            }
            
            //采集主站部分结束



            if ((GameObject.Find("System").transform.localPosition.y) == 0.5f)
            {
                
                GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 1f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 0f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "首先检查终端外观是否损坏";
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰负控终端外观进行检查";
                audioo[20].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 0.5f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 2.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 3f, 0f);

                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 2f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "外观未损坏\n观察电源灯是否常亮";
                audioo[3].Play();
                GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请靠近触碰从而观察电源灯状态";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 2.5f, 0f);
                GameObject.Find("Capsule061").GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 3.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 5.5f, 0f);
                GameObject.Find("-外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("main").transform.Find("start").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("start2").gameObject.SetActive(true);
                GameObject.Find("ICON").transform.Find("ICON2").gameObject.SetActive(true);
                GameObject.Find("ICON").transform.Find("ICON4").gameObject.SetActive(true);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 7f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 7.5f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
                GameObject.Find("Box008").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("Box010").GetComponent<BoxCollider>().enabled = true;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 6.5f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "请检查通信模块是否正常";
                audioo[16].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请打开盒盖，触碰检查通信模块";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 7f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 6f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 6.1f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "电压正常\n电源灯常亮";
                audioo[8].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 6.5f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 8f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 8.5f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
                GameObject.Find("016").GetComponent<BoxCollider>().enabled = true;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 9.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 10f, 0f);
                GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = true;
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 9f)
            {
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "信号弱\n请调整天线位置";
                audioo[1].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰天线从而调整位置";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 9.5f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 11f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 11f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 10.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 11f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "请检查终端参数是否正常";
                audioo[15].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n显示屏-参数设置与查看";
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 11.5f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 12f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 12.5f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 14f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 13f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 13.5f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }

            ///终端部分结束
            ///户表部分开始
            ///
           if ((GameObject.Find("System").transform.localPosition.y) == 15.5f)
            {
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 16f, 0f);
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f); 
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 15f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 15.5f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "首先检查户表外观是否正常";
                audioo[19].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰户表外观进行检查";

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 17f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = true;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 17.5f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 18f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 16.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 17f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "外观无问题\n请检查电压是否正常";
                audioo[2].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请在户表终端上按键操作进行电压检查";

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 18.5f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 19f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 21f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
                GameObject.Find("部件一").GetComponent<BoxCollider>().enabled = true;
                GameObject.Find("Box008").GetComponent<BoxCollider>().enabled = true;
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 20.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 21f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "终端载波模块出现故障\n请更换载波模块";
                audioo[9].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请触碰终端载波模块以更换";
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 20f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 20.5f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "非档案问题和表内数据问题\n则排查施工问题";
                audioo[18].Play();
            }
            if ((GameObject.Find("System").transform.localPosition.y) == 22f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);
                GameObject.Find("Box167").GetComponent<BoxCollider>().enabled = true;

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 21.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 22f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "请检查程序是否兼容";
                audioo[14].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请在户表终端上按键操作进行程序检查";

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 23f)
            {
                image0.DOMove(new Vector3(-0.194f, 15f, 0.094f), 0.5f);

            }
            if ((GameObject.Find("System").transform.localPosition.y) == 22.5f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 23f, 0f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "户表故障处理部分完成";
                audioo[7].Play();
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n培训内容完成";

            }


        }


        public void Button_Pink()
        {
            VRTK_Logger.Info("步骤1");
            image1.DOMove(new Vector3(0,0,-1000), 0f);            
            handd.transform.localPosition = new Vector3(0f, 0f, 0f);
            if ((GameObject.Find("System").transform.localPosition.x) == 13f)
            {
                luosi.transform.localPosition = new Vector3(-0.05f, 0f, 0.1f);
                GameObject.Find("System").transform.localPosition = new Vector3(14f, 4.1f, 0f);
                GameObject.Find("-盒盖2").GetComponent<BoxCollider>().enabled = true;
            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                qianzi.transform.localPosition = new Vector3(0.02f, -0.02f, 0.1f);
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4.5f, 0f);
                GameObject.Find("lineyellow").GetComponent<jiexian>().enabled = true;
            }
        }

        public void Button_qianzi()
        {
            VRTK_Logger.Info("步骤钳子");
            image1.DOMove(new Vector3(0, 0, -1000), 0f);
            if ((GameObject.Find("System").transform.localPosition.y) == 4.2f)
            {
                qianzi.transform.localPosition = new Vector3(0.02f, -0.02f, 0.1f);
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4.5f, 0f);
                GameObject.Find("lineyellow").GetComponent<jiexian>().enabled = true;
            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                qianzi.transform.localPosition = new Vector3(0.02f, -0.02f, 0.1f);
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4.5f, 0f);
                GameObject.Find("lineyellow").GetComponent<jiexian>().enabled = true;
            }
            handd.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        public void Button_zhangji()
        {
            VRTK_Logger.Info("掌机");
            image1.DOMove(new Vector3(0, 0, -1000), 0f);
            if ((GameObject.Find("System").transform.localPosition.x)== 303f)
            {
                zhangji.transform.localPosition = new Vector3(-0.21f, 0.053f, -0.081f);
                GameObject.Find("System").transform.localPosition = new Vector3(304f, 200f, 0f);
                GameObject.Find("户表外观").GetComponent<BoxCollider>().enabled = true;
            }
            handd.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        public void Button_zhongduan()
        {
            VRTK_Logger.Info("终端");
            image1.DOMove(new Vector3(0, 0, -1000), 0f);
            if ((GameObject.Find("System").transform.localPosition.y) == 6f)
            {
                image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "更换终端成功";
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 6.1f, 0f);
            }
            handd.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        public void Button_dianhua()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image1.DOMove(new Vector3(0,0,-1000), 0f);
            imagedianhua.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            handd.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        public void Button_dianhua2()
        {
            VRTK_Logger.Info("P联系了");
            imagedianhua.DOMove(new Vector3(0,0,-1000), 0f);
            if ((GameObject.Find("System").transform.localPosition.y) == 1f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 2f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                image4.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            }
        }


        public void Button_dianhua3()
        {
            VRTK_Logger.Info("联系生产商");
            imagedianhua.DOMove(new Vector3(0,0,-1000), 0.5f);
            if ((GameObject.Find("System").transform.localPosition.x) == 21f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(22f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text ="集中器不在线情况培训完成\n点击进入在线情况培训";
                image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == 108f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(109f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "全部户表无法抄回情况培训完成";
                image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(109f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "考核完成";
                image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            }
        }

        public void Button_dianhua4()
        {
            VRTK_Logger.Info("联系助战");
            imagedianhua.DOMove(new Vector3(0, 0, -1000), 0.5f);
            if ((GameObject.Find("System").transform.localPosition.y) == 18.5f)
            {
              
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "表内数据出现问题\n请连接掌机修改";
                audioo[13].Play();
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 19f, 0f);
                GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请打开工具箱，使用掌机连接电表修改数据";
                image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            }
        }

        public void Button_dianhua5()
        {
            VRTK_Logger.Info("联系内勤");
            imagedianhua.DOMove(new Vector3(0, 0, -1000), 0.5f);
            if ((GameObject.Find("System").transform.localPosition.x) == 403f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(404f, 200f, 0f);
                GameObject.Find("main/start2/correct").gameObject.SetActive(true);
                audio2.Play();
                if ((GameObject.Find("System2").transform.localPosition.y) == 0f) { 
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "成功联系内勤人员";
                image0.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }
            }
        }

        public void Button_2()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image2.DOMove(new Vector3(0,0,-1000), 0.5f);
            image3.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            help.SetActive(true);
        }
        public void Button_3()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image3.DOMove(new Vector3(0,0,-1000), 0.5f);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 1f, 0f);
        }
        public void Button_4()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image4.DOMove(new Vector3(0,0,-1000), 0.5f);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 3f, 0f);
            GameObject.Find("main").transform.Find("start").gameObject.SetActive(true);
            GameObject.Find("main").transform.Find("start2").gameObject.SetActive(true);
            GameObject.Find("ICON").transform.Find("ICON1").gameObject.SetActive(true);
            GameObject.Find("ICON").transform.Find("ICON3").gameObject.SetActive(true);
            correct.SetActive(false);
            help.SetActive(true);
        }
        public void Button_5()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image5.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 5f, 0f);
        }
        public void Button_6()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image6.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 6f, 0f);
        }
        public void Button_7()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image7.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 7f, 0f);
        }
        public void Button_8()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image8.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("Plane001").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 8f, 0f);
            GameObject.Find("ICON").transform.Find("ICON3").gameObject.SetActive(false);
            GameObject.Find("ICON").transform.Find("ICON4").gameObject.SetActive(true);
        }
        public void Button_9()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image9.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("016").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("Box008").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 9f, 0f);
        }
        public void Button_10()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image10.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("Plane001").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 10f, 0f);
            GameObject.Find("ICON").transform.Find("ICON1").gameObject.SetActive(false);
            GameObject.Find("ICON").transform.Find("ICON2").gameObject.SetActive(true);
        }
        public void Button_11()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image11.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 11f, 0f);
            GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = true;
        }
        public void Button_12()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image12.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 12f, 0f);
        }
        public void Button_13()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image13.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 13f, 0f);
        }
        public void Button_14()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image14.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 17f, 0f);
            GameObject.Find("Box010").GetComponent<BoxCollider>().enabled = true;
        }
        public void Button_15()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image15.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 18f, 0f);
        }
        public void Button_16()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image16.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
           image17.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 19f, 0f);
            GameObject.Find("Capsule060").GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void Button_17()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image17.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 20f, 0f);
        }
        public void Button_18()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image18.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 21f, 0f);
        }
        public void Button_19()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image19.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 22f, 0f);
            GameObject.Find("部件一").GetComponent<BoxCollider>().enabled = true;
        }
        public void Button_20()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image20.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 23f, 0f);
        }
        public void Button_21()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image21.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 24f, 0f);
        }
        public void Button_22()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image22.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 25f, 0f);
        }
        public void Button_23()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image23.DOMove(new Vector3(0,0,-1000), 0.5f);
            correct.SetActive(false);
            help.SetActive(true);
            GameObject.Find("System").transform.localPosition = new Vector3(0f, 26f, 0f);
        }
        public void Button_chakan1()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            if ((GameObject.Find("System").transform.localPosition.y) == 3f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                image5.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            }
        }
        public void Button_chakan2()
        {
            VRTK_Logger.Info("Pink Button Clicked");
        image18.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Button_chakan3()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image21.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Button_chakan4()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image23.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Button_xiugai1()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            if ((GameObject.Find("System").transform.localPosition.y) == 4f)
            {
                    
                xiugai++;
            }
            
            if (xiugai == 2)
            {

                image6.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f); 
                correct.SetActive(true);
                help.SetActive(false);
            }
            }
        public void Button_xiugai2()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            if ((GameObject.Find("System").transform.localPosition.y) == 5f)
            {
                
                xiugai2++;
            }
            if (xiugai2 == 2)
            {
                correct.SetActive(true);
                help.SetActive(false); 
                image7.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
            }
                
        }
        public void Button_xiugai3()
        {
            VRTK_Logger.Info("Pink Button Clicked");

            if ((GameObject.Find("System").transform.localPosition.y) == 6f)
            {
                image8.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
                correct.SetActive(true);
                help.SetActive(false);
             
            }
        }

        public void Button_xiugai4()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image13.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Button_xiugai5()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image19.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Button_xiugai6()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image22.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Button_xiugai7()
        {
            VRTK_Logger.Info("Pink Button Clicked");
            image24.DOMove(new Vector3(-0.194f,0.449f , 0.094f), 0.5f);
        }
        public void Toggle(bool state)
        {
            VRTK_Logger.Info("The toggle state is " + (state ? "on" : "off"));
        }

        public void Dropdown(int value)
        {
            VRTK_Logger.Info("Dropdown option selected was ID " + value);
        }

        public void SetDropText(BaseEventData data)
        {
            var pointerData = data as PointerEventData;
            var textObject = GameObject.Find("ActionText");
            if (textObject)
            {
                var text = textObject.GetComponent<Text>();
                text.text = pointerData.pointerDrag.name + " Dropped On " + pointerData.pointerEnter.name;
            }
        }

        public void CreateCanvas()
        {
            StartCoroutine(CreateCanvasOnNextFrame());
        }

        private IEnumerator CreateCanvasOnNextFrame()
        {
            yield return null;

            var canvasCount = FindObjectsOfType<Canvas>().Length - EXISTING_CANVAS_COUNT;
            var newCanvasGO = new GameObject("TempCanvas");
            newCanvasGO.layer = 5;
            var canvas = newCanvasGO.AddComponent<Canvas>();
            var canvasRT = canvas.GetComponent<RectTransform>();
            canvasRT.position = new Vector3(-4f, 2f, 3f + canvasCount);
            canvasRT.sizeDelta = new Vector2(300f, 400f);
            canvasRT.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            canvasRT.eulerAngles = new Vector3(0f, 270f, 0f);

            var newButtonGO = new GameObject("TempButton", typeof(RectTransform));
            newButtonGO.transform.SetParent(newCanvasGO.transform);
            newButtonGO.layer = 5;

            var buttonRT = newButtonGO.GetComponent<RectTransform>();
            buttonRT.position = new Vector3(0f, 0f, 0f);
            buttonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            buttonRT.localPosition = new Vector3(0f, 0f, 0f);
            buttonRT.sizeDelta = new Vector2(180f, 60f);
            buttonRT.localScale = new Vector3(1f, 1f, 1f);
            buttonRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            newButtonGO.AddComponent<Image>();
            var canvasButton = newButtonGO.AddComponent<Button>();
            var buttonColourBlock = canvasButton.colors;
            buttonColourBlock.highlightedColor = Color.red;
            canvasButton.colors = buttonColourBlock;

            int testinteger = 0;
            float testfloat = 0;

            var newTextGO = new GameObject("BtnText", typeof(RectTransform));
            newTextGO.transform.SetParent(newButtonGO.transform);
            newTextGO.layer = 5;

            var textRT = newTextGO.GetComponent<RectTransform>();
            textRT.position = new Vector3(0f, 0f, 0f);
            textRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            textRT.localPosition = new Vector3(0f, 0f, 0f);
            textRT.sizeDelta = new Vector2(180f, 60f);
            textRT.localScale = new Vector3(1f, 1f, 1f);
            textRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            var txt = newTextGO.AddComponent<Text>();
            txt.text = "New Button";
            txt.color = Color.black;
            txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

            newCanvasGO.AddComponent<VRTK_UICanvas>();
        }
    }
}