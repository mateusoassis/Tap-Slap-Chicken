using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetScript3 : MonoBehaviour
{
	public Vector3 straightLineToTarget;
	
	public float timePeriod = 2;
	public float height = 30f;
	private float timeSinceStart;
	private Vector3 pivot;

    public AudioSource nuggetSound;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(Destroyasd());
        //straightLineToTarget = new Vector3(NuggetScript2.nuggetTarget2.x, NuggetScript2.nuggetTarget2.y, 0f);
		
		pivot = transform.position;
		height /= 2;
		timeSinceStart = (3 * timePeriod) / 4;


        nuggetSound = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = new Vector3(0.0f, 2 * Mathf.Sin(Time.deltaTime * 4), 0.0f);
		//var rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
		//transform.rotation = rotation;
		Vector3 nextPos = transform.localPosition;
		nextPos.y = pivot.y + height + height * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
		timeSinceStart += Time.deltaTime;
		transform.localPosition = nextPos;
    }
	
	
	
    public void GetNuggeto()
    {
        DiamondEggCounter.DECounter += 2;
		NuggetSpawnScript.nuggetAround = false;
        StartCoroutine(SoundKiller());      
    }
	
    IEnumerator Destroyasd()
    {
        yield return new WaitForSeconds(10f);
		NuggetSpawnScript.nuggetAround = false;
        Destroy(transform.parent.gameObject);
    }
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "DestroyNugget"){
			NuggetSpawnScript.nuggetAround = false;
			Destroy(transform.parent.gameObject);
		}
	}

    IEnumerator SoundKiller()
    {
        nuggetSound.PlayOneShot(nuggetSound.clip);
        Destroy(transform.parent.gameObject);
        yield return null;
    }
}
