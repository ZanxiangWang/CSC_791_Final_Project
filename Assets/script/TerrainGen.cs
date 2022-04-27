using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    //this makes the track game object applyable to the TerrainGen script
    public SpriteShapeController Track;
    //the scale of the terrain
    public int scale = 1000;
    //number of index added between index 0 and 1 from the sprite shape
    public int octave = 175;

    //a game object that is the image of a gas tank
    public GameObject gasTank;

    // Start is called before the first frame update
    void Start()
    {
        //the distance between the 175 points evenly spread across the sprite
        float interval = (float)scale / (float)octave;
        //allow editing of the sprite shape
        Track = GetComponent<SpriteShapeController>();
        /*expanding the sprite shape without distorting its image
        index 1 ->  o-------------o  <-index 2
                    |             |
        index 0 ->  o-------------o  <-index 3 */
        /*moving index 2 to the right by scale 1000
          moving index 3 to the right by scale 1000
          this two lines extends the length of the sprite shape*/
        Track.spline.SetPosition(2, Track.spline.GetPosition(2) + Vector3.right * scale);
        Track.spline.SetPosition(3, Track.spline.GetPosition(3) + Vector3.right * scale);
        /*moving index 0 down by scale 10
          moving index 3 down by scale 10
          this two lines extends the width of the sprite shape*/
        Track.spline.SetPosition(3, Track.spline.GetPosition(3) + Vector3.down * 10);
        Track.spline.SetPosition(0, Track.spline.GetPosition(0) + Vector3.down * 10);
        // a for loop that adds the 175 index with the random value from the perlin noise one by one
        for (int i = 0; i < octave; i++)
        {
            //getting the noise value
            float noise = Mathf.PerlinNoise(i * Random.Range(5f, 20f), 0);
            //getting the position of the next index being added
            float currentPos = Track.spline.GetPosition(i + 1).x + interval;
            /* inserting the index at said position with the noise scaling up to 15
               this makes the generated track more hilly otherwise the course would
               be too flat and boring*/
            Track.spline.InsertPointAt(i + 2, new Vector3(currentPos, noise * 15));
            //this line makes sure the tangent mode is continuous and not line or break mode
            Track.spline.SetTangentMode(i + 2, ShapeTangentMode.Continuous);
            /* left tangent-------------o-----------right tangent
               these two line of code manipulate the left and right tangent of the newly added index
               the higher value on (x, 0, 0) left tangent or lower value on (-x, 0, 0) right tangent
               makes the edge of the hill smoother, the lower of the value makes it sharper*/
            Track.spline.SetLeftTangent(i + 2, new Vector3(Random.Range(-1, -3), 0, 0));
            Track.spline.SetRightTangent(i + 2, new Vector3(Random.Range(1, 3), 0, 0));
        }
    }
}
