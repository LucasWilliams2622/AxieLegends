using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFollowPlayer : FollowToDistance
{
    float distanceTarget;
    [SerializeField] protected float time;
    [SerializeField] protected float speed;
    [SerializeField] ExpFollowPlayer expFollowPlayer;
    [SerializeField] protected GameObject Magnet;
    public SpriteRenderer sprite;
    public Collider2D col;
    protected override void Start()
    {
        base.Start();
        distanceTarget = ExpFollowPlayer.distanceTarget;
        speed = ExpFollowPlayer.moveSpeedTarget;
        target = GameObject.Find("Player");
        ExpFollowPlayer.distanceTarget = 3.5f; 
        ExpFollowPlayer.moveSpeedTarget = 40;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(destroyGameobject());
           
        }
    }

    IEnumerator destroyGameobject()
    {
        ExpFollowPlayer.distanceTarget = 20f;
        ExpFollowPlayer.moveSpeedTarget = 60f;
        sprite.enabled = false;
        col.enabled = false;

        yield return new WaitForSeconds(2);
        ExpFollowPlayer.distanceTarget = 3.5f;
        ExpFollowPlayer.moveSpeedTarget = 40;

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        StopCoroutine(destroyGameobject());

    }
}
