using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_head : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)     //트리거
    {
        if (other.transform.CompareTag("Head"))
        {
            Debug.Log("머리충돌");
            Wallgame_manager_HS.instance.ishead = 0;
        }
    }
}
