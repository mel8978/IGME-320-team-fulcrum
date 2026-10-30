using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textComponent;
    [SerializeField]
    string[] lines;
    [SerializeField]
    float textSpeed;

    [SerializeField]
    PickUpItem itemScript;
    private bool givenCheese = false;

    [SerializeField]
    LayerMask npcLayer;
    [SerializeField]
    Camera playerCamera;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void PressDialogue(InputAction.CallbackContext context)
    {
        Ray raycast = playerCamera.ScreenPointToRay(Mouse.current.position.value);
        RaycastHit hit;

        if (context.performed && Physics.Raycast(raycast, out hit, 20, npcLayer))
        {
            if(gameObject.activeSelf)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
            else
            {
                StartDialogue();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        textComponent.text = string.Empty;

        if(itemScript.inventory.Count == 0 && !givenCheese)
        {
            lines = new[] { "Hi, could you find me some cheese?", "I'll be waiting! "};
        }
        else if (givenCheese)
        {
            lines = new[] { "That cheese was delicious! " };
        }
        else
        {
            lines = new[] { "Thanks so much!" };
            givenCheese = true;
        }
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
