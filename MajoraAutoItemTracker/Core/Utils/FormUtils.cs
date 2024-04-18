using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace MajoraAutoItemTracker.Core
{
    internal class FormUtils
    {
        public static void SaveFormState(Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Location = form.RestoreBounds.Location;
                Properties.Settings.Default.Size = form.RestoreBounds.Size;
                Properties.Settings.Default.Maximised = true;
                Properties.Settings.Default.Minimised = false;
            }
            else if (form.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Location = form.Location;
                Properties.Settings.Default.Size = form.Size;
                Properties.Settings.Default.Maximised = false;
                Properties.Settings.Default.Minimised = false;
            }
            else
            {
                Properties.Settings.Default.Location = form.RestoreBounds.Location;
                Properties.Settings.Default.Size = form.RestoreBounds.Size;
                Properties.Settings.Default.Maximised = false;
                Properties.Settings.Default.Minimised = true;
            }
            Properties.Settings.Default.HasDefaultWindowSet = true;
            Properties.Settings.Default.Save();
        }

        public static void RestoreFormState(Form form)
        {
            if (!Properties.Settings.Default.HasDefaultWindowSet)
                return;
            if (Properties.Settings.Default.Maximised)
            {
                form.Location = Properties.Settings.Default.Location;
                form.WindowState = FormWindowState.Maximized;
                form.Size = Properties.Settings.Default.Size;
            }
            else if (Properties.Settings.Default.Minimised)
            {
                form.Location = Properties.Settings.Default.Location;
                form.WindowState = FormWindowState.Minimized;
                form.Size = Properties.Settings.Default.Size;
            }
            else
            {
                form.Location = Properties.Settings.Default.Location;
                form.Size = Properties.Settings.Default.Size;
            }
        }
    }
}
