using App.Data;
using App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Desktop
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var da = new ArtistDA();
            // dgvListado.DataSource=da.
            lblCount.Text = da.Count().ToString();
            dgvListado.DataSource = da.Gets(txtFiltro.Text.Trim());
            dgvListado.Refresh();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new frmArtistEdicion();
            frm.ShowDialog();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var artist = (Artist)dgvListado.Rows[e.RowIndex].DataBoundItem;
            //mostrando el formulario de edicion de artista
            var frm = new frmArtistEdicion();
            frm.Artist = artist;
            frm.ShowDialog();

        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
