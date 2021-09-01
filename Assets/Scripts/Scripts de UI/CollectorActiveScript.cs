using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorActiveScript : MonoBehaviour
{
    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(camera.position.y > -1 && camera.position.y < 1)
        {
            this.gameObject.SetActive(false);

        } else if (camera.position.y > 49 && camera.position.y < 51 && UpgradeScripts.collectorUpgrade) {
            this.gameObject.SetActive(true);
        }*/
    }
}
