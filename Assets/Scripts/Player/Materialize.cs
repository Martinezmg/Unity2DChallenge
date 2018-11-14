using UnityEngine;
using TouchScript.Gestures;

public class Materialize : MonoBehaviour
{
    [SerializeField]
    private TapGesture dtap;
    [SerializeField]
    private SpriteRenderer sr;

    private void OnEnable()
    {
        dtap = GetComponent<TapGesture>();
        sr = GetComponentInChildren<SpriteRenderer>();

        dtap.Tapped += Rainbow;
    }

    private void OnDisable()
    {
        dtap.Tapped -= Rainbow;
    }

    private void Rainbow(object sender, System.EventArgs e)
    {
        Debug.Log("hice doble tap");
        sr.color = new Color(Random.value, Random.value, Random.value);
    }
}
