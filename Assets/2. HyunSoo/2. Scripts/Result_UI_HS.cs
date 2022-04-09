using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.IO;

public class Result_UI_HS : MonoBehaviour
{
    public TMP_Text total_score;

    // 과거기록 
    public TMP_Text past_SBS;
    public TMP_Text past_ST;
    public TMP_Text past_T;
    //현재기록 
    public TMP_Text cur_SBS;
    public TMP_Text cur_ST;
    public TMP_Text cur_T;

    /// <summary>
    /// ///////////////////////////////////
    /// </summary>
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


    /// <summary>
    /// ////////////////////////////////////////
    /// </summary>

    //과거기록용 캐시 리스트
    List<data_set> temp_data = new List<data_set>();

    int SBS;
    int ST;
    int T;
    int Chairstand;
    int Gatespeed;

    int example;
    // Start is called before the first frame update
    private void Awake()
    {

        SBS = PlayerPrefs.GetInt("SBS");
        ST = PlayerPrefs.GetInt("ST");
        T = PlayerPrefs.GetInt("T");
        Chairstand = PlayerPrefs.GetInt("CHAIR");
        Gatespeed = PlayerPrefs.GetInt("GAIT");

        ///////////
        example = PlayerPrefs.GetInt("Example");
    }
    void Start()
    {
        total_score.text = (SBS + ST + T + Chairstand + Gatespeed).ToString();



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
        //*********************************************

        string temp_data_s = File.ReadAllText(Application.streamingAssetsPath + "/test.json");
        Debug.Log(temp_data_s == "");
        temp_data = JsonConvert.DeserializeObject<List<data_set>>(temp_data_s);
        Debug.Log(temp_data);

        if (temp_data == null || temp_data.Count == 1)  /// 과거
        {
            Debug.Log("하하");
            past_SBS.text = SBS + ST + T + "점";
            //**********************************************
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

            past_ST.text = Chairstand + "점";
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


            past_T.text = Gatespeed + "점";
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
            //*********************************************
        }


        else
        {

            past_SBS.text = temp_data[temp_data.Count - 2].SBS + temp_data[temp_data.Count - 2].ST + temp_data[temp_data.Count - 2].T + "점";
            //*******************************************
            if (temp_data[temp_data.Count - 2].SBS + temp_data[temp_data.Count - 2].ST + temp_data[temp_data.Count - 2].T < 2)
            {
                pass_sbs_danger.SetActive(true);
            }
            else if (temp_data[temp_data.Count - 2].SBS + temp_data[temp_data.Count - 2].ST + temp_data[temp_data.Count - 2].T == 4)
            {
                pass_sbs_pass.SetActive(true);
            }
            else
            {
                pass_sbs_cautious.SetActive(true);
            }
            //********************************************

            past_ST.text = temp_data[temp_data.Count - 2].ChairStand + "점";
            //*******************************************
            if (temp_data[temp_data.Count - 2].ChairStand < 2)
            {
                pass_chair_danger.SetActive(true);
            }
            else if (temp_data[temp_data.Count - 2].ChairStand == 4)
            {
                pass_chair_pass.SetActive(true);
            }
            else
            {
                pass_chair_cautious.SetActive(true);
            }
            //**********************************************

            past_T.text = temp_data[temp_data.Count - 2].Gatespeed + "점";
            //*******************************************
            if (temp_data[temp_data.Count - 2].Gatespeed < 2)
            {
                pass_walk_danger.SetActive(true);
            }
            else if (temp_data[temp_data.Count - 2].Gatespeed == 4)
            {
                pass_walk_pass.SetActive(true);
            }
            else
            {
                pass_walk_cautious.SetActive(true);
            }

            //**********************************************
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}