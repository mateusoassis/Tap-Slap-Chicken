using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenChickenDestroyer : MonoBehaviour
{
    public float timeToDie;
    public ChickenChanger goldenchicken;
    public ChickenSpawner chickenSpawner;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        timeToDie = 5f;
        goldenchicken = GetComponent < ChickenChanger >();
        chickenSpawner = GameObject.Find("Posição 1").GetComponent<ChickenSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

        timeToDie -= Time.deltaTime;
        if (timeToDie <= 0 && transform.position.x > -.1 && transform.position.x < .1)
        {
            goldenchicken.posicao = 2;
            chickenSpawner.WhichChicken();
        }
    }
}
