using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallgame_manager_HS : MonoBehaviour
{
   /* public GameObject righthandUI;
    public GameObject lefthandUI;
    public GameObject headUI;*/
    public GameObject gameoverUI;
    public GameObject camera;
    public GameObject confetti;


    public GameObject b_rightfootUI_o;
    public GameObject b_leftfootUI_o;
    public GameObject b_righthandUI_o;
    public GameObject b_lefthandUI_o;
    public GameObject b_headUI_o;

    public GameObject b_rightfootUI_x;
    public GameObject b_leftfootUI_x;
    public GameObject b_righthandUI_x;
    public GameObject b_lefthandUI_x;
    public GameObject b_headUI_x;


    public int isright;        // 어디가 잘못 걸렸는지 알려주는 flag
    public int isleft;
    public int ishead;
    public int isright_f;
    public int isleft_f;
    public int isdestroy = 0;
    public int decisionflag = 0; //wall이 destroy되는 시점을 판단하기 위한 flag

    public AudioClip[] sound;
    AudioSource aud;

    public static Wallgame_manager_HS instance;
    Vector3 headUI_originsize;
    // Start is called before the first frame update
    void Start()
    {
        confetti.SetActive(false);
        instance = this;
        aud = this.GetComponent<AudioSource>();
        //headUI_originsize = headUI.transform.localScale;
        ishead = isleft = isright = isleft_f = isright_f = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Wall_Respawn_HS.instance.level == 0 && Wall_Respawn_HS.instance.level_c == 0)// level과 level_c는 생성과 파괴시점에 따라서 나눈것
        {
            confetti.SetActive(true);
            gameoverUI.SetActive(true);
        }
        if(decisionflag == 1)  // wall 이 파괴될 시점일 때
        {
            Debug.Log("벽파괴시점");
            Check_Whereis();  // 어디부분이 걸렷는지 체크하는함수
            decisionflag = 0;  //decisionflag를 0으로 초기화 
        }
       /* Head_UI();
        Hand_UI();//UI의 빌보드*/

    }

    private void Check_Whereis()
    {
        if (ishead == 1)                      //각각에대해 머리 왼쪽손 오른쪽손을 순차적으로 검사
        {
           // headUI.SetActive(true);            //1일경우 collider을 못넘은경우이니 주의 ui 를 on
            b_headUI_o.SetActive(false);
            b_headUI_x.SetActive(true);
        }
        else
        {
           // headUI.SetActive(false);           // 그외의경우는 벽을 넘은경우이므로 주의 ui 를 off
            b_headUI_x.SetActive(false);
            b_headUI_o.SetActive(true);
            
        }

        if (isright == 1)
        {
            //righthandUI.SetActive(true);
            b_righthandUI_o.SetActive(false);
            b_righthandUI_x.SetActive(true);
        }
        else
        {
            //righthandUI.SetActive(false);
            b_righthandUI_o.SetActive(true);
            b_righthandUI_x.SetActive(false);
        }

        if (isleft == 1)
        {
            //lefthandUI.SetActive(true);
            b_lefthandUI_o.SetActive(false);
            b_lefthandUI_x.SetActive(true);
        }
        else
        {
           // lefthandUI.SetActive(false);
            b_lefthandUI_o.SetActive(true);
            b_lefthandUI_x.SetActive(false);
        }
        if (isleft_f == 1)
        {
            b_leftfootUI_x.SetActive(true);
            b_leftfootUI_o.SetActive(false);
          
        }
        else
        {
            b_leftfootUI_x.SetActive(false);
            b_leftfootUI_o.SetActive(true);
              
        }
        if (isright_f == 1)
        {
            b_rightfootUI_x.SetActive(true);
            b_rightfootUI_o.SetActive(false);
            
        }
        else
        {
            b_rightfootUI_x.SetActive(false);
            b_rightfootUI_o.SetActive(true);
            
        }

        if ( (ishead == 1) || (isright == 1) || (isleft == 1)|| (isleft_f == 1)|| (isright_f == 1))
        {
            aud.Stop();
            aud.PlayOneShot(sound[0]);
            ishead = isleft = isright = isleft_f = isright_f = 1;

        }
        else if(ishead == 0 && isright == 0 && isleft == 0 && isleft_f == 0 && isright_f == 0) 
        {
            aud.Stop();
            aud.PlayOneShot(sound[1]);
            ishead = isleft = isright = isleft_f = isright_f = 1;
        }
    }

   /* void Head_UI ()
        {
         Ray ray = new Ray(camera.transform.position, camera.transform.forward); // camera(headset)의 앞으로 시야가 
         RaycastHit hitinfo;
           if (Physics.Raycast(ray, out hitinfo))
            {
                headUI.transform.position = hitinfo.point;
                headUI.transform.localPosition = headUI_originsize * hitinfo.distance;
                headUI.transform.rotation = camera.transform.rotation;// billboard
            }
            else
            {
                headUI.transform.position = camera.transform.forward * 10;
                headUI.transform.localScale = headUI_originsize * 10;
                headUI.transform.rotation = camera.transform.rotation;
            }
        }
      void Hand_UI ()
      {
        righthandUI.transform.rotation = camera.transform.rotation;//손에 컨트롤러에 ui 가 붙어있으므로 빌보드만
        lefthandUI.transform.rotation = camera.transform.rotation;
      }*/
    
}
