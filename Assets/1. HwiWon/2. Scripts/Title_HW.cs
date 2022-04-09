using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_HW : MonoBehaviour
{
    float time;
    public GameObject titleCanvas, titleUI;
    Animator titleAnim;
    // Start is called before the first frame update
    void Start()
    {
        titleAnim = titleUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 5.5)
        {
            // 타이틀 위로 올라가는 애니메이션
            titleAnim.SetTrigger("Title");
        }
        
        if(time > 7)
        {
            // 트래커 튜토리얼 켜기
            titleCanvas.transform.GetChild(1).gameObject.SetActive(true);
        }
        if(time > 17)
        {
            // 트래커 튜토리얼 끄기
            titleCanvas.transform.GetChild(1).gameObject.SetActive(false);
            // 캘리브레이션 튜토리얼 켜기
            titleCanvas.transform.GetChild(2).gameObject.SetActive(true);
        }
        if(time > 27)
        {
            // 캘리브레이션 튜토리얼 끄기
            titleCanvas.transform.GetChild(2).gameObject.SetActive(false);
            // 테스트 진행방식 켜기
            titleCanvas.transform.GetChild(3).gameObject.SetActive(true);
        }
        if(time > 34)
        {
            // 테스트 진행방식 끄기
            titleCanvas.transform.GetChild(3).gameObject.SetActive(false);
            // 물러나기 켜기
            titleCanvas.transform.GetChild(4).gameObject.SetActive(true);
        }
        if (time > 40)
        {
            // 물러나기 끄기
            titleCanvas.transform.GetChild(4).gameObject.SetActive(false);
            // 결과 켜기
            titleCanvas.transform.GetChild(5).gameObject.SetActive(true);
        }
        if (time > 50)
        {
            // 결과 끄기
            titleCanvas.transform.GetChild(5).gameObject.SetActive(false);
            // 미니게임 켜기
            titleCanvas.transform.GetChild(6).gameObject.SetActive(true);
        }
        if (time > 60)
        {
            // 미니게임 끄기
            titleCanvas.transform.GetChild(6).gameObject.SetActive(false);
            // 종료 켜기
            titleCanvas.transform.GetChild(7).gameObject.SetActive(true);
        }
        if(time > 70)
        {
            SceneManager.LoadScene("Lobby");
        }

    }
}
