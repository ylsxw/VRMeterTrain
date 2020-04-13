namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class SIM : VRTK_InteractableObject
    {
        public RectTransform image;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("SIM卡更换成功");
            GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "SIM卡更换成功";
            GameObject.Find("System").transform.localPosition = new Vector3(16f, 200f, 0f);
            image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
            //GameObject.Find("016").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
            GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
            GameObject.Find("ICON").transform.Find("ICON4").gameObject.SetActive(false);
            GameObject.Find("ICON").transform.Find("ICON3").gameObject.SetActive(true);
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
