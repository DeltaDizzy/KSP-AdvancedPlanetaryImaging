using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BlueImageEffect : ImageEffect
{
    [SerializeField]
    private Boolean enabled = true;
    
    private override void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if(enabled)
        {
            Graphics.Blit(src, dst, mat);
        }
        else
        {
            Graphics.Blit(src, dst);
        }
    }
}
