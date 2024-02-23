using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(GameMemento memento)
    {
        // Serializar e salvar o GameMemento em um arquivo ou PlayerPrefs
    }

    public GameMemento LoadGame()
    {
        // Carregar e deserializar o GameMemento de um arquivo ou PlayerPrefs
        return new GameMemento(/* parâmetros para reconstruir o estado do jogo */);
    }
}
