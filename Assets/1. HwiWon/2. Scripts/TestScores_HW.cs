using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//데이터의 값이 들어오면 해당되는 데이터를 지표와 비교하여 점수를 부여한다.
public class TestScores_HW : MonoBehaviour
{
    public static TestScores_HW instance;
    
    void Awake()
    {
        instance = this;
    }

    
    // 결과 저장시 플래그
    public static bool resultSave;

    float timeLapse; // 데이터가 들어올 부분 
    // 스톱워치 스크립트에서 초 불러다 timeLapse에 저장
    int testScore;
    int index;
    Scene sc;

    // 4m 도달하면 뒤로 돌아가라는 경고 문구
    public GameObject cautionCanvas;
    // 저장시 한번만 호출되게끔 막는용도 플래그
    bool saveFlag;

    private void Start()
    {
        sc = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        // 결과저장 플래그가 true 이면 (스톱워치가 끝나는 순간 호출됨)
        if (resultSave)
        {
            print("결과저장 호출");
            resultSave = false;
            // 테스트 결과값 저장
            timeLapse = StopWatch.m_TotalSeconds;

            // 결과 저장 후 StopWatch.m_TotalSeconds를 0으로 초기화
            StopWatch.Reset();
            testScore = 0;

            // 시나리오2일 때(자세 테스트)
            if (sc.name == "SC2")
            {
                // 일반, 반일렬, 일렬자세 구분 위한 인덱스 증가
                index++;

                switch (index)
                {
                    case 1:
                        SBSTestScore();
                        break;
                    case 2:
                        STTestScore();
                        break;
                    case 3:
                        TTestScore();
                        break;
                }
            }
            else if (sc.name == "SC3")
            {
                ChairTestScore();
            }
            else if (sc.name == "SC4")
            {
                GaitTestScore();
            }
        }
    }

    // 스톱워치 기준
    public void SBSTestScore()
    {
        if (timeLapse >= 10)
        {
            testScore += 1;
        }
        else
        {
            testScore = 0;
        }
        // 플레이 한적이 없다면
        if(PlayerPrefs.GetInt("isPlaying") != 1)
        {
            PlayerPrefs.SetInt("Past_SBS", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Past_SBS", PlayerPrefs.GetInt("SBS"));
            PlayerPrefs.SetInt("SBS", testScore);
        }

        print("일반자세 점수: " + PlayerPrefs.GetInt("SBS"));
    }

    public void STTestScore()
    {
        if (timeLapse >= 10)
        {
            testScore += 1;
        }
        else
        {
            testScore = 0;
        }
        // 플레이 한적이 없다면
        if (PlayerPrefs.GetInt("isPlaying") != 1)
        {
            PlayerPrefs.SetInt("Past_ST", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Past_ST", PlayerPrefs.GetInt("ST"));
            PlayerPrefs.SetInt("ST", testScore);
        }

        print("반일렬자세 점수: "+PlayerPrefs.GetInt("ST"));
    }

    public void TTestScore()
    {
        if (timeLapse >= 10)
        {
            testScore += 2;
        }
        else if (timeLapse >= 3)
        {
            testScore += 1;
        }
        else
        {
            testScore = 0;
        }
        // 플레이 한적이 없다면
        if (PlayerPrefs.GetInt("isPlaying") != 1)
        {
            PlayerPrefs.SetInt("Past_T", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Past_T", PlayerPrefs.GetInt("T"));
            PlayerPrefs.SetInt("T", testScore);
        }
        print("일렬자세 점수: " +PlayerPrefs.GetInt("T"));

    }

    public void ChairTestScore()
    {
        if (timeLapse <= 11.2)
        {
            testScore = 4;
        }
        else if (13.7 <= timeLapse && timeLapse > 11.2)
        {
            testScore += 3;
        }
        else if (16.7 <= timeLapse && timeLapse > 13.7)
        {
            testScore += 2;
        }
        else if (60 <= timeLapse && timeLapse > 16.7)
        {
            testScore += 1;
        }
        else
        {
            testScore = 0;
        }
        // 플레이 한적이 없다면
        if (PlayerPrefs.GetInt("isPlaying") != 1)
        {
            PlayerPrefs.SetInt("Past_CHAIR", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Past_CHAIR", PlayerPrefs.GetInt("CHAIR"));
            PlayerPrefs.SetInt("CHAIR", testScore);
        }
        print("의자자세 점수: " + PlayerPrefs.GetInt("CHAIR"));
    }

    public void GaitTestScore()
    {
        if (timeLapse <= 4.82)
        {
            testScore = 4;
        }
        else if (6.2 <= timeLapse && timeLapse > 4.82)
        {
            testScore += 3;
        }
        else if (8.7 <= timeLapse && timeLapse >= 6.21)
        {
            testScore += 2;
        }
        else if (8.7 < timeLapse )
        {
            testScore += 1;
        }
        else
        {
            testScore = 0;
        }
        // 플레이 한적이 없다면
        if (PlayerPrefs.GetInt("isPlaying") != 1)
        {
            PlayerPrefs.SetInt("Past_GAIT", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Past_GAIT", PlayerPrefs.GetInt("GAIT"));
            PlayerPrefs.SetInt("GAIT", testScore);
        }
        print("걷기 점수: " +PlayerPrefs.GetInt("GAIT"));
        /////////////////////////////현수수정
        if (!saveFlag)
        {
            saveFlag = true;
            jsonsave_leveling_HS.instance.Onclick_save();
        }
        cautionCanvas.transform.GetChild(0).gameObject.SetActive(true);

    }
}
