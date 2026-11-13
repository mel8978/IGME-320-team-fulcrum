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
    TextMeshProUGUI nameLabel;
    [SerializeField]
    string[] lines;
    [SerializeField]
    float textSpeed;
    
    public bool demoOver; // for tracking demo progress

    string tag;
    bool givenCheese = false;

    [SerializeField]
    PickUpItem itemScript;
    [SerializeField]
    InventoryManager inv;

    [SerializeField]
    LayerMask npcLayer;
    [SerializeField]
    Camera playerCamera;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        demoOver = false;
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
                if (demoOver) { return; } // Don't allow dialogue if demo is over

                if (hit.collider.gameObject.tag == "Brunhilde")
                {
                    tag = "Brunhilde";
                }
                else if(hit.collider.gameObject.tag == "DragonRider")
                {
                    tag = "DragonRider";
                }
                StartDialogue();
            }
        }

    }

    void StartDialogue()
    {
        index = 0;
        textComponent.text = string.Empty;

        if (tag == "Brunhilde")
        {
            if(inv.FindItem("Cheese") && !givenCheese)
            {
                lines = new[] { "Woah, thanks for the Cheese!" };
                givenCheese = true;
                demoOver = true;
            }
            else if(givenCheese)
            {
                lines = new[] { "Thanks again for the cheese!" };
            }
            else
            {
                lines = new[] { "Hi, could you find me some cheese?", "I'll be waiting! " };
            }
            nameLabel.text = "Brunhilde";
            
        }
        else if (tag == "DragonRider")
        {
            lines = new[] { "Yo, I'm a Dragon Rider!", "Don't feel like talking to you right now! " };
            nameLabel.text = "Dragon Rider";
        }

        gameObject.SetActive(true);
        PopupMenu.openMenus++;
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
            PopupMenu.openMenus--;
            gameObject.SetActive(false);
        }
    }
}
