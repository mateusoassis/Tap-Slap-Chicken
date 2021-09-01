using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetScript : MonoBehaviour
{

    /*public float vel;
    public float posX;
    public float posY;

    public Transform transform;

    public Vector2 target;*/
	
	////////////////////////////////
	public float speed;
	public Vector2 nuggetTarget;
	public Vector3 straightLineToTarget;
    ////////////////////////////////

    


    // Start is called before the first frame update
    void Start()
    {
		NuggetSpawnScript.nuggetAround = true;
        /*posX = Random.Range(-4.4f, 4.4f);
        posY = Random.Range(-10.6f, 10.6f);
        target =  new Vector2(posX, posY);*/
        
        float x = 10f;
		float y = Mathf.Clamp(Random.Range(-7.5f,7.5f), -7.5f, 7.5f);
		nuggetTarget = new Vector2(x,y);
		straightLineToTarget = new Vector3(nuggetTarget.x, nuggetTarget.y, 0f);
		
		
        //transform = GetComponent<Transform>();

        StartCoroutine(Destroyasd());

        
    }

    // Update is called once per frame
    void Update()
    {	
		transform.position = Vector2.MoveTowards(transform.position, nuggetTarget, speed);
		Vector3 relativePos = straightLineToTarget - transform.position;
		Quaternion angle = XLookRotation2D(relativePos);
		transform.rotation = Quaternion.Lerp(transform.localRotation, angle, 100);
        //transform.position = Vector2.Lerp(transform.position,target, Time.deltaTime * vel);
    }
	
	Quaternion XLookRotation2D(Vector3 right)
	{
		Quaternion rightToUp = Quaternion.Euler(0f, 0f, 80f);
		Quaternion upToTarget = Quaternion.LookRotation(Vector3.forward, right);

		return upToTarget * rightToUp;
	}
	
	
	
    void OnMouseDown()
    {
        DiamondEggCounter.DECounter++;
		NuggetSpawnScript.nuggetAround = false;
        StartCoroutine(SoundKiller());
                
    }

    IEnumerator Destroyasd()
    {
        yield return new WaitForSeconds(8f);
		NuggetSpawnScript.nuggetAround = false;
        Destroy(this.gameObject);
    }

    IEnumerator SoundKiller()
    {
        
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
}
