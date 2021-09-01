using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapSoundScript : MonoBehaviour
{
    public AudioSource tapinhaSound;

    public AudioClip[] tapinhaArray;

    void Awake()
    {
        tapinhaSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*public void OnMouseDown()
    {
        if (UpgradePanel.isUpgradeScreenUp == false && PixChanger.isPixUp == false && SkinChanger.isSkinUp == false && LojaChanger.isLojaUp == false){
            TocaTapa();
		}
    }*/

    public void TocaTapa()
        {
            tapinhaSound.clip = tapinhaArray[Random.Range(0, tapinhaArray.Length)];
            tapinhaSound.PlayOneShot(tapinhaSound.clip);
        }   

}
