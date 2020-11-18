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
    public partial class frmArtistEdicion : Form
    {
        public Artist Artist { get; set; }

        public frmArtistEdicion()
        {
            InitializeComponent();

            
        }

        public  void MostrarDatos()
        {
            if(IsEdit()) //Ocurre durante la edicion del artista
            {
                //var artist = new 

                txtNombre.Text = this.Artist.Name;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var artist = new Artist();
            artist.Name = txtNombre.Text.Trim();

            var artistDA = new ArtistDA();

            if(IsEdit())
            {
                artist.ArtistId = this.Artist.ArtistId;
                artistDA.Update(artist);
            }
            else
                artistDA.Insert(artist);

            this.Close();
        }

        private bool IsEdit()
        {
            return this.Artist != null;
        }

        private void frmArtistEdicion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
