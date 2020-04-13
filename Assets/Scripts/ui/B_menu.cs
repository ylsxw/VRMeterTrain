using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_menu : MonoBehaviour {
    
    public Animator b_menu;
	public void SetMenu()
    {
        b_menu.SetBool("b_menu", true);
    }
    public void SetMenuOut()
    {
        Debug.Log("1");
        b_menu.SetBool("b_menu", false );
        b_menu.SetBool("b_menu1", true);
    }


}
