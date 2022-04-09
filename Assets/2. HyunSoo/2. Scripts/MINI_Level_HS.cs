using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINI_Level_HS : MonoBehaviour
{
    public GameObject lv1;
    public GameObject lv2;
    public GameObject lv3;
    // Start is called before the first frame update
    void Start()
    {
        lv1.SetActive(false);
        lv2.SetActive(false);
        lv3.SetActive(false);
        int SBS = PlayerPrefs.GetInt("SBS");
        int ST = PlayerPrefs.GetInt("ST");
        int T = PlayerPrefs.GetInt("T");

    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
