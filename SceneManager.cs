using System;
using Godot;

namespace MatchTheCards;

public class SceneManager
{
    public static object InstantiateScene(PackedScene scene)
    {
        return scene.Instantiate<object>();
    }
}