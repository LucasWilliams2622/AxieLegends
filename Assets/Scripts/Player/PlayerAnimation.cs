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
        Anim.AnimationName = PLAYER_RUN;
        Anim.timeScale = animSpeed;
    }

    public void PlayHurt()
    {
        var myAnim = Anim.AnimationName = PLAYER_HURT;
        Anim.loop = false;
        Anim.timeScale = animSpeed;
    }

    public void PlayIdle()
    {
        Anim.AnimationName = PLAYER_IDLE;
        Anim.timeScale = animSpeed;
    }

    public void PlayDie()
    {
        Instantiate(deadPS, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
