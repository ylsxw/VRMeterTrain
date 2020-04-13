using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHide : MonoBehaviour
{
    //管理红绿灯的闪烁
    private float shake;
    //通过控制物体的MeshRenderer组件的开关来实现物体闪烁的效果
    private MeshRenderer BoxColliderClick;
    // Use this for initialization
    void Start()
    {
        BoxColliderClick = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        shake += 5*Time.deltaTime;
        //Debug.Log(shake);
        //取余运算，结果是0到被除数之间的值
        //如果除数是1 1.1 1.2 1.3 1.4 1.5 1.6 
        //那么余数是0 0.1 0.2 0.3 0.4 0.5 0.6
        if (shake % 1 > 0.5f)
        {
            BoxColliderClick.enabled = true;
        }
        else
        {
            BoxColliderClick.enabled = false;
        }
    }
}