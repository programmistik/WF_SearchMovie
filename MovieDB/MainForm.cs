using Newtonsoft.Json;
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
using Newtonsoft.Json.Linq;


namespace MovieDB
{
    public partial class MainForm : Form
    {
        //------------------------------------------------------------------------------------
        public List<MovieShort> shortMList = new List<MovieShort>();  
        //------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();
            ActiveControl = Title;
        }
        //------------------------------------------------------------------------------------
        private void Title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton.PerformClick();
                MovieListBox.Focus();               
            }
        }
      
        //------------------------------------------------------------------------------------
        private void SearchButton_Click(object sender, EventArgs e)
        {
            shortMList.Clear();

            var mr = new MovieResponse();
            try
            {
                DBConnect.GetResponse("s", Title.Text.Trim(), ref mr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MoreButton.Enabled = false;
            }

            SearchMovie ms = mr as SearchMovie;

            foreach (var item in ms.Search)
                shortMList.Add(item);

            MovieListBox.DataSource = null;
            MovieListBox.DataSource = shortMList;
            MoreButton.Enabled = true;
            MovieListBox.Focus();
            MovieListBox.SelectedIndex = 0;
            if (Uri.IsWellFormedUriString(shortMList[0].Poster, UriKind.Absolute))
                Poster.Load(shortMList[0].Poster);

        }
        //------------------------------------------------------------------------------------
        private void MoreButton_Click(object sender, EventArgs e)
        {
            var wnd = new MoreForm();
            
            if (MovieListBox.SelectedIndex != -1)
            {
                var sm = shortMList[MovieListBox.SelectedIndex];
                wnd.SelectedMovie = sm;
                wnd.Text = sm.Title;
            }
            
            wnd.ShowDialog();
        }
        //------------------------------------------------------------------------------------
        private void MovieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shortMList.Count > 0)
            {
                if (MovieListBox.SelectedIndex != -1)
                {
                    var PosterUri = shortMList[MovieListBox.SelectedIndex].Poster;
                    if (Uri.IsWellFormedUriString(PosterUri, UriKind.Absolute))
                        Poster.Load(PosterUri);
                    else
                        Poster.Image = null;
                }
            }
        }
        //------------------------------------------------------------------------------------
        private void MovieListBox_DoubleClick(object sender, EventArgs e)
        {
            if (shortMList.Count > 0)
            {
                MoreButton.PerformClick();
            }
        }
        //------------------------------------------------------------------------------------
        private void MovieListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                MoreButton.PerformClick();
        }
        //------------------------------------------------------------------------------------
    }
}
