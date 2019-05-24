using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovingControl : MonoBehaviour
{
    public GameObject[] mountains = new GameObject[4];
    public GameObject mountainAxis;
    public GameObject graveyardAxis;
    public GameObject cameraObj;
    public PlayerControl script_PlayerControl;
    float movingSpeed = 1;

    float scrollSpeed = 0.1f;

    public MeshRenderer rendererMat;
    float Offset;

    private void Start()
    {
    }
    void Update()
    {
            movingSpeed = script_PlayerControl.GetMoveX();
            MountainIterativeDeployment();
            Offset -= Time.deltaTime * (movingSpeed * scrollSpeed);
            rendererMat.material.mainTextureOffset = new Vector2(Offset, 0);
        
        transform.localPosition = new Vector2(cameraObj.transform.localPosition.x, cameraObj.transform.localPosition.y);
        mountainAxis.transform.localPosition = new Vector2(mountainAxis.transform.localPosition.x, -cameraObj.transform.localPosition.y * 0.2f);
        graveyardAxis.transform.localPosition = new Vector2(graveyardAxis.transform.localPosition.x, -cameraObj.transform.localPosition.y*0.5f);
    }

    void MountainIterativeDeployment()
    {
        foreach (GameObject obj in mountains)
        {
            if (obj.transform.localPosition.x<=-24)
            {
                obj.transform.localPosition = new Vector2(14.4f, -1.96f);
            }
            else if (obj.transform.localPosition.x >= 24)
            {
                obj.transform.localPosition = new Vector2(-14.4f, -1.96f);
            }
            obj.transform.Translate(Vector2.left * Time.deltaTime * movingSpeed);
        }
    }
}
