using System;
using System.Runtime.InteropServices;
using UnityEngine;

//
//DLLをインポートするのでWindowsアプリでしか動かない
//DLLのリファレンスはmicrosoftのサイトから消えてる模様
//https://qiita.com/wakagomo/items/6e83019481d7cd326e72

public class TransparentWindowManager : SingletonMonoBehaviour<TransparentWindowManager>
{

    [SerializeField] bool transparentOnStart = true;


    #region Enum

    internal enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }

    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    #endregion Enum

    #region Struct

    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    #endregion Struct

    #region DLL Import

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr handle,int x,int y,int w,int h, uint flag);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    #endregion DLL Import

    const int GWL_STYLE = -16;
    const uint WS_POPUP = 0x80000000;
    const uint WS_VISIBLE = 0x10000000;
    const uint WS_BORDER = 0x800000;//境界線を描画
    const uint WS_DLGFRAME = 0x400000;//メニューバーを描画（閉じるボタンなどはなし）透過はできなくなる
    const uint WS_THICKFRAME = 0x40000;//サイズ変更境界
    const uint WS_SYSMENU = 0x80000;//
    const uint WS_OVERLAPPEDWINDOW = 0x00CF0000;

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    const uint SWP_NOSIZE = 0x0001;
    const uint SWP_NOMOVE = 0x0002;
    const uint SWP_NOACTIVE = 0x0010;
    const uint SWP_SHOWWINDOW = 0x0040;

    #region Method

    // CAUTION:
    // To control enable or disable, use Start method instead of Awake.

    protected virtual void Start()
    {
        if (transparentOnStart)
        {
            SetTransparent(true);
        }
    }

    #endregion Method

    public void SetTransparent(bool flag)
    {

#if UNITY_EDITOR || !UNITY_STANDALONE_WIN
        Debug.LogWarning("TransparentWindowManager does not work. This is for windows app.");
#else
        // NOTE:
        // https://msdn.microsoft.com/ja-jp/library/cc410861.aspx
        var windowHandle = IntPtr.Zero;

        windowHandle = GetActiveWindow();

        if (windowHandle == IntPtr.Zero)
        {
            Debug.LogError("window handle not found.");
            return;
        }

        // NOTE:
        // https://msdn.microsoft.com/ja-jp/library/cc411203.aspx
        // 
        // "SetWindowLong" is used to update window parameter.
        // The arguments shows (target, parameter, value).

        uint windowState = GetWindowState(flag);

        SetWindowLong(windowHandle, GWL_STYLE, windowState);
        SetWindowPos(windowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVE | SWP_SHOWWINDOW);

        MARGINS margins = new MARGINS()
        {
            cxLeftWidth = -1
        };

        DwmExtendFrameIntoClientArea(windowHandle, ref margins);
#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN
    }

    uint GetWindowState(bool isTransparented)
    {
      return isTransparented ?
            WS_POPUP | WS_VISIBLE :
            WS_VISIBLE | WS_BORDER | WS_DLGFRAME | WS_THICKFRAME | WS_SYSMENU;
    }


}