using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wallgame_remain_HS : MonoBehaviour
{
    public TMP_Text remainUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainUI.text = "남은갯수 : " + "<color=blue>"+ Wall_Respawn_HS.instance.level_c +"</color>";
    }
}
