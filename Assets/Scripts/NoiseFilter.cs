using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter{

    Noise noise = new Noise();
    NoiseSettings noiseSettings;

    public NoiseFilter(NoiseSettings noiseSettings) {
        this.noiseSettings = noiseSettings;
    }
    public float Evaluate(Vector3 point) { 

        float noiseValue = (noise.Evaluate(point * noiseSettings.roughness + noiseSettings.centre)+1)*.5f;
        return noiseValue*noiseSettings.strength;

    }
}