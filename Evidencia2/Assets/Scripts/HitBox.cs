using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public bool blocked = false;

    private void OnTriggerEnter(Collider other) {
        blocked = true;
    }

    private void OnTriggerExit(Collider other) {
        blocked = false;
    }

    public bool getState(){
        return blocked;
    }
}
