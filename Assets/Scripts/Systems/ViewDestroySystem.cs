using Entitas;
using UnityEngine;

//��� ���� �������, ����� ����������� ����� �������� � ����, ������ �� ����� �������.
//��� ������� ��� �������. View - ������������� ����� �������� � Unity

//�����. ����� ���������� ������� ���������� ��� �������� ���������� �� �� ����� �������� ������
//� ����������� ����� ����������, � ��� ���� GO ��� �����������.
public class ViewDestroySystem : IInitializeSystem, ITearDownSystem
{
    IGroup<GameEntity> group;

    public ViewDestroySystem(Contexts contexts)
    {
        //���� ������ ���������, � ������� ���� ��������� View
        group = contexts.game.GetGroup(GameMatcher.View);
    }

    public void Initialize()
    {
        //������������� �� �������, ������� ���������� �� ���� ��� �������� ���������� � ��������� �����
        group.OnEntityRemoved += OnViewRemoved;
    }

    //���������� ������ ���������
    public void TearDown()
    {
        //������������ �� �������, ��������� �� �����
        group.OnEntityRemoved -= OnViewRemoved;
    }

    // ���������� ����� ��� ��� ��������� ����� �����
    void OnViewRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        //������� - ������������ �������������� ����� ������)). �.�. �����, ��� ���� ������ �������� ������ � View
        var view = (ViewComponent)component;
        GameObject.Destroy(view.gameObject);
    }
}
