using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandartTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
        Debug.Log("standart turrt purchese");
    }
    public void PurchaseMissileLaunchTurret()
    {
        buildManager.SetTurretToBuild(buildManager.MissileLaunchTurretPrefab);
        Debug.Log("Another turrt purchese");
    }
}
