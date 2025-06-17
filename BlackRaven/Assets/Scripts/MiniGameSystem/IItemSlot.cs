using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ��������� ��� ��������, ���� ����� ������� �������� (������ � �������)
 */
public interface IItemSlot
{
    bool CanAccept();
    void Accept(GameObject itemInstance);
}
