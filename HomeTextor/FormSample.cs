using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTextor
{
    public partial class FormSample : Form
    {
        public FormSample()
        {
            InitializeComponent();
        }

        private void EliminarPestana()
        {
            if (tabControlSample.TabPages.Count != 1)
            {
                tabControlSample.TabPages.Remove(tabControlSample.SelectedTab);
            }
            else
            {
                tabControlSample.TabPages.Remove(tabControlSample.SelectedTab);
            }
        }

        private void EliminarTodasLasPestanas()
        {
            foreach (TabPage Page in tabControlSample.TabPages)
            {
                tabControlSample.TabPages.Remove(Page);
            }
            
            
        }

        private void EliminarTodasLasPestanasMenosEsta()
        {
            foreach (TabPage Page in tabControlSample.TabPages)
            {
                if (Page.Name != tabControlSample.SelectedTab.Name)
                {
                    tabControlSample.TabPages.Remove(Page);
                }
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarPestana();
        }

        private void cerrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarTodasLasPestanas();
        }

        private void cerrarTodosExceptoEstaVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarTodasLasPestanasMenosEsta();
        }
    }
}
