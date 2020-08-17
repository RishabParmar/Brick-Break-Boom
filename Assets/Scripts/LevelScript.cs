using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{    
    [SerializeField] SceneLoader sceneLoader;
    GameObject blocks;
    int unbreakableBlockCount = 0;
   
    // Start is called before the first frame update
    void Start()
    {      
        blocks = GameObject.Find("Blocks");
        unbreakableBlockCount = GameObject.FindGameObjectsWithTag("Unbreakable").Length;
    }

    // Update is called once per frame
    void Update()
    {        
        // The level will proceed only when the blocks.childCount is equal to the unbreakable blocks
        // It means that when only unbreakable blocks remain, the only children that remain are the unbreakable blocks
        if(blocks.transform.childCount == unbreakableBlockCount)
        {
            sceneLoader.LoadNextScene();
        }   
    }
    
}
