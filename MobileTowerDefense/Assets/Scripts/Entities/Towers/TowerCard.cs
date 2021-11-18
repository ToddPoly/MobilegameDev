using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TowerCard : MonoBehaviour //change whole class to an input manager to read the objects
{
    public GameObject tower;
    public Image tower_Icon;

    public int cost;
    public string name;
    public TextMeshProUGUI costDisplay;

    private void Start()
    {
        //cost = get the tower cost once the tower is put in proplery not on button event trigger
        costDisplay = GetComponentInChildren<TextMeshProUGUI>();
        costDisplay.text = name + " " + cost.ToString();
    }
}
