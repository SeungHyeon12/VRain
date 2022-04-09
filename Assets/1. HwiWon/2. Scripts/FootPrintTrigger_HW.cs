using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 풋프린트 본체에 달려있는 컬라이더 감지 스크립트 ( 발 개별)
public class FootPrintTrigger_HW : MonoBehaviour
{
    // 양발 발가락 올려져있는지 확인용
    public static bool bothToeOn;

    // 왼발 ,오른발이 올려져 있는지
    public static bool LT_On, RT_On;

    // 테스트용 발판 캔버스 (올라가면 텍스트 표시) **************************************
    public GameObject footPrintCanvas_L, footPrintCanvas_R;

    private void Start()
    {
        bothToeOn = false;
    }
    private void FixedUpdate()
    {
        // 오른발, 왼발 발가락이 둘다 올려져 있다면
        if (RT_On && LT_On)
        {
            //print("양 발가락 On");
            bothToeOn = true;
        }
        else
        {
            //print("양 발가락 Off");
            bothToeOn = false;
        }
        // 오른발 발가락 이미지 o 표시
        footPrintCanvas_R.transform.GetChild(0).gameObject.SetActive(RT_On);
        footPrintCanvas_R.transform.GetChild(1).gameObject.SetActive(!RT_On);
        // 왼발 발가락 이미지 x 표시
        footPrintCanvas_L.transform.GetChild(0).gameObject.SetActive(LT_On);
        footPrintCanvas_L.transform.GetChild(1).gameObject.SetActive(!LT_On);
    }

    private void OnTriggerStay(Collider other)
    {
        // 왼발이 맞게 올라와 있다면
        if (gameObject.tag == "LFT" && other.gameObject.tag == "LF")
        {
            //print("왼발 토 체크 확인");
            LT_On = true;
        }
        // 오른발이 맞게 올라와 있다면
        if (gameObject.tag == "RFT" && other.gameObject.tag == "RF")
        {
            //print("오른발 토 체크 확인");
            RT_On = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 왼발이 떨어졌다면
        if (gameObject.tag == "LFT" && other.gameObject.tag == "LF")
        {
            //print("좌 토 떨어짐");
            LT_On = false;
        }
        // 오른발이 떨어졌다면
        if (gameObject.tag == "RFT" && other.gameObject.tag == "RF")
        {
            //print("우 토 떨어짐");
            RT_On = false;
        }
    }
    public static void ToeReset()
    {
        RT_On = false;
        LT_On = false;
        bothToeOn = false;
    }
}
