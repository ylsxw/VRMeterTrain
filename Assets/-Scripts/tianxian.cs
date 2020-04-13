namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class tianxian : VRTK_InteractableObject
    {
        public bool flipped = false;
        public bool rotated = false;
        public RectTransform image;
        private float sideFlip = -1;
        private float side = -1;
        private float smooth = 270.0f;
        private float doorOpenAngle = -90f;
        private bool open = false;
        AudioSource audio2;
        private Vector3 defaultRotation;
        private Vector3 openRotation;
        //此脚本管理天线操作

        protected void Start()
        {
            VRTK_Logger.Info("开始了");
            defaultRotation = transform.eulerAngles;
            SetRotation();
            sideFlip = (flipped ? 1 : -1);
            audio2 = GameObject.Find("逻辑控制/操作正确").GetComponent<AudioSource>();
        }


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("开始天线");
            base.StartUsing(usingObject);
            SetDoorRotation(usingObject.transform.position);
            SetRotation();
            open = !open;

            if ((GameObject.Find("System").transform.localPosition.x) == 18f)
            {
                GameObject.Find("main/start2/correct").gameObject.SetActive(true);
                audio2.Play();
                if ((GameObject.Find("System2").transform.localPosition.y) == 0f)
                {
                    GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "信号恢复正常";
                    image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                }
                GameObject.Find("System").transform.localPosition = new Vector3(19f, 200f, 0f);
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("ICON").transform.Find("ICON2").gameObject.SetActive(false);
                GameObject.Find("ICON").transform.Find("ICON1").gameObject.SetActive(true);
            }

            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                audio2.Play();
                GameObject.Find("Line022").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("main").transform.Find("correct").gameObject.SetActive(true);
                GameObject.Find("main").transform.Find("help").gameObject.SetActive(false);
                GameObject.Find("ICON").transform.Find("ICON2").gameObject.SetActive(false);
                GameObject.Find("ICON").transform.Find("ICON1").gameObject.SetActive(true);
            }
        }

        protected override void Update()
        {
            base.Update();
            if (open)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation), Time.deltaTime * smooth);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * smooth);
            }
        }

        private void SetRotation()
        {
            openRotation = new Vector3(defaultRotation.x, defaultRotation.y + (doorOpenAngle * (sideFlip * side)), defaultRotation.z);
        }

        private void SetDoorRotation(Vector3 interacterPosition)
        {
            side = ((rotated == false && interacterPosition.z > transform.position.z) || (rotated == true && interacterPosition.x > transform.position.x) ? -1 : 1);
        }
    }
}