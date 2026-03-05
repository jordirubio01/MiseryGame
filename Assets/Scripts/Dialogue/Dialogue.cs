using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform target;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private bool hasReachedPlayer;
    private int lineIndex;
    private Rigidbody2D rb;
    private Animator animator;

    public LevelExit levelexit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isPlayerInRange)
        {
            return;
        }

        else if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.qKey.wasPressedThisFrame)
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasReachedPlayer && !isPlayerInRange)
        {
            Debug.Log(rb.linearVelocity);
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (target == null) return;

        float direction = target.position.x - transform.position.x;

        rb.linearVelocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.linearVelocity.y);

        animator.SetBool("walking", true); // Activa l'animació de caminar

        // Flip del sprite segons la direcció
        if (direction < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            if (GameManager.bucle > 1) levelexit.NextSceneName = "Choose";
            levelexit.ExitLevel();
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            hasReachedPlayer = true;
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("walking", false); // Para l'animació en arribar
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }

    public void SetDialogueLines(string[] lines)
    {
        dialogueLines = lines;
    }
}