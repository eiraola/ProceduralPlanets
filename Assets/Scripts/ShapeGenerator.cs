using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator 
{

    ShapeSettings settings;

    public ShapeGenerator(ShapeSettings sett) {
        settings = sett;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere) {

        return pointOnUnitSphere * settings.planetRadius;
    }
}
