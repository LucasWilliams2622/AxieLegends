using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    public GameObject pointPlayer;
    public GameObject pointAxe;
    public GameObject hurtPlace;
    public bool showHurtPlace;
    public BossFollowPlayer bossFollowPlayer;
    public Rigidbody2D rb;

    void Start()
    {
        showHurtPlace = false;
        hurtPlace.SetActive(false);
    }

    private void Update()
    {

        
        //hurtPlace.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (bossFollowPlayer.speed == 0)
        {
            showHurtPlace = true;
            if (showHurtPlace)
            {
                showHurtPlace = false;

                Vector3 direction = ((Vector2)pointPlayer.transform.position - rb.position).normalized;

                float angle = Vector3.Cross(direction, hurtPlace.transform.up).z;
                rb.angularVelocity = -angle;

                hurtPlace.SetActive(true);
                StartCoroutine(HideHurtPlace());
            }
        }
    }

    IEnumerator HideHurtPlace()
    {
        yield return new WaitForSeconds(1.5f);
        hurtPlace.SetActive(false);
    }
}
