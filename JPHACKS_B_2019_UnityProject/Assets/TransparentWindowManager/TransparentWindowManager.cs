using System;
using System.Runtime.InteropServices;
using UnityEngine;

//
//DLLをインポートするのでWindowsアプリでしか動かない
//DLLのリファレンスはmicrosoftのサイトから消えてる模様


public class TransparentWindowManager : SingletonMonoBehaviour<TransparentWindowManager>
{




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

    #region Method

    // CAUTION:
    // To control enable or disable, use Start method instead of Awake.

    protected virtual void Start()
    {
        var windowHandle = IntPtr.Zero;

        // NOTE:
        // https://msdn.microsoft.com/ja-jp/library/cc410861.aspx
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        windowHandle = GetActiveWindow();
#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN

        if (windowHandle == IntPtr.Zero)
        {
            Debug.LogError("window handle not found");
            return;
        }

        // NOTE:
        // https://msdn.microsoft.com/ja-jp/library/cc411203.aspx
        // 
        // "SetWindowLong" is used to update window parameter.
        // The arguments shows (target, parameter, value).

        // NOTE:
        // http://chokuto.ifdef.jp/urawaza/prm/window_style.html

#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        SetWindowLong(windowHandle, GWL_STYLE,  WS_POPUP | WS_VISIBLE);

        IntPtr HWND_TOPMOST = new IntPtr(-1);
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_NOACTIVE = 0x0010;
        const uint SWP_SHOWWINDOW = 0x0040;

        SetWindowPos(windowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVE | SWP_SHOWWINDOW);
#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN

        // NOTE:
        // https://msdn.microsoft.com/ja-jp/library/windows/desktop/aa969512(v=vs.85).aspx
        // https://msdn.microsoft.com/ja-jp/library/windows/desktop/bb773244(v=vs.85).aspx
        // 
        // DwmExtendFrameIntoClientArea will spread the effects
        // which attached to window frame to contents area.
        // So if the frame is transparent, the contents area gets also transparent.
        // MARGINS is structure to set the spread range.
        // When set -1 to MARGIN, it means spread range is all of the contents area.

        MARGINS margins = new MARGINS()
        {
            cxLeftWidth = -1
        };
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN

        DwmExtendFrameIntoClientArea(windowHandle, ref margins);

#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN
    }

    #endregion Method

    public void SetWindowMode(bool flag)
    {

        // NOTE:
        // https://msdn.microsoft.com/ja-jp/library/cc410861.aspx

        var windowHandle = IntPtr.Zero;
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        windowHandle = GetActiveWindow();
#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN
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

        uint windowState = flag ? 
            WS_POPUP | WS_VISIBLE :
            WS_VISIBLE | WS_BORDER | WS_DLGFRAME | WS_THICKFRAME | WS_SYSMENU;

#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        SetWindowLong(windowHandle, GWL_STYLE, windowState);
#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN

        MARGINS margins = new MARGINS()
        {
            cxLeftWidth = -1
        };

#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        DwmExtendFrameIntoClientArea(windowHandle, ref margins);
#endif // !UNITY_EDITOR && UNITY_STANDALONE_WIN
    }


}