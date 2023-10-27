using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class BossFinalAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation anim;
    [SerializeField] private float animSpeed;
    [SerializeField] private Transform targetTransform;

    private string BOSS_RUN = "action/move-back";
    private string BOSS_HURT = "defense/hit-by-normal";
    private string BOSS_ATTACK = "attack/melee/normal-attack";
    private string BOSS_DIE = "defence/hit-die";
    private string BOSS_IDLE = "action/idle/normal";
    public BossFollowPlayer bossFollowPlayer;
    public SkeletonAnimation Anim { get => anim; set => anim = value; }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void PlayAttack()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = BOSS_ATTACK;
    }
    public void PlayRun()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = BOSS_RUN;
    }

    public void PlayHurt()
    {
        Anim.loop = false;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = BOSS_HURT;
    }

    public void PlayIdle()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = BOSS_IDLE;
    }

    public void PlayDie()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = BOSS_DIE;
    }
}
