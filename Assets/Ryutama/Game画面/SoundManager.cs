using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seFall;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SEFall()
    {
        seFall.Play();
    }
}
