using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PaintingCamera : MonoBehaviour
{
    public static event Action<PaintingCameraData> OnPaintingCameraBind;
    public static event Action<PaintingCameraData> OnPaintingCameraUnbind;
    
    [SerializeField] private string _cameraID = "2DCamera";
    [SerializeField] private Vector2Int _textureSize = new Vector2Int(960, 540);
    private PaintingCameraData _data;

    void Start() => BindCamera();

    private void OnDestroy() => UnbindCamera();

    private void BindCamera()
    {
        var camera = GetComponent<Camera>();
        var rt = new RenderTexture(_textureSize.x, _textureSize.y, 24, RenderTextureFormat.ARGB32)
        {
            name = $"RT_{name}",
            filterMode = FilterMode.Bilinear,
            wrapMode = TextureWrapMode.Clamp,
            useMipMap = false,
            antiAliasing = 1,
        };
        rt.Create();
        
        var aspect = _textureSize.x / _textureSize.y;
        camera.targetTexture = rt;
        camera.aspect = aspect;

        _data = new PaintingCameraData
        {
            ID = _cameraID,
            Camera = camera,
            RenderTexture = rt,
        };
        OnPaintingCameraBind?.Invoke(_data);
    }
    
    private void UnbindCamera()
    {
        OnPaintingCameraUnbind?.Invoke(_data);
        
        if (_data.Camera && _data.Camera.targetTexture == _data.RenderTexture)
            _data.Camera.targetTexture = null;

        if (_data.RenderTexture)
        {
            _data.RenderTexture.Release();
            Destroy(_data.RenderTexture);
            _data.RenderTexture = null;
        }
    }
}

public class PaintingCameraData
{
    public string ID;
    public Camera Camera;
    public RenderTexture RenderTexture;
}