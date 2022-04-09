using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestResult_HW : MonoBehaviour
{
    public TMP_Text total_score;

    // 과거기록 
    public TMP_Text past_balance;
    public TMP_Text past_chair;
    public TMP_Text past_gait;
    //현재기록 
    public TMP_Text cur_SBS;
    public TMP_Text cur_ST;
    public TMP_Text cur_T;

    public GameObject pass_sbs_pass;
    public GameObject pass_sbs_cautious;
    public GameObject pass_sbs_danger;

    public GameObject pass_chair_pass;
    public GameObject pass_chair_cautious;
    public GameObject pass_chair_danger;

    public GameObject pass_walk_pass;
    public GameObject pass_walk_cautious;
    public GameObject pass_walk_danger;

    public GameObject cur_sbs_pass;
    public GameObject cur_sbs_cautious;
    public GameObject cur_sbs_danger;

    public GameObject cur_chair_pass;
    public GameObject cur_chair_cautious;
    public GameObject cur_chair_danger;

    public GameObject cur_walk_pass;
    public GameObject cur_walk_cautious;
    public GameObject cur_walk_danger;

    int SBS;
    int ST;
    int T;
    int Chairstand;
    int Gatespeed;

    private void Awake()
    {
        // 과거점수
        past_balance.text = (PlayerPrefs.GetInt("Past_SBS") + PlayerPrefs.GetInt("Past_T") + PlayerPrefs.GetInt("Past_ST")).ToString() + "점";
        //**********************************************
        if (SBS + ST + T < 2)
        {
            pass_sbs_danger.SetActive(true);
        }
        else if (SBS + ST + T == 4)
        {
            pass_sbs_pass.SetActive(true);
        }
        else
        {
            pass_sbs_cautious.SetActive(true);
        }
        //*********************************************

        past_chair.text = PlayerPrefs.GetInt("Past_CHAIR").ToString() + "점";
        //**********************************************
        if (Chairstand < 2)
        {
            pass_chair_danger.SetActive(true);
        }
        else if (Chairstand == 4)
        {
            pass_chair_pass.SetActive(true);
        }
        else
        {
            pass_chair_cautious.SetActive(true);
        }
        //*********************************************

        past_gait.text = PlayerPrefs.GetInt("Past_GAIT").ToString() + "점";
        //**********************************************
        if (Gatespeed < 2)
        {
            pass_walk_danger.SetActive(true);
        }
        else if (Gatespeed == 4)
        {
            pass_walk_pass.SetActive(true);
        }
        else
        {
            pass_walk_cautious.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // 총점
        total_score.text = (SBS + ST + T + Chairstand + Gatespeed).ToString();

        SBS = PlayerPrefs.GetInt("SBS");
        ST = PlayerPrefs.GetInt("ST");
        T = PlayerPrefs.GetInt("T");
        Chairstand = PlayerPrefs.GetInt("CHAIR");
        Gatespeed = PlayerPrefs.GetInt("GAIT");

        cur_SBS.text = SBS + ST + T + "점";
        //********************************************** //// 현재
        if (SBS + ST + T < 2)
        {
            cur_sbs_danger.SetActive(true);
        }
        else if (SBS + ST + T == 4)
        {
            cur_sbs_pass.SetActive(true);
        }
        else
        {
            cur_sbs_cautious.SetActive(true);
        }
        //*********************************************

        cur_ST.text = Chairstand + "점";
        //**********************************************
        if (Chairstand < 2)
        {
            cur_chair_danger.SetActive(true);
        }
        else if (Chairstand == 4)
        {
            cur_chair_pass.SetActive(true);
        }
        else
        {
            cur_chair_cautious.SetActive(true);
        }
        //*********************************************

        cur_T.text = Gatespeed + "점";
        //**********************************************
        if (Gatespeed < 2)
        {
            cur_walk_danger.SetActive(true);
        }
        else if (Gatespeed == 4)
        {
            cur_walk_pass.SetActive(true);
        }
        else
        {
            cur_walk_cautious.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
