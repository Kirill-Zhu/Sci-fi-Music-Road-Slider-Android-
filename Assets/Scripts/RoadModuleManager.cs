using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadModuleManager : MonoBehaviour
{
    private bool hasSpawnedNewModule = false;
    public Transform nextModuleTransform;
    [Tooltip("Attach the FIRST PickUpZone(GameObject with SpawnPickUps script")]
    public SpawnPickUps firstPickUpZone;

    [Tooltip("Attach the LAST PickUpZone(GameObject with SpawnPickUps script")]
    [SerializeField] SpawnPickUps LastPickUpZone;

    public static float speed;
    private void Start()
    {
        if(RoadManaager.instance!=null)
        {
            RoadManaager.instance.nextModuleTransform = nextModuleTransform;
           
           
            firstPickUpZone.GetIndex(RoadManaager.instance.bridgeSpawnZoneIndex);
           
        }
        
    }

    private void Update()
    {
        RoadManaager.instance.SetBridgeIndex(LastPickUpZone.spawnIndex);
        transform.Translate(0, 0, -1*speed*Time.deltaTime);

        if (transform.position.z<0&&!hasSpawnedNewModule)
        {
            RoadManaager.instance.SpawnModule();
            hasSpawnedNewModule = true;
        }
        if (transform.position.z < -100)
            Destroy(gameObject);
    }
    public static void ChangeSpeed(float newSpeedValue)
    {
        speed = newSpeedValue;

    }
}
