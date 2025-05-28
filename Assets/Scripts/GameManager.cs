using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public string correctWord = "EXAMPLE";
    public string collectedWord = "PLEMAXE"; // this will be updated in level 1
    public TextMeshProUGUI[] letterSlots; // Assign in Inspector

    private HashSet<int> revealedIndices = new HashSet<int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps it between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Optional: clear the slots initially
        foreach (var slot in letterSlots)
        {
            slot.text = "_";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CollectLetter(char collected)
    {
        collected = char.ToUpper(collected);

        for (int i = 0; i < collectedWord.Length; i++)
        {
            if (collectedWord[i] == collected && !revealedIndices.Contains(i))
            {
                letterSlots[i].text = collected.ToString();
                revealedIndices.Add(i);
                break;
            }
        }
        //  Check if all letters are revealed
        if (revealedIndices.Count == collectedWord.Length)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Make sure the next scene exists in Build Settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Load the main menu scene by name
            SceneManager.LoadScene("MenuScene");
        }
    }
}

