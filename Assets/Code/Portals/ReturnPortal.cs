using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal : MonoBehaviour
{
    //возврат на стартовую локу
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ZeroLevel");
    }
}
