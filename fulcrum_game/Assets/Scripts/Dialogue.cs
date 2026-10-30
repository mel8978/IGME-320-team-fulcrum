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
    LayerMask npcLayer;
    [SerializeField]
    Camera playerCamera;

    private int index;
    private bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
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
            active = false;
        }
    }
}
