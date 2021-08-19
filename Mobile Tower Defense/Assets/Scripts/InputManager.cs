using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject ground;
    public bool spawnedObject = false;
    private GameObject towerDragInstance;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 12));//z (12) is distance from camera
            Ray ray = Camera.main.ScreenPointToRay(touch.position);           
            int id = touch.fingerId;
            //Debug.DrawRay(Camera.main.transform.position, touchedPos, Color.green);

            Debug.Log(touch.phase);
            if (touch.phase == TouchPhase.Began)//Read the raycast hit collider UI tower panel and instatiate the tower prefab in the player touch point
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    var hit = hitInfo.collider.name;
                    if (hit != null)
                    {
                        Debug.Log(hit);
                    }
                }
                if (!spawnedObject)
                {
                    //check touched ui tower element
                    //Set tower towerDragInstance to the gameObject of the UI tower element you have touched
                    //towerDragInstance = Instantiate(, ground.transform);

                    towerDragInstance.transform.position = touchedPos;

                    spawnedObject = true;
                }
            }
            else
            {
                Debug.Log("Not UI");
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (spawnedObject)
                {
                    towerDragInstance.transform.position = touchedPos;
                }
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
