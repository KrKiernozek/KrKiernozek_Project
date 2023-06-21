using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public int bulletdamage;
    public float bulletSpeed;

    [SerializeField] private bool isMoving=false;

    public void SetValues(Transform enemy, int damage)
    {
        target = enemy;
        bulletdamage = damage;
    }
    private void Update()
    {
        if (target !=null)
        {
            if(!isMoving)Move();
        }
        else
        {
            DieAction();
        }
    }

    private void Move()
    {
        isMoving = true;
        transform.DOMove(target.transform.position,1f/bulletSpeed,snapping:false).OnComplete(DieAction);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(typeof(Enemy)) != null)
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(bulletdamage);
            GameManager.Instance.musicManager.PlayHit();
            DieAction();
        }
    }

    private void DieAction()
    {
        Destroy(gameObject);
    }
}
