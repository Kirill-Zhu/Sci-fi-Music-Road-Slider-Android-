using UnityEngine;

public class TorchLights : MonoBehaviour
{
    [SerializeField] Material material;
    private int _band=4;


    void Update()
    {
        material.SetColor("_EmissionColor", new Color(GetAudioSpectrum.freqBand[_band], GetAudioSpectrum.freqBand[_band], GetAudioSpectrum.freqBand[_band],1));
    }
}
