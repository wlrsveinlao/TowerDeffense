using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // changing color 
    public Color hoverColor;

    //idk
    private Renderer rend;
    private Color startColor;

    //spawn our turret on correct position
    public Vector3 positionOffset;

    //ref on turret
    [Header("option")]
    public GameObject turret;
        
    BuildManager buildManager;

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void Start()
    {
        //idk for now
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    //when we press on mouse then we build it
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("we cant bield it here");
            return;
        }
        buildManager.BuildTurretON(this);
    }

    //just changing colors
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }
    //just changing colors
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
