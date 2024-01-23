using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class JsonMapBuilder : MonoBehaviour
{
    [SerializeField]
    private TextAsset mapJson;

    [SerializeField] private GameObject basePlane;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject softWall;
    [SerializeField] private GameObject entrance;
    [SerializeField] private GameObject barrier;

    private GameObject basePlaneRealObject;

    public GameObject GetBasePlaneObject() { return basePlaneRealObject; }

    private class MapList
    {
        public List<List<int>> map;
        public List<string> mapping;

    }

    private MapList mapList = new MapList();

    private int xSize;
    private int ySize;

    private List<string> doorSideAllowed = new List<string>()
    {
        "wall"
    };
    private List<string> windowSideAllowed = new List<string>()
    {
        "window",
        "wall"
    };

    private List<string> signAllowFacing = new List<string>()
    {
        "barrier",
    };

    


    // Start is called before the first frame update
    void Start()
    {
        mapList = JsonConvert.DeserializeObject<MapList>(mapJson.ToString());

        ySize = mapList.map.Count;
        xSize = mapList.map[0].Count;

        BuildMap();
    }

    public string GetMapObjectFromMap(int x, int y)
    {
        if (x >= this.xSize || x < 0 || y >= this.ySize || y < 0)
        {
            return null;
        }
        else
        {
            // Debug.Log(mapList.mapping[mapList.map[y][x]]);
            return mapList.mapping[mapList.map[y][x]];
        }
        
    }

    void BuildMap()
    {
        GameObject baseObject = Instantiate(basePlane, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        baseObject.GetComponent<BaseSizeModifier>().SetBaseSize(xSize, ySize);
        basePlaneRealObject = baseObject;

        for (int yIndex = 0; yIndex < ySize; yIndex++) 
        {
            for (int xIndex = 0; xIndex < xSize; xIndex++) 
            {
                // Debug.Log($"x: {xIndex}, y: {yIndex}");
                if (GetMapObjectFromMap(xIndex, yIndex) == "wall")
                {
                    Instantiate(wall, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "door")
                {
                    CreateDoor(xIndex, yIndex);
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "window")
                {
                    CreateWindow(xIndex, yIndex);              
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "softWall")
                {
                    Instantiate(softWall, new Vector3(yIndex, 0, xIndex), Quaternion.Euler(0, Random.Range(0, 360), 0), gameObject.transform);
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "entrance")
                {
                    CreateEntrance(xIndex, yIndex);
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "barrier")
                {
                    Instantiate(barrier, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                }

            }
        }
    }

    void CreateWindow(int xIndex, int yIndex)
    {
        ExtendDirection.ExtendDirectionEnum extendDirectionEnum;
        if (windowSideAllowed.Contains(GetMapObjectFromMap(xIndex-1, yIndex))
            && windowSideAllowed.Contains(GetMapObjectFromMap(xIndex + 1, yIndex)))
        {
            extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.XDirection;
        }
        else if (windowSideAllowed.Contains(GetMapObjectFromMap(xIndex, yIndex-1))
            && windowSideAllowed.Contains(GetMapObjectFromMap(xIndex, yIndex + 1)))
        {
            extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.YDirection;
        }
        else
        {
            extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.Null;
        }

        
        GameObject windowObject = Instantiate(window, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
        windowObject.GetComponent<ExtendDirection>().SetExtendDirectionEnum(extendDirectionEnum);
    }

    void CreateDoor(int xIndex, int yIndex)
    {
        ExtendDirection.ExtendDirectionEnum extendDirectionEnum;
        if (doorSideAllowed.Contains(GetMapObjectFromMap(xIndex-1, yIndex))
            && doorSideAllowed.Contains(GetMapObjectFromMap(xIndex + 1, yIndex)))
        {
            extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.XDirection;
        }
        else if (doorSideAllowed.Contains(GetMapObjectFromMap(xIndex, yIndex-1))
            && doorSideAllowed.Contains(GetMapObjectFromMap(xIndex, yIndex + 1)))
        {
            extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.YDirection;
        }
        else
        {
            extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.Null;
        }

        
        GameObject doorObject = Instantiate(door, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
        doorObject.GetComponent<ExtendDirection>().SetExtendDirectionEnum(extendDirectionEnum);

    }
    void CreateEntrance(int xIndex, int yIndex)
    {
        List<SignRandomer.Direction> allowedDirections = new List<SignRandomer.Direction>();
        int lenAllowDirections = 0, count = 1;
        while (lenAllowDirections != 0 && xIndex + count >= xSize && xIndex - count < 0 && yIndex + count >= ySize && yIndex - count < 0)
        {
            if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex + count, yIndex)))
            {
                allowedDirections.Add(SignRandomer.Direction.PositiveX);
            }

            if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex - count, yIndex)))
            {
                allowedDirections.Add(SignRandomer.Direction.NegativeX);
            }

            if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex, yIndex + count)))
            {
                allowedDirections.Add(SignRandomer.Direction.PositiveY);
            }

            if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex, yIndex - count)))
            {
                allowedDirections.Add(SignRandomer.Direction.NegativeY);
            }
            lenAllowDirections = allowedDirections.Count;
        }

        GameObject entranceObject = Instantiate(entrance, new Vector3(yIndex, 0, xIndex), Quaternion.Euler(0, Random.Range(0, 360), 0), gameObject.transform);
        if (lenAllowDirections != 0)
            entranceObject.GetComponent<SignRandomer>().SetRotation(allowedDirections.ElementAt(Random.Range(0, lenAllowDirections)));
    }
}
