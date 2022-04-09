using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UImanager_w_HS : MonoBehaviour
{
    public GameObject UI;
    public static UImanager_w_HS instance;
    public GameObject righthandUI;
    public GameObject lefthandUI;
    public GameObject headUI;
    public GameObject reamainUI;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UI.SetActive(false);     // ui 다끄기
        reamainUI.SetActive(false);
        righthandUI.SetActive(false);
        lefthandUI.SetActive(false);
        headUI.SetActive(false);
    }
    
    public void Re_gameOnclick()   //재시작 버튼용
    {
        SceneManager.LoadScene("MINI_Wall");
    }
    public void Go_Menu() //메뉴가기 버튼용
    {
        SceneManager.LoadScene("Minigame_Menu");
    }
   
}
