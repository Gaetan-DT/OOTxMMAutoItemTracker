using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MajoraAutoItemTracker.Core.Utils
{
    public static class Utils
    {
        public static void OpenUrlInBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true,
                });
            } catch (Exception e) {
                MessageBox.Show("Error", e.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
