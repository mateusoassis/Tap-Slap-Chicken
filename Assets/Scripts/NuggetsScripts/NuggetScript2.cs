using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetScript2 : MonoBehaviour
{
	public float speed;
	public static Vector2 nuggetTarget2;
	public static Vector3 straightLineToTarget2;
	
    // Start is called before the first frame update
    void Start()
    {
		float x = 10f;
		float y = Mathf.Clamp(Random.Range(-4.5f,4.5f), -4.5f, 4.5f);
		nuggetTarget2 = new Vector2(x,y);
		straightLineToTarget2 = new Vector3(nuggetTarget2.x, nuggetTarget2.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, nuggetTarget2, speed);
		Vector3 relativePos = straightLineToTarget2 - transform.position;
		Quaternion angle = XLookRotation2D(relativePos);
		transform.rotation = Quaternion.Lerp(transform.localRotation, angle, 100f);
    }
	
	Quaternion XLookRotation2D(Vector3 right)
	{
		Quaternion rightToUp = Quaternion.Euler(0f, 0f, 80f);
		Quaternion upToTarget = Quaternion.LookRotation(Vector3.forward, right);

		return upToTarget * rightToUp;
	}
	
}
