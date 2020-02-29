using System;
using System.Collesctions.Generic;
using UnityEngine;

namespace AdvancedPlanetaryImaging
{
  // Gets texture from the camera
  public class APIModuleCamera : PartModule
  {
    MODULE
    {
      name = APIModuleCamera
      cameraId = rangerB2
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
    public String CameraTransformName = "cameraTransform";
    
    [ParserTarget("cameraId")]
    public String CameraID;
    
    [ParserTarget("fieldOfView")]
    public Int32 fov;
    
    [ParserTargetCollection("Overlays", Namesignificance = NameSignificance.Key, Key = "item")]
    public List<String> Overlays;
    
    [ParserTargetCollection("Filters", Namesignificance = NameSignificance.Key, Key = "item")]
    public List<String> Filters;
    
    [ParserTargetCollection("Effects", Namesignificance = NameSignificance.Key, Key = "item")]
    public List<String> Effects;
    
    public Transform CameraTransform;
    
    private RenderTexture PreviewRender;
    
    private RenderTexture FullResRender;
    
    private Texture2D PreviewTexture;
    
    private Texture2D FullResTexture;
    
    public virtual Texture2D ApplyFilter(string filterPath, Texture2D inputTexture)
    {
      return inputTexture;
    }
    
    public Camera GetCamera(Transform transform)
    {
      Camera camera = transform.GetComponent<Camera>();
      return camera;
    }
    // TODO: VAB Part Info
    
    
  }
}
