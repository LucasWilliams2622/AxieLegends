using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class BossFinalAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation anim;
    [SerializeField] private float animSpeed;
    [SerializeField] private Transform targetTransform;
    [SerializeField] protected BossAttackPlayer bossAttackPlayer;

    private string BOSS_RUN = "action/move-back";
    private string BOSS_HURT = "defense/hit-by-normal";
    private string BOSS_ATTACK = "attack/melee/normal-attack";
    private string BOSS1_ATTACK = "attack/melee/normal-attack";
    private string BOSS_DIE = "defense/hit-die";
    private string BOSS_IDLE = "action/idle/normal";
    private string BOSS_ULTIMATE = "attack/melee/scratch-attack";   

    public BossFollowPlayer bossFollowPlayer;
    public SkeletonAnimation Anim { get => anim; set => anim = value; }

    void Start()
    {
        anim = GetComponent<SkeletonAnimation>();
        targetTransform = gameObject.transform;
        bossFollowPlayer = GetComponent<BossFollowPlayer>();
        bossAttackPlayer = GetComponent<BossAttackPlayer>();
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

    
    public void PlayUltimate()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = BOSS_ULTIMATE;
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
