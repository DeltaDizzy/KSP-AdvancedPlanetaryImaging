using System;
using System.Collections.Generic;
using UnityEngine;

namespace KSP-API
{
  [RequireComponent(typeof(Camera))]
  public class ImageEffect : MonoBehaviour
  {
    [SerializeField]
    protected Shader shader;
    protected Material mat;
    
    private void Awake()
    {
      mat = new Material(shader);
    }
    
    protected virtual void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
      Graphics.Blit(src, dst, mat);
    }
  }
}
