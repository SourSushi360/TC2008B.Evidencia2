using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public GameObject over;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Han") || other.CompareTag("Luke")){
            over = other.gameObject;
        }
    }

    public void Boom(){
        Destroy(over);
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
