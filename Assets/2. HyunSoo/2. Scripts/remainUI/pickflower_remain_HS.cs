using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickflower_remain_HS : MonoBehaviour
{
    public TMP_Text remainUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        remainUI.text = "남은갯수 : " + "<color=blue>" + Flower_respawn_HS.instance.game_level + "</color>";
    }
}
