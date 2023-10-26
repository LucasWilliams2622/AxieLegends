using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltiCD : MonoBehaviour
{
    [SerializeField] private GameObject tonglao;
    [SerializeField] private Button btn;
    [SerializeField] private GameObject cooldown;
    public bool lockRun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tonglao.activeInHierarchy == true&& !lockRun)
        {
            lockRun = true;
            btn.enabled = false;
            cooldown.SetActive(true);
        }
    }
}
