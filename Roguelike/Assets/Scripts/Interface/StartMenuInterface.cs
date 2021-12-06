using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuInterface : InterfaceMenu
{
    public void TurnOnMainMenu()
    {
        InterfacesManager.Instance.ChangeInterface(InterfacesState.MainMenu);
    }
}
