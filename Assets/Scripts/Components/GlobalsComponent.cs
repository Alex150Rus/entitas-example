using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

//���������, �������� ���������� ��������. Unique ��������, ��� ���� ��������� ����� ������������ ������ � ������������ ����������
//�.�. �� �� ����� ����������� �� ���������� Entity, �� ����� ����������� �� ��������� � �� ������ �������� � ���� ������ ��
//������ �����, ��� � ��� ���� ������ � ���������, �� ��� ���� �� �� ������ ������� ��������� ����������� ������ ����������
[Unique]
public class GlobalsComponent : IComponent
{
    public GameObject shotPrefab;
}
