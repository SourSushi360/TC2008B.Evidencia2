using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lift(){
        Vector3 newPosition = initialPosition;
        newPosition.y += 5;
        this.transform.position = newPosition; 
    }

    public void Close(){
        this.transform.position = initialPosition;
    }
}
