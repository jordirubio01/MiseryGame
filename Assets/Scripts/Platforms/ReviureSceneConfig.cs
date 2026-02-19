using UnityEngine;

public class ReviureSceneConfig : MonoBehaviour
{
    public float JumpForceMultiplier = 1.5f;

    void Start()
    {
        GameObject paul = GameObject.Find("Paul");
        if (paul != null)
        {
            PaulMovement paulMovement = paul.GetComponent<PaulMovement>();
            if (paulMovement != null)
            {
                paulMovement.JumpForce *= JumpForceMultiplier;
                Debug.Log($"Reviure: Jump force increased to {paulMovement.JumpForce}");
            }
        }
    }
}
