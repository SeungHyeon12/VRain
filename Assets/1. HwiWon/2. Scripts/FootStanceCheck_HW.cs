using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발판에서 플레이어 트래커와 충돌여부 판정 스크립트
public class FootStanceCheck_HW : MonoBehaviour
{
    public static FootStanceCheck_HW instance;
    bool effectFlag;
    private void Awake()
    {
        instance = this;
    }
    public enum Test
    {
        SBS,
        ST,
        T
    }
    public Test test;

    public GameObject footEffect;
    public Transform sbs_L, st_L, t_L;

    public GameObject testAuraEffect;
    public bool testAuraEffectOn;
    public bool footprintChange;
    public static bool isTTest;
    // 양발 플래그
    public bool bothFootOn;

    // 양발이 다 올라가 있다면
    // SC2Dial에서 호출
    public IEnumerator BothFootOn()
    {
        if (!effectFlag && !StartButton_HW.isTestStart)
        {
            effectFlag = true;
            // 발 올라간 효과
            GameObject go = Instantiate(footEffect);

            if(test == Test.SBS)
            {
                go.transform.position = sbs_L.transform.position + new Vector3(0f, 0.35f, 0.1f);
            }
            else if (test == Test.ST)
            {
                go.transform.position = st_L.transform.position + new Vector3(0.1f, 0.35f, 0.1f);
            }
            else if(test == Test.T)
            {
                go.transform.position = t_L.transform.position + new Vector3(0.15f, 0.35f, 0.1f);
            }

            yield return new WaitForSeconds(2);
            Destroy(go);
            effectFlag = false;
        }
    }

    private void FixedUpdate()
    {
        if (FootHeelCheck_HW.bothHeelOn && FootPrintTrigger_HW.bothToeOn)
        {
            bothFootOn = true;
        }
        else
        {
            bothFootOn = false;
        }

        // 테스트가 진행중이라면 아우라 효과
        if (StartButton_HW.isTestStart && !testAuraEffectOn)
        {
            testAuraEffectOn = true;
            GameObject go = Instantiate(testAuraEffect);
            go.name = "Aura";

            if (test == Test.SBS)
            {
                go.transform.position = sbs_L.transform.position;
            }
            else if (test == Test.ST)
            {
                go.transform.position = st_L.transform.position;
            }
            else if (test == Test.T)
            {
                go.transform.position = t_L.transform.position;
            }
        }

        // 10초가 지나면(테스트가 끝나면)
        if (!CircleCount.isTimerOn)
        {
            // 아우라효과 삭제
            Destroy(GameObject.Find("Aura"));
        }

        // 일반자세
        if (test == Test.SBS)
        {
           // print(test);
            UpdateSBS();
        }
        // 반일렬자세
        else if (test == Test.ST)
        {
            //print(test);
            UpdateST();
        }
        // 일렬자세
        else if (test == Test.T)
        {
            //print(test);
            UpdateT();
        }
    }

    // SBS 발판 위치************************************************************************
    private void UpdateSBS()
    {
        if (!footprintChange)
        {
            footprintChange = true;
            // SBS 발판 켜기
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    // ST 발판 위치
    private void UpdateST()
    {
        if (footprintChange)
        {
            footprintChange = false;
            // SBS 발판 없애기
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            // ST 발판 켜기
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }
    // T 발판 위치
    private void UpdateT()
    {
        if (!footprintChange)
        {
            footprintChange = true;

            // 15초
            CircleCount.loadingProgress = 1.5f;
            // TTest때 서클카운트 이미지 fillAmount 바꿔주기 위함
            isTTest = true;
            // ST 발판 끄기
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            // T 발판 켜기
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
        }
    }

    // 다른 스크립트에서 설정용
    public void Test_SBS()
    {
        SetTest(Test.SBS);
    }
    public void Test_ST()
    {
        SetTest(Test.ST);
    }
    public void Test_T()
    {
        SetTest(Test.T);
    }

    // 상태 전이용 
    void SetTest(Test next)
    {
        // 테스트를 다음상태로 전이하고
        test = next;

        if (next == Test.SBS)
        {
            UpdateSBS();
        }
        else if (next == Test.ST)
        {
            UpdateST();
        }
        else if (next == Test.T)
        {
            UpdateT();
        }
    }
}
