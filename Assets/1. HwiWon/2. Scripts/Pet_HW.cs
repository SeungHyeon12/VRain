using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet_HW : MonoBehaviour
{
    // 펫 인덱스 (거북이 0 , 홍학 1, 원숭이 2)
    int p_Index;
    NavMeshAgent nma;
    Animator anim;
    // 이동할 목적지 목록
    public GameObject[] destinations;
    int d_index;
    float defaultSpeed;
    bool isWater;
    bool isTouch;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("Turtle"))
        {
            p_Index = 0;
            nma = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }
        else if (gameObject.name.Contains("Flamingo"))
        {
            p_Index = 1;
            nma = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }
        else if (gameObject.name.Contains("Monkey"))
        {
            p_Index = 2;
            nma = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }
        defaultSpeed = nma.speed;

        // 목적지 랜덤 호출
        RandomDest();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어와 상호작용 상태가 아닐 때 이동
        //if ()
        //{
        switch (p_Index)
        {
            // 거북이
            case 0:
                nma.destination = destinations[d_index].transform.position;
                // 물과 터치가 아닐때만 걷기
                if (!isWater && !isTouch)
                {
                    anim.SetBool("Walk", true);
                }
                break;
            // 홍학
            case 1:
                nma.destination = destinations[d_index].transform.position;
                if (!isTouch)
                {
                    anim.SetBool("Walk", true);
                }
                break;
            // 원숭이
            case 2:
                nma.destination = destinations[d_index].transform.position;
                if (!isTouch)
                {
                    anim.SetBool("Walk", true);
                }
                break;
        }

        // 목적지와 거리가 2m 이내이면
        if ((Vector3.Distance(destinations[d_index].transform.position, transform.position) < 2))
        {
            // 목적지 랜덤 호출
            RandomDest();
        }

        // 터치시 속도 0
        if (isTouch)
        {
            nma.speed = 0;
        }
        // 원래 속도로 돌려줌
        else
        {
            nma.speed = defaultSpeed;
        }

    }

    // 목적지 랜덤
    void RandomDest()
    {
        int temp = d_index;
        // 목적지 인덱스 랜덤
        d_index = Random.Range(0, destinations.Length);

        // 랜덤으로 돌린 목적지과 이전과 같으면 재실행
        if (temp == d_index)
        {
            d_index = Random.Range(0, destinations.Length);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         // 거북이가 물 위에 올라가면 수영
        if (other.gameObject.name.Contains("Water") && gameObject.name.Contains("Turtle"))
        {
            isWater = true;
            nma.speed = 2;
            anim.SetBool("Walk", false);
            anim.SetBool("Swim", true);
        }

        // 플레이어 vr_glove 혹은 vr_Trakcer와 닿으면
        if (other.gameObject.name.Contains("vr_"))
        {
            isTouch = true;
            anim.SetBool("Walk", false);
            // 시간초 지연 필요 -> 코루틴 분기
            anim.SetBool("Touch", true);
            StartCoroutine("TouchFinish");
        }
    }
    // 거북이가 물에서 나오면 걷기
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Water") && gameObject.name.Contains("Turtle"))
        {
            anim.SetBool("Swim", false);
            isWater = false;
            nma.speed = defaultSpeed;
        }
    }

    IEnumerator TouchFinish()
    {
        yield return new WaitForSeconds(2f);
        isTouch = false;
        anim.SetBool("Touch", false);
    }
}
