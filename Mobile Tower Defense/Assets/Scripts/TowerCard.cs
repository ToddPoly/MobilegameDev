using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerCard : MonoBehaviour
{
    public GameObject tower_Drag;
    public GameObject tower_Game;
    public GameObject ground;
    public bool spawnedObject = false;

    private GameObject towerDragInstance;

    public void OnDrag(PointerEventData eventData)
    {
        //towerDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //towerDragInstance = Instantiate(tower_Drag, ground.transform);
        //towerDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 12));//z (12) is distance from camera
            int id = touch.fingerId;          

            if (EventSystem.current.IsPointerOverGameObject(id))//Currently takes whole panel in ui need to change to only do the actualy card/button
            {
                Debug.Log(touch.phase);
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)//Read the UI tower panel and instatiate the tower prefab in the player touch point
                {
                    if (!spawnedObject)
                    {
                        //check touched ui tower element
                        towerDragInstance = Instantiate(tower_Drag, ground.transform);

                        towerDragInstance.transform.position = touchedPos;

                        spawnedObject = true;
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    towerDragInstance.transform.position = touchedPos;
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    Destroy(towerDragInstance);
                    spawnedObject = false;
                }

                Debug.Log(spawnedObject);
            }
        }

    }
}
