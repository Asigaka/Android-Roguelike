using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterfacesState { StartMenu, MainMenu, GameInterface}
public class InterfacesManager : MonoBehaviour
{
    [SerializeField] private List<InterfaceMenu> interfaceMenus;

    public static InterfacesManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;
    }

    private void Start()
    {
        ChangeInterface(InterfacesState.StartMenu);
    }

    public void ChangeInterface(InterfacesState state)
    {
        foreach (InterfaceMenu inter in interfaceMenus)
        {
            inter.gameObject.SetActive(inter.InterfaceState == state);
        }
    }
}
