using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private int trackIndex;
    public List<Transform> tracks;
    [SerializeField] LayerMask maskPickUp;
    [SerializeField] GameObject rearLamps;
    private Color _startColor;


    void Start()
    {
        #region Singletone
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        #endregion
      //  transform.position = tracks[trackIndex].position;
      _startColor = rearLamps.GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            GoLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            GoRight();
       
        Ray ray = new Ray(transform.position + new Vector3(0,2,0), Vector3.down);
        if (Physics.SphereCast(ray, 1, out RaycastHit hit,100, maskPickUp))
        {
            hit.collider.GetComponent<PickUpEffect>().DoPickUpEffect();
            StartCoroutine(RearLampsPickUpEffect(0.2f));         
              
        }
      
    }
  IEnumerator RearLampsPickUpEffect(float sec)
    {
      
        rearLamps.GetComponent<Renderer>().material.SetColor("_EmissionColor", _startColor+new Color(1,1,1,1));
        yield return new WaitForSeconds(sec);
        rearLamps.GetComponent<Renderer>().material.SetColor("_EmissionColor", _startColor);
    }
    public void GoLeft()
    {
       
        trackIndex--;
        trackIndex = Mathf.Clamp(trackIndex, 0, tracks.Count - 1);
        transform.position = tracks[trackIndex].position;
    }
    public void GoRight()
    {
       
        trackIndex++;
        trackIndex = Mathf.Clamp(trackIndex, 0, tracks.Count - 1);
        transform.position = tracks[trackIndex].position;
    }
 
    
   
}
