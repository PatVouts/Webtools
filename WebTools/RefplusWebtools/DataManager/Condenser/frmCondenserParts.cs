using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Condenser
{
    public partial class FrmCondenserParts : Form
    {
        //list of tables
        private readonly string[] _strTableList = {"CondenserSerie" };

        public FrmCondenserParts()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCondenserParts_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();

            cboCondenserSerie.SelectedIndex = 0;
        }

        private void Fill_Combobox()
        {
            Fill_CondenserSerie();
        }

        private string Motor()
        {
            return ComboBoxControl.IndexInformation(cboCondenserSerie).Substring(0, 1);
        }

        private string CoilArr()
        {
            return ComboBoxControl.IndexInformation(cboCondenserSerie).Substring(1, 1);
        }

        private void Fill_CondenserSerie()
        {
            cboCondenserSerie.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //clean the inactive record
            DataTable dtClearedCondenserSerie = Public.DSDatabase.Tables["CondenserSerie"];

            //loop through all conenser serie
            foreach (DataRow drCondenserSerie in dtClearedCondenserSerie.Rows)
            {
                string strIndex = drCondenserSerie["Motor"].ToString() + drCondenserSerie["CoilArr"];
                string strText = drCondenserSerie["Motor"].ToString().Replace("S", "V") + drCondenserSerie["CoilArr"] + " - " + drCondenserSerie["Description"];
                ComboBoxControl.AddItem(cboCondenserSerie, strIndex, strText);
            }
        }

        private void Fill_Motor(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM MotorModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["MotorID"].ToString(), dr["MotorID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_MotorMount(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM MotorMountModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["MotorMountID"].ToString(), dr["MotorMountID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_Fan(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM FanModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["FanID"].ToString(), dr["FanID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_FanGuard(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM FanGuardModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["FanGuardID"].ToString(), dr["FanGuardID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private static ComboBox GetPartCombobox()
        {
            var cbo = new ComboBox {DropDownStyle = ComboBoxStyle.DropDownList};
            return cbo;
        }

        private string getDefault_Motor(string voltageID)
        {
            string Default = Query.Select("SELECT * FROM CondenserMotor WHERE Motor = '" + Motor() + "' AND CoilArr = '" + CoilArr() + "' AND VoltageID = " + voltageID).Rows[0]["MotorID"].ToString();

            return Default;
        }

        private string getDefault_MotorMount(string voltageID)
        {
            string Default = Query.Select("SELECT * FROM CondenserMotorMount WHERE Motor = '" + Motor() + "' AND CoilArr = '" + CoilArr() + "' AND VoltageID = " + voltageID).Rows[0]["MotorMountID"].ToString();
           
            return Default;
        }

        private string getDefault_Fan(string voltageID)
        {
            string Default = Query.Select("SELECT * FROM CondenserFan WHERE Motor = '" + Motor() + "' AND CoilArr = '" + CoilArr() + "' AND VoltageID = " + voltageID).Rows[0]["FanID"].ToString();

            return Default;
        }

        private string getDefault_FanGuard(string voltageID)
        {
            string Default = Query.Select("SELECT * FROM CondenserFanGuard WHERE Motor = '" + Motor() + "' AND CoilArr = '" + CoilArr() + "' AND VoltageID = " + voltageID).Rows[0]["FanGuardID"].ToString();

            return Default;
        }

        private void Fill_ListOfParts()
        {
            lvParts.Items.Clear();

            DataTable dtValidVoltage = Query.Select("SELECT * FROM Voltage WHERE MotorCoilArr Like '%" + Motor() + CoilArr() + "%'");

            foreach (DataRow dr in dtValidVoltage.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvParts);

                myItem.SubItems[0].Text = dr["VoltageID"].ToString();
                myItem.SubItems[1].Text = dr["VoltDescription"].ToString();

                ComboBox cboMotor = GetPartCombobox();
                ComboBox cboMotorMount = GetPartCombobox();
                ComboBox cboFan = GetPartCombobox();
                ComboBox cboFanGuard = GetPartCombobox();

                Fill_Motor(ref cboMotor);
                Fill_MotorMount(ref cboMotorMount);
                Fill_Fan(ref cboFan);
                Fill_FanGuard(ref cboFanGuard);

                myItem.SubItems[2].Control = cboMotor;
                myItem.SubItems[3].Control = cboMotorMount;
                myItem.SubItems[4].Control = cboFan;
                myItem.SubItems[5].Control = cboFanGuard;

                lvParts.Items.Add(myItem);
            }

            LoadParts();

            lvParts.Refresh();
        }

        private void cboCondenserSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_ListOfParts();
        }

        private void LoadParts()
        {
            for (int i = 0; i < lvParts.Items.Count; i++)
            {
                string defaultMotor = getDefault_Motor(lvParts.Items[i].SubItems[0].Text);
                string defaultMotorMount = getDefault_MotorMount(lvParts.Items[i].SubItems[0].Text);
                string defaultFan = getDefault_Fan(lvParts.Items[i].SubItems[0].Text);
                string defaultFanGuard = getDefault_FanGuard(lvParts.Items[i].SubItems[0].Text);

                if (((ComboBox)lvParts.Items[i].SubItems[2].Control).FindString(defaultMotor) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[2].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[2].Control).FindString(defaultMotor);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[3].Control).FindString(defaultMotorMount) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[3].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[3].Control).FindString(defaultMotorMount);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[4].Control).FindString(defaultFan) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[4].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[4].Control).FindString(defaultFan);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[5].Control).FindString(defaultFanGuard) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[5].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[5].Control).FindString(defaultFanGuard);
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save these changes", "Êtes-vous sûr de vouloir savegarder ces changements", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteAll();

                if (Query.Execute(GetSaveQuery()))
                {
                    UpdateTableVersions();
                    Public.LanguageBox("Saving completed", "Sauvegarde completée");
                }
                else
                {
                    Public.LanguageBox("An error occured while saving", "Une erreur est survenue lors de la sauvegarde");
                }
            }
            else
            {
                Public.LanguageBox("Saving canceled", "Sauvegarde annulée");
            }
        }

        private void UpdateTableVersions()
        {
            Query.UpdateServerTableVersion("CondenserMotor");
            Query.UpdateServerTableVersion("CondenserMotorMount");
            Query.UpdateServerTableVersion("CondenserFan");
            Query.UpdateServerTableVersion("CondenserFanGuard");
        }


        private void DeleteAll()
        {
            string strMotor = Motor();
            string strCoilArr = CoilArr();

            string tsql = " DELETE FROM CondenserMotor WHERE Motor = '" + strMotor + "' AND CoilArr = '" + strCoilArr + "'";
            tsql += " DELETE FROM CondenserMotorMount WHERE Motor = '" + strMotor + "' AND CoilArr = '" + strCoilArr + "'";
            tsql += " DELETE FROM CondenserFan WHERE Motor = '" + strMotor + "' AND CoilArr = '" + strCoilArr + "'";
            tsql += " DELETE FROM CondenserFanGuard WHERE Motor = '" + strMotor + "' AND CoilArr = '" + strCoilArr + "'";

            Query.Execute(tsql);
        }

        private string GetSaveQuery()
        {
            string tsql = "";

            string strMotor = Motor();
            string strCoilArr = CoilArr();
      
            for (int i = 0; i < lvParts.Items.Count; i++)
            {
                string strVoltageID = lvParts.Items[i].SubItems[0].Text;

                tsql += " INSERT INTO CondenserMotor (Motor,CoilArr,VoltageID,MotorID) ";
                tsql += " VALUES ('" + strMotor + "','" + strCoilArr + "'," + strVoltageID + ",'" + lvParts.Items[i].SubItems[2].Control.Text + "') ";

                tsql += " INSERT INTO CondenserMotorMount (Motor,CoilArr,VoltageID,MotorMountID) ";
                tsql += " VALUES ('" + strMotor + "','" + strCoilArr + "'," + strVoltageID + ",'" + lvParts.Items[i].SubItems[3].Control.Text + "') ";

                tsql += " INSERT INTO CondenserFan (Motor,CoilArr,VoltageID,FanID) ";
                tsql += " VALUES ('" + strMotor + "','" + strCoilArr + "'," + strVoltageID + ",'" + lvParts.Items[i].SubItems[4].Control.Text + "') ";

                tsql += " INSERT INTO CondenserFanGuard (Motor,CoilArr,VoltageID,FanGuardID) ";
                tsql += " VALUES ('" + strMotor + "','" + strCoilArr + "'," + strVoltageID + ",'" + lvParts.Items[i].SubItems[5].Control.Text + "') ";

            }

            return tsql;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmCondenserParts_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }        
    }
}