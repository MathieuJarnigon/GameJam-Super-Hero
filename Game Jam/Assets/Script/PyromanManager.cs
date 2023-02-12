using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyroman_Animation : MonoBehaviour
{
    public int spriteInt = 1;

    GameObject new_prefab;
    GameObject new_prefab_gameObject;
    GameObject prefab;

    public Sprite[] sprite;
    public Sprite[] spriteFlemme;

    public int spriteCount = 0;
    public int pointIndex = 0;

    public GameObject[] point;
    public GameObject fire;
    public GameObject fire_place;

    public int speed;

    bool cooldown = false;
    int creat = 0;

    [SerializeField] private AudioSource fireSound;

    GameObject prefab_gameObject;
    SpriteRenderer spriteRenderer;

    GameObject RandomPoint;
    [SerializeField] private SpriteRenderer spriteRendererFlemme;
    [SerializeField] private SpriteRenderer spriteRendererFire;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRendererFlemme = GetComponent<SpriteRenderer>();
        spriteRendererFire = GetComponent<SpriteRenderer>();
        fireSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (spriteInt <= 5)
        {
            if (cooldown == false)
            {
                cooldown = true;
                spriteInt++;
                StartCoroutine(NextSprite());
            }
        }
        if (spriteInt >= 5)
        {
            if (creat == 0)
                CreatFire();
            if (RandomPoint.tag != "Fire")
                Fire();
            else
            {
                Destroy(prefab_gameObject);
                Destroy(prefab);
                creat = 0;
            }
        }
    }

    IEnumerator NextSprite()
    {
        yield return new WaitForSeconds(2);
        spriteRenderer.sprite = sprite[spriteInt];
        cooldown = false;
    }

    private void CreatFire()
    {
        prefab = new GameObject("Empty GameObject");
        RandomPoint = point[Random.Range(0, pointIndex)];
        prefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        prefab.transform.parent = transform;
        prefab_gameObject = Instantiate(
            fire,
            new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
            Quaternion.identity,
            transform
        );
        if (RandomPoint.name == "0" || RandomPoint.name == "3")
            prefab_gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        if (RandomPoint.name == "2")
            prefab_gameObject.transform.Rotate(0.0f, 0.0f, 145.0f);
        if (RandomPoint.name == "1")
            prefab_gameObject.transform.Rotate(0.0f, 0.0f, 15.0f);
        if (RandomPoint.name == "4")
            prefab_gameObject.transform.Rotate(0.0f, 0.0f, 45.0f);
        if (RandomPoint.name == "5")
            prefab_gameObject.transform.Rotate(0.0f, 0.0f, 120.0f);
        prefab_gameObject.name = "Fire Prefab";
        fireSound.Play();
        creat++;
    }

    private void Fire()
    {
        if (prefab_gameObject.transform.position == RandomPoint.transform.position)
        {
            Destroy(prefab_gameObject);
            Destroy(prefab);
            spriteInt = 0;
            cooldown = false;
            creat = 0;
        }
        else
        {
            prefab_gameObject.transform.position = Vector3.MoveTowards(prefab_gameObject.transform.position, RandomPoint.transform.position, speed * Time.deltaTime);
            if (prefab_gameObject.transform.position == RandomPoint.transform.position)
            {
                Instantiate(fire_place, RandomPoint.transform.position, Quaternion.identity);
                Destroy(prefab_gameObject);
                Destroy(prefab);
                spriteCount = 0;
                spriteInt = 0;
                creat = 0;
            }
        }
    }
}
