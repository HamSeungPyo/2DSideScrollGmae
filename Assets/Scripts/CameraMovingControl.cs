using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingControl : MonoBehaviour
{
    float speed = 5;
    Vector2 move=new Vector2();
    void Start()
    {
        
    }
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        
        //move.y = Input.GetAxisRaw("");

        transform.Translate(move * Time.deltaTime * speed);
    }
    public float GetMoveX()
    {
        return move.x;
    }
}
