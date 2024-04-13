using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI
{
    public class DialogListBox
    {
        public static DialogResult Show(
            string title, 
            string promptText,
            List<string> dataToDisplay,
            ref int selectedIndex)
        {
            //'value' is to return Some value
            Form form = new Form();
            Label label = new Label();
            ListBox lv = new ListBox();

            dataToDisplay.ForEach(data => { lv.Items.Add(data); });

            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            lv.SetBounds(9, 40, 280, 66);


            buttonOk.SetBounds(228, 110, 75, 23);
            buttonCancel.SetBounds(309, 110, 75, 23);

            label.AutoSize = true;

            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 150);
            form.Controls.AddRange(new Control[] { label, lv, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (lv.SelectedIndex != -1)
            {
                selectedIndex = lv.SelectedIndex;
            }
            return dialogResult;
        }
    }
}
