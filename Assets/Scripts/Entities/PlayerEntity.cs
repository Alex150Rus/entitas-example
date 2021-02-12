using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� (Entity) �� �������� ������ ��� ����, ���� ���������� ����� �����������. GameObject
public class PlayerEntity : AbstractEntity
{
    public GameObject playerPrefab;
    public float health;

    protected override void Start()
    {
        //�������� ����� �� AnstractEntity, ������� ������� entity � ���������
        base.Start();
        //��������� � entity ��������� Player (� go ��������� ���������)
        entity.isPlayer = true;
        entity.AddPrefab(playerPrefab);
        //��������� ��������� �������� AddHealth ������ isHealth = true, ��� ��� ���� �������� � ����������
        entity.AddHealth(health);
    }
}
