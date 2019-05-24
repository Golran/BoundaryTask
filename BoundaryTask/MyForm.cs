using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BoundaryTask.Actionss;

namespace BoundaryTask
{
    public class MyForm : Form
    {
        public MyForm(IUiAction[] actions, ChartHolder chartHolder)
        {
            
            BackColor = Color.White;
            var mainMenu = new MenuStrip();
            mainMenu.BackColor = Color.MediumPurple;
            mainMenu.Items.AddRange(actions.ToMenuItems());
            Text = "Решение краевой задачи";
            Size = new Size(1200,800);
            Controls.Add(mainMenu);
            var label = new PictureBox { BorderStyle = BorderStyle.None, BackColor = Color.White }; ;
            Controls.Add(label);
            SizeChanged += (sender, args) => SizeSet(label);
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            chartHolder.SetParent(label);
        }

        private void SizeSet(PictureBox pb)
        {
            var topShift = 40;
            pb.Location = new Point(0, topShift);
            pb.Size = new Size(Size.Width, (Size.Height - 2 * topShift));
        }
    }
}