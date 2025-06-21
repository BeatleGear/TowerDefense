using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More then one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;    
    }
}
