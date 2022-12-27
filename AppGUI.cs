using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using JrNBALeagueRo.domain;
using JrNBALeagueRo.repository.database;
using JrNBALeagueRo.service;
namespace JrNBALeagueRo
{
    public partial class AppGUI : Form
    {
        private Service srv;

        private Guid guidMeciSelectat;

        private DateTime startDateAleasa;
        private DateTime finalDateAleasa;
        public AppGUI(ref Service service)
        {
            this.srv = service;
            InitializeComponent();
            reloadMeciDataGridView((List<Meci>)srv.getMeciuri());
            
            btnShowEchipaGazda.Visible = false;
            btnShowEchipaOaspete.Visible = false;
            btnShowMeciScor.Visible = false;
            displayJucatoriActiviMeci.Visible = false;
            listaJucatoriActiviMeci.Visible = false;
            
        }

        private void tabelMeciuri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = tabelMeciuri.Rows[e.RowIndex];
                guidMeciSelectat = Guid.Parse(row.Cells["guidMeci"].Value.ToString());

                btnShowEchipaGazda.Visible = true;
                btnShowEchipaOaspete.Visible = true;
                btnShowMeciScor.Visible = true;
                displayJucatoriActiviMeci.Visible = true;
                listaJucatoriActiviMeci.Visible = true;
            }
        }

        private void btnFilterMeciByDate_Click(object sender, EventArgs e)
        {
            List<Meci> listaMeciuri = (from meci in srv.getMeciuri()
                                       where meci.getDataMeci.CompareTo(finalDateAleasa) < 0 && meci.getDataMeci.CompareTo(startDateAleasa) > 0
                                       select meci).ToList();

            reloadMeciDataGridView(listaMeciuri);
        }

        private void btnShowEchipaGazda_Click(object sender, EventArgs e)
        {
            List<Jucator> listaJucatori =srv.getJucatoriForEchipa(srv.findMeciById(guidMeciSelectat).getEchipaGazda.ID).ToList();
            reloadJucatoriActiviLista(listaJucatori);

        }

        private void btnShowEchipaOaspete_Click(object sender, EventArgs e)
        {
            List<Jucator> listaJucatori = srv.getJucatoriForEchipa(srv.findMeciById(guidMeciSelectat).GetEchipaOaspete.ID).ToList();
            reloadJucatoriActiviLista(listaJucatori);
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            startDateAleasa = startDateTimePicker.Value;
        }

        private void finalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            finalDateAleasa = finalDateTimePicker.Value;
        }

        
        private void btnMeciScor_Click(object sender, EventArgs e)
        {

        }


        private void reloadJucatoriEchipaList(Echipa e)
        {
            List<Jucator> listaJucatori = srv.getJucatoriForEchipa(e.ID).ToList();
            listJucatoriEchipaAleasa.Items.Clear();
            foreach(Jucator jucator in listaJucatori)
            {
                string[] listRow = { jucator.Nume, jucator.Scoala };
                var listViewItem = new ListViewItem(listRow);
                listJucatoriEchipaAleasa.Items.Add(listViewItem);
            }
            
        }


        private void reloadJucatoriActiviLista(List<Jucator> listaJucatori)
        {
            listaJucatoriActiviMeci.Items.Clear();
            foreach (Jucator jucator in listaJucatori)
            {
                string[] listRow = { jucator.Nume, jucator.Scoala };
                var listViewItem = new ListViewItem(listRow);
                listaJucatoriActiviMeci.Items.Add(listViewItem);

            }

        }
        private void reloadMeciDataGridView(List<Meci> listaMeciuri)
        {

            tabelMeciuri.Rows.Clear();
            tabelMeciuri.Refresh();
            foreach(Meci meci in listaMeciuri)
            {
                tabelMeciuri.Rows.Add(meci.getEchipaGazda.Nume, meci.GetEchipaOaspete.Nume, meci.getDataMeci.ToString(),meci.ID.ToString());
            }
            btnShowEchipaGazda.Visible = false;
            btnShowEchipaOaspete.Visible = false;
            btnShowMeciScor.Visible = false;
            displayJucatoriActiviMeci.Visible = false;
            listaJucatoriActiviMeci.Visible = false; 
            guidMeciSelectat = Guid.Empty;
        }
        private void comboBoxEchipe_SelectedIndexChanged(object sender, EventArgs e)
        {

            reloadJucatoriEchipaList(srv.findEchipaByName(comboBoxEchipe.Text));
        }
    }
}
