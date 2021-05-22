﻿using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Providers
{
    public interface IFormProvider
    {
        void ShowDialog();
        void Close();

        Form Form { get; }

        void SetStartPosition(FormStartPosition startPosition);
        void AddControl(Control control);

        int Height { get; set; }
        int Width { get; set; }

        int ExtraPaddingForFullRow { get; set; }
        int InitialTopPadding { get; set; }
        int SecondColumnLeftPadding { get; set; }
        int BottomSpace { get; set; }
        int ButtonRightPadding { get; set; }
        int ButtonBottomPadding { get; set; }

        Action OnCloseHandler { get; set; }
    }
}
