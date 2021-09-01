
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
	public Rigidbody2D chicken;
    public Rigidbody2D goldenchicken;
    public static bool isItGolden;
    public int select;

    public Rigidbody2D pumba;

    public Rigidbody2D friends;


    // Start is called before the first frame update
    void Start()
    {
        isItGolden = false;
        Rigidbody2D clone;
        if (SkinSelect.defaultSkinU)
        {
            clone = Instantiate(chicken, transform.position, Quaternion.identity);
        }
        if (SkinSelect.pumbaSkinU)
        {
            clone = Instantiate(pumba, transform.position, Quaternion.identity);
        }
        if (SkinSelect.friendsSkinU)
        {
            clone = Instantiate(friends, transform.position, Quaternion.identity);
        }
		
    }

    // Update is called once per frame
    void Update() { 
    
        if(ClickFillBar.fillAmounter == 1){
			WhichChicken2();
		}
    }

    public void WhichChicken()
    {
        Rigidbody2D clone;
        Rigidbody2D goldenclone;
        select = Random.Range(1, 20);
        if (SkinSelect.defaultSkinU)
        {
            clone = Instantiate(chicken, transform.position, Quaternion.identity);
            isItGolden = false;
        } else if (SkinSelect.pumbaSkinU)
        {
            clone = Instantiate(pumba, transform.position, Quaternion.identity);
        } else if (SkinSelect.friendsSkinU)
        {
            clone = Instantiate(friends, transform.position, Quaternion.identity);
        }
    }
    
    public void WhichChicken2()
    {
        Rigidbody2D clone;
        Rigidbody2D goldenclone;
        select = Random.Range(1, 11);
        if (select == 10)
        {
            goldenclone = Instantiate(goldenchicken, transform.position, Quaternion.identity);
            isItGolden = true;
        }
        else if (SkinSelect.defaultSkinU)
        {
            clone = Instantiate(chicken, transform.position, Quaternion.identity);
            isItGolden = false;
        }
        else if (SkinSelect.pumbaSkinU)
        {
            clone = Instantiate(pumba, transform.position, Quaternion.identity);
        }
        else if (SkinSelect.friendsSkinU)
        {
            clone = Instantiate(friends, transform.position, Quaternion.identity);
        }
    }

}
