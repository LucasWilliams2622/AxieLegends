using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LBallStrikeColltroler : MonoBehaviour
{
    [SerializeField] private ParticleSystem lightningStrike;
    [SerializeField] private float numAttack;
    [SerializeField] private float timeBetween;
    [SerializeField] private float ballChargeTime;
    [SerializeField] private LballDelayShotTime delayShotTime;
    [SerializeField] private List<Transform> listEnemy;
    [SerializeField] private float numMaxEnemy;

    private Animator anim;
    private bool isStartCount;
    private float timer;
    private float count;
    private Transform startObject;
    public bool IsStartCount { get => isStartCount; set => isStartCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsStartCount = false;
        startObject = transform;
    }

    // Update is called once per frame
    void Update()
    {
        delayShotTime.ChargeTime = ballChargeTime;

        if (IsStartCount)
        {
            anim.Play("LBall_Spread");
            timer += Time.deltaTime;
            if (timer > timeBetween && count < numAttack)
            {
                timer = 0;
                count++;
                startStrike();
            }
        }

        if (count == numAttack)
        {
            count = 0;
            delayShotTime.enabled = true;
            listEnemy.Clear();
            IsStartCount = false;
            anim.Play("LBall_Idle");
        }
    }

    void startStrike()
    {
        if (listEnemy != null && listEnemy.Count > 0)
        {
            for (int i = 0; i < listEnemy.Count; i++)
            {
                var endObject = listEnemy[i];
                var obj = Instantiate(lightningStrike, endObject.position, Quaternion.identity);
                obj.Play();

                var emit = new ParticleSystem.EmitParams();
                emit.position = startObject.position;
                obj.Emit(emit, 1);

                emit.position = endObject.position;
                obj.Emit(emit, 1);

                emit.position = (startObject.position + endObject.position) / 2;
                obj.Emit(emit, 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") && listEnemy.Count < numMaxEnemy && !listEnemy.Contains(collision.gameObject.transform))
        {
            listEnemy.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv1") && listEnemy.Count < numMaxEnemy && !listEnemy.Contains(collision.gameObject.transform))
        {
            listEnemy.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv2") && listEnemy.Count < numMaxEnemy && !listEnemy.Contains(collision.gameObject.transform))
        {
            listEnemy.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv3") && listEnemy.Count < numMaxEnemy && !listEnemy.Contains(collision.gameObject.transform))
        {
            listEnemy.Add(collision.gameObject.transform);
        }
    }
}
