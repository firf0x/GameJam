using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public static bool destroy = false;
    public GameObject obj;
    
    void Start()
    {
        // если переменная включена, то убираем объект(заборчик)
        if (destroy == true)
        {
            obj.SetActive(false);
        }
    }

}
