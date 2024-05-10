using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Config;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Transform wolf;
    [SerializeField] private PlayerScript player;
    public void Dead()
    {
        player.Dead();
        wolf.position = new Vector3(-9.69f, -24.09f, 0);
    }

    public void Finish()
    {
        player.fadeAnim.enabled = false;
    }
}
