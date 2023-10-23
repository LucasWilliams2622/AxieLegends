using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CarrotPSkill : MonoBehaviour
{

    
    [SerializeField] private float shootingForce;
    public Transform activeRangeTransform;
    public SkillScanNearMob activeRange;
    public Transform piercingCarrot;

    [Header("Đừng động vào rotationModifier")]
    [SerializeField] private float rotationModifier;

   
    private Animator anim;
    private PolygonCollider2D col2D;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool isShooting = false;

    private Transform nearestEnm;
    private Vector2 direction;
    private Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable()
    {
        LoadStuff();

        anim.Play("PCarrot_FlyUp");
        float dur = anim.GetCurrentAnimatorClipInfo(0).Length;
        Invoke(nameof(ShootCarrot), dur);//đặt trong onenable để đoạn lệnh này chỉ chạy một lần direction không bị trừ liên tục gây lỗi
       
    }
    // Update is called once per frame
    void Update()
    {
        nearestEnm = activeRange.NearestEnm;
    }
    private void FixedUpdate()
    {
        if (isShooting)
        {
            rb.velocity = new Vector2(direction.x, direction.y).normalized * shootingForce;
        }
    }

    void LoadStuff()
    {
        activeRangeTransform = GameObject.Find("ActiveRange").GetComponent<Transform>();
        activeRange = GameObject.Find("ActiveRange").GetComponent<SkillScanNearMob>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col2D = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void ShootCarrot()
    {
        transform.SetParent(null);
        sprite.sortingOrder = 1;
        col2D.enabled = true;
        anim.enabled = false;
        isShooting = true;
        direction = (nearestEnm.position - transform.position);
        rotation = (transform.position - nearestEnm.position);

        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - rotationModifier;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ActiveRange4Skill"))
        {
            transform.SetParent(piercingCarrot);
            transform.position = activeRangeTransform.position;
            gameObject.SetActive(false);
            col2D.enabled = false;
            anim.enabled = true;
            isShooting = false;
            sprite.sortingOrder = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
