/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //игрок и границы карты
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float yMin, yMax;
    private float camY;
    private float camOrthsize;
    private Camera mainCam;

    private void Start()
    {
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
    }
    
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin - camOrthsize, yMax + camOrthsize);
        this.transform.position = new Vector3(0f, camY, this.transform.position.z);
        
        
    }
}*/


using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //игрок и границы карты
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin - cameraRatio, xMax + cameraRatio);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);


    }
}
