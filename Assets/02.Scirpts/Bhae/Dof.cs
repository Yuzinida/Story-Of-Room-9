using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Dof : MonoBehaviour
{
    public PostProcessVolume volume;
    private DepthOfField _DepthOfField;
    public float dof = 1;
    // Start is called before the first frame update
    void Start()
    {
            volume.profile.TryGetSettings(out _DepthOfField);
            
    }

    // Update is called once per frame
    void Update()
    {
        _DepthOfField.focalLength.value = dof;
    }
}
