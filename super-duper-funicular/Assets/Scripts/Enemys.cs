using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemys : MonoBehaviour
{

    Health hp;
    [SerializeField] TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "" + hp.health + "/" + hp.maxHealth;
        transform.Translate(Vector2.left / 25);
    }

    private void Awake()
    {
        hp = GetComponent<Health>();
    }
}
