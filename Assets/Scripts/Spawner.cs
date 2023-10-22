using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> listPrefabs;
    [SerializeField] public Transform holder;
    [SerializeField]protected int index;
    // Start is called before the first frame update


    protected virtual void Start()
    {
        index = 1;
        LoadComponent();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
    protected virtual void FixedUpdate()
    {
    }

    protected virtual void LoadComponent()
    {
        ListPrefabs();
        holder = transform.Find("Holder");
    }

    protected virtual void ListPrefabs()
    {
        Transform enemyPrefabs = transform.Find("Prefabs");
        foreach (Transform prefabs in enemyPrefabs)
        {
            this.listPrefabs.Add(prefabs);
            prefabs.gameObject.SetActive(false);
        }
    }

    protected virtual void ListSpawner(int listNumber)
    {
        foreach (Transform prefabs in this.listPrefabs)
        {
            if (prefabs == this.listPrefabs[listNumber])
            {
                CreatePrefabs(prefabs);
            }
        }
    }

    protected virtual void CreatePrefabs(Transform pfefabs)
    {
        Transform prefabs = Instantiate(pfefabs);
        CreatePosition(prefabs);
        prefabs.name = pfefabs.name + "#" + index;
        prefabs.gameObject.SetActive(true);
        prefabs.parent = this.holder;
        index++;
    }

    protected virtual void CreatePosition(Transform prefabs)
    {
        
    }

    protected virtual void Spawners()
    {

    }
}
