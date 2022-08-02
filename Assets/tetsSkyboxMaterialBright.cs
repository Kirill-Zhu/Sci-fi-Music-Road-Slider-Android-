using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetsSkyboxMaterialBright : MonoBehaviour
{
    [SerializeField] Material material;
    private int _band=6;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetAudioSpectrum.freqBand[_band]/2>1)
        RenderSettings.skybox.SetFloat("_Exposure", GetAudioSpectrum.freqBand[_band]/3);
        else
            RenderSettings.skybox.SetFloat("_Exposure", 1);
    }
}
