namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using DG.Tweening;

    public class check : VRTK_InteractableObject
    {
        //此脚本及check2,3管理检查操作
        public bool flipped = false;
        public bool rotated = false;

        private float sideFlip = -1;
        private float side = -1;
        private float smooth = 270.0f;
        private float doorOpenAngle = -90f;
        private bool open = false;
        private int open2 = 0;

        private Vector3 defaultRotation;
        private Vector3 openRotation;
        public RectTransform image;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("开始检查");
            //base.StartUsing(usingObject);
            //SetDoorRotation(usingObject.transform.position);
            //SetRotation();
            float step = 0.1f * Time.deltaTime;
            open = !open;
            open2 = 5;
        }
    

        protected void Start()
        {
            defaultRotation = transform.eulerAngles;
            SetRotation();
            sideFlip = (flipped ? 1 : -1);
        }

        protected override void Update()
        {
            base.Update();
            if (open&&open2>0)
            {
                open2--;
                float step = 0.1f * Time.deltaTime;
                transform.localPosition = new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 0, step), Mathf.Lerp(gameObject.transform.localPosition.y, 0, step), Mathf.Lerp(gameObject.transform.localPosition.z, 2, step));
                // transform.localPosition = new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 0, step), Mathf.Lerp(gameObject.transform.localPosition.y, 0, step), Mathf.Lerp(gameObject.transform.localPosition.z, 1, step));
                //transform.position = new Vector3(0f+, 0f, 0f);
                
            }
            else
            {
                if (open2 > 0)
                {
                    open2--;
                    float step = 0.1f * Time.deltaTime;
                    transform.localPosition = new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 0, step), Mathf.Lerp(gameObject.transform.localPosition.y, 0, step), Mathf.Lerp(gameObject.transform.localPosition.z, -2, step));
                    //transform.position = new Vector3(5f, 5f, 5f);
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * smooth);
                    if (open2 == 0)
                    {
                        if ((GameObject.Find("System").transform.localPosition.x) == 105f)
                        {
                            GameObject.Find("部件一").GetComponent<BoxCollider>().enabled = false;
                            image.DOMove(new Vector3(-0.194f, 0.449f, -0.2f), 0.5f);
                            GameObject.Find("二级菜单/1menu-1/Text").GetComponent<Text>().text = "更换模块成功";
                            GameObject.Find("System").transform.localPosition = new Vector3(106f, 200f, 0f);
                            GameObject.Find("Capsule072").GetComponent<MeshRenderer>().material.color = Color.red;
                            //设置更改窗口的大小
                            //Vector3 max = new Vector3(1f, 1f, 1f);
                            //image.DOScale(max, 1f);
                        }
                    }
                }
            }
        }

        private void SetRotation()
        {
            //openRotation = new new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 0, step), Mathf.Lerp(gameObject.transform.localPosition.y, 0, step), Mathf.Lerp(gameObject.transform.localPosition.z, 1, step));
        }

        private void SetDoorRotation(Vector3 interacterPosition)
        {
            //side = ((rotated == false && interacterPosition.z > transform.position.z) || (rotated == true && interacterPosition.x > transform.position.x) ? -1 : 1);
        }
    }
}