using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject human;
    public GameObject robot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCharacter(){
        int chance = Random.Range(0, 11);
        if(chance > 8){
            Instantiate(
                    robot,
                    this.transform
                );
        } else {
            Instantiate(
                    human,
                    this.transform
                );
        }
        
    }
}
