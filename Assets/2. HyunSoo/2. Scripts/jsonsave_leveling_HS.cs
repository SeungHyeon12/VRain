using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

class data_set
{
    public string sex;
    public int age;
    public int height;
    public int SBS;
    public int ST;
    public int T;
    public int ChairStand;
    public int Gatespeed;


    public data_set(string sex, int age, int height, int SBS, int ST, int T, int ChairStand, int Gatespeed)
    {
        this.sex = sex;
        this.age = age;
        this.height = height;
        this.SBS = SBS;
        this.ST = ST;
        this.T = T;
        this.ChairStand = ChairStand;
        this.Gatespeed = Gatespeed;
    }
}


public class jsonsave_leveling_HS : MonoBehaviour
{
    public static jsonsave_leveling_HS instance;
    List<data_set> data = new List<data_set>();

    ///////
    // public TMP_Text text111;
    //  public string file = "test.txt";

    private void Start()
    {
        instance = this;
    }

    //////////////
    //public void Save()
    //{
    //    print("저장");
    //    string sex = PlayerPrefs.GetString("sex");
    //    int age = PlayerPrefs.GetInt("age");
    //    int height = PlayerPrefs.GetInt("Height");
    //    int SBS = PlayerPrefs.GetInt("SBS");
    //    int ST = PlayerPrefs.GetInt("ST");
    //    int T = PlayerPrefs.GetInt("T");
    //    int Chairstand = PlayerPrefs.GetInt("CHAIR");
    //    int Gatespeed = PlayerPrefs.GetInt("GAIT");

    //    Save_MInigame_lv(SBS, ST, T, Chairstand, Gatespeed);// 테스트값 저장

    //    string json = JsonUtility.ToJson(data);
    //    WriteToFile(file, json);


    //    Load();
    //}
    //public void Load()
    //{
    //    print("저장값 호출");
    //    string json = ReadFromFile(file);
    //    JsonUtility.FromJsonOverwrite(json, data);
    //}
    //void WriteToFile(string fileName, string json) 
    //{
    //    print("파일쓰기");
    //    string path = GetFilePath(file);
    //    FileStream fileStream = new FileStream(path, FileMode.Create);

    //    using(StreamWriter writer = new StreamWriter(fileStream)){
    //        writer.Write(json);
    //    }
    //}
    //string ReadFromFile(string fileName)
    //{
    //    print("파일읽기");
    //    string temp_jdata2 = Application.persistentDataPath + "/test.json";
    //    if (File.Exists(temp_jdata2))
    //    {
    //        using (StreamReader reader = new StreamReader(temp_jdata2))
    //        {
    //            string json = reader.ReadToEnd();
    //            return json;
    //        }
    //    }
    //    else
    //        Debug.LogWarning("File Not Found");
    //    return "";
    //}
    //string GetFilePath(string fileName)
    //{
    //    return Application.persistentDataPath + "/test.json";
    //}

    public void Onclick_save()
    {
        string sex = PlayerPrefs.GetString("sex");
        int age = PlayerPrefs.GetInt("age");
        int height = PlayerPrefs.GetInt("Height");
        int SBS = PlayerPrefs.GetInt("SBS");
        int ST = PlayerPrefs.GetInt("ST");
        int T = PlayerPrefs.GetInt("T");
        int Chairstand = PlayerPrefs.GetInt("CHAIR");
        int Gatespeed = PlayerPrefs.GetInt("GAIT");

        Save_MInigame_lv(SBS, ST, T, Chairstand, Gatespeed);// 테스트값 저장
                                                            //string strfile = Application.streamingAssetsPath + "/test.json";
                                                            //FileInfo fileinfo = new FileInfo(strfile);  // 파일확인 


        //////////////////////////////////////
        /* if (!fileinfo.Exists)//파일이 없을경우
         {
             File.Create(strfile);
             Debug.Log("파일이 만들어졌소");
         }*/
        string temp_jdata = File.ReadAllText(Application.streamingAssetsPath + "/test.json");

        ////////////////////////
        /* if (temp_jdata != null)
         {
             text111.text = "못읽어옴";
         }
         else
         {
             text111.text = "읽어옴";
         }*/

        Debug.Log(temp_jdata);


        if (temp_jdata != "")
        {
            data = JsonConvert.DeserializeObject<List<data_set>>(temp_jdata);
            Debug.Log("로드된다");
            data.Add(new data_set(sex, age, height, SBS, ST, T, Chairstand, Gatespeed));

        }
        else
        {
            data.Add(new data_set(sex, age, height, SBS, ST, T, Chairstand, Gatespeed));
            Debug.Log("작동된다");
        }
        string jdata = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.streamingAssetsPath + "/test.json", jdata);
    }



    private void Save_MInigame_lv(int SBS, int ST, int T, int Chairstand, int Gatespeed)
    {
        //////////////미니게임 징검다리
        if (SBS + ST + T <= 1)
            PlayerPrefs.SetInt("MINI_lv", 1);
        else if (SBS + ST + T == 4)
            PlayerPrefs.SetInt("MINI_lv", 3);
        else
            PlayerPrefs.SetInt("MINI_lv", 2);
        //////꽃줍기는 lv 로
        if (Chairstand <= 1)
            PlayerPrefs.SetInt("MINI_F_lv", 4);
        else if (Chairstand == 4)
            PlayerPrefs.SetInt("MINI_F_lv", 9);
        else
            PlayerPrefs.SetInt("MINI_F_lv", 6);
        ///////마찬가지로 gatespeed 도 갯수로
        if (Chairstand <= 1)
            PlayerPrefs.SetInt("MINI_W_lv", 4);
        else if (Chairstand == 4)
            PlayerPrefs.SetInt("MINI_W_lv", 9);
        else
            PlayerPrefs.SetInt("MINI_W_lv", 6);

        PlayerPrefs.SetInt("Example", 3);
    }

    //읽는데
    /*
    public void Onclick_Load()
    {
        string jdata = File.ReadAllText(Application.streamingAssetsPath + "/test.json");
        Debug.Log(jdata.Split(',').Length);
       // tx.text = jdata;

    }*/
}