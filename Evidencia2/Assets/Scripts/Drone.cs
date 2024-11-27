using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Vector3 startPos;
    Vector3 startFacing;
    bool move = false;
    public float speed = 5f;

    public Transform[] routeCheckpoints = new Transform[4];
    Vector3 target;
    Vector3 targetDirection;
    public int patrolCheckpoint = 0;
    public static Drone Instance {
        get;
        private set;
    }

    void Awake(){
        if(Instance != null){
            Destroy(gameObject);
        } else {
            // If not, we pick the space
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            takeOff();
        }
        if(Input.GetKeyDown(KeyCode.L)){
            land();
        }
        if(Input.GetKeyDown(KeyCode.P)){
            StartCoroutine(Patrol());
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            StartCoroutine(flyToGate(1));
        }
        if(Input.GetKeyDown(KeyCode.E)){
            StartCoroutine(flyToGate(2));
        }
    }

    void FixedUpdate() {
        float step = speed * Time.deltaTime;
        if(move){
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void takeOff(){
        patrolCheckpoint = 0;
        target = startPos;
        target.y = startPos.y + 3;
        Vector3 targetDir = transform.position;
        targetDir.x -= 1;
        targetDirection = transform.position - targetDir;
        move = true;
        StartCoroutine(Stop());
    }

    public void land(){
        target = startPos;
        move = true;
        StartCoroutine(Stop());
    }

    public IEnumerator Stop(){
        while(Vector3.Distance(transform.position, target) != 0){
            yield return Time.deltaTime;
        }
        move = false;
    }

    public IEnumerator Patrol(){
        
        move = true;
        
        while(patrolCheckpoint < 4){
            if(patrolCheckpoint == 0 || patrolCheckpoint == 1){
                turnToGateA();
            } else {
                turnToGateB();
            }
            target = routeCheckpoints[patrolCheckpoint].position;
            while(Vector3.Distance(transform.position, target) != 0){
                yield return Time.deltaTime;
            }
            yield return new WaitForSeconds(1);
            patrolCheckpoint++;
            Debug.Log(patrolCheckpoint);
        }
        takeOff();
        patrolCheckpoint = 0;
        
    }

    public IEnumerator flyToGate(int gate){
        move = false;
        StopAllCoroutines();
        if(patrolCheckpoint > 0){
            patrolCheckpoint--;
        }
        int area;
        if(gate == 1){
            area = 0;
            turnToGateA();
        } else{
            area = 3;
            turnToGateB();
        }
        target = routeCheckpoints[area].position;
        
        move = true;
        while(Vector3.Distance(transform.position, target) != 0){
            yield return Time.deltaTime;
        }
        move = false;
        //Check the camera
    }

    public void eliminateTarget(){
        Debug.Log("Boom!");
    }

    private void turnToGateA(){
        Vector3 targetDir = transform.position;
        targetDir.z += 1;
        targetDirection = transform.position - targetDir;
    }

    private void turnToGateB(){
        Vector3 targetDir = transform.position;
        targetDir.z -= 1;
        targetDirection = transform.position - targetDir;
    }
}
