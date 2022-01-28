using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstace;

    public List<LevelBlock> allPlattformBlocks = new List<LevelBlock>();
    public List<LevelBlock> currentNumberPlattformBlocks = new List<LevelBlock>();

    public Transform levelStartPosition;
    void Awake(){
        if(sharedInstace==null){
            sharedInstace=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        FirstPlattforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlattforms(){

    }
    public void RemovePlattforms(){
        
    }
    //si se muere elimina todas las plataformas
    public void RemoveAllPlattforms(){
        
    }
    public void FirstPlattforms(){
        for(int i=0; i<2; i++){
            AddPlattforms();
        }
    }
}
