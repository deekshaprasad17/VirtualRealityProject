using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public GameObject character;
    public Text textComponent;

    private RectTransform bubbleRectTransform;

    void Start()
    {
        // Get the RectTransform of the speech bubble
        bubbleRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Position the speech bubble above the character
        Vector3 characterPosition = character.transform.position;
        Vector3 bubblePosition = new Vector3(characterPosition.x, characterPosition.y + 2f, characterPosition.z);
        bubbleRectTransform.position = Camera.main.WorldToScreenPoint(bubblePosition);
    }

    // Function to update the text displayed in the speech bubble
    public void UpdateText(string newText)
    {
        textComponent.text = newText;
    }
}