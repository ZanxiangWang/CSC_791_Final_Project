using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public SpriteShapeController Track;
    public int scale = 1000;
    public int octave = 175;

    // Start is called before the first frame update
    void Start()
    {
        float interval = (float)scale / (float)octave;
        Track = GetComponent<SpriteShapeController>();

        Track.spline.SetPosition(2, Track.spline.GetPosition(2) + Vector3.right * scale);
        Track.spline.SetPosition(3, Track.spline.GetPosition(3) + Vector3.right * scale);
        Track.spline.SetPosition(3, Track.spline.GetPosition(3) + Vector3.down * 10);
        Track.spline.SetPosition(0, Track.spline.GetPosition(0) + Vector3.down * 10);
        
        for (int i = 0; i < octave; i++)
        {
            float noise = Mathf.PerlinNoise(i * Random.Range(5f, 20f), 0);
            float currentPos = Track.spline.GetPosition(i + 1).x + interval;
            Track.spline.InsertPointAt(i + 2, new Vector3(currentPos, noise * 15));
            Track.spline.SetTangentMode(i + 2, ShapeTangentMode.Continuous);
            Track.spline.SetLeftTangent(i + 2, new Vector3(Random.Range(-1, -2), 0, 0));
            Track.spline.SetRightTangent(i + 2, new Vector3(Random.Range(1, 2), 0, 0));
        }
    }
}
