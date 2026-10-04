# Render2DIn3D

在 3D 场景中把一个 2D 场景的画面实时渲染到平面上（类似“会动的画”）。

## 环境

- Unity **6000.5.10f1**（Unity 6.5）
- Universal Render Pipeline 17.5.0（打开项目时由 Package Manager 自动安装）

## 运行

1. 克隆仓库，用 Unity Hub 选择 *Add project from disk* 打开该目录。
2. 打开 `Assets/Scenes/3DScene.unity`，点击 Play。
   - `SceneBootstrap` 会在运行时自动以 Additive 方式加载 `2DScene`，无需手动同时打开两个场景。

## 原理

| 文件 | 作用 |
| --- | --- |
| `Assets/Scripts/PaintingCamera.cs` | 挂在 2D 场景的相机上，创建 RenderTexture 作为相机输出，并通过静态事件广播。 |
| `Assets/Scripts/PaintingCanvas.cs` | 挂在 3D 场景的平面（MeshRenderer）上，收到事件后用 MaterialPropertyBlock 把 RenderTexture 设到 `_BaseMap` / `_MainTex`。 |
| `Assets/Scripts/SceneBootstrap.cs` | 进入 Play 时若当前是 `3DScene`，自动叠加加载 `2DScene`。 |

2D 场景相机使用 `2D_Renderer`（PC_RPAsset 中的 renderer index 1），3D 场景使用 `PC_Renderer`。

## 素材

`Assets/Kenny Retro-Medieval` 来自 [Kenney](https://kenney.nl)（CC0）。
