using System;
using System.Threading;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "이상한 던전";
    private PlayerCharacter _player;

    public void Run()
    {
        Init();

        // 1. 오프닝 실행 (모든 연출은 클래스 내부에서 완결)
        OpeningScene opening = new OpeningScene();
        opening.Play();

        // 2. 오프닝 종료 후 본 게임 로직 시작
        Console.Clear();
        Console.WriteLine("🐣🐥🐤 Now Loading... 🐣🐥🐤");
        Thread.Sleep(1000);

        while (!IsGameOver)
        {
            // 렌더링
            Console.Clear();
            SceneManager.Render();
            // 키입력 받고
            InputManager.GetUserInput();

            if (InputManager.GetKey(ConsoleKey.L))
            {
                SceneManager.Change("Log");
            }

            // 데이터 처리
            SceneManager.Update();
        }
    }

    private void Init()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        _player = new PlayerCharacter();
        
        SceneManager.AddScene("Title", new TitleScene());
        SceneManager.AddScene("Story", new StoryScene());
        SceneManager.AddScene("Town", new TownScene(_player));
        SceneManager.AddScene("Log", new LogScene());
        
        SceneManager.Change("Title");
        
        Debug.Log("게임 데이터 초기화 완료");
    }
}