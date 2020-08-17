using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{    
    [SerializeField] SceneLoader sceneLoader;
    GameObject blocks;   

    // Start is called before the first frame update
    void Start()
    {      
        blocks = GameObject.Find("Blocks");        
    }

    // Update is called once per frame
    void Update()
    {        
        if(blocks.transform.childCount == 0)
        {
            sceneLoader.LoadNextScene();
        }   
    }
    
}
