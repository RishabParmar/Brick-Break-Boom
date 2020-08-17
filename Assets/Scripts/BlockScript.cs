using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public LevelScript levelScript;
    [SerializeField] public AudioClip clip;
    static int gameScore;
    private void Start()
    {
        gameScore = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // PlayClipAtPoint creates a temporary gameObject that is created in the world space so that
        // the sound keeps on playing even though the gameobject is deleted or destroyed
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        gameScore += 83;
        scoreText.text = gameScore.ToString();
        Debug.Log("Object name: " + collision.gameObject.name);
        Debug.Log("GameScore: " + gameScore);
        Debug.Log(scoreText.text);
        Destroy(gameObject);               
    }
}
