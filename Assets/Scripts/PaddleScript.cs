using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaddleScript : MonoBehaviour
{   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2((Input.mousePosition.x / Screen.width) * 16, transform.position.y);
        // x and y clamp values taken by placing the ball on the paddle in the editor for a perfect place
        paddlePos.x = Mathf.Clamp(paddlePos.x, 1.07f, 14.927f);
        transform.position = paddlePos;       
    }
}
