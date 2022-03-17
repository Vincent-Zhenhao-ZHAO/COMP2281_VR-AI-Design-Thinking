using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pen : MonoBehaviour
{
    // variables we have to draw something on the whitboard
    [SerializeField] private Transform writing_point; // or tip 
    [SerializeField] private int pensize = 5;

    private Renderer _renderer;
    private Color[] _colors;
    private float _pointHeight;
    
    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;
    
    // get renderer and set up colour and tip height.
    void Start()
    {
        _renderer = writing_point.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, pensize * pensize).ToArray();
        _pointHeight = writing_point.localScale.y;
    }

    // in update method we just call draw everytime
    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(writing_point.position, transform.up, out _touch, _pointHeight))
        {
            // checking the whiteboard: if the pen is touching?
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }
                // get touch position when we touched the whiteboard
                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int) (_touchPos.x * _whiteboard.textturesize.x - (pensize / 2));
                var y = (int) (_touchPos.y * _whiteboard.textturesize.y - (pensize / 2));

                // if the pen is outside of whiteboard, do nothing;
                if (y < 0 || y > _whiteboard.textturesize.y || x < 0 || x > _whiteboard.textturesize.x ) return;
                
                // if we touch last frame, colour last pixel
                if (_touchedLastFrame)
                {
                    _whiteboard.texture.SetPixels(x , y ,pensize , pensize , _colors);

                    for (float f = 0.01f; f < 1.00f; f+=0.01f)
                    {
                        var lerpX = (int) Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int) Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX , lerpY ,pensize , pensize , _colors);
                    }

                    transform.rotation = _lastTouchRot;
                    
                    _whiteboard.texture.Apply();
                }
                // if didn't, then set it. (so we get one frame late)
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }
    
}
