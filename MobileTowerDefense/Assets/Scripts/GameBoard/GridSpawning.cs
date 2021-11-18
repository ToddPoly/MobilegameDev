using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawning : MonoBehaviour
{
    public GameObject prefab;
    public float gridX = 9f;
    public float gridY = 5f;
    public float spacingX = 1.6f;
    public float spacingY = 2f;

    void Awake()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(this.transform.localPosition.x + (x * spacingX) + 1, 0, this.transform.localPosition.z + (y * spacingY) + 0.5f);//super scuffed way of added offset
                GameObject newTile = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            }
        }
    }
}
