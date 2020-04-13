namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class jiexian : VRTK_InteractableObject
    {
        //此脚本管理接线操作
        public int i = 0;
        public float scale = 1;
        public RectTransform image;
        AudioSource audio2;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("开始用了");
            if (i == 0)
            {
                
                i++;
            }
            else
            {
                i = 3;
            }


        }

        protected void Start()
        {
            VRTK_Logger.Info("开始了");
            audio2 = GameObject.Find("逻辑控制/操作正确").GetComponent<AudioSource>();
        }

        protected override void Update()
        {
            base.Update();
            if (i == 1)
            {
                scale = scale - 0.01f;
                this.transform.localScale = new Vector3(1f, scale, 1f);
                this.transform.localPosition -= new Vector3(0f, 0.005f, 0f);
                if (scale <= 0.7f)
                    i = 2;
            }
            if (i == 3)
            {
                scale = scale + 0.01f;
                this.transform.localScale = new Vector3(1f, scale, 1f);
                this.transform.localPosition += new Vector3(0f, 0.005f, 0f);
                if (scale >= 1f)
                {
                    i = 0;
                    GameObject.Find("main/start2/correct").gameObject.SetActive(true);
                    audio2.Play();
                    if ((GameObject.Find("System").transform.localPosition.x) != -1f)
                    {
                        image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                        GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "接线成功，请检查GPRS模块";
                        GameObject.Find("0menu-1/inform").GetComponent<Text>().text += "\n请检查右侧GPRS模块信号灯，灯灭进行更换";
                        GameObject.Find("System").transform.localPosition = new Vector3(14f, 200f, 0f);
                    }
                    
                    GameObject.Find("lineyellow").GetComponent<BoxCollider>().enabled = true;
                    GameObject.Find("qianzi").transform.localPosition = new Vector3(0f, 100f, 0f);
                    //设置更改窗口的大小
                    //Vector3 max = new Vector3(0.002f, 0.002f, 0.02f);
                    //image.DOScale(max, 1f);
                }

            }
            }
        }
    }

