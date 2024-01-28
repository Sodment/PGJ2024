using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadScroller : MonoBehaviour
{

    public List<GameObject> roadGameObjects;
    public List<GameObject> newSegments;
    public List<GameObject> builtSegments;
    public List<GameObject> oldSegments;
    public float roadSegmentDistance;
    public uint generatedSegments = 0;
    public GameObject Player;
    public float GetAligmentDistance(GameObject obj1, GameObject obj2)
    {
        Bounds bounds1 = obj1.transform.GetChild(0).GetComponent<Renderer>().bounds;
        Bounds bounds2 = obj2.transform.GetChild(0).GetComponent<Renderer>().bounds;

        float adjustDistance = bounds1.extents.z + bounds2.extents.z;
        return adjustDistance;
    }

    public GameObject GetRandomRoadGO()
    {
        int index = Random.Range(0, roadGameObjects.Count);
        return roadGameObjects[index];
    }

    public void GenerateRoadSegment()
    {
        List<GameObject> segment = new List<GameObject>();
        float currentSegmentDistance = 0.0f;
        while(currentSegmentDistance < roadSegmentDistance)
        {
            GameObject go = GetRandomRoadGO();
            float goLength = go.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
            currentSegmentDistance += goLength;
            segment.Add(go);
        }
        newSegments = segment;
        ++generatedSegments;
    }

    public List<GameObject> BuildSegment(List<GameObject> segment,float startPoint)
    {
        Debug.Log(startPoint);

        List<GameObject> builtSegment = new List<GameObject>
        {
            Instantiate(segment.First(), new Vector3(0, 0, startPoint), Quaternion.identity)
        };
        float accumulatedDistance = startPoint;
        for(int i = 1; i < segment.Count; i++)
        {
            float aligmentDistance = GetAligmentDistance(segment[i - 1], segment[i]);
            builtSegment.Add(Instantiate(segment[i], new Vector3(0,0, accumulatedDistance + aligmentDistance), Quaternion.identity));
            accumulatedDistance += aligmentDistance;
        }
        List<GameObject> oldRoad = builtSegments;
        builtSegments = builtSegment;
        return oldRoad;
    }

    public float GetSegmentsConnectionPoint(List<GameObject> firstSegment, List<GameObject> secondSegment)
    {
        float aligmentDistance = GetAligmentDistance(firstSegment.Last(), secondSegment.First());
        return firstSegment.Last().transform.position.z + aligmentDistance;
    }

    void Start()
    {
        GenerateRoadSegment();
        BuildSegment(newSegments, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z >= ((generatedSegments - 1) * roadSegmentDistance) + (roadSegmentDistance / 2.0f))
        { 
            GenerateRoadSegment();
            oldSegments = BuildSegment(newSegments, GetSegmentsConnectionPoint(builtSegments, newSegments));
        }
    }
}
