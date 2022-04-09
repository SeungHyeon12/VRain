using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart_F_HS : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("LH") || other.tag.Contains("RH"))
        {
            UImanager_f_HS.instance.Re_gameOnclick();
        }
    }
}
