using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPositionManager_HW : MonoBehaviour
{
    public GameObject pos_default, pos_result;
    public GameObject player;
    public GameObject resultCanvas;
    // 첫 실행시 하는 설문조사
    public GameObject LobbyPrefab;

    private void Awake()
    {
        if (SceneManager_HW.firstTime == 1)
        {
            player.transform.position = pos_default.transform.position;
            player.transform.rotation = pos_default.transform.rotation;
        }
        else if(SceneManager_HW.firstTime == 2)
        {
            player.transform.position = pos_result.transform.position;
            player.transform.rotation = pos_result.transform.rotation;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager_HW.firstTime == 2)
        {
            resultCanvas.SetActive(true);
            LobbyPrefab.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
