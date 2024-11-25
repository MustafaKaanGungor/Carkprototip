using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSc : MonoBehaviour
{
    //Borderlar silmiyor :/ ona bakýlcak , örnek sorular json formatýnda eklendi (2 tane)   
    [SerializeField] private Transform GridSpawnPos;
    [SerializeField] private float GridSpeed;
    [SerializeField] public GameObject[] classes;
    [SerializeField] private Transform platformWidth;
    private List<GameObject> platforms = new List<GameObject>();
    private bool isGrid = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RollWhell();
    }
    private void RollWhell()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrid)
            {
                SlideGrid();
            }
            isGrid = true;
            GameObject newPlatform = Instantiate(classes[Random.Range(0,classes.Length)],GridSpawnPos.position,Quaternion.identity);
            platforms.Add(newPlatform);
        }
    }
     public   void SlideGrid()
    {
        
        Debug.Log("Slided");
        for (int i = 0; i < platforms.Count; i++) {
            platforms[i].transform.Translate(Vector3.left * platformWidth.localScale.x);
        }
    }

}
