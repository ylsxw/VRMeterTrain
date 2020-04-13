using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolmenu : MonoBehaviour
{

    public Animator boolmenu;
    public Animator boolmenu1;
    public Animator boolmenu2;
    public void SetMenuin()
    {
   
        boolmenu .SetBool("boolmenu", true);
    }
    public void SetMenuout()
    {
        boolmenu1.SetBool("boolmenu1", true);
        boolmenu.SetBool("boolmenu", false);
        boolmenu2.SetBool("boolmenu2", true);
        boolmenu1.SetBool("boolmenu1", false);

    }


}
