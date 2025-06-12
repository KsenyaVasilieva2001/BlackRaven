using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ��������� ��� ��������, ���� ����� ������� �������� (������ � �������)
 */
public interface IItemSlot
{
    bool CanAccept(Item item);
    void Accept(GameObject itemInstance);
}
