using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSc : MonoBehaviour
{
    //Borderlar silmiyor :/ ona bak�lcak , �rnek sorular json format�nda eklendi (2 tane)   
    [SerializeField] private Transform GridSpawnPos;
    [SerializeField] private float GridSpeed;
    [SerializeField] public GameObject[] classes;
    [SerializeField] private Transform platformWidth;
    private List<GameObject> platforms = new List<GameObject>();
    private bool isGrid = false;
    void Start()
    {
        for(int i = 0; i < 10; i++) {
            RollWhell();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            RollWhell();
        }
    }
    private void RollWhell()
    {
        
            if (isGrid)
            {
                SlideGrid();
            }
            isGrid = true;
            GameObject newPlatform = Instantiate(classes[Random.Range(0,classes.Length)],GridSpawnPos.position,Quaternion.identity);
            platforms.Add(newPlatform);
        
    }
     public   void SlideGrid()
    {
        
        Debug.Log("Slided");
        for (int i = 0; i < platforms.Count; i++) {
            //platforms[i].transform.Translate(Vector3.left * platformWidth.localScale.x);
            platforms[i].transform.position += Vector3.left * platformWidth.localScale.x;

            if(platforms[i].transform.position.x < -5) {
                Destroy(platforms[i].gameObject);
                platforms.RemoveAt(i);
            }
        }
    }

}
