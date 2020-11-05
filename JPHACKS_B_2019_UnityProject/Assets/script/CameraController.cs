using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://corevale.com/unity/2346

public class CameraController : MonoBehaviour
{
    public enum Mouse
    {
        LEFT = 0,
        RIGHT = 1,
        MIDDLE = 2
    }

    // カメラオブジェクトを格納する変数
    public Camera mainCamera;

    [Header("Rotate")]
    public Mouse dragButton = Mouse.LEFT;
    // カメラの回転速度を格納する変数
    public Vector2 rotationSpeed;
    // マウス移動方向とカメラ回転方向を反転する判定フラグ
    public bool reverse;

    // マウス座標を格納する変数
    [SerializeField] private Vector2 lastMousePosition;
    // カメラの角度を格納する変数（初期値に0,0を代入）
    private Vector2 newAngle = new Vector2(0, 0);
    bool rotateFlag = false;

    [Header("Move")]
    public Mouse moveButton = Mouse.MIDDLE;
    public Vector2 moveSpeed;
    [SerializeField]private Vector2 lastMouseMovePosition;

    [Header("Zoom")]
    public float zoomSpeed;

    RuntimeGizmos.TransformGizmo runtimeGizmo;
    private void Start()
    {
        runtimeGizmo = GetComponent<RuntimeGizmos.TransformGizmo>();
    }
    // Update is called once per frame
    void Update()
    {
        Zoom();
        Move(moveButton);
        //オブジェクトを動かす座標軸が表示されてなければ
        if (runtimeGizmo.mainTargetRoot == null)
            Rotate(dragButton);
        else rotateFlag = false;
    }

    void Move(Mouse button)
    {
        if (Input.GetMouseButtonDown((int)button))
        {
            lastMouseMovePosition = Input.mousePosition;
        }
        // 左ドラッグしている間
        if (Input.GetMouseButton((int)button))
        {
            var mousePos = Input.mousePosition;
            var deltaX = (mousePos.x - lastMouseMovePosition.x) * moveSpeed.x;
            var deltaY = (mousePos.y - lastMouseMovePosition.y) * moveSpeed.y;
            Debug.Log(new Vector2(deltaX, deltaY));
            mainCamera.transform.position -= mainCamera.transform.right * deltaX + mainCamera.transform.up * deltaY;
            lastMouseMovePosition = mousePos;
        }
    }

    void Zoom()
    {
        var scroll = Input.mouseScrollDelta.y;
        mainCamera.transform.position += mainCamera.transform.forward * scroll * zoomSpeed;
    }

    void Rotate(Mouse button)
    {
        // 左クリックした時
        if (Input.GetMouseButtonDown((int)button))
        {
            // カメラの角度を変数"newAngle"に格納
            newAngle = mainCamera.transform.localEulerAngles;
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
            rotateFlag = true;
        }
        // 左ドラッグしている間
        else if (Input.GetMouseButton((int)button)&& rotateFlag)
        {
            float isReverse = reverse ? -1f : 1f;//reverseがtrueのときに反転されるための係数

            //カメラ回転方向の判定フラグが"true"の場合
            // Y軸の回転：マウスドラッグ方向に視点回転
            // マウスの水平移動値に変数"rotationSpeed"を掛ける
            //（クリック時の座標とマウス座標の現在値の差分値）
            newAngle.y -= isReverse * (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
            // X軸の回転：マウスドラッグ方向に視点回転
            // マウスの垂直移動値に変数"rotationSpeed"を掛ける
            //（クリック時の座標とマウス座標の現在値の差分値）
            newAngle.x -= isReverse * (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;

            // "newAngle"の角度をカメラ角度に格納
            mainCamera.transform.localEulerAngles = newAngle;
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
        }else if (Input.GetMouseButtonUp((int)button))
        {
            rotateFlag = false;
        }
    }
}
