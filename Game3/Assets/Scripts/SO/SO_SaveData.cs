using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Save Data SO", menuName = "ScriptableObjects/Save Data Object", order = 1)]
public class SO_SaveData : ScriptableObject
{
    [Header("Change these values before FINAL BUILD!!!")]
    public bool shouldLoad = false;

    public Vector3 cubePlayerPosition;

    public SpherePose spherePose;

    public LevelLocator.currentLevel currentLevel;
}

[Serializable]
public class SpherePose
{
    public Vector3 spherePlayerPosition;

    public Vector3 spherePlayerRotation;
}

public class LevelLocator
{
    public static currentLevel currentLevelLocator;
    public enum currentLevel
    {
        Level1,Level2
    }
}
