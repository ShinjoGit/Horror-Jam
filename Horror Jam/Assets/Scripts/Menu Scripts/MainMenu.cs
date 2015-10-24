using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    int selected;
    public GameObject[] _button;
    bool transition;
    // Use this for initialization
    void Start()
    {
        transition = false;
        //_button [0].GetComponent<Image> ().color = Color.yellow;
        selected = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && !transition)
        {
            if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && selected != 0)
            {
                transition = true;
                float fadetime = GameManager.manager.GetComponent<Fade>().BeginFade(1);
                Invoke("PauseLoad", fadetime);
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                selected--;
                if (selected <= 0)
                    selected = _button.Length;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                selected++;
                if (selected > _button.Length || selected == 0)
                    selected = 1;
            }
            for (int i = 1; i <= _button.Length; i++)
            {
                if (i == selected)
                    _button[i - 1].GetComponent<Image>().color = Color.cyan;
                else
                    _button[i - 1].GetComponent<Image>().color = Color.white;

            }
        }
    }

    public void MouseOver(GameObject _obj)
    {
        if (!transition)
        {
            for (int i = 1; i <= _button.Length; i++)
            {
                if (_obj == _button[i - 1])
                {
                    selected = i;
                    break;
                }
            }
            _obj.GetComponent<Image>().color = Color.cyan;
        }
    }

    public void MouseLeave(GameObject _obj)
    {
        if (!transition)
        {
            _obj.GetComponent<Image>().color = Color.white;
            selected = 0;
        }
    }

    void PauseLoad()
    {

        if (selected == _button.Length - 1)
            Application.Quit();
        else if (selected == 0)
            Application.LoadLevel(0);
        else if (selected == 1)
            Application.LoadLevel(1);
    }
}
