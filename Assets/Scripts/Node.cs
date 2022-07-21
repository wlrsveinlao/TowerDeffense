using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject turret;

    private void Start()
    {
        //idk for now
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    //when we press on mouse then we build it
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("we cant bield it here");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    //just changing colors
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    //just changing colors
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
