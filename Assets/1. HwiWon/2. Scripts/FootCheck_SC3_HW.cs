using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCheck_SC3_HW : MonoBehaviour
{
    public GameObject LFT, LFH, RFT, RFH;
    public GameObject footEffect;
    bool effectFlag;
    //현수수정
    

    // 양발 플래그
    public static bool bothFootOn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FootHeelCheck_HW.bothHeelOn && FootPrintTrigger_HW.bothToeOn)
        {
            bothFootOn = true;
            StartCoroutine(BothFootOn());
        }
        else
        {
            bothFootOn = false;
        }
    }

    public IEnumerator BothFootOn()
    {
        if (!effectFlag && !StartButton_HW.isTestStart)
        {
            effectFlag = true;
            // 발 올라간 효과
            GameObject go = Instantiate(footEffect);
            go.transform.position = LFT.transform.position + new Vector3(0f, 0.35f, 0.1f);

            yield return new WaitForSeconds(2);
            Destroy(go);
            effectFlag = false;
        }
    }
}
