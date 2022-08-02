
using System.Collections.Generic;
using UnityEngine;

public class MusicCubeBehaviour : MonoBehaviour
{
    [Tooltip("Insert some sorts od materials")]
    [SerializeField] List<Material> materials;
    void Start()
    {
        int materialIndex = Random.Range(0, materials.Count-1);
        GetComponent<Renderer>().material = materials[materialIndex];

        var scale = transform.localScale;
        scale.x = scale.x * Random.Range(0.9f, 1.1f);
        scale.y= scale.y* Random.Range(0.9f, 1.1f);
        scale.z = scale.z* Random.Range(0.9f, 1.1f);
        transform.localScale = scale;
    }


    void Update()
    {
        transform.Translate(0, -10* Time.deltaTime, 0);
        transform.Rotate(0, 10 * Time.deltaTime * Random.Range(1, 5),0);
    }
}
