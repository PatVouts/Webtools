using System;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmControlPanelAndOptionPriceIncrease : Form
    {
        public FrmControlPanelAndOptionPriceIncrease()
        {
            InitializeComponent();
        }

        private void cmdGoToConfirmation_Click(object sender, EventArgs e)
        {
            var confirmation = new FrmConfirmPriceChange(-1, Public.LanguageString("all control panel and options", "tous les panneaux de contrôle et options"));

            if (confirmation.ShowDialog() == DialogResult.Yes)
            {
                UpdatePrices(confirmation.GetReason());
            }

        }

        private decimal GetFactor()
        {
            return 1m + (numFactor.Value / 100m);
        }

        private void frmControlPanelAndOptionPriceIncrease_Load(object sender, EventArgs e)
        {

            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);
        }

        private void UpdatePrices(string strReason)
        {
            ThreadProcess.Start(Public.LanguageString("Saving in progress", "Sauvegarde en cours"));

            string serverDate = Public.GetServerDate().ToString(CultureInfo.InvariantCulture);


            string tsql = "";


            tsql += " UPDATE ControlPanel_PanelPrices SET Price = Price * " + GetFactor() + " WHERE Price <> -1000000";
            //TSQL += " UPDATE ControlPanel_PanelOptionPrices SET PanelPrice = PanelPrice * " + getFactor().ToString() + " WHERE PanelPrice <> -1000000";
            tsql += " UPDATE ControlPanel_PanelOptionPrices SET Price = Price * " + GetFactor() + " WHERE Price <> -1000000";
            tsql += @" INSERT INTO [PricingChangeLog]
                           ([Model]
                           ,[CurrentPrice]
                           ,[NewPrice]
                           ,[PercentageSelected]
                           ,[PercentageCalculated]
                           ,[UserModified]
                           ,[DateChanged]
                           ,[Reason]
                           ,[Username])
                     VALUES
                           ('Control Panel and option'
                           ,0
                           ,0
                           ," + numFactor.Value + @"
                           ," + numFactor.Value + @"
                           ,0
                           ,'" + serverDate + @"'
                           ,'" + strReason.Replace("'", "''") + @"'
                           ,'" + UserInformation.UserName + @"')";

            Query.Execute(tsql);

            Query.UpdateServerTableVersion("ControlPanel_PanelPrices");
            Query.UpdateServerTableVersion("ControlPanel_PanelOptionPrices");

            ThreadProcess.Stop();
            Focus();

            Public.LanguageBox("Saving complete", "Sauvegarde completée");

        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

     
    }
}