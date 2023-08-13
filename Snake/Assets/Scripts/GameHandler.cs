using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour{
    
    private static GameHandler instance;

    private static int score;

    [SerializeField] private Snake snake;

    private LevelGrid levelGrid;
           
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
        InitializeStatic();
    }
    private void Start(){
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(20,20);

        //lets check if the snake is not null
        if(snake == null){
            Debug.LogError("Snake is null");
        }

        //lets check if the levelGrid is not null
        if(levelGrid == null){
            Debug.LogError("levelGrid is null");
        }

        snake.Setup(levelGrid); //Here I'm getting a NullReferenceException 
        // The snake and the levelGrid are both created, but the snake is not setup with the levelGrid
        levelGrid.Setup(snake);

        /*
        CodeMonkey.CMDebug.ButtonUI(Vector2Int.zero, "Reload Scene", () => {
            Loader.Load(Loader.Scene.GameScene); });
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) )
        {
            if (IsGamePaused()) {
                GameHandler.ResumeGame();
            } else
            {
                  GameHandler.PauseGame();
            }
            
  
        }
    }

    private static void InitializeStatic()
    {
        score = 0;
    }
    
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;   
    }

    public static void SnakeDied()
    {
        GameOverWindow.ShowStatic();
    }

    public static void ResumeGame() {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    
    }

    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }

}
