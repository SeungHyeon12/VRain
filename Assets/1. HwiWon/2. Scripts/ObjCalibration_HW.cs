using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCalibration_HW : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("[CameraRig]_Player").transform.GetChild(0).transform;    
    }

    // Update is called once per frame
    void Update()
    {
        if (StartButton_HW.isBtnExit)
        {
            transform.parent = null;
            transform.position = new Vector3(-.15f,0,0);
            transform.rotation = Quaternion.Euler(0,0,0);
            transform.localScale = Vector3.one;
        }
    }
}
