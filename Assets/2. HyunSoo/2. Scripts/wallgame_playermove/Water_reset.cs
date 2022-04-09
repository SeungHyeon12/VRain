using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Water_reset : MonoBehaviour
{
  
    public GameObject watersplash;
    GameObject temp_splash;
    private void Start()
    {
       
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RF") || other.CompareTag("LF"))
        {
            temp_splash = Instantiate(watersplash);
            temp_splash.transform.position = other.transform.position;
            print("물이터졋다");
        }
    }
 
}
