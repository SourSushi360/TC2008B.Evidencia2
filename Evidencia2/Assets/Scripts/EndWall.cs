using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndWall : MonoBehaviour
{
    GameObject thing;
    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Luke")){
            Guard.Instance.updateCounter(0);

            thing = other.gameObject;
            Destroy(thing);
        } else if(other.CompareTag("Han")){
            Guard.Instance.updateCounter(1);

            thing = other.gameObject;
            Destroy(thing);
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
