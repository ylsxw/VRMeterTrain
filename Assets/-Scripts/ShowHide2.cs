using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHide2 : MonoBehaviour
{



    //创建一个常量，用来接收时间的变化值
    private float shake = 0;
    //通过控制物体的MeshRenderer组件的开关来实现物体闪烁的效果
    private MeshRenderer BoxColliderClick;
    public int i=0;
    // Use this for initialization
    void Start()
    {
        BoxColliderClick = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            if (transform.GetComponent<MeshRenderer>().material.color.r > 0)
            {
                transform.GetComponent<MeshRenderer>().material.color -= new Color(1, 1, 1) * Time.deltaTime * 0.5f;
            }
            else
                i = 1;
        }
        if (i == 1)
        {
            if (transform.GetComponent<MeshRenderer>().material.color.r < 1f)
            {
                transform.GetComponent<MeshRenderer>().material.color += new Color(1, 0.5f, 0) * Time.deltaTime * 0.5f;
            }
            else
                i = 0;
        }
    }
}
