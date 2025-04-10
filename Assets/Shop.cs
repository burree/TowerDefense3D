using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }



    public void PurchaseStandardTurret ()
    {
        Debug.Log("PurchaseStandardTurret");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseTackShooter()
    {
        Debug.Log("PurchaseTackShooter");
        buildManager.SetTurretToBuild(buildManager.tackShooterPrefab);
    }
}
