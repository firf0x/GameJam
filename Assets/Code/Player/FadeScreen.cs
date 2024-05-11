using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Config;
using UnityEngine.SceneManagement;
public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Transform wolf;
    [SerializeField] private PlayerScript player;
    public void Dead()
    {
        player.Dead();
        if (player.firstLevel)
            wolf.position = new Vector3(-9.69f, -24.09f, 0);
        else
        {
            SceneManager.LoadScene("SecondLevel");
        }

    }

    public void Finish()
    {
        player.fadeAnim.enabled = false;
    }
}
