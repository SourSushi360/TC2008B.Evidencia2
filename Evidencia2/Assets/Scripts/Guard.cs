using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Guard : MonoBehaviour
{
    [SerializeField] private UnityEvent _SpawnCharacters;
    public static Guard Instance {
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
        StartCoroutine(createCharacters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyTarget(){
        Drone.Instance.eliminateTarget();
    }

    IEnumerator createCharacters(){
        int counter = 0;
        while(true){
            if(counter < 6){
                _SpawnCharacters.Invoke();  
                counter++; 
            }
            yield return new WaitForSeconds(5);
        }
    }
}
