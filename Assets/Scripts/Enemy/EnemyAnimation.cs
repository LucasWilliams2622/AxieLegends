using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation anim;
    [SerializeField] private float animSpeed = 1f;
    private string ENEMY_RUN = "action/move-forward";
    private string ENEMY_DIE = "action/die";
    
    public void PlayRun()
    {
        anim.AnimationName = ENEMY_RUN;
        anim.timeScale = animSpeed;
    }
    public void PlayDie()
    {
        anim.AnimationName = ENEMY_DIE;
        anim.loop = false;
        anim.timeScale = animSpeed;
    }
}
