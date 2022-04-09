using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_Manager_HS : MonoBehaviour
{
    public static Fade_Manager_HS instance;
    public bool isFade_start = false;
    public GameObject Fade_gameobj;
    Image Fade_Object;
    bool isFade_end = false;
 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Fade_Object = Fade_gameobj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade_start)
        {
            StartCoroutine(MainSplash_reverse());
        }
        if (!isFade_end)
        {
            StartCoroutine(MainSplash());
        }
        
    }

   

    IEnumerator MainSplash()
    {
        Color color = Fade_Object.color;


        if (color.a < 0)
        {
            color.a = 0;
            isFade_end = true;
            yield return null;
        }
        else
        {
            color.a -= 0.17f * Time.deltaTime;
            Fade_Object.color = color;
            
            
        }                           //코루틴 종료
    }
    IEnumerator MainSplash_reverse()
    {
        Color color = Fade_Object.color;


        if (color.a > 1)
        {
            color.a = 1;
            isFade_end = false;
            Destroy(this.gameObject);
            yield return null;
        }
        else
        {
            color.a += 0.2f * Time.deltaTime;
            Fade_Object.color = color;
   
        }                           //코루틴 종료
    }
}
