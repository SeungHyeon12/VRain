using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBillboard_HS : MonoBehaviour
{
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = camera.transform.rotation;
    }
}
