using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetCameraSize2 : MonoBehaviour
{
    private enum RestictDir
    {
        none,
        both,
        // Set collider to big collider when using big room. tho dont change the restriction collider
        x,
        y
    }

    [SerializeField]
    private RestictDir restrictDir;
    private PolygonCollider2D roomCollider;
    public CinemachineVirtualCamera roomCamera;
    public Camera simpleCamera;


    private void Awake()
    {
        roomCollider = GetComponent<PolygonCollider2D>();
        SetScreenSize();
    }

    public Vector2 GetRoomSize()
    {
        // [0] == up right; [1] == down right; [2] == down Left; [3] == up left
        Vector2 roomSize = new Vector2(Vector3.Distance(roomCollider.points[3], roomCollider.points[0]), Vector3.Distance(roomCollider.points[2], roomCollider.points[3]));
        return roomSize;
    }

    public Vector2 GetScreenSize()
    {
        float x = Vector3.Distance(simpleCamera.ViewportToWorldPoint(new Vector3(0f, 0f, roomCamera.m_Lens.NearClipPlane)), simpleCamera.ViewportToWorldPoint(new Vector3(1f, 0f, roomCamera.m_Lens.NearClipPlane)));
        float y = roomCamera.m_Lens.OrthographicSize;
        return new Vector2(x, y);
    }


    public void SetScreenSize()
    {
        if(restrictDir == RestictDir.x)
        {
            SetScreenXAxis();
        }
        if(restrictDir == RestictDir.y)
        {
            SetScreenYAxis();
        }
        if (restrictDir == RestictDir.both)
        {
            if(GetRoomSize().x <= GetRoomSize().y * 2)
            {
                SetScreenYAxis();
            }
            if(GetRoomSize().x > GetRoomSize().y *2)
            {
                SetScreenXAxis();
            }
        }
    }

    private void SetScreenXAxis()
    {
        // make x screen size to x roomsize
        roomCamera.m_Lens.OrthographicSize = (roomCamera.m_Lens.OrthographicSize / GetScreenSize().x) * GetRoomSize().x;
    }

    private void SetScreenYAxis()
    {
        // make y screen size to y roomsize
        roomCamera.m_Lens.OrthographicSize = (roomCamera.m_Lens.OrthographicSize / GetScreenSize().y) * GetRoomSize().y / 2;
    }
}
