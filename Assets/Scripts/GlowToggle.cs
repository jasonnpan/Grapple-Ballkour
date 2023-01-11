using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
// using UnityEngine.Rendering;
// using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GlowToggle : MonoBehaviour
{

    private GameObject postProcessing;
    private float glowVolume;


    [SerializeField] Slider glowSlider;

    // Start is called before the first frame update
    void Start()
    {
        postProcessing = GameObject.Find("Post Processing Volume");

        if(!PlayerPrefs.HasKey("glowVolume"))
        {
            PlayerPrefs.SetFloat("glowVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

        glowVolume = PlayerPrefs.GetFloat ("glowVolume");
        postProcessing.GetComponent<PostProcessVolume>().weight = glowVolume;
    }

    public void ChangeVolume()
    {
        Save();
    }

    private void Load()
    {
        glowSlider.value = PlayerPrefs.GetFloat("glowVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("glowVolume", glowSlider.value);
    }

    void Update()
    {
        glowVolume = PlayerPrefs.GetFloat ("glowVolume");
        postProcessing.GetComponent<PostProcessVolume>().weight = glowVolume;
    }
}
