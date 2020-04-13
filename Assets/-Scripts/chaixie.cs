namespace VRTK.Examples
{
    using UnityEngine;

    public class chaixie : VRTK_InteractableObject
    {
        //此脚本管理盒盖的拆卸
        public bool flipped = false;
        public bool rotated = false;

        private float sideFlip = -1;
        private float side = -1;
        private float smooth = 270.0f;
        private float doorOpenAngle = -90f;
        private bool open = false;

        private Vector3 defaultRotation;
        private Vector3 openRotation;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            VRTK_Logger.Info("开始用了");
            base.StartUsing(usingObject);
            SetDoorRotation(usingObject.transform.position);
            SetRotation();
            open = !open;
            if ((GameObject.Find("System").transform.localPosition.y) == 4.1f)
            {
                GameObject.Find("System").transform.localPosition = new Vector3(0f, 4.2f, 0f);
                GameObject.Find("luosidao").transform.localPosition = new Vector3(0f, 100f, 0f);
            }
            if ((GameObject.Find("System").transform.localPosition.x) == -1f)
            {
                GameObject.Find("luosidao").transform.localPosition = new Vector3(0f, 100f, 0f);
            }
        }

        protected void Start()
        {
            VRTK_Logger.Info("开始了");
            defaultRotation = transform.eulerAngles;
            SetRotation();
            sideFlip = (flipped ? 1 : -1);
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