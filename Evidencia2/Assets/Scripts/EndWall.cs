using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Luke")){
            Guard.Instance.updateCounter(0);
        } else {
            Guard.Instance.updateCounter(1);
        }

        Destroy(other);
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
