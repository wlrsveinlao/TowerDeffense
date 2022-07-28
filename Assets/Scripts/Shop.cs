using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint LiserTurret;

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
        Debug.Log("Missile turrt purchese");
    }
    public void SelectLiserTurret()
    {
        buildManager.SelectTurretToBuild(LiserTurret);
        Debug.Log("Liser Turret purchese");

    }
}
