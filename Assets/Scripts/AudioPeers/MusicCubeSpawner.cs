
using UnityEngine;

public class MusicCubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject musicCubePrefab;
    private Vector3 spawnOffset;
    void Start()
    {            
        InvokeRepeating("SpawnNewMusicCube", 1, 10);
    }

   
    private void SpawnNewMusicCube()
    {
        float offsesRandom = Random.Range(-100, 100);
        spawnOffset = new Vector3(offsesRandom, 0, offsesRandom);
        GameObject tmpCube = Instantiate(musicCubePrefab);
        tmpCube.transform.position = transform.position + spawnOffset;
    }
}
