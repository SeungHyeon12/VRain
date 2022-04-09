using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 풋프린트 본체의 자식에 달려있는 뒤꿈치 충돌감지 스크립트
public class FootHeelCheck_HW : MonoBehaviour
{
    // 양발 뒷꿈치 올려져있는지 확인용
    public static bool bothHeelOn;

    // 왼발 ,오른발이 올려져 있는지
    public static bool LH_On, RH_On;

    // 테스트용 발판 캔버스
    public GameObject footPrintCanvas_L, footPrintCanvas_R;

    private void Start()
    {
        bothHeelOn = false;
    }

    private void Update()
    {
        // 오른발, 왼발 뒷꿈치가 둘다 올려져 있다면
        if (RH_On && LH_On)
        {
            //print("양 뒷꿈치 On");
            bothHeelOn = true;
        }
        else
        {
            //print("양 뒷꿈치 Off");
            bothHeelOn = false;
        }

        if (!bothHeelOn)
        {
            //print("뒷꿈치 떨어짐");
        }

        // 왼발 뒤꿈치 이미지 o 표시
        footPrintCanvas_L.transform.GetChild(2).gameObject.SetActive(LH_On);
        footPrintCanvas_L.transform.GetChild(3).gameObject.SetActive(!LH_On);
        // 오른발 뒤꿈치 이미지 o 표시
        footPrintCanvas_R.transform.GetChild(2).gameObject.SetActive(RH_On);
        footPrintCanvas_R.transform.GetChild(3).gameObject.SetActive(!RH_On);
    }

    private void OnTriggerStay(Collider other)
    {
        // 왼발이 맞게 올라와 있다면
        if (gameObject.tag == "LFH" && other.gameObject.tag == "LF")
        {
            //print("왼발 힐 체크 확인");
            LH_On = true;
        }
        // 오른발이 맞게 올라와 있다면
        if (gameObject.tag == "RFH" && other.gameObject.tag == "RF")
        {
            //print("오른발 힐 체크 확인");
            RH_On = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 왼발이 떨어졌다면
        if (gameObject.tag == "LFH" && other.gameObject.tag == "LF")
        {
            //print("좌 힐 떨어짐");
            LH_On = false;
        }
        // 오른발이 떨어졌다면
        if (gameObject.tag == "RFH" && other.gameObject.tag == "RF")
        {
            // print("우 힐 떨어짐");
            RH_On = false;
        }
    }

    public static void HeelReset()
    {
        RH_On = false;
        LH_On = false;
        bothHeelOn = false;
    }
}
