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
        move.y = Input.GetAxisRaw("Vertical");
        move.Normalize();
        transform.Translate(move * Time.deltaTime * speed);
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, 0, 10),-10);
    }
    public float GetMoveX()
    {
        return move.x;
    }
}
