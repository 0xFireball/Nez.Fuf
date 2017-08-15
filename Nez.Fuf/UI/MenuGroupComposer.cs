using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez.UI;

namespace Nez.Fuf.UI
{
    public class MenuGroupComposer
    {
        public TextButtonStyle ButtonStyle { get; }
        public Vector2 ButtonDimens { get; }
        public int Padding { get; }
        public List<MenuGroupButton> Buttons { get; }

        public class MenuGroupButton
        {
            public string Text { get; set; }
            public Action<Button> Click { get; set; }
            public bool Enabled { get; set; } = true;
        }

        public MenuGroupComposer(TextButtonStyle buttonStyle, Vector2 buttonDimens, int padding)
        {
            ButtonStyle = buttonStyle;
            ButtonDimens = buttonDimens;
            Padding = padding;
            Buttons = new List<MenuGroupButton>();
        }

        public void attachTo(Table table)
        {
            foreach (var button in Buttons)
            {
                var uiButton = new TextButton(button.Text, ButtonStyle);
                uiButton.setDisabled(!button.Enabled);
                if (button.Click != null)
                {
                    uiButton.onClicked += button.Click;
                }
                table.add(uiButton).setMinWidth(ButtonDimens.X).setMinHeight(ButtonDimens.Y).pad(Padding);
                table.row();
            }
        }
    }
}