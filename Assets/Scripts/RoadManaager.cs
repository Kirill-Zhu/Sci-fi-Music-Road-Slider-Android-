
using System.Collections.Generic;
using UnityEngine;

public class RoadManaager : MonoBehaviour
{
    private bool _roadIsMove = true;
    public List<GameObject> roadModules;
    public Transform nextModuleTransform;
    [HideInInspector]
    public int bridgeSpawnZoneIndex=2;
  
    public float currentSpeed;
    [Range(0, 10)]
    public float minSpeed;
    [Range(10, 100)]
    public float maxSpeed;
    private float _tmpSpeed;

    public static RoadManaager instance;

    private void Start()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion
        _tmpSpeed = currentSpeed;
        GlobalEventSystem.OnPlayPauseGame += StopMoveRoadSlide;
        GlobalEventSystem.OnSpeedUp += SpeedUp;
        GlobalEventSystem.OnSlowDown += SlowDown;
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnPlayPauseGame -= StopMoveRoadSlide;
        GlobalEventSystem.OnSpeedUp -= SpeedUp;
        GlobalEventSystem.OnSlowDown -= SlowDown;

    }
    private void Update()
    {
        RoadModuleManager.ChangeSpeed(currentSpeed);
    }

    public void SpawnModule()
    {

        int randomRoadModule = Random.Range(0, roadModules.Count);
        GameObject tmpModule = roadModules[randomRoadModule];
        tmpModule.transform.position = nextModuleTransform.position;
        Instantiate(tmpModule);      
       
    }
  public void SetBridgeIndex(int spawnIndex)
    {
        bridgeSpawnZoneIndex = spawnIndex;
    }
    public void StopMoveRoadSlide()
    {
        _roadIsMove = !_roadIsMove;

        if (!_roadIsMove)
        {
            _tmpSpeed = currentSpeed;
            currentSpeed = 0;
        }
        else
            currentSpeed = _tmpSpeed;
    }
    public void SpeedUp()
    {
        if(currentSpeed<maxSpeed)
        currentSpeed += 0.1f;
    }
    public void SlowDown()
    {
       if(currentSpeed>minSpeed)
        currentSpeed -= 0.2f;
    }
}

