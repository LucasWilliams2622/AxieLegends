using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private SkeletonAnimation anim; // cần các nhân vật có tích hợp component skeletonsanimation;
    [SerializeField] private float animSpeed = 1f;
    private string ENEMY_RUN = "action/move-forward";
    private string ENEMY_DIE = "action/die";

    private void Start()
    {
        anim = GetComponent<SkeletonAnimation>();
        PlayRun();
    }

    public void PlayRun()
    {
        anim.loop = true;
        anim.timeScale = animSpeed;
        anim.AnimationName = ENEMY_RUN;
        
    }
    public void PlayDie()
    {
        anim.loop = false;
        anim.timeScale = animSpeed;
        anim.AnimationName = ENEMY_DIE;
        
    }
}
