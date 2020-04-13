namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class xianshiping : VRTK_InteractableObject
    {
        //此脚本管理显示屏操作
        public RectTransform image;
        public RectTransform image2;
        public int i=0;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
                if ((GameObject.Find("System").transform.localPosition.y) == 10f)
                {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 10.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                    GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                    image2.DOMove(new Vector3(-0.194f, 0.449f, 0.094f), 0.5f);
                GameObject.Find("Plane001").GetComponent<BoxCollider>().enabled = false;
            }
                i++;
            if ((GameObject.Find("System").transform.localPosition.y) == 8f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 8.5f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                image.DOMove(new Vector3(-0.194f, 0.449f, 0.094f), 0.5f);
                GameObject.Find("Plane001").GetComponent<BoxCollider>().enabled = false;
            }



        }

        protected void Start()
        {
            VRTK_Logger.Info("开始了");
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
