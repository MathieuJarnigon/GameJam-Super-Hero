using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyroman_Animation : MonoBehaviour
{
    public int spriteInt = 0;
    public Sprite[] sprite;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        NextSprite();
    }

    IEnumerator NextSprite()
    {
        if (spriteInt == 4)
            spriteInt = 0;
        spriteRenderer.sprite = sprite[spriteInt];
        spriteInt++;
        yield return new WaitForSeconds(1);
    }
}
