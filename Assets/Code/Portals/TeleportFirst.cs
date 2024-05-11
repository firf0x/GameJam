using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportFirst : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //даём команду заборчикам на уничтожение
        FenceScript.destroy = true;
        SceneManager.LoadScene("SampleScene");
    }
}

