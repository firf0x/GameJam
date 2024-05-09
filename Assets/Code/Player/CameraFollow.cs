using System.Collections;
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
}