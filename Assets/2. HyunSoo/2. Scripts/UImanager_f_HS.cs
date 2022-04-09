using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UImanager_f_HS : MonoBehaviour
{
    public GameObject UI;
    public static UImanager_f_HS instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UI.SetActive(false);     // ui 다끄기
    }
    
    public void Re_gameOnclick()   //재시작 버튼용
    {
        SceneManager.LoadScene("MINI_PickFlower");
    }
    public void Go_Menu() //메뉴가기 버튼용
    {
        SceneManager.LoadScene("Minigame_Menu");
    }
    private void Update()
    {
        print("테스트레벨1" + PlayerPrefs.GetInt("MINI_lv"));
        print("테스트레벨2" + PlayerPrefs.GetInt("MINI_F_lv"));
        print("테스트레벨3" + PlayerPrefs.GetInt("MINI_W_lv"));

    }
}
