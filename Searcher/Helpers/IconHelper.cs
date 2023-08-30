using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Searcher
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    public static class IconHelper
    {
        
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DestroyIcon(IntPtr hIcon);

        public const uint SHGFI_ICON = 0x000000100;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        public const uint SHGFI_OPENICON = 0x000000002;
        public const uint SHGFI_SMALLICON = 0x000000001;
        public const uint SHGFI_LARGEICON = 0x000000000;

        public static Icon GetFolderIcon(string folderPath)
        {
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
            flags += SHGFI_SMALLICON;

            var shfi = new SHFILEINFO();
            var res = SHGetFileInfo(folderPath,
                16,
                out shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);

            if (res == IntPtr.Zero)
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());

            Icon.FromHandle(shfi.hIcon);

            var icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();

            DestroyIcon(shfi.hIcon); 

            return icon;
        }

        public static Icon GetFileIcon(string folderPath)
        {
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
            flags += SHGFI_SMALLICON;

            var shfi = new SHFILEINFO();
            var res = SHGetFileInfo(folderPath,
                0,
                out shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);

            if (res == IntPtr.Zero)
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());

            Icon.FromHandle(shfi.hIcon);

            var icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();

            DestroyIcon(shfi.hIcon);

            return icon;
        }

    }
}
