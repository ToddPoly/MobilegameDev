using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public GameObject ground;
    public bool spawnedObject = false;
    public LayerMask groundGridLayer;//set in editor

    private MeshRenderer rend = null;
    public GameObject tower;
    private GameObject towerDragInstance;

    private void Update()
    {
        TouchInputs();
    }

    public void TouchInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 12));//z (12) is distance from camera
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            int id = touch.fingerId;

            //Debug.Log(touch.phase);
            if (touch.phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(id))//Checking if touch is on UI then will set tower only if a UI event has passed a gameobject to the class GetTower below
                {
                    Debug.Log("On UI");
                    if (!spawnedObject && tower)
                    {
                        //check touched ui tower element
                        //Set tower towerDragInstance to the gameObject of the UI tower element you have touched
                        towerDragInstance = Instantiate(tower, ground.transform);

                        towerDragInstance.transform.position = touchedPos;

                        spawnedObject = true;
                    }
                }
                else// Only run when not on UI, might add ability to move towers or upgrade/sell them later using a raycast on their colliders
                {
                    Debug.Log("Not UI");
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        var hit = hitInfo.collider.name;
                        if (hit != null)
                        {
                            //Debug.Log(hit);
                        }
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved)//Read the raycast gridtile and hightlight it in game showing where the tower will go
            {
                if (spawnedObject)
                {
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundGridLayer))//Only collides against groundGridLayer
                    {
                        HighLight(hitInfo);
                    }
                    towerDragInstance.transform.position = touchedPos;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)//Read the raycast grid tile location from the moved or ended phase then pass the held tower gameobject to the tile at that location then delete it in this class
            {
                if (spawnedObject)
                {
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundGridLayer))//Only collides against groundGridLayer
                    {
                        hitInfo.collider.gameObject.GetComponentInParent<ObjectContainer>().SetObject(tower);

                        Debug.Log(hitInfo.collider.name);
                    }
                }

                Destroy(towerDragInstance);
                tower = null;
                spawnedObject = false;
                rend.enabled = false;
            }
            //Debug.Log(spawnedObject);
        }
    }

    public void GetTower(GameObject gameObject)//Passed from UI Event trigger
    {
        tower = gameObject;
    }

    public void HighLight(RaycastHit hitInfo)//Turns on the mesh renderer for the tile you are touching ie hightlighting it. Also checks if you are raycasting to the same tile or a new one
    {
        MeshRenderer curRend = hitInfo.collider.GetComponent<MeshRenderer>();

        if (curRend == rend)
            return;

        if (curRend && curRend != rend)
        {
            if (rend)
            {
                rend.enabled = false;
            }
        }

        if (curRend)
            rend = curRend;
        else
            return;

        rend.enabled = true;
    }
}





