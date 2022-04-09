using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_leftfoot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("LF"))
        {
            Debug.Log("왼다리 충돌");
            Wallgame_manager_HS.instance.isleft_f = 0;
        }
    }
}
