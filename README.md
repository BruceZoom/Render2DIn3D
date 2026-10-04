# Render2DIn3D

Renders a live 2D scene onto a plane inside a 3D scene (like a moving painting on a wall).

## Requirements

- Unity **6000.5.10f1** (Unity 6.5)
- Universal Render Pipeline 17.5.0 (installed automatically by the Package Manager when the project is opened)

## Running

1. Clone the repository and open the folder in Unity Hub via *Add project from disk*.
2. Open `Assets/Scenes/3DScene.unity` and press Play.
   - `SceneBootstrap` loads `2DScene` additively at runtime, so there is no need to open both scenes manually.

## How it works

| File | Purpose |
| --- | --- |
| `Assets/Scripts/PaintingCamera.cs` | Attached to the camera in the 2D scene. Creates a RenderTexture as the camera's target and broadcasts it through a static event. |
| `Assets/Scripts/PaintingCanvas.cs` | Attached to the plane (MeshRenderer) in the 3D scene. On the event, assigns the RenderTexture to `_BaseMap` / `_MainTex` via a MaterialPropertyBlock. |
| `Assets/Scripts/SceneBootstrap.cs` | When entering Play Mode with `3DScene` active, loads `2DScene` additively. |

The 2D scene camera uses `2D_Renderer` (renderer index 1 in `PC_RPAsset`); the 3D scene uses `PC_Renderer`.

## Assets

`Assets/Kenny Retro-Medieval` is from [Kenney](https://kenney.nl) (CC0).
