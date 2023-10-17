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
    private string PLAYER_HURT = "activity/appear";
    private string PLAYER_IDLE = "action/idle/normal";
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
        anim.AnimationName = PLAYER_RUN;
        anim.timeScale = animSpeed;
    }

    public void PlayHurt()
    {
        anim.AnimationName = PLAYER_HURT;
        anim.loop = false;
        anim.timeScale = animSpeed;
    }

    public void PlayIdle()
    {
        anim.AnimationName = PLAYER_IDLE;
        anim.timeScale = animSpeed;
    }

    public void PlayDie()
    {
        Instantiate(deadPS, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
