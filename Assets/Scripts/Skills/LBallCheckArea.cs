using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBallCheckArea : MonoBehaviour
{

    [SerializeField] private LBallStrikeColltroler strike;
    [SerializeField] private float maxTargetStrike;

    [SerializeField] private List<Transform> enemyList;

    public List<Transform> EnemyList {get => enemyList; set => enemyList = value;}


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster")&&!EnemyList.Contains(collision.gameObject.transform) && EnemyList.Count<maxTargetStrike)
        {

            //gửi thông tin cho cầu sét tấn công
            EnemyList.Add(collision.gameObject.transform);
            
        }
    }
}
