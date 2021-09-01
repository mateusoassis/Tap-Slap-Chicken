using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInSound : MonoBehaviour
{

    public AudioSource moneySound;

    public AudioClip moneyClip;

    public AudioSource readySound;

    public AudioClip readyClip;

    // Start is called before the first frame update
    void Start()
    {
        moneySound = GetComponent<AudioSource>();
        
        readySound = GetComponent<AudioSource>();
        
    }



    // Update is called once per frame
    void Update()
    {
       if(ClickFillBar.fillAmounter == 1)
       {
            StartCoroutine(PlayDoneSound());
       } 
    }



    IEnumerator PlayDoneSound()
    {
        readySound.clip = readyClip;
        readySound.PlayOneShot(readySound.clip);
        yield return new WaitForSeconds(0.5f);
        moneySound.clip = moneyClip;
        moneySound.PlayOneShot(moneySound.clip);
    }

    
}
