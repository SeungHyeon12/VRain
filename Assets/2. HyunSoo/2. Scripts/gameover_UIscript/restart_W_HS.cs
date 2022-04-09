using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart_W_HS : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("LH") || other.tag.Contains("RH"))
        {
            UImanager_w_HS.instance.Re_gameOnclick();
        }
    }
}
