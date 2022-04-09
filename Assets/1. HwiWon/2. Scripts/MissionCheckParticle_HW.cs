using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCheckParticle_HW : MonoBehaviour
{
    // 터치 됐을 때 생성할 파티클 프리팹
    public GameObject particlePrefab;

    AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RH" && gameObject.tag == "RH")
        {
            myAudio.Play();
            GameObject goRH = Instantiate(particlePrefab);
            goRH.transform.position = transform.position + new Vector3(0, -1f, 0);
            Destroy(gameObject,1);
        }
        else if (other.gameObject.tag == "LH" && gameObject.tag == "LH")
        {
            myAudio.Play();
            GameObject goLH = Instantiate(particlePrefab);
            goLH.transform.position = transform.position + new Vector3(0, -1f, 0);
            Destroy(gameObject, 1);
        }
        else if (other.gameObject.tag == "RF" && gameObject.tag == "RF")
        {
            myAudio.Play();
            GameObject goRF = Instantiate(particlePrefab);
            goRF.transform.position = transform.position + new Vector3(0, -1f, 0);
            Destroy(gameObject, 1);
        }
        else if (other.gameObject.tag == "LF" && gameObject.tag == "LF")
        {
            myAudio.Play();
            GameObject goLF = Instantiate(particlePrefab);
            goLF.transform.position = transform.position + new Vector3(0, -1f, 0);
            Destroy(gameObject, 1);
        }
    }
}
