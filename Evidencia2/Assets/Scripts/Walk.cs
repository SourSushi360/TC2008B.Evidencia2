using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public HitBox frontHB;
    public float speed = 1f;
    bool blocked = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkIfCanWalk());
    }
    private void FixedUpdate() {
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator checkIfCanWalk(){
        while(true){
            blocked = frontHB.getState();
            if(blocked){
                yield return new WaitForSeconds(2);
            } else {
                float step = speed * Time.deltaTime;
                Vector3 target = transform.position + transform.forward;
                transform.position = Vector3.MoveTowards(transform.position, target, step);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
