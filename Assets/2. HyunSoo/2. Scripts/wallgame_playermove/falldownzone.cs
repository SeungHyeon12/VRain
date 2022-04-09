using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldownzone : MonoBehaviour
{
    public GameObject camerarig;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Contains("RF") || other.tag.Contains("LF"))
        {
            Debug.Log("가라앉는다");
            camerarig.transform.position += Time.deltaTime * 0.45f * Vector3.down;
        }
    }

}
