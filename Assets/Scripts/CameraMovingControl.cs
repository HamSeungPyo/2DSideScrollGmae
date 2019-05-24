using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingControl : MonoBehaviour
{
    public GameObject player;
    float speed = 5;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector3.Lerp( transform.position, player.transform.position, Time.deltaTime* speed);
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, 0, 10),-10);
    }
    
}
