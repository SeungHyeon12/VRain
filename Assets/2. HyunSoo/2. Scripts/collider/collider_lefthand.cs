using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_lefthand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("LH"))
        {
            Debug.Log("왼손 충돌");
            Wallgame_manager_HS.instance.isleft = 0;
        }
    }
}
