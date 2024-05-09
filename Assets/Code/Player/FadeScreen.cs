using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Transform wolf;
    [SerializeField] private PlayerScript player;
    public void Dead()
    {
        player.Dead();
        wolf.position = new Vector3(0.3844f, -5.0565f, 0);
    }

    public void Finish()
    {
        player.anim.enabled = false;
    }
}
