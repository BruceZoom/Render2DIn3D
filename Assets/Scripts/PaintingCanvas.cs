using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PaintingCanvas : MonoBehaviour
{
    [SerializeField] private string _cameraID = "2DCamera";
    private MeshRenderer _meshRenderer;
    private MaterialPropertyBlock _mpb;
    
    static readonly int BaseMapId = Shader.PropertyToID("_BaseMap"); // URP
    static readonly int MainTexId = Shader.PropertyToID("_MainTex"); // Built-in

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _mpb = new MaterialPropertyBlock();
    }

    private void OnEnable()
    {
        PaintingCamera.OnPaintingCameraBind += HandleCameraBind;
        PaintingCamera.OnPaintingCameraUnbind += HandleCameraUnbind;
    }

    private void OnDisable()
    {
        PaintingCamera.OnPaintingCameraBind -= HandleCameraBind;
        PaintingCamera.OnPaintingCameraUnbind -= HandleCameraUnbind;
    }

    private void HandleCameraBind(PaintingCameraData data)
    {
        _meshRenderer.GetPropertyBlock(_mpb);
        _mpb.SetTexture(BaseMapId, data.RenderTexture);
        _mpb.SetTexture(MainTexId, data.RenderTexture);
        _meshRenderer.SetPropertyBlock(_mpb);
    }

    private void HandleCameraUnbind(PaintingCameraData data)
    {
        
    }
}