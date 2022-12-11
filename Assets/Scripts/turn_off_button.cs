using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_off_button : MonoBehaviour
{
    
     public GameObject yourbutton;
 public void DisableButton ()
 {
       yourbutton.SetActive(false);
 }
}
