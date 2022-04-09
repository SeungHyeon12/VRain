using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Respawn_HS : MonoBehaviour
{
    public List<GameObject> poses;
    public Transform respawn;
    int rand_number = 0;
    public float make_time;
    public int level;
    public int level_c;
    float cur_time = 0;
    public static Wall_Respawn_HS instance;
    public bool isstart = false;
    // Start is called before the first frame update
    void Start()
    {
        level =  PlayerPrefs.GetInt("MINI_W_lv"); 
        instance = this;
        level_c = level;

    }

    // Update is called once per frame
    void Update()
    {
        rand_number = Random.RandomRange(0, 3); //랜덤으로 수 생성
        if (level > 0 && isstart)
        {
            if (cur_time >= make_time) // make_time 마다 생성
            {
                GameObject temp = Instantiate(poses[rand_number]); // 벽생성
                temp.transform.position = respawn.position;
                level--;
                cur_time = 0;
                
            }
            cur_time += Time.deltaTime;
        }
    }
}
