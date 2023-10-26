using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation anim;
    [SerializeField] private float animSpeed;
    [SerializeField] private ParticleSystem deadPS;
    [SerializeField] private Transform targetTransform;

    private string PLAYER_RUN = "draft/run-origin";
    private string PLAYER_HURT = "defense/hit-by-normal";
    private string PLAYER_IDLE = "action/idle/normal";
    private string PLAYER_SPEED_RUN = "action/move-forward";


    public SkeletonAnimation Anim { get => anim; set => anim = value; }

    // private string PLAYER_DIE ; 
    // player die sẽ cho làm particle bung thành 5 cục 5 hướng khác nhau, xóa sprite
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayRun()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = PLAYER_RUN;
    }
    public void PlaySpeedRun()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = PLAYER_SPEED_RUN;
    }

    public void PlayHurt()
    {
        Anim.loop = false;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = PLAYER_HURT;
    }

    public void PlayIdle()
    {
        Anim.loop = true;
        Anim.timeScale = animSpeed;
        Anim.AnimationName = PLAYER_IDLE;
    }

    public void PlayDie()
    {
        Instantiate(deadPS, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
