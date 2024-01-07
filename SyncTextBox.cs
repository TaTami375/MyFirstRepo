using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinForms_Draft_2
{
    //===================================================================================================================================
    //создаём свой класс синхронизированный TextBox, наследуемый от TextBox, который будет иметь общий scroll на все экземпляры
    class SyncTextBox : RichTextBox
    {

        public SyncTextBox()
        {
            this.Multiline = true;
            this.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.SelectionHighlightEnabled = false;
        }
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;
        [DefaultValue(true)]
        public bool SelectionHighlightEnabled { get; set; }
        public Control Buddy { get; set; }

        private static bool scrolling;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS && !SelectionHighlightEnabled)
                m.Msg = WM_KILLFOCUS;
            base.WndProc(ref m);
            //Ловит сообщение WM_VSCROLL и передает buddy
            if ((m.Msg == 0x115 || m.Msg == 0x20a) && !scrolling && Buddy != null && Buddy.IsHandleCreated)
            {
                scrolling = true;
                SendMessage(Buddy.Handle, m.Msg, m.WParam, m.LParam);
                scrolling = false;
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }

    //===================================================================================================================================
}
