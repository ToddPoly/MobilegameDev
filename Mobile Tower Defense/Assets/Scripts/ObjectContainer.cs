using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Instantiate(tower, this.transform.position, Quaternion.identity, this.transform);
    }
}
