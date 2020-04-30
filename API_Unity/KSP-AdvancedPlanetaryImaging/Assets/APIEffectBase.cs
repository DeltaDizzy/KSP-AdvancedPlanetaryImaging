using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class APIEffectBase : MonoBehaviour
{
    [SerializeField]
    protected Shader shader;
    protected Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = new Material(shader);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, material);
    }
}
