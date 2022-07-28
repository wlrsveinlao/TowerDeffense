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

    public GameObject BuildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild!= null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cast; } }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretON(Node node)
    {
        if (PlayerStats.money < turretToBuild.cast)
        {
            Debug.Log("Not Enough money to build");
            return;
        }
        PlayerStats.money -= turretToBuild.cast;

        GameObject turret = (GameObject)Instantiate(turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject buildeffect = (GameObject)Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildeffect, 5f);
        Debug.Log("Turret builded! Money Left: " + PlayerStats.money);
    }
}
