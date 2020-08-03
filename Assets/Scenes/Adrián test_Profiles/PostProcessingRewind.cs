using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessingRewind : MonoBehaviour
{
    public PostProcessVolume volume;

    private ColorGrading colorGrading;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
        colorGrading.saturation.value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            colorGrading.saturation.value = -100f;
        }else{
            colorGrading.saturation.value = 0.0f;
        }
    }
}
