﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    public float strength = 1;
    [Range(1,8)]
    public int numLayers = 1;
    public float baseRoughness = 1;
    public float roughness = 1;
    public Vector3 centre;
    public float persistence = .5f;
    public float minValue = 0;
}
