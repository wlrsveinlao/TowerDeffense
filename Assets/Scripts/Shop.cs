using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        buildManager.SelectTurretToBuild(standartTurret);
        Debug.Log("standart turrt purchese");
    }
    public void SelectMissileLaunchTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
        Debug.Log("Another turrt purchese");
    }
}
