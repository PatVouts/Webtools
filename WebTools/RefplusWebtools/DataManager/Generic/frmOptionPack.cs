using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Data.OleDb;
using RefplusWebtools.DataManager.Costing;

namespace RefplusWebtools.DataManager.Generic
{
    /* This form lets the user take all pieces from syteline and arrange them
     * into an "option kit" with a price, quantities of every piece involved and 
     * a total price.  Since the price list is updated from syteline monthly, an option
     * to update the price of the kit is included.
     * */
    public partial class FrmOptionPack : Form
    {
        private readonly List<Quintuple> _piecesIDs = new List<Quintuple>();

        private bool _loaded;

        private string _connection;

        private const string ExcelDataBaseLocation = "P:\\Refplus\\Rpapps\\DataBase\\Syteline Data\\";

        private decimal _idOpenedKit = -1;

        private string _kitName;

        private DataTable _sytelinePiecesDataCopy;

        private DataTable _sytelinePiecesData;

        private Boolean _firstSaved;

        private readonly Boolean _openedWithKit;
        
        
        public FrmOptionPack()
        {
            _firstSaved = true;
            _openedWithKit = false;
            InitializeComponent();
            PartRadio.Checked = true;
        }
        public FrmOptionPack(string kitName)
        {
            _firstSaved = true;
            _openedWithKit = true;
            InitializeComponent();
            PartRadio.Checked = true;
            FillPiecesTable("");
            LoadKit(kitName);
        }

        private void frmOptionPack_Load(object sender, EventArgs e)
        {
            ThreadProcess.Start(Public.LanguageString("Loading pieces", "Chargement des pièces"));
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);

            rdioCurrent.Checked = true;

            FillKitDropDown();

            FillTypeDropDown();
            if(!_openedWithKit)
            {
                FillPiecesTable("");
                txtLoaded.Text = @"None";
                txtBoxFactor.Text = @"6.76";
                _loaded = true;
                _piecesIDs.Clear();
            }
            else
            {
                kitsComboBox.Text = _kitName;
            }


            
            ThreadProcess.Stop();
            Focus();
        }
        private void FillKitDropDown()
        {
            DataTable kits = Query.Select("Select KitName from dbo.KitInfo order by kitName ASC");
            kitsComboBox.Items.Clear();
            ComboBoxControl.AddItem(kitsComboBox, "0", "(new)");
            for (int i = 0; i < kits.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(kitsComboBox, (i + 1).ToString(CultureInfo.InvariantCulture), kits.Rows[i]["KitName"].ToString());
            }
            kitsComboBox.Text = @"(new)";

        }
        private void FillTypeDropDown()
        {
            DataTable types = Query.Select("Select Distinct(TypeName) from dbo.KitType");
            for (int i = 0; i < types.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(comboBox1, i.ToString(CultureInfo.InvariantCulture), types.Rows[i]["TypeName"].ToString());
            }
        }

        private void FillPiecesTable(string strWhere)
        {
            try
            {
                //For some reason (the fact that ACE isn't compatible with higher than 2007 excel?)
                //Means I can't create a table for scratch for this code... which is why the OLEDBDataAdapter refers to
                //CUCapacity... copied from another file that was made with the (?)correct Excel
                _connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelDataBaseLocation + "rel_SytelinePieces.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

                var objConn = new OleDbConnection(_connection);
                objConn.Open();
                var adp = new OleDbDataAdapter("SELECT * FROM CUCapacity Where [Part Number] IS NOT NULL" + strWhere, objConn);
                var ds = new DataSet();
                adp.Fill(ds);
                objConn.Close();
                if(_sytelinePiecesData != null)
                {
                    _sytelinePiecesData.Clear();
                }
                _sytelinePiecesData = ds.Tables[0];

                dgPieces.Rows.Clear();
                if (_sytelinePiecesData != null)
                {
                    _sytelinePiecesData = Public.SelectAndSortTable(_sytelinePiecesData, "", "Part number ASC");
                    if (_sytelinePiecesDataCopy == null)
                    {
                        _sytelinePiecesDataCopy = _sytelinePiecesData;
                    }
                    foreach (DataRow row in _sytelinePiecesData.Rows)
                    {
                        dgPieces.Rows.Add(row["Part Number"], row["Description"], row["Price"], row["Each"]);
                    }
                }

                _connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelDataBaseLocation + "PiecesSimon.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";


                objConn = new OleDbConnection(_connection);
                objConn.Open();
                adp = new OleDbDataAdapter("SELECT * FROM CUCapacity Where [Part Number] IS NOT NULL" + strWhere, objConn);
                ds = new DataSet();
                adp.Fill(ds);
                objConn.Close();
                _sytelinePiecesData = ds.Tables[0];


                foreach (DataRow row in _sytelinePiecesData.Rows)
                {
                   _sytelinePiecesDataCopy.Rows.Add(row["Part number"], row["Description"], row["price"], row["Each"]);
                   
                    dgPieces.Rows.Add(row["Part Number"], row["Description"], row["Price"], row["Each"]);
                }


                DateTime lastUpdate = File.GetLastWriteTime(ExcelDataBaseLocation + "rel_SytelinePieces.xlsx");
                txt_date.Text = lastUpdate.ToShortDateString();
            }
            catch (Exception ex)
            {
                Public.LanguageBox(ex.ToString(), "frmOptionPack FillPiecesTable");
            }
        }

        private void cmdAddKit_Click(object sender, EventArgs e)
        {
            if (dgPieces.SelectedRows.Count != 0)
            {
                var quant = new FrmQuantity(true, Convert.ToDecimal(dgPieces.SelectedRows[0].Cells[2].Value));
                quant.ShowDialog();
                decimal quantity = quant.GetQuantity();

                decimal price = quant.GetPrice();
                if (quantity == 0)
                {
                    ++quantity;
                    price = Convert.ToDecimal(dgPieces.SelectedRows[0].Cells[2].Value);
                }
                quant.Close();

                for (int i = 0; i < dgPieces.SelectedRows.Count; ++i )
                {
                    AddPiece(i, quantity, price);
                }
                SearchTextBox.Focus();
            }
            else
            {
                Public.LanguageBox("Please select a piece before clicking on add", "Veuillez sélectionner une pièce avant de l'ajouter à une trousse");
            }
        }

        private void AddPiece(int index, decimal quantity, decimal price)
        {
            bool exists = false;
            var existingPair = new Quintuple(0, "", "", "", "");

            //first, add the new piece and the quantity decided to the list of pieces to add to the kit whenever kit's done


            string idToFind = dgPieces.SelectedRows[index].Cells[0].Value.ToString();
            foreach (Quintuple piece in _piecesIDs)
            {
                if (piece.ID == idToFind)
                {
                    exists = true;
                    existingPair = piece;
                }
            }
            if (quantity > 0)
            {
                int i = 0;
                string idPiece = dgPieces.SelectedRows[index].Cells[0].Value.ToString();
                if (exists)
                {
                    _piecesIDs.Remove(existingPair);
                    _piecesIDs.Add(new Quintuple(quantity + existingPair.Quantity, idPiece, dgPieces.SelectedRows[index].Cells[1].Value.ToString(), price.ToString(CultureInfo.InvariantCulture), dgPieces.SelectedRows[index].Cells[3].Value.ToString()));
                    dgKits.Rows.Clear();
                    foreach (Quintuple piece in _piecesIDs)
                    {
                        
                        
                        dgKits.Rows.Add(piece.ID, piece.Description, piece.Unit, piece.Price, piece.Quantity, piece.Quantity * Convert.ToDecimal(piece.Price));
                        if (Convert.ToDecimal(price) != GetPrice(piece.ID) && idPiece == piece.ID)
                        {
                            dgKits.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dgKits.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                        ++i;
                    }

                }
                else
                {
                    _piecesIDs.Add(new Quintuple(quantity, idPiece.ToString(CultureInfo.InvariantCulture), dgPieces.SelectedRows[index].Cells[1].Value.ToString(), price.ToString(CultureInfo.InvariantCulture), dgPieces.SelectedRows[index].Cells[3].Value.ToString()));

                    dgKits.Rows.Add(idPiece.ToString(CultureInfo.InvariantCulture), GetDescFromID(idPiece), GetUnitFromID(idPiece), price.ToString(CultureInfo.InvariantCulture), quantity, quantity * price);
                    if (Convert.ToDecimal(price) != GetPrice(idPiece))
                    {
                        dgKits.Rows[dgKits.Rows.Count -1].DefaultCellStyle.BackColor = Color.Red;
                        dgKits.Rows[dgKits.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
                    }
                    ++i;
                }
                txtCostUpdated.Text = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void LoadKit(string kitName)
        {
            ThreadProcess.Start(Public.LanguageString("Loading Option kit", "Chargement de la trousse"));
            _firstSaved = false;
            _piecesIDs.Clear();
            //Load kit into the right table, then load the kit into the pieces list,
            //so that we can drop and recreate the kit as needed

            string sql = "Select * from dbo.KitInfo where KitName = '" + kitName + "'";

            DataTable dtKit = Query.Select(sql);
            _kitName = dtKit.Rows[0]["kitname"].ToString();
            txtLoaded.Text = _kitName;
            txtModified.Text = dtKit.Rows[0]["LastMod"].ToString();
            _idOpenedKit = Convert.ToDecimal(dtKit.Rows[0]["kitID"].ToString());
            txtBoxFactor.Text = dtKit.Rows[0]["factor"].ToString();
            txtCostNotUpdated.Text = decimal.Round(Convert.ToDecimal(dtKit.Rows[0]["Price"].ToString()), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            txtListPrice.Text = (Math.Ceiling(Convert.ToDecimal(txtCostNotUpdated.Text) * Convert.ToDecimal(txtBoxFactor.Text) * 100) / 100.0M).ToString(CultureInfo.InvariantCulture);
            comboBox1.Text = GetTypeFromID(dtKit.Rows[0]["KitType"].ToString());
            
            dtKit.Dispose();
            sql = "Select * from dbo.KitPiecesRelationship where kitID = " + _idOpenedKit + " order by [index] ASC";
            dtKit = Query.Select(sql);
            dgKits.Rows.Clear();
            foreach (DataRow row in dtKit.Rows)
            {

                string idPiece = row["PiecesID"].ToString();

                string amount = row["amount"].ToString();

                string desc = GetDescFromID(idPiece);
                string unit = GetUnitFromID(idPiece);
                string price = GetPrice(idPiece).ToString(CultureInfo.InvariantCulture);
                _piecesIDs.Add(new Quintuple(Convert.ToDecimal(amount), idPiece.ToString(CultureInfo.InvariantCulture), desc, price, unit));
                dgKits.Rows.Add(idPiece, desc, unit, row["Price"], row["Amount"], Convert.ToDecimal(row["Amount"]) * Convert.ToDecimal(row["Price"]));
                if (Convert.ToDecimal(row["Price"]) != GetPrice(idPiece))
                {
                    dgKits.Rows[dgKits.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                    dgKits.Rows[dgKits.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            txtCostUpdated.Text = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);

            foreach (DataGridViewColumn col in dgKits.Columns)
            {
                if (col.Name != "Column3")
                {
                    col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, false);
                }
            }

            DataTable accessNeeded =
                Query.Select("Select MinimumUserLevel from KitAccess where KitID = " + _idOpenedKit);
            if (accessNeeded.Rows.Count == 0)
            {
                Public.LanguageBox("That Option Kit was created before the Access Level was established.  Therefore, it's defaulted at 0.  Please validate if that is the correct value", "Ce kit d'options a été créé avant que le niveau d'accès minimal n'ai été ajouté.  Par conséquent, il sera mit par défaut à 0.  Veuillez valider. Merci");
                numericUpDown1.Value = 0;
            }
            else
            {
                numericUpDown1.Value = Convert.ToDecimal(accessNeeded.Rows[0]["MinimumUserLevel"]);
            }
            ThreadProcess.Stop();
            Focus();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //Delete the unit

            string kitToDelete =  (kitsComboBox.Text);
            _piecesIDs.Clear();
            if (UserInformation.Userlevel > 90)
            {

                string sql = "DELETE FROM dbo.KitInfo where kitName = '" + kitToDelete + "'";
                Query.Execute(
                    "Delete from dbo.KitPiecesRelationship where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleCompressorLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleMotorCFM where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleMotorLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleReceiverLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleBaseLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleWCCLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleGenericLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(
                    "Delete from dbo.moduleCoilLogic where kitID = (Select kitID from dbo.KitInfo where kitname = '" +
                    kitToDelete + "')");
                Query.Execute(sql);
            }
            ResetForm();
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSearchPieces_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                Public.LanguageBox("You must enter something in the search text for the search to work.", "Vous devez entrer un filtre dans la barre de recherche pour que celle-ci fonctionne.");
            }
            else
            {
                ThreadProcess.Start(Public.LanguageString("Searching", "Recherche"));
                if (DescriptionRadio.Checked)
                {
                    FillPiecesTable(" AND Description like '%" + SearchTextBox.Text + "%'");
                }
                else if (PartRadio.Checked)
                {
                    FillPiecesTable(" AND [part number] like '%" + SearchTextBox.Text + "%'");
                }
                else
                {
                    Public.LanguageBox("For the search to work, you need to select either parts number, or description, before clicking search", "Pour que la recherche fonctionne, vous devez choisir soit le numéro de pièce, soit la description, avant de cliquer sur recherche");
                }
                if (dgPieces.Rows.Count == 1)
                {
                    dgPieces.Rows[0].Selected = true;
                    dgPieces.Focus();
                }
                ThreadProcess.Stop();
                Focus();
            }
        }

        private void cmdSaveKit_Click(object sender, EventArgs e)
        {
            bool saved = false;
            bool save = true;
            bool saveAsNew = true;
            string typename = comboBox1.Text;
            var frmName = new FrmName((kitsComboBox.Text == @"(new)") ? "" : kitsComboBox.Text);
            string typeText = comboBox1.Text;
            string oldName = _kitName;

            if (_piecesIDs.Count == 0)
            {
                Public.LanguageBox("Please have at least one piece in your kit to save it", "Veuillez avoir au moins une pièce dans votre trousse pour la sauvegarder");
            }
            else if (comboBox1.Text == "")
            {
                Public.LanguageBox("Please have a type selected for your kit", "Veuillez sélectionner un type pour votre trousse d'outils");
            }
            //If we're editing an opened kit, the idOpenedKit isn't -1
            else
            {
                int nextID;
                
                if (!_firstSaved)
                {
                    if (MessageBox.Show(Public.LanguageString("Do you want to update this kit (yes) or save as a new copy (no)?", "Voulez-vous mettre la trousse ouverte à jour (oui) ou sauvegarder comme une nouvelle trousse (non)?"), @"Save", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        saveAsNew = false;
                        DataTable assoc = Query.Select("Select * From KitAssociation where KitID = " + _idOpenedKit);
                        nextID = GetNewKitID();
                        foreach (DataRow row in assoc.Rows)
                        {
                            Query.Execute("Insert Into KitAssociation VALUES ('" + nextID + "','" + row["type"] + "','" + row["Model"] + "')");
                        }
                    }
                }
                nextID = GetNewKitID();
                //Need to drop the tables and rewrite them from scratch.  If price
                //changed, need to warn user that the price WILL be updated by the save
                if (txtCostNotUpdated.Text != txtCostUpdated.Text && _idOpenedKit != -1 && saveAsNew)
                {
                    if (MessageBox.Show(Public.LanguageString("The price of the kit changed, if you save, price will be updated.  Do you still want to save", "Le prix changé entre la dernière sauvegarde de la trousse et le prix courant.  Si vous sauvegardez, le prix de la trousse changera.  Voulez-vous sauvegarder?"), Public.LanguageString("Price Change", "Changement de prix"), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        save = false;
                        txtCostUpdated.Text = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
                    }
                }
                string sql;
                if ((_idOpenedKit == -1 || !saveAsNew) && save)
                {
                    bool nameExists = false;
                    bool overwrite = false;
                    //Need to find a new kit and fill the tables 
                    frmName.ShowDialog();
                    if(frmName.Getsaved())
                    {
                        for (int i = 0; i < kitsComboBox.Items.Count; ++i)
                        {
                            if (frmName.Getname() == kitsComboBox.GetItemText(kitsComboBox.Items[i]))
                            {
                                nameExists = true;
                                break;
                            }
                        }
                        if (nameExists)
                        {
                            if(Public.LanguageQuestionBox("This name already exists. Do you want to overwrite it?", "Une trousse d'outil avec ce nom existe déjà dans la base.  Voulez-vous enregistrer par dessus?",MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                overwrite = true;
                                DataTable modelID = Query.Select("Select * from dbo.KitInfo where KitName = '" + frmName.Getname() + "'");
                                int kitID = Convert.ToInt32(modelID.Rows[0]["kitID"]);
                                Query.Execute("Delete from KitInfo where KitId = " + kitID);
                                Query.Execute("Delete from KitAccess where KitId = " + kitID);
                                Query.Execute("Delete from KitPiecesRelationship where KitId = " + kitID);
                            }
                        }

                        if(nameExists == false || overwrite)
                        {
                            _kitName = frmName.Getname();
                            sql = "Insert into dbo.KitInfo VALUES('" + nextID + "','" + _kitName + "'," + decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero) + ",1," + GetIDFromType() + ",'" + UserInformation.UserName.Substring(0, 2) + "', " + txtBoxFactor.Text + ")";
                            Query.Execute(sql);
                            sql = "Insert into dbo.KitAccess VALUES('" + nextID + "'," + numericUpDown1.Value + ")";
                            Query.Execute(sql);
                            foreach (Quintuple piece in _piecesIDs)
                            {
                                int i = 0;
                                int index = 0;
                                foreach (DataGridViewRow itm in dgKits.Rows)
                                {
                                    if (itm.Cells[1].Value.ToString() == piece.Description)
                                    {
                                        index = i;
                                    }
                                    ++i;
                                }
                                sql = "Insert into dbo.KitPiecesRelationship VALUES('" + nextID + "','" + piece.ID + "'," + piece.Quantity + "," + piece.Price + ", '" + piece.Description + "'," + index + ")";
                                Query.Execute(sql);
                            }
                            saved = true;

                            
                        }
                    }
                }
                else if (save)
                {
                    sql = "Delete from dbo.KitInfo where kitID = '" + _idOpenedKit + "'";
                    Query.Execute(sql);
                    sql = "Delete from dbo.kitPiecesRelationship where KitID = '" + _idOpenedKit + "'";
                    Query.Execute(sql);
                    sql = "Delete from dbo.kitAccess where KitID = '" + _idOpenedKit + "'";
                    Query.Execute(sql);

                    foreach (Quintuple piece in _piecesIDs)
                    {
                        int i = 0;
                        int index = 0;
                        foreach (DataGridViewRow itm in dgKits.Rows)
                        {
                            if (itm.Cells[1].Value.ToString() == piece.Description)
                            {
                                index = i;
                            }
                            ++i;
                        }
                        sql = "INSERT INTO dbo.KitPiecesRelationship VALUES('" + _idOpenedKit + "','" + piece.ID + "'," +
                              piece.Quantity + "," + piece.Price + ",'" + piece.Description + "'," + index +
                              ")";
                        Query.Execute(sql);

                    }
                    sql = "Insert into dbo.KitInfo VALUES('" + _idOpenedKit + "','" + _kitName + "'," + txtCostUpdated.Text + ",1," + GetIDFromType() + ", '" + UserInformation.UserName.Substring(0, 2) + "', " + txtBoxFactor.Text + ")";
                    Query.Execute(sql);
                    sql = "Insert into dbo.KitAccess VALUES('" + _idOpenedKit + "'," + numericUpDown1.Value + ")";
                    Query.Execute(sql);
                    saved = true;


                }

            }

            if (typeText.Contains("MODULE") && saved)
            {

                var frmLogic = new FrmLogic(_kitName, typename, !saveAsNew, oldName );
                frmLogic.ShowDialog();
            }

            frmName.Close();
        }

        /* Whenever the user wants to update the price of his kit, needs to restart from
         * scratch, take every single item, price, quantity, and add them together.
         * from there, change the price in the kit table and reswitch the "TOTAL CURRENT COST"
         * */
        private void cmdUpdatePrice_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Public.LanguageString("This operation cannot be reset.  If you click yes, you'll lose the previous price entry of the items in this kit.  Do you want to continue?", "Cette opération est irréversible.  Si vous appuyez sur oui, vous perdrez les anciens prix associés aux pièces dans cette trousse.  Voulez-vous continuer?"), Public.LanguageString("Confirm", "Confirmation"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                decimal newPrice = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero);
                txtCostNotUpdated.Text = newPrice.ToString(CultureInfo.InvariantCulture);
                txtListPrice.Text = (Convert.ToDecimal(txtCostNotUpdated.Text) * Convert.ToDecimal(txtBoxFactor.Text)).ToString(CultureInfo.InvariantCulture);
                string sql = "update dbo.KitInfo set Price = " + newPrice.ToString(CultureInfo.InvariantCulture) + " where KitID = '" + _idOpenedKit + "'";
                Query.Execute(sql);
                sql = "delete from dbo.KitPiecesRelationship where kitID = " + _idOpenedKit;
                Query.Execute(sql);
                foreach (Quintuple piece in _piecesIDs)
                {
                    int i = 0;
                    int index = 0;
                    foreach (DataGridViewRow itm in dgKits.Rows)
                    {
                        if (itm.Cells[1].Value.ToString() == piece.Description)
                        {
                            index = i;
                            break;
                        }
                        ++i;
                    }
                    sql = "insert into dbo.KitPiecesRelationship VALUES(" + _idOpenedKit + ",'" + piece.ID + "'," + piece.Quantity + "," + piece.Price + ",'" + piece.Description + "'," + index + ")";
                    Query.Execute(sql);
                }
            }
        }


        //Recalculates the price of a kit using the list of items we have in the kit
        private decimal RecalculatePrice()
        {
            decimal price = 0;
            foreach (Quintuple item in _piecesIDs)
            {
                price += item.Quantity * Convert.ToDecimal(item.Price);
            }
            return price;
        }


        //Gets the price of a piece using its id
        private decimal GetPrice(string id)
        {

            decimal price = 0;
            foreach (DataRow row in _sytelinePiecesDataCopy.Rows)
            {

                if (row["Part Number"].ToString() == id)
                {
                    price = Convert.ToDecimal(row["Price"].ToString());
                    break;
                }
            }
            return price;

        }

        private void kitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kitsComboBox.Text == @"(new)" && _loaded && txtLoaded.Text != @"None")
            {
                if (MessageBox.Show(Public.LanguageString("If you select the new entry, any change you made on the current kit will be lost.  Proceed?", "Si vous choississez une nouvelle trousse d'options, toutes les modifications sur l'ancienne trousse seront perdues.  Continuer?"), Public.LanguageString("Clear all Confirmation", "Confirmation pour tout effacer"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _loaded = false;
                    ResetForm();
                    _loaded = true;
                    
                }
                else
                {
                    kitsComboBox.Text = _kitName;
                    
                }
            }
            if(txtLoaded.Text != "")
            {
                LoadKit(kitsComboBox.Text);
            }

            
        }




        //Conversion both ways between ID and typename for type
        private int GetIDFromType()
        {
            DataTable type = Query.Select("Select typeID from dbo.KitType where TypeName = '" + comboBox1.Text + "'");
            return Convert.ToInt32(type.Rows[0]["typeID"].ToString());
        }

        private static string GetTypeFromID(string id)
        {
            DataTable type = Query.Select("Select typeName from dbo.KitType where TypeID = " + id + "");
            return type.Rows[0]["typeName"].ToString();
        }


        //Select the list and get the last kit id from the list to be able to find the next possible ID
        private static int GetNewKitID()
        {
            int ret;
            DataTable kits = Query.Select("Select Max(kitId) as ID from dbo.kitinfo");
            if (kits.Rows[0]["ID"].ToString() == "")
            {
                ret = 0;
            }
            else
            {
                ret = Convert.ToInt32(kits.Rows[0]["ID"].ToString()) + 1;
            }
            return ret;
        }


        //Checking the costs updated and not updated to color the text in red as needed
        private void Colortext()
        {
            if (txtCostNotUpdated.Text != txtCostUpdated.Text && kitsComboBox.Text != @"(new)" && txtCostNotUpdated.Text + @"0" != txtCostUpdated.Text)
            {
                txtCostNotUpdated.BackColor = Color.Red;
                txtCostUpdated.BackColor = Color.Red;
            }
            else
            {
                txtCostNotUpdated.BackColor = Color.White;
                txtCostUpdated.BackColor = Color.White;
            }
        }


        // Just clearing the form.
        private void ResetForm()
        {
            _piecesIDs.Clear();
            txtCostUpdated.Text = @"0";
            txtCostNotUpdated.Text = @"0";
            txtListPrice.Text = @"0";
            _idOpenedKit = -1;
            comboBox1.SelectedIndex = -1;
            dgKits.Rows.Clear();
            if (kitsComboBox.Text != @"(new)" && txtLoaded.Text == @"None")
            {
                kitsComboBox.Text = @"(new)";
            }
            _firstSaved = true;
            txtLoaded.Text = @"None";
            txtModified.Text = "";
            txtBoxFactor.Text = @"6.76";
            FillKitDropDown();

        }


        // Passing through the collection to see the description of a specific piece.
        private string GetDescFromID(string id)
        {
            string desc = "";
            foreach (DataRow row in _sytelinePiecesDataCopy.Rows)
            {
                if (row["Part Number"].ToString() == id)
                {
                    desc = row["Description"].ToString();
                    break;
                }
            }
            return desc;
        }


        // Passing through the collection to see the unit of a specific piece.
        private string GetUnitFromID(string id)
        {
            string unit = "";
            foreach (DataRow row in _sytelinePiecesDataCopy.Rows)
            {
                if (row[0].ToString() == id)
                {
                    unit = row["Each"].ToString();
                    break;
                }
            }
            return unit;
        }


        //when the text change, reverify coloring
        private void txtCostNotUpdated_TextChanged(object sender, EventArgs e)
        {
            Colortext();
        }

        private void txtCostUpdated_TextChanged(object sender, EventArgs e)
        {
            Colortext();
        }


        // when you remove a piece, it has to be deleted from both the grid and the piece collection (so that whenever
        //you save it's not added again
        private void cmd_remove_Click(object sender, EventArgs e)
        {
            var existingPair = new Quintuple(0, "", "", "", "");
            foreach (Quintuple piece in _piecesIDs)
            {
                if (piece.ID == dgKits.SelectedRows[0].Cells[0].Value.ToString())
                {
                    existingPair = piece;
                }
            }
            _piecesIDs.Remove(existingPair);
            foreach (DataGridViewRow row in dgKits.Rows)
            {
                if (row.Cells[0].Value.ToString() == dgKits.SelectedRows[0].Cells[0].Value.ToString())
                {
                    dgKits.Rows.Remove(row);
                }
            }
            txtCostUpdated.Text = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            txtListPrice.Text = (Convert.ToDecimal(txtCostNotUpdated.Text == ""? txtCostUpdated.Text: txtCostNotUpdated.Text) * Convert.ToDecimal(txtBoxFactor.Text)).ToString(CultureInfo.InvariantCulture);
        }


        //  When you reinitialize that table, it refills the table from scratch with no where clause (to get everything)
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadProcess.Start(Public.LanguageString("Reinitializing", "Réinitialisation"));
            FillPiecesTable("");
            ThreadProcess.Stop();
            Focus();
        }


        //Double-clicking = clicking on "add pieces to kit"
        private void dgPieces_DoubleClick(object sender, EventArgs e)
        {
            cmdAddKit_Click(sender, e);
        }


        //When the user clicks on this, it changes which price is shown in the table for the kit.
        //So it changes, line by line, and makes sure that the price didn't change.  If it did, the whole line is in
        //red.
        private void ChangePriceForm()
        {
            ThreadProcess.Start(Public.LanguageString("Loading", "Chargement"));
            int i = 0;
            if (rdioCurrent.Checked)
            {
                rdioUpdated.Checked = false;

                dgKits.Rows.Clear();
                foreach (Quintuple item in _piecesIDs)
                {

                    dgKits.Rows.Add(item.ID, item.Description, item.Unit, item.Price, item.Quantity, Convert.ToDecimal(item.Price) * item.Quantity);
                    if (Convert.ToDecimal(item.Price) != GetSavedPrice(item.ID))
                    {
                        dgKits.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgKits.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    }
                    ++i;
                }

            }
            else
            {
                dgKits.Rows.Clear();
                foreach (Quintuple item in _piecesIDs)
                {
                    dgKits.Rows.Add(item.ID, item.Description, item.Unit, GetSavedPrice(item.ID), item.Quantity, GetSavedPrice(item.ID) * item.Quantity);
                    if (Convert.ToDecimal(item.Price) != GetSavedPrice(item.ID))
                    {
                        dgKits.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgKits.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    ++i;
                }
            }
            ThreadProcess.Stop();
            Focus();

        }

        //This is just to get the saved price from within the database.  Like that we can compare the saved price
        //From the database to the current price in the "syteline pieces" document
        private decimal GetSavedPrice(string id)
        {
            decimal price = 0;

            string sql = "Select * from dbo.KitPiecesRelationship where kitID = " + _idOpenedKit + " order by [index] ASC";
            DataTable dtKit = Query.Select(sql);
            foreach (DataRow row in dtKit.Rows)
            {
                if (id == row["PiecesID"].ToString())
                {
                    price = Convert.ToDecimal(row["Price"]);
                    break;
                }
            }

            return price;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable assoc = Query.Select("Select * From KitAssociation where kitID = " + _idOpenedKit.ToString(CultureInfo.InvariantCulture));
            DataTable moduleType =
    Query.Select(
        "select *, TypeName from kitInfo INNER JOIN kitType on kitInfo.kitType = kitType.TypeID and kitInfo.kitName = '" +
        _kitName + "'");
            string module = moduleType.Rows[0]["TypeName"].ToString();
            if(!module.Contains("MODULE"))
            {
                if (assoc.Rows.Count > 0)
                {
                    var models = new List<string>();
                    foreach (DataRow row in assoc.Rows)
                    {
                        models.Add(row["Model"].ToString());
                    }
                    var frm = new FrmModelList(_idOpenedKit.ToString(CultureInfo.InvariantCulture), "kit", models, assoc.Rows[0]["type"].ToString());
                    frm.ShowDialog();
                }
                else
                {
                    var frm = new FrmModelSelector(_idOpenedKit.ToString(CultureInfo.InvariantCulture),"kit",false);
                    frm.ShowDialog();
                }
            }
        }


        private void dgPieces_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdAddKit_Click(sender, e);
            }
        }

        private void txtBoxFactor_TextChanged(object sender, EventArgs e)
        {
            if(txtCostNotUpdated.Text != "" && txtBoxFactor.Text != "")
            {
                txtListPrice.Text = (Math.Ceiling(Convert.ToDecimal(txtCostNotUpdated.Text) * Convert.ToDecimal(txtBoxFactor.Text) * 100) / 100.0M).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void dgKits_DoubleClick(object sender, EventArgs e)
        {
            if (dgKits.SelectedRows.Count == 1)
            {
                var quant = new FrmQuantity(false, Convert.ToDecimal(dgKits.SelectedRows[0].Cells[3].Value.ToString()));
                quant.ShowDialog();
                decimal quantity = quant.GetQuantity();
                decimal price = quant.GetPrice();
                if(quantity == 0)
                {
                    quantity = Convert.ToDecimal(dgKits.SelectedRows[0].Cells[4].Value);
                }
                if (price == 0)
                {
                    price = Convert.ToDecimal(dgKits.SelectedRows[0].Cells["Column5"].Value);
                }
                quant.Close();
                dgKits.SelectedRows[0].Cells["Column2"].Value = quantity;
                dgKits.SelectedRows[0].Cells["Column5"].Value = price;
                dgKits.SelectedRows[0].Cells["Column6"].Value = Convert.ToDecimal(dgKits.SelectedRows[0].Cells["Column2"].Value) * Convert.ToDecimal(dgKits.SelectedRows[0].Cells["Column5"].Value);

                foreach (Quintuple piece in _piecesIDs)
                {
                    if (piece.ID == dgKits.SelectedRows[0].Cells["Column1"].Value.ToString())
                    {
                        piece.Quantity = quantity;
                        piece.Price = price.ToString(CultureInfo.InvariantCulture);
                    }
                }
                txtCostUpdated.Text = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            }
            else if (dgKits.SelectedRows.Count == 0)
            {
                Public.LanguageBox("Please select one unit to change its quantity", "Veuillez sélectionner une unité pour pouvoir en changer la quantité");
            }
            else
            {
                Public.LanguageBox("Please select one unit to change its quantity", "Veuillez sélectionner une unité pour pouvoir en changer la quantité");
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSearchPieces_Click(sender, e);
            }
        }

        private void dgKits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgKits_DoubleClick(sender,e);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                for (int i = dgKits.SelectedRows.Count - 1; i >= 0; --i)
                {
                    for (int j = _piecesIDs.Count - 1; j >= 0; --j)
                    {
                        if (_piecesIDs[j].ID == dgKits.SelectedRows[i].Cells["Column1"].Value.ToString())
                        {
                            _piecesIDs.Remove(_piecesIDs[j]);
                        }
                    }
                }
                dgKits.Refresh();
                txtCostUpdated.Text = decimal.Round(RecalculatePrice(), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangePriceForm();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangePriceForm();
        }

        private void btnSytelineOpen_Click(object sender, EventArgs e)
        {
            OpenExcel("rel_SytelinePieces.xlsx");
        }

        private void btnManualListOpen_Click(object sender, EventArgs e)
        {
            OpenExcel("PiecesSimon.xlsx");
        }

        private void OpenExcel(string fileName)
        {
            Type tp = Type.GetTypeFromProgID("Excel.Application");
            object xlApp = Activator.CreateInstance(tp);

            var parameter = new object[1];
            parameter[0] = true;
            xlApp.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, xlApp, parameter);

            //~~> Get the xlWb collection
            object xlWbCol = xlApp.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlApp, null);

            System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

            //~~> Create a new xlWb
            xlWbCol.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, xlWbCol, new object[] { ExcelDataBaseLocation + @"\" + fileName  });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Contains("MODULE"))
            {
                txtBoxFactor.Visible = false;
                lblFactor.Visible = false;
                sMinimumAccessLevel.Visible = false;
                numericUpDown1.Visible = false;
                cmdChoose.Visible = false;
                label4.Visible = false;
                label3.Visible = false;
                txtListPrice.Visible = false;
                btnLogic.Visible = true;
            }
            else
            {
                txtBoxFactor.Visible = true;
                lblFactor.Visible = true;
                sMinimumAccessLevel.Visible = true;
                numericUpDown1.Visible = true;
                cmdChoose.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                txtListPrice.Visible = true;
                btnLogic.Visible = false;
            }
        }

        private void btnLogic_Click(object sender, EventArgs e)
        {
            DataTable moduleType =
                Query.Select(
                    "select *, TypeName from kitInfo INNER JOIN kitType on kitInfo.kitType = kitType.TypeID and kitInfo.kitName = '" +
                    _kitName + "'");
            string module = moduleType.Rows[0]["TypeName"].ToString();
            if (_idOpenedKit != -1 && module.Contains("MODULE"))
            {
                var logic = new FrmLogic(_kitName, module, false, "");
                logic.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var currentIndex = dgKits.SelectedRows[0].Index;
            var item = dgKits.Rows[currentIndex];
            if (currentIndex > 0)
            {
                dgKits.Rows.RemoveAt(currentIndex);
                dgKits.Rows.Insert(currentIndex - 1, item);
                dgKits.Rows[currentIndex - 1].Selected = true;
                dgKits.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var currentIndex = dgKits.SelectedRows[0].Index;
            var item = dgKits.Rows[currentIndex];
            if (currentIndex < dgKits.Rows.Count - 1)
            {
                dgKits.Rows.RemoveAt(currentIndex);
                dgKits.Rows.Insert(currentIndex + 1, item);
                dgKits.Rows[currentIndex + 1].Selected = true;
                dgKits.Focus();
            }
        }
    }
}
