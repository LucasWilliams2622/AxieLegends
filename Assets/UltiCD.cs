using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltiCD : MonoBehaviour
{
    [SerializeField] private GameObject tonglao;
    [SerializeField] private Button btn;
    [SerializeField] private GameObject cooldown;
    // Start is called before the first frame update
    private void Awake()
    {
        btn.onClick.AddListener(onClickUlti);
    }
     
    void onClickUlti()
    {
        btn.enabled = false;
        cooldown.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
