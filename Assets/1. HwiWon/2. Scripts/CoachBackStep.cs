using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoachBackStep : MonoBehaviour
{
    float time;
    float startTime;

    bool isDialStart, is7sec;
    bool idleTrigger;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (StartButton_HW.isBtnExit)
        {
            isDialStart = true;
        }
        // 캘리 x버튼이 눌렸는지
        if (isDialStart)
        {
            startTime += Time.deltaTime;
        }
        else
        {
            startTime = 0;
        }

        // 스타트타임이 7보다 커지면
        if (startTime > 7.5f)
        {
            is7sec = true;
        }

        // 애니메이션 시작한지 7초가 지났는지
        if (is7sec)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }

        // 4초동안만
        if(time < 3.7f && is7sec)
        {
            // 코치 움직임
            transform.position += new Vector3(-0.01f, 0, 0);
        }
        
        if(time > 4)
        {
            idleTrigger = true;
        }

        if (idleTrigger)
        {
            anim.SetTrigger("Idle");
        }
    }
}
