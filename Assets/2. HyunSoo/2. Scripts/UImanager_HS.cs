using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class UImanager_HS : MonoBehaviour
{
    public GameObject UI;
    public static UImanager_HS instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UI.SetActive(false);     // ui 다끄기
    }
    
    public void Re_gameOnclick()   //재시작 버튼용
    {
        SceneManager.LoadScene("MINI_game");
    }
    public void Go_Menu() //메뉴가기 버튼용
    {
        SceneManager.LoadScene("Minigame_Menu");
    }

}
