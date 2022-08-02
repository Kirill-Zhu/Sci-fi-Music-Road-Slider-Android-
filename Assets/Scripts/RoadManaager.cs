
using System.Collections.Generic;
using UnityEngine;

public class RoadManaager : MonoBehaviour
{
    private bool _roadIsMove = true;
    public List<GameObject> roadModules;
    public Transform nextModuleTransform;
    [Tooltip("Links the previous RoadModuleManager whit next RoadModuleManager by their First and Last Pick Up zones")]
    public int bridgeIndex;
    [Range(0, 40)]
    public float speed;
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
        _tmpSpeed = speed;
        GlobalEventSystem.OnPlayPauseGame += StopMoveRoadSlide;
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnPlayPauseGame -= StopMoveRoadSlide;
    }
    private void Update()
    {
        RoadModuleManager.ChangeSpeed(speed);
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
        bridgeIndex = spawnIndex;
    }
    public void StopMoveRoadSlide()
    {
        _roadIsMove = !_roadIsMove;

        if (!_roadIsMove)
        {
            _tmpSpeed = speed;
            speed = 0;
        }
        else
            speed = _tmpSpeed;
    }
}

