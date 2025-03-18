using Unity.Cinemachine;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject[] levelPrefabs;
    private GameObject currentLevel;
    private int currentIndex = 0;

    public GameObject playerPrefab;
    private GameObject currentPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        LoadLevel(currentIndex);
    }

    public void LoadNextLevel()
    {
        currentIndex++;

        if (currentIndex < levelPrefabs.Length)
        {
            Destroy(currentLevel);
            Destroy(currentPlayer);
            LoadLevel(currentIndex);
        }
        else
        {
            Debug.Log(" You Win All Levels");
        }
    }

    void LoadLevel(int index)
    {
        currentLevel = Instantiate(levelPrefabs[index], Vector3.zero, Quaternion.identity);
        Transform startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        currentPlayer = Instantiate(playerPrefab, startPoint.position, Quaternion.identity);
        GameObject vcamObj = GameObject.Find("CinemachineCamera"); 
        if (vcamObj != null)
        {
            var vcam = vcamObj.GetComponent<CinemachineCamera>();
            vcam.Follow = currentPlayer.transform;
        }
    }
}
