using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    class data_Test
    {
        public string sex;
        public int age;
        public int height;
        public int SBS;
        public int ST;
        public int T;
        public int ChairStand;
        public int Gatespeed;


        public data_Test(string sex, int age, int height, int SBS, int ST, int T, int ChairStand, int Gatespeed)
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

    private void Awake()
    {
        string sex = PlayerPrefs.GetString("sex");
        int age = PlayerPrefs.GetInt("age");
        int height = PlayerPrefs.GetInt("Height");
        int SBS = PlayerPrefs.GetInt("SBS");
        int ST = PlayerPrefs.GetInt("ST");
        int T = PlayerPrefs.GetInt("T");
        int Chairstand = PlayerPrefs.GetInt("CHAIR");
        int Gatespeed = PlayerPrefs.GetInt("GAIT");
    }
}
