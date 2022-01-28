using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//un enumerado (enum) me sirve cuando tengo pocas opciones en este caso estar en juego, terminar juego y estar en el menú
public enum GameState{
    menu,
    gameOver,
    inGame
}
public class GameManager : MonoBehaviour
{
    //declaro que cuando inicia el juego empiezo en el menú
    public GameState currentState = GameState.menu;
    //para que no existan 2 managers necesito crear un static
    public static GameManager sharedInstance;

    public MakoController controller;
    void Awake()
    {
        if (sharedInstance == null){
            sharedInstance = this; //me aseguro que el primer manager que cargue sea el que mande en el juego, a prueba de errores
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       controller = GameObject.FindWithTag ("Player").
                    GetComponent<MakoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit")&& 
            currentState != GameState.inGame ){
            StartGame();
         }
    }
    //para iniciar el juego
    public void StartGame(){
        SetState(GameState.inGame);

    }
    //para acabar el juego
    public void GameOver(){
        SetState(GameState.gameOver);
    }

    //para volver al menú principal
    public void BackToMenu(){
        SetState(GameState.menu);
    }

    private void SetState(GameState newState){
        if(newState ==GameState.menu){
            //TODO: hacer el menú
        }else if(newState == GameState.inGame){
            controller.StartGame();
            //TODO: preparar para jugar
        }else if (newState == GameState.gameOver){
            //TODO: preparar para terminar partida
        }

        this.currentState= newState;


    }

}
