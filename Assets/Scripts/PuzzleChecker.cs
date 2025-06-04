using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleChecker : MonoBehaviour
{
    public Transform slotContainer;
    public string correctWord = "EXAMPLE";

    public void CheckWord()
    {
        if (!AllSlotsFilled())
        {
            Debug.Log("Not all slots are filled.");
            return;
        }

        string currentWord = "";

        for (int i = 0; i < slotContainer.childCount; i++)
        {
            Transform slot = slotContainer.GetChild(i);

            if (slot.childCount > 0)
            {
                DraggableLetter draggable = slot.GetChild(0).GetComponent<DraggableLetter>();
                if (draggable != null)
                {
                    currentWord += draggable.letter;
                }
            }
        }

        Debug.Log("Player assembled word: " + currentWord);

        if (currentWord == correctWord)
        {
            Debug.Log("Correct! Loading next scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        else
        {
            Debug.Log("Incorrect word.");
        }
    }

    private bool AllSlotsFilled()
    {

        for (int i = 0; i < slotContainer.childCount; i++)
        {
            if (slotContainer.GetChild(i).childCount == 0)
                return false;
        }
        return true;
    }
}
