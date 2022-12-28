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
            setVisibilityForLabelsForScor(false);
            setVisibilityForMeciRelatedWidgets(false);

        }

        private void tabelMeciuri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = tabelMeciuri.Rows[e.RowIndex];
                guidMeciSelectat = Guid.Parse(row.Cells["guidMeci"].Value.ToString());
                setVisibilityForMeciRelatedWidgets(true);
                setVisibilityForLabelsForScor(false);
                listaJucatoriActiviMeci.Items.Clear();
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
            List<JucatorActiv> listaJucatoriActivi = (from jucatorActiv in srv.getJucatoriActivi()
                                           where jucatorActiv.Echipa.ID.Equals(srv.findMeciById(guidMeciSelectat).getEchipaGazda.ID)
                                           select jucatorActiv).ToList();
            reloadJucatoriActiviLista(listaJucatoriActivi);

        }

        private void btnShowEchipaOaspete_Click(object sender, EventArgs e)
        {
            List<JucatorActiv> listaJucatoriActivi = (from jucatorActiv in srv.getJucatoriActivi()
                                                      where jucatorActiv.Echipa.ID.Equals(srv.findMeciById(guidMeciSelectat).GetEchipaOaspete.ID)
                                                      select jucatorActiv).ToList();
            reloadJucatoriActiviLista(listaJucatoriActivi);
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            startDateAleasa = startDateTimePicker.Value;
        }

        private void finalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            finalDateAleasa = finalDateTimePicker.Value;
        }

        private void setVisibilityForMeciRelatedWidgets(bool v)
        {
            btnShowEchipaGazda.Visible = v;
            btnShowEchipaOaspete.Visible = v;
            btnShowMeciScor.Visible = v;
            displayJucatoriActiviMeci.Visible = v;
            listaJucatoriActiviMeci.Visible = v;
        }
        private void setVisibilityForLabelsForScor(bool v)
        {
            labelNumeEchipaGazda.Visible = v;
            labelNumeEchipaOaspete.Visible = v;
            scorEchipaGazda.Visible = v;
            scorEchipaOaspete.Visible = v;
        }
        private void btnMeciScor_Click(object sender, EventArgs e)
        {
            
            Echipa echipaGazda = srv.findMeciById(guidMeciSelectat).getEchipaGazda;
            Echipa echipaOaspete = srv.findMeciById(guidMeciSelectat).GetEchipaOaspete;

            List<JucatorActiv> listaJucatoriActiviEchipaGazda = (from jucatorActiv in srv.getJucatoriActivi()
                                                                 where jucatorActiv.Echipa.ID.Equals(echipaGazda.ID)
                                                                 select jucatorActiv).ToList();

            List<JucatorActiv> listaJucatoriActiviEchipaOaspete = (from jucatorActiv in srv.getJucatoriActivi()
                                                                 where jucatorActiv.Echipa.ID.Equals(echipaOaspete.ID)
                                                                 select jucatorActiv).ToList();
            int puncteEchipaGazda = 0;
            int puncteEchipaOaspete = 0;
            foreach (JucatorActiv j in listaJucatoriActiviEchipaGazda)
            {
                puncteEchipaGazda += j.getNrPuncteInscrise;
            }
            foreach (JucatorActiv j in listaJucatoriActiviEchipaOaspete)
            {
                puncteEchipaOaspete += j.getNrPuncteInscrise;
            }
            setVisibilityForLabelsForScor(true);
            labelNumeEchipaGazda.Text = echipaGazda.Nume;
            labelNumeEchipaOaspete.Text = echipaOaspete.Nume;

            scorEchipaGazda.Text = puncteEchipaGazda.ToString();
            scorEchipaOaspete.Text = puncteEchipaOaspete.ToString();


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


        private void reloadJucatoriActiviLista(List<JucatorActiv> listaJucatori)
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

            setVisibilityForMeciRelatedWidgets(false);
            guidMeciSelectat = Guid.Empty;
        }
        private void comboBoxEchipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadJucatoriEchipaList(srv.findEchipaByName(comboBoxEchipe.Text));
        }
    }
}
