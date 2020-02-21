using System;
using System.Collesctions.Generic;
using UnityEngine;

namespace AdvancedPlanetaryImaging
{
  public class APIModuleCamera : PartModule
  {
    MODULE
    {
      name = APIModuleCamera
      cameraTransform = camera
      fieldOfView = degrees
      Overlays
      {
        item = crt_360
        item = guide_ranger
      }
      Filters
      {
        item = static_01
      }
      Effects
      {
        item = greyscale
      }
    }
    
    [ParserTarget("cameraTransform")]
    public String cameraTransformName = "cameraTransform";
    
    [ParserTarget("fieldOfView")]
    public Int32 fov;
    
    [ParserTargetCollection("Overlays", Namesignificance = NameSignificance.Key, Key = "item")]
    public List<String> overlays;
    
    [ParserTargetCollection("Filters", Namesignificance = NameSignificance.Key, Key = "item")]
    public List<String> filters;
    
    [ParserTargetCollection("Effects", Namesignificance = NameSignificance.Key, Key = "item")]
    public List<String> effects;
    
    public Transform CameraTransform;
    
    private RenderTexture previewRender;
    
    private RenderTexture fullResRender;
    
    private Texture2D previewTexture;
    
    private Texture2D fullResTexture;
    
    public virtual Texture2D ApplyFilter(string filterPath, Texture2D inputTexture)
    {
      return inputTexture;
    }
    
    // TODO: VAB Part Info
  }
}
