using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner cubeSpawner;
    [SerializeField]
    private GameController gameController;

    private CubeController[] touchCubes;   // 터치 가능한 큐브셋의 큐브들

    private int correctCount = 0;
    private int incorrectCount = 0;

    public int CorrectCount
    {
        set => correctCount = Mathf.Max(0, value);
        get => correctCount;
    }
    public int IncorrectCount
    {
        set => incorrectCount = Mathf.Max(0, value);
        get => incorrectCount;
    }

    private void Awake()
    {
        touchCubes = GetComponentsInChildren<CubeController>();
        for (int i = 0; i < touchCubes.Length; ++ i)
        {
            touchCubes[i].Setup(cubeSpawner, this);
        }
    }

    private void Update()
    {
        // 현재 상태가 게임오버이면 점수 검사를 하지 않는다
        if (gameController.IsGameOver == true) return;

        // 맞은 개수 + 틀린 개수가 터치 가능한 큐브의 개수와 같을 때
        if (CorrectCount + IncorrectCount == touchCubes.Length)
        {
            // 하나도 틀리지 않았을 때 : 성공
            if (IncorrectCount == 0)
            {
                // Debug.Log("Success");
                gameController.IncreaseScore();
            }
            // 하나라도 틀렸을 때 : 실패
            else
            {
                // Debug.Log("Failed");
                gameController.GameOver();
            }

            CorrectCount = 0;
            IncorrectCount = 0;
        }
    }
}
