using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public bool blocked = false;
    GameObject over;

    private void Update() {
        if(over == null){
            blocked = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Gate") || other.CompareTag("Luke") || other.CompareTag("Han")){
            blocked = true;
            over = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Gate") || other.CompareTag("Luke") || other.CompareTag("Han"))
        blocked = false;
    }

    public bool getState(){
        return blocked;
    }
}
