using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerCard : MonoBehaviour
{
    public GameObject tower_Drag;
    public GameObject tower_Game;
    public GameObject ground;

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
            Debug.Log("noice");
            Touch touch = Input.GetTouch(0);
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 12));//z (12) is distance from camera

            if (touchedPos == this.transform.position)
            {
                if (touch.phase == TouchPhase.Began)//Read the UI tower panel and instatiate the tower prefab in the player touch point
                {
                    //check touched ui tower element
                    towerDragInstance = Instantiate(tower_Drag, ground.transform);

                    towerDragInstance.transform.position = touchedPos;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    towerDragInstance.transform.position = touchedPos;
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    Destroy(towerDragInstance);
                }
            }
        }

    }
}
