﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageControls
{
   
       public partial class ThumbnailBox : UserControl
        {
            private ThumbTextPosition _ThumbTextPosition;
            private bool isSet;

            public delegate void SelectDelegate(ThumbnailBox thumbnailBox);
            public new event SelectDelegate Select;
            public ThumbTextPosition ThumbTextPosition
            {
                get { return _ThumbTextPosition; }
                set
                {
                    _ThumbTextPosition = value;
                    if (_ThumbTextPosition == ImageControls.ThumbTextPosition.Top)
                    {
                        labelPanel.Dock = DockStyle.Top;
                    }
                    else
                    {
                        labelPanel.Dock = DockStyle.Bottom;
                    }
                }
            }

            public bool IsSelected
            {
                get { return isSet; }
                set
                {
                    isSet = value;
                    if (isSet)
                    {
                        thumbLabel.ForeColor = Color.White;
                        this.BackColor = Color.DarkBlue;
                    }
                    else
                    {
                        this.BackColor = Color.Gray;
                        thumbLabel.ForeColor = Color.Black;
                    }
                }
            }

            public string Caption
            {
                get { return thumbLabel.Text; }
                set { thumbLabel.Text = value; thumbLabel.Left = (this.Width - thumbLabel.Width) / 2; }
            }

            public Image Thumb
            {
                get { return ThumbPictureBox.BackgroundImage; }
                set
                {
                    ThumbPictureBox.BackgroundImage = value;
                }
            }

            public ThumbnailBox()
            {
                _ThumbTextPosition = ThumbTextPosition.Top;
                InitializeComponent();
                ThumbPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                ThumbPictureBox.Click += delegate
                {
                    if (this.Select != null)
                    {
                        Select(this);
                    }
                };
                thumbLabel.Click += delegate
                {
                    if (this.Select != null)
                    {
                        Select(this);
                    }
                };
                labelPanel.Click += delegate
                {
                    if (this.Select != null)
                    {
                        Select(this);
                    }
                };
                OuterPanel.Click += delegate
                {
                    if (this.Select != null)
                    {
                        Select(this);
                    }
                };

                this.Resize += ThumbnailBox_Resize;
                this.Load += ThumbnailBox_Load;
                thumbLabel.Left = (this.Width - thumbLabel.Width) / 2;

            }

            void ThumbnailBox_Load(object sender, EventArgs e)
            {
                adjust();
            }
          
            void ThumbnailBox_Resize(object sender, EventArgs e)
            {
                adjust();
            }
            private void adjust()
            {
                thumbLabel.Left = (this.labelPanel.Width - thumbLabel.Width) / 2;
                OuterPanel.Height = this.Height - 6;
                OuterPanel.Width = this.Width - 6;
                OuterPanel.Left = (this.Width - this.OuterPanel.Width) / 2;
                OuterPanel.Top = (this.Height - OuterPanel.Height) / 2;
            }
        }
    
}
