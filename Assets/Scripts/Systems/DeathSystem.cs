using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


//���� ��� ���������� � �������� (Systems), ����������� �������� ������� ��������� �� ������ 
//������� ��� ���������� � ��� �����-���� �����������

//������� ��������, ����� �� �������� �������� ����
public class DeathSystem : IExecuteSystem
{
    //�������� �� ������������ ����� entities, �������� ����� �����������
    IGroup<GameEntity> entities;
    List<Entity> deadEntities = new List<Entity>();

    //�����������
    public DeathSystem(Contexts contexts)
    {
        //� ��������� game ������ ������ ���������, � ������� ���� ��������� Health;
        entities = contexts.game.GetGroup(GameMatcher.Health);
    }

    //���������� ������ ����. ������ ������� � ����� �����������, �� ����� �� �� ��������� � ������ ����������
    //� �� ��������� ��� ������.  
    public void Execute()
    {
        //���������������� ���� ������ � �����. ��� �� ����� ������ ���� ����������, � ����� �������������
        deadEntities.Clear();

        //���������� �� ������ ��������� � ���������� Health
        foreach (var e in entities) {
            if (e.health.value <= 0)
                //�� �� ����� ����� ��������� e.Destroy(), ��� ��� ��������� ������ (�� ������� ������� �� ������,
                //�� ������� �����������)
                deadEntities.Add(e);
        }

        foreach (var e in deadEntities)
            //��������� ���������� �������� � ����������� ���������� �� ������
            e.Destroy();
    }
}
