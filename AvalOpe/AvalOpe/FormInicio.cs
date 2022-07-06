using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

//using System.Data.SQLite;

namespace AvalOpe
{

    public partial class FormInicio : Form
    {
        //string mDbPath = Application.StartupPath + "/getstarted.db";
        //SQLiteConnection mConn;
        //SQLiteDataAdapter mAdapter;
        //DataTable mTable;

        public FormInicio(bool exibeBotao)
        {
            InitializeComponent();

            btDistribuição.Visible = exibeBotao;
            btSubtransmissão.Visible = exibeBotao;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ((FormInterface)this.MdiParent).showAvaliacao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((FormInterface)this.MdiParent).showReconfiguracaoDeRedes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((FormInterface)this.MdiParent).showFluxoPotencia();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((FormInterface)this.MdiParent).showCadastroTreinamento();
        }

        private void btDistribuição_Click(object sender, EventArgs e)
        {
            ((FormInterface)this.MdiParent).setTipoSistema(1);
            btDistribuição.Visible = false;
            btSubtransmissão.Visible = false;
        }

        private void btSubtransmissão_Click(object sender, EventArgs e)
        {
            ((FormInterface)this.MdiParent).setTipoSistema(2);
            btDistribuição.Visible = false;
            btSubtransmissão.Visible = false;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
           //// --------------------Connecting To DB --------------------
           //// ----------------------------------------------------------
           //// If DB Not Exists, it will be created.
           //mConn = new SQLiteConnection("Data Source=" + mDbPath);

           // // ----------------- Opening The Connection -----------------
           // // ----------------------------------------------------------
           // // I.e. Opening DB's File for Reading And Writing.
           // // SQLiteDataAdapter cans do it automatically.
           // // But, if you would also use SQLiteCommand, or GetSchema(),
           // // you should Open DB Manually.
           // mConn.Open();

           // // ---------- Creating A Test Table, If Not Exists ----------
           // // ----------------------------------------------------------
           // // id        - Unique Counter - Key Field (Required in any table)
           // // FirstName - Text
           // // Age       - Integer

           // using (SQLiteCommand mCmd = new SQLiteCommand ("CREATE TABLE IF NOT EXISTS [Test Table] (id INTEGER PRIMARY KEY AUTOINCREMENT, 'FirstName' TEXT, 'Age' INTEGER); ", mConn))
           // {
           //     mCmd.ExecuteNonQuery();
           // }

           // // ---------- Get All Tables From DB to ComboBox -----------
           // // ---------------------------------------------------------
           // // There "Tables" is a system table which contains info
           // // about tables in DB.
           // // "TABLE_NAME" field in "Tables" contains table names.
           // using (DataTable mTables = mConn.GetSchema("Tables"))
           // {
           //     for (int i = 0; i < mTables.Rows.Count; i++)
           //     {
           //         CmbTables.Items.Add(mTables.Rows[i].ItemArray[mTables.Columns.IndexOf("TABLE_NAME")].ToString());
           //     }

           //     if (CmbTables.Items.Count > 0)
           //     {
           //         CmbTables.SelectedIndex = 0; // Default selected index.
           //     }
           // }
        }

        private void FormInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            //// -------- Saving Modified Data To Selected Table ---------
            //// -------------------- On Form Closed ---------------------
            //// ---------------------------------------------------------

            //if (mAdapter == null) // If No Table Selected.
            //    return;

            //mAdapter.Update(mTable);
        }
    }
}
