using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTriggerEffect_HW : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Camera" && FootCheck_SC3_HW.bothFootOn)
        {
            GameObject go = Instantiate(effectPrefab);
            go.transform.position = transform.position;
            Destroy(go, 2);
        }
    }
}
