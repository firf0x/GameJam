using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 defaultScale;
    void Start()
    {
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CahgeRadius(string state)
    {
        if(state == "run")
        {
            transform.localScale = defaultScale;
        }
        else if (state == "sitting")
        {
            transform.localScale /= 2;
        }
        else if(state == "invisible")
        {
            transform.localScale = Vector3.zero;
            Debug.Log("success");
        }
    }
}
