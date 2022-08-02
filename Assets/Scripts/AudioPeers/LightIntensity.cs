
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    Skybox skybox;
 
    private int band=1;
    Color _StartEmissionColor;
  
    private float changeIntesity;
    private float RChannel;
    private float GChannel;
    private float Bchannel;
    void Start()
    {
       
        RChannel = Random.Range(0, 255f);
        Bchannel = Random.Range(0, 255f);
        _StartEmissionColor = GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        changeIntesity = GetAudioSpectrum.freqBand[band];
        
        Color newColor = new Vector4(RChannel/255f, changeIntesity/2, Bchannel/255f, 0);
       
        GetComponent<Renderer>().material.SetColor("_EmissionColor",_StartEmissionColor+ newColor);
    }
}
