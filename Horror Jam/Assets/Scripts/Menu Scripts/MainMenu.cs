using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    int selected;
    public Button[] _button;
    bool transition;

    //enum buttons { PLAY = 0, CREDITS, QUIT};

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
                //transition = true;
                //float fadetime = GameManager.manager.GetComponent<Fade>().BeginFade(1);
                _button[selected - 1].onClick.Invoke();
                //Invoke("PauseLoad", fadetime);
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

    public void PauseLoad(string levelName)
    {
        Application.LoadLevel(levelName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
