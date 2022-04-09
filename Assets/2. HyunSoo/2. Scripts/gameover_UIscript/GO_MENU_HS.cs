using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO_MENU_HS : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("LH") || other.tag.Contains("RH"))
        {
            UImanager_HS.instance.Go_Menu();
        }
    }
}
