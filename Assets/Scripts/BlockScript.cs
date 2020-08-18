using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    [SerializeField] int maxHits = 3;
    [SerializeField] public LevelScript levelScript;
    [SerializeField] public AudioClip clip;
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] Sprite[] damageSprites;
    // static data will persist across all the objects for the type of Block or BlockScript
    public static int gameScore = 0;
    int timesHit = 0;

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = gameScore.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if(timesHit <= (maxHits - 1) && gameObject.tag == "Breakable")
        {         
            GetComponent<SpriteRenderer>().sprite = damageSprites[timesHit - 1];
        }
        if(gameObject.tag == "Breakable" && timesHit >= maxHits)
        {
            // PlayClipAtPoint creates a temporary gameObject that is created in the world space so that
            // the sound keeps on playing even though the gameobject is deleted or destroyed
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            gameScore += 83;
            // The following line gives the referrene to the score object of the canvas directly        
            scoreText.text = gameScore.ToString();
            // Playing the VFX particle effect
            // First Instantiate the particle effect that will run. It returns a gameObject. 
            // Then destroy the gameObject after 1 second delay
            Destroy(Instantiate(blockParticleVFX, transform.position, transform.rotation), 1f);
            Destroy(gameObject);
        }               
    }
}
