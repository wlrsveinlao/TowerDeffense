using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //is that ref of class
    public static BuildManager instance;

    //checking 
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more then one buildmanager in scene");
            return;
        }
        instance = this;
    }
    // ref of turret
    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;

    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }


}
