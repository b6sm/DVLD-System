using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace My_DVLD
{
    public class FormMain : ToolStripProfessionalRenderer
    {
        public FormMain() : base(new DarkColors()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }

        public class DarkColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(45, 45, 48);

            public override Color MenuItemBorder => Color.FromArgb(46, 204, 113);

            public override Color SeparatorDark => Color.FromArgb(70, 70, 70);

            public override Color SeparatorLight => Color.FromArgb(70, 70, 70);

            public override Color ToolStripDropDownBackground => Color.FromArgb(30, 30, 30);

            public override Color ImageMarginGradientBegin => Color.FromArgb(30, 30, 30);

            public override Color ImageMarginGradientMiddle => Color.FromArgb(30, 30, 30);

            public override Color ImageMarginGradientEnd => Color.FromArgb(30, 30, 30);

            public override Color MenuItemPressedGradientBegin => Color.FromArgb(35, 35, 35);

            public override Color MenuItemPressedGradientEnd => Color.FromArgb(35, 35, 35);

            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(50, 50, 50);

            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(50, 50, 50);

            public override Color MenuBorder => Color.FromArgb(60, 60, 60);

            public override Color ToolStripBorder => Color.Transparent;



        }


    }
    public class DarkColorForContextMenueTrip : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground => Color.FromArgb(36,36,36);

        public override Color ImageMarginGradientBegin => Color.FromArgb(36, 36, 36);

        public override Color ImageMarginGradientMiddle => Color.FromArgb(36, 36, 36);

        public override Color ImageMarginGradientEnd => Color.FromArgb(36, 36, 36);

        public override Color MenuItemSelected => Color.FromArgb(55, 55, 55);

        public override Color MenuItemBorder => Color.Transparent;




    }
}
