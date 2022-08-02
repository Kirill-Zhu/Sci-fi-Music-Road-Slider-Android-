using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUps : MonoBehaviour
{
    public List<GameObject> pickUps;

    [Tooltip("Attach the next one PickUpZone(GameObject) in heirarchy")]
    public SpawnPickUps nextPickUp;

    public int spawnIndex;
   
   
    private void Start()
    {
        if(nextPickUp!=null)
        nextPickUp.GetIndex(spawnIndex);

       
    }

    public void GetIndex(int index)
    {
        switch (index)
        {
            case 0:
                spawnIndex = Random.Range(0, 2);
                break;
            case 1:
                spawnIndex = Random.Range(0, 3);
                break;
            case 2:
                spawnIndex = Random.Range(1, 4);
                break;
            case 3:
                spawnIndex = Random.Range(2, 4);
                break;
            case 4:
                spawnIndex = Random.Range(3, 4);
                break;

            default:
                spawnIndex = Random.Range(0, 4);
                break;
        }     
        SpawnPickUp();

    }
    private void SpawnPickUp()
    {
        foreach(GameObject pickUp in pickUps)
        {
            if (pickUp == pickUps[spawnIndex])
                pickUp.SetActive(true);
            else
                pickUp.SetActive(false);
        }
        
    }
}
