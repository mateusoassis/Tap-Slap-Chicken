using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceImageScript : MonoBehaviour
{

    public int place;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(Screen.width * place, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
