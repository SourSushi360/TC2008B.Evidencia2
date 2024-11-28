using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserBeam : MonoBehaviour
{
    public GameObject over;
    [SerializeField] private UnityEvent _Alarm;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Han") || other.CompareTag("Luke")){
            over = other.gameObject;
            if(other.CompareTag("Han")){
                //_Alarm.Invoke();
            }  
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
