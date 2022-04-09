using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_righthand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("RH"))
        {
            Debug.Log("오른손 충돌");
            Wallgame_manager_HS.instance.isright = 0;
        }
     }
}
