using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDB
{
    public partial class MoreForm : Form
    {
        
        //------------------------------------------------------------------------------------
        public MovieShort SelectedMovie { get; set; }
        //------------------------------------------------------------------------------------
        public MoreForm()
        {
            InitializeComponent();
            
        }
        //------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                Close();
            return true;
        }
        //------------------------------------------------------------------------------------
        private void MoreForm_Load(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(SelectedMovie.Poster, UriKind.Absolute))
                Poster.Load(SelectedMovie.Poster);

            var mr = new MovieResponse();
            try
            {
                DBConnect.GetResponse("i", SelectedMovie.imdbID, ref mr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Movie movie = mr as Movie;
            labelTitle.Text = movie.Title;
            MyLabel LabelMore = new MyLabel();
            tableLayoutPanel1.Controls.Add(LabelMore);
            LabelMore.Dock = DockStyle.Fill;
           
            LabelMore.Text = movie.ToString();

            buttonOK.Focus();

        }
        //------------------------------------------------------------------------------------
        private void buttonOK_Click(object sender, EventArgs e) => Close();
        //------------------------------------------------------------------------------------
       
    }
}
