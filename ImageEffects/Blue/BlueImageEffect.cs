using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BlueImageEffect : MonoBehaviour
{
    [SerializeField]
    private Shader shader;
    private Material mat;
    private Boolean enabled = true;
    
    private void Awake()
    {
        mat = new Material(shader);
    }
    
    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if(enabled)
        {
            Graphics.Blit(src, dst, mat);
        }
    }
}
