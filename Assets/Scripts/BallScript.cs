using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    bool ballClicked = false;
    Rigidbody2D ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
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
            ballRigidBody.velocity = new Vector2(2f, 10f);
            ballClicked = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Giving the ball an extra velocity push every time a collision occurs so that the ball is not stuck
        // in the infinte loop
        ballRigidBody.velocity += new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (ballClicked)
        {
            // Giving the ball an extra velocity push every time a collision occurs so that the ball is not stuck
            // in the infinte loop
            ballRigidBody.velocity += new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            GetComponent<AudioSource>().Play();
        }
    }

}
