using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinZone_HW : MonoBehaviour
{
    // 양발이 다 존 안에 들어왔는지
    public static bool isSpinZone;
    // 왼발, 오른발이 존 안에 들어왔는지
    static bool isLFinZone, isRFinZone;

    // 씬옮기는 플래그
    bool scFlag;
    Scene sc;

    private void Awake()
    {
        isSpinZone = false;
        isLFinZone = false;
        isRFinZone = false;
    }
    private void Start()
    {
        // false로 초기화
        isSpinZone = false;
        isLFinZone = false;
        isRFinZone = false;
        sc = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        // 왼발 오른발이 다 존 안에 있다면
        if(isLFinZone && isRFinZone)
        {
            // 양발이 존 안에 있음, 씬매니저 스크립트에서 불러다 쓰기 위함
            isSpinZone = true;
        }
        else
        {
            isSpinZone = false;
        } 
        print("양발" + isSpinZone);

        if(sc.name == "SC4" && isSpinZone && !scFlag)
        {
            scFlag = true;
            SceneManager_HW.firstTime = 2;
            SceneManager_HW.instance.Confetti();
            Invoke("LobbyResult",4f);
            PlayerPrefs.SetInt("isPlaying", 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LF")
        {
            isLFinZone = true;
        }
        else if (other.gameObject.tag == "RF")
        {
            isRFinZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LF")
        {
            isLFinZone = false;
        }
        else if (other.gameObject.tag == "RF")
        {
            isRFinZone = false;
        }
    }

    void LobbyResult()
    {
        SceneManager.LoadScene("Lobby");
    }
}
