using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovingControl : MonoBehaviour
{
    public GameObject[] mountains = new GameObject[4];
    public GameObject graveyard;
    public GameObject cameraObj;
    CameraMovingControl script_cameraObj;
    float movingSpeed = 1;
    public bool bMovingStop = false;

    float scrollSpeed = 0.1f;

    public MeshRenderer rendererMat;
    float Offset;

    private void Start()
    {
        script_cameraObj = cameraObj.GetComponent<CameraMovingControl>();
    }
    void Update()
    {
        if (!bMovingStop)
        {
            movingSpeed = script_cameraObj.GetMoveX();
            MountainIterativeDeployment();
            Offset -= Time.deltaTime * (movingSpeed * scrollSpeed);
            rendererMat.material.mainTextureOffset = new Vector2(Offset, 0);
        }
    }

    void MountainIterativeDeployment()
    {
        transform.localPosition = new Vector2(cameraObj.transform.localPosition.x, 0);
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
