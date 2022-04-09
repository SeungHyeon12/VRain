using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class buttoncollision_HS : MonoBehaviour
{
    Material origin;
    Material temp;
    private void Start()
    {
        origin = GetComponent<Material>();
        temp = origin;
    }

    private void OnTriggerStay(Collider other)
    {
        ButtonManager.instance.collisionGameobejct = gameObject;
        ButtonManager.instance.Gameobject_name = this.gameObject.name;
    }
}
