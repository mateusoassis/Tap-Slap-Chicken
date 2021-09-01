using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelect : MonoBehaviour
{
    /*public SpriteRenderer workerSR;
    public List<Sprite> workerSkins = new List<Sprite>();
	public List<Sprite> chickenSkins = new List<Sprite>();*/

    public Sprite[] workerSkins;
    public Sprite[] chickenSkins;
    public Sprite[] testImages;


    //worker skin
    //0 = default
    //1 = timão
    public int selectedWorkerSkin = 0;


    public static bool pumbaSkinA;
    public static bool pumbaSkinU;
    public GameObject pumbaBuyButton;
    public GameObject pumbaUseObject;
    public Button pumbaUseButton;

    public static bool friendsSkinA;
    public static bool friendsSkinU;
    public GameObject friendsBuyButton;
    public GameObject friendsUseObject;
    public Button friendsUseButton;

    public GameObject defaultChickenObject;
    public Button defaultChickenButton;


    public ChickenChanger chickenCloneSkiper;

    public ChickenSpawner chickenSpawner;

    public static bool defaultSkinU = true;

    void Awake()
    {

        if (PlayerPrefs.HasKey("defaultSkinU"))
        {
            defaultSkinU = (PlayerPrefs.GetInt("defaultSkinU") != 0);
        }
        if (PlayerPrefs.HasKey("pumbaSkinU"))
        {
            pumbaSkinU = (PlayerPrefs.GetInt("pumbaSkinU") != 0);
        }
        if (PlayerPrefs.HasKey("pumbaSkinA"))
        {
            pumbaSkinA = (PlayerPrefs.GetInt("pumbaSkinA") != 0);
        }
        if (PlayerPrefs.HasKey("friendsSkinU"))
        {
            friendsSkinU = (PlayerPrefs.GetInt("friendsSkinU") != 0);
        }
        if (PlayerPrefs.HasKey("friendsSkinA"))
        {
            friendsSkinA = (PlayerPrefs.GetInt("friendsSkinA") != 0);
        }
        if (pumbaSkinA)
        {
            pumbaBuyButton.SetActive(!pumbaSkinA);
            pumbaUseObject.SetActive(pumbaSkinA);
        }
        if (friendsSkinA)
        {
            friendsBuyButton.SetActive(!pumbaSkinA);
            friendsUseObject.SetActive(pumbaSkinA);
        }
        if (pumbaSkinU)
        {
            pumbaUseButton.interactable = false;
            defaultChickenButton.interactable = true;
            friendsUseButton.interactable = true;
        }
        if (defaultSkinU)
        {
            pumbaUseButton.interactable = true;
            defaultChickenButton.interactable = false;
            friendsUseButton.interactable = true;
        }
        if (friendsSkinU)
        {
            friendsUseButton.interactable = false;
            defaultChickenButton.interactable = true;
            pumbaUseButton.interactable = true;
        }
    }

    void Start()
    {
        //aqui é simplesmente pra trocar a sprite que mostra
        //vou ver depois como que troca ANIMAÇÃO e tal

        chickenSpawner = GameObject.Find("Posição 1").GetComponent<ChickenSpawner>();
    }


    void Update()
    {
        PlayerPrefs.SetInt("defaultSkinU", (defaultSkinU ? 1 : 0));
        PlayerPrefs.SetInt("pumbaSkinU", (pumbaSkinU ? 1 : 0));
        PlayerPrefs.SetInt("pumbaSkinA", (pumbaSkinA ? 1 : 0));
        PlayerPrefs.SetInt("friendsSkinU", (friendsSkinU ? 1 : 0));
        PlayerPrefs.SetInt("friendsSkinA", (friendsSkinA ? 1 : 0));
    }
    public void ChangeWorkerToTimao() // xxx.transform.GetChild(0).gameObject.GetComponent
    {
        selectedWorkerSkin = 1;
        //workerSR.sprite = workerSkins[selectedWorkerSkin];
    }

    public void ChangeWorkerToClassic()
    {
        selectedWorkerSkin = 0;
        //workerSR.sprite = workerSkins[selectedWorkerSkin];
    }

    public void BuyPumbaSkin()
    {

        if (DiamondEggCounter.DECounter >= 50)
        {
            Debug.Log("ASDASD");
            pumbaSkinA = true;
            DiamondEggCounter.DECounter -= 50;
            pumbaBuyButton.SetActive(false);
            pumbaUseObject.SetActive(true);
        }

    }

    public void ChangeChickenToPumba()
    {
        if (pumbaSkinA)
        {
            if (defaultSkinU)
            {
                chickenCloneSkiper = GameObject.Find("GalinhaFinal(Clone)").GetComponent<ChickenChanger>();
                chickenCloneSkiper.posicao = 2;

                pumbaSkinU = true;
                defaultSkinU = false;
                friendsSkinU = false;

                chickenSpawner.WhichChicken();
            }
            if (friendsSkinU)
            {
                chickenCloneSkiper = GameObject.Find("Friends(Clone)").GetComponent<ChickenChanger>();
                chickenCloneSkiper.posicao = 2;

                pumbaSkinU = true;
                defaultSkinU = false;
                friendsSkinU = false;

                chickenSpawner.WhichChicken();
            }



            pumbaUseButton.interactable = false;
            defaultChickenButton.interactable = true;
            friendsUseButton.interactable = true;


        }
    }

    public void BuyFriendsSkin()
    {
        if (DiamondEggCounter.DECounter >= 50)
        {
            friendsSkinA = true;
            DiamondEggCounter.DECounter -= 50;
            friendsBuyButton.SetActive(false);
            friendsUseObject.SetActive(true);
        }

    }

    public void ChangeChickenToFriends()
    {
        if (friendsSkinA)
        {
            if (defaultSkinU)
            {
                chickenCloneSkiper = GameObject.Find("GalinhaFinal(Clone)").GetComponent<ChickenChanger>();
                chickenCloneSkiper.posicao = 2;

                friendsSkinU = true;
                defaultSkinU = false;
                pumbaSkinU = false;

                chickenSpawner.WhichChicken();
            }
            else if (pumbaSkinU)
            {
                chickenCloneSkiper = GameObject.Find("PumbaGalinha(Clone)").GetComponent<ChickenChanger>();
                chickenCloneSkiper.posicao = 2;

                friendsSkinU = true;
                defaultSkinU = false;
                pumbaSkinU = false;

                chickenSpawner.WhichChicken();
            }



            friendsUseButton.interactable = false;
            pumbaUseButton.interactable = true;
            defaultChickenButton.interactable = true;


        }
    }


    public void ChangeChickenToClassic()
    { 
        pumbaUseButton.interactable = true;
        friendsUseButton.interactable = true;
        defaultChickenButton.interactable = false;

        if (pumbaSkinU)
        {
            chickenCloneSkiper = GameObject.Find("PumbaGalinha(Clone)").GetComponent<ChickenChanger>();
            chickenCloneSkiper.posicao = 2;

            defaultSkinU = true;
            pumbaSkinU = false;
            friendsSkinU = false;

            //Coloca nova galinha
            chickenSpawner.WhichChicken();
        }
        else if (friendsSkinU)
        {
            chickenCloneSkiper = GameObject.Find("Friends(Clone)").GetComponent<ChickenChanger>();
            chickenCloneSkiper.posicao = 2;

            defaultSkinU = true;
            pumbaSkinU = false;
            friendsSkinU = false;

            //Coloca nova galinha
            chickenSpawner.WhichChicken();
        }


       
    }








}
