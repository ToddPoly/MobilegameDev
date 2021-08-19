using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    public void SetHighLight()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
