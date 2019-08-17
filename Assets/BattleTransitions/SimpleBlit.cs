using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SimpleBlit : MonoBehaviour
{
    public Material TransitionMaterial;
    public float transitionValue = 0.0f;

    void Update()
    {
        
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (TransitionMaterial != null)
        {
            TransitionMaterial.SetFloat("_Cutoff", transitionValue);
            Graphics.Blit(src, dst, TransitionMaterial);
        }
    }
}
