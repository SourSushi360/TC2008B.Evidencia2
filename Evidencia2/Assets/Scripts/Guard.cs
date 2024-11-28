using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Guard : MonoBehaviour
{
    [SerializeField] private UnityEvent _SpawnCharacters;
    [SerializeField] private UnityEvent _OpenGates;
    [SerializeField] private UnityEvent _CloseGates;
    int activeCharacterCounter = 0;
    int totalCharacters = 0;
    int humanCharacters = 0;
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
        if(Input.GetKeyDown(KeyCode.O)){
            StartCoroutine(handleGates());
        }
        if(Input.GetKeyDown(KeyCode.B)){
            destroyTarget();
        }
    }

    void destroyTarget(){
        Drone.Instance.eliminateTarget();
    }

    IEnumerator createCharacters(){
        while(true){
            if(activeCharacterCounter < 12){
                _SpawnCharacters.Invoke();  
                activeCharacterCounter+=2; 
            }
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator handleGates(){
        _OpenGates.Invoke();
        yield return new WaitForSeconds(5);
        _CloseGates.Invoke();
    }

    public void updateCounter(int type){
        activeCharacterCounter --;
        if (type == 0){
            humanCharacters ++;
        }
        totalCharacters ++;
    }
}
