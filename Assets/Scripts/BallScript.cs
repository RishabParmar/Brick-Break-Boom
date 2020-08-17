using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    bool ballClicked = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballClicked)
        {         
            GetComponent<AudioSource>().Play();
        }      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For sticking the ball to the paddle
        if (!ballClicked)
        {
            Vector2 paddlePos = new Vector2((Input.mousePosition.x / Screen.width) * 16, paddle.transform.position.y);    
            paddlePos.x = Mathf.Clamp(paddlePos.x, 1.07f, 14.927f);
            transform.position = new Vector2(paddlePos.x, 0.964f);     
        }
        // For releasing the ball from the paddle
        if (Input.GetMouseButtonDown(0) && !ballClicked)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            ballClicked = true;
        }
    }
}
