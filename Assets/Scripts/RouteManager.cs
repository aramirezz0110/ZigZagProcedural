using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public static RouteManager Instance;

    [SerializeField] private GameObject routeBlockPrefab;
    [SerializeField] private float instantiateRate=.5f;
    public float differenceBetweenBlocks = 0.7071068f;
    public Transform lastRouteBlock;
    [SerializeField] private List<GameObject> routeBlocks = new List<GameObject>();
    
    private Vector3 lastPosition;
    private int routeBlockCounter = 0;    
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        lastPosition = lastRouteBlock.position;      
    }    
    public void CreateNewRoutePart()
    {        
        Vector3 newPosition = Vector3.zero;
        float option = Random.Range(0,100);
        if (option <= 50)
        {
            newPosition = new Vector3(lastPosition.x + differenceBetweenBlocks,lastPosition.y, lastPosition.z+differenceBetweenBlocks);
        }
        else if(option>50)
        {
            newPosition = new Vector3(lastPosition.x - differenceBetweenBlocks, lastPosition.y, lastPosition.z + differenceBetweenBlocks);
        }
        GameObject tempInstance = Instantiate(routeBlockPrefab, newPosition, Quaternion.Euler(0, 45, 0));
        lastPosition = tempInstance.transform.position;
        tempInstance.transform.parent = this.gameObject.transform;
        routeBlocks.Add(tempInstance);
        routeBlockCounter++;
        if (routeBlockCounter % 5 == 0)
        {
            tempInstance.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (routeBlockCounter == 5)
        {
            InvokeRepeating("DestroyUnusedRouteBlocks", 1f, instantiateRate);
        }
    }
    public void StartRouteConstruction()
    {
        InvokeRepeating("CreateNewRoutePart", 1f, instantiateRate);
    }
    private void DestroyUnusedRouteBlocks()
    {
        GameObject tempReference = routeBlocks[0];        
        routeBlocks.RemoveAt(0);
        Destroy(tempReference);

    }
}
