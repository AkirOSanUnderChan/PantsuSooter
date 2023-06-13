using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Sounds : MonoBehaviour
{
    public AudioClip AK_47_SingleShot;
    AudioSource AudSors;

    // Start is called before the first frame update
    void Start()
    {
        AudSors = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void PlayAK47Sound()
    {
        AudSors.PlayOneShot(AK_47_SingleShot);

    }
}
