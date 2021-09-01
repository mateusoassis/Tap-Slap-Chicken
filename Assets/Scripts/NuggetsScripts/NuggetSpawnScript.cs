using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetSpawnScript : MonoBehaviour
{
	public Rigidbody2D nuggetPrefab;
	
	public float timerToNugget;
	public float timerToNuggetRefresh;
	
	public static bool nuggetAround;
	
    // Start is called before the first frame update
    void Start()
    {
		nuggetAround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerToNugget > 0){
			timerToNugget -= Time.deltaTime;
		} else if(timerToNugget <= 0){
			SpawnNugget();
			timerToNugget = timerToNuggetRefresh;
		}
    }
	
	void SpawnNugget()
	{
		transform.position = new Vector3 (-10f, Mathf.Clamp(Random.Range(-4.5f,4.5f), -4.5f, 4.5f), 0f);
		Rigidbody2D clone;
		clone = Instantiate(nuggetPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		nuggetAround = true;
	}
}
