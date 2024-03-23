using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class SetCameraSystem : IEcsInitSystem
{
    private EcsFilter<UpdateCameraEvent> _filter;
    private SceneData _sceneData;
    private Configuration _configuration;
    public void Init()
    {
        if (!_filter.IsEmpty())
        {
            var height = _configuration.LevelHeight;
            var width = _configuration.LevelWidth;

            var camera = _sceneData.Camera;
            camera.orthographic = true;
            camera.orthographicSize = height / 2f + (height - 1) * _configuration.Offset.y / 2;
            _sceneData.CameraTransform.position = new Vector3(width / 2f + (width - 1) * _configuration.Offset.x / 2, height / 2f + (height - 1) * _configuration.Offset.y / 2, 0);
        }
    }
}
