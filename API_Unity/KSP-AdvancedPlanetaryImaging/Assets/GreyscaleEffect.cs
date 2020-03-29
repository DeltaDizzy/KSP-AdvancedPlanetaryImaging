﻿using System.Collections;
using UnityEngine;

namespace AdvancedPlanetaryImaging
{
    [ExecuteInEditMode]
    public class GreyscaleEffect : MonoBehaviour
    {
        public float intensity;
        private Material material;
        
        void Awake()
        {
            material = new Material(Shader.Find("KSPAPI/Greyscale"));
        }
        
        // Process Image
        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (intensity == 0)
            {
            Graphics.Blit(source, destination);
            return;
            }
            material.SetFloat("_bwBlend", intensity);
            Graphics.Blit(source, destination, material);
        }
    }
}