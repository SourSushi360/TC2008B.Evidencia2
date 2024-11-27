using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public HitBox frontHB;
    public float speed = 1f;
    bool blocked = false;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate() {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        blocked = frontHB.getState();
        if(blocked){
            move = false;
            StopAllCoroutines();
        } else {
            StartCoroutine(DelayForWalk());
        }   
        if(move){
            float step = speed * Time.deltaTime;
            Vector3 target = transform.position + transform.forward;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    public IEnumerator DelayForWalk(){
        yield return new WaitForSeconds(3);
        move = true;
    }
}
