using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Vector3 startPos;
    bool move = false;
    public float speed = 5f;

    public Transform[] routeCheckpoints = new Transform[4];
    Vector3 target;

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
        }
    }

    public void takeOff(){
        target = startPos;
        target.y = startPos.y + 3;
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
        int patrolCheckpoint = 0;
        target = routeCheckpoints[patrolCheckpoint].position;
        move = true;
        while(patrolCheckpoint < 4){
            
            target = routeCheckpoints[patrolCheckpoint].position;
            while(Vector3.Distance(transform.position, target) != 0){
                yield return Time.deltaTime;
            }
            yield return new WaitForSeconds(1);
            patrolCheckpoint++;
        }
        move = false;
        takeOff();
    }

    public IEnumerator flyToGate(int gate){
        move = false;
        StopCoroutine(Patrol());
        int area;
        if(gate == 1){
            area = 0;
        } else{
            area = 3;
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
}
