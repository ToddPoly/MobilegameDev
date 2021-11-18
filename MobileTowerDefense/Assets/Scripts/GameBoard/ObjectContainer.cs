using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    public GameObject tower;

    public float height = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInChildren<Tower>())
        {
            isFull = false;
            tower = null;
        }
    }

    public void SetObject(GameObject gameObject)
    {
        if (!isFull && gameObject.tag == "Tower")
        {
            tower = gameObject;           
            SpawnObject();
            isFull = true;
        }
    }

    public void SpawnObject()
    {
        Instantiate(tower, transform.position + new Vector3(0,height,0), Quaternion.Euler(0,90,0), this.transform);
        tower.GetComponent<Entity>().isActive = true;
    }
}
