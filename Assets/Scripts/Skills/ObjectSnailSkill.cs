using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnailSkill : MonoBehaviour
{
    [SerializeField] private float projectileHeight = 10f;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private Transform tSnailGameObject;
    [SerializeField] float destroyTime = 0.01f;
    private Vector3 startPos;
    private Vector3 endPos;
    [SerializeField] float fireLerp = 1;

    private void Start()
    {
        tSnailGameObject = GameObject.Find("ThrowingSnailSkill").transform;
        transform.position = tSnailGameObject.position;
        startPos = transform.position;
        endPos = GameObject.Find("ThrowingSnailTarget").transform.position;
    }

    void Update()
    {
        if (fireLerp < 1)
        {
            Vector3 newProjectilePos = CalculateTrajectory(startPos, endPos, fireLerp);
            transform.position = newProjectilePos;

            fireLerp += projectileSpeed * Time.deltaTime;
        }
    }

    Vector3 CalculateTrajectory(Vector3 firePos, Vector3 targetPos, float t)
    {
        Vector3 linearProgress = Vector3.Lerp(firePos, targetPos, t);
        float perspectiveOffset = Mathf.Sin(t * Mathf.PI) * projectileHeight;

        Vector3 trajectoryPos = linearProgress + (Vector3.up * perspectiveOffset);
        return trajectoryPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnailArea"))
        {
            collision.GetComponent<TSnailTargetImpact>().IsTrigger = true;
            Destroy(gameObject, destroyTime);
        }
    }
}
