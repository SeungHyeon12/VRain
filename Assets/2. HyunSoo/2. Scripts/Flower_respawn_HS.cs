using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_respawn_HS : MonoBehaviour
{
    public GameObject flower;
    public int game_level; // playerpref 를 통해서  게임레벨을 받음
    public GameObject respawn_particle;
    public GameObject gameover_UI;
    public static Flower_respawn_HS instance;
    public int isfinish;
    public GameObject confetti;
    Animator anim;
    ParticleSystem ps;
    GameObject temp_flower;
    // Start is called before the first frame update
    void Start()
    {
        confetti.SetActive(false);
        gameover_UI.SetActive(false);
        game_level = PlayerPrefs.GetInt("MINI_F_lv");
        ps = respawn_particle.GetComponent<ParticleSystem>();
        temp_flower = Instantiate(flower);
        temp_flower.transform.position = this.transform.position;  //처음에 꽃을 생성( 다른 음성인식 후 나오게하거나 이벤트 추가예정)
       
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Flower_respawn_HS.instance.game_level + "점");
        if (temp_flower == null && game_level != 0)  // 받은 게임레벨을 하나씩 감소하면서 리스폰시킴
        {
            ps.Play();
            temp_flower = Instantiate(flower);
            temp_flower.transform.position = this.transform.position;
            game_level--;
        }
        else if(temp_flower != null && game_level != 0)
        {
            ps.Stop();
        }
        else // 게임오브젝트가 더이상 리스폰안되고 게임레벨이 0으로 다운시 게임오버 ui 가 나오게끔
        {
            confetti.SetActive(true);
            isfinish = 1; // 대화가 끝나면
            ps.Stop();
            gameover_UI.SetActive(true);
          
        }
    }
}
