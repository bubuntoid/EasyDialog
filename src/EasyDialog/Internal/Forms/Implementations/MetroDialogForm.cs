﻿using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using EasyDialog.Enums;
using EasyDialog.Internal.Forms.Interfaces;
using EasyDialog.Internal.Forms.Templates;
using MetroFramework;
using MetroFramework.Drawing;
using MetroFramework.Forms;

namespace EasyDialog.Internal.Forms.Implementations
{
    internal class MetroDialogForm : IDialogForm
    {
        private const int SECOND_COLUMN_X_COORD = 150;

        private const int INITIAL_TOP_PADDING = 80;

        private const int VALUE_CONTROL_WIDTH = 150;

        private const int BUTTON_HEIGHT = 40;
        private const int BUTTON_WIDTH = 120;

        private const int BOTTOM_SPACE = BUTTON_HEIGHT + 35;

        public DialogContext Context { get; set; }

        private readonly MetroForm form;

        public MetroDialogForm(MetroTheme theme)
        {
            form = new MetroForm()
            {
                Width = 335,

                Style = (MetroColorStyle)theme,
                MaximizeBox = false,
                Resizable = false,
                StartPosition = FormStartPosition.CenterParent,
                BorderStyle = MetroBorderStyle.FixedSingle
            };
        }

        public string Title
        {
            get => form.Text;
            set => form.Text = value;
        }
        public string ButtonText { get; set; }

        public void Show()
        {
            form.ShowDialog();
        }

        public void Close()
        {
            form.Close();
        }

        public void SetItems(IEnumerable<BaseDialogItem> items)
        {
            var currentHeight = INITIAL_TOP_PADDING;
            var count = items.Count();

            for (int i = 0; i < count; i++)
            {
                var currentItem = items.ElementAt(i);

                var control = currentItem.Control;

                control.Enabled = currentItem.Enabled;
                control.AutoSize = false;
                control.Size = new Size(VALUE_CONTROL_WIDTH, currentItem.ControlHeight);
                control.Location = new Point
                {
                    X = SECOND_COLUMN_X_COORD,
                    Y = currentHeight
                };

                form.Controls.Add(LabelTemplate.DefaultLabel(currentItem.Name, currentHeight + 3));
                form.Controls.Add(control);

                currentHeight += control.Size.Height + 10;
            }

            form.Height = currentHeight + BOTTOM_SPACE + 50;
            
            var buttonControl = new Button()
            {
                Text = ButtonText,
                Height = BUTTON_HEIGHT,
                Width = BUTTON_WIDTH,
                Location = new Point()
                {
                    X = form.Width - 150,
                    Y = form.Height - BUTTON_HEIGHT - 26
                }
            };
            buttonControl.Click += (o, e) => { Context.OnButtonClick(); };
            form.Controls.Add(buttonControl);
            buttonControl.Select();
        }
    }
}
