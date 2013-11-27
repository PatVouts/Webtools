using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Windows.Forms;
using GlacialComponents.Controls;
using RefplusWebtools.DataManager.Generic;
using Color = System.Drawing.Color;
using DataTable = System.Data.DataTable;


namespace RefplusWebtools.DataManager.Costing
{
    //This form, QUITE massive, is used to generate the pricing of a certain unit.  This form is so big because it tries to let ALL unit types to be created here.  So it's 12 forms in 1.  
    //Most logic is handled by the combobox with the type of the unit in it, passed through a switch, then all different units are treated their own "special" way
    public partial class FrmCosting : Form
    {
        //
        private string _draggedPrice;
        private string _draggedName;
        private int _loadedMachineID;
        private string _loadedMachineName;
        //This list is to keep the compressor ratios for condensing unit
        private List<Pair> _compressorRatiosForCondensingUnits;
        private IEnumerable<BalancingData> _globalBalancing; 


        public FrmCosting()
        {
            InitializeComponent();
            
        }

        private void FrmCosting_Load(object sender, EventArgs e)
        {
            RefreshForm();
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
            _compressorRatiosForCondensingUnits = new List<Pair>();
        }

        private void RefreshForm()
        {
            FillPiecesAndKit();
            FillTypes();
            //Reload the unit selected (in case the module edited was used for this machine)
            LoadUnit(cmb_Unit.Text);
        }
        public void FillPiecesAndKit()
        {
            cmb_Types.Items.Clear();
            DataTable dtKits = Query.Select("Select * from Types order by UnitType");
            foreach (DataRow drKits in dtKits.Rows)
            {
                cmb_Types.Items.Add(drKits["UnitType"].ToString());
            }

        }
        public void FillTypes()
        {
            tv_Kits.Nodes.Clear();
            DataTable dtPieces = Query.Select("SELECT kitType.TypeName as type, info.[KitID] as ID, [KitName],info.[Price] as kPrice, description, pieces.PiecesID, pieces.Amount, pieces.Price FROM [kitInfo] as info inner join KitPiecesRelationship as pieces on pieces.KitID = info.KitID inner join kitType on kitType.TypeID = info.kitType where info.Active = 1 order by info.KitType, kitName");
            string kitID = dtPieces.Rows[0]["ID"].ToString();
            string kitName = "";
            if (dtPieces.Rows[0]["type"].ToString().Contains("MODULE"))
            {
                kitName = dtPieces.Rows[0]["Type"] + " - ";
            }
            kitName += dtPieces.Rows[0]["KitName"] + @" - " + dtPieces.Rows[0]["kPrice"];
            var nodeKit = new TreeNode
            {

                Text = kitName,
                Tag = kitID
            };

            foreach (DataRow drPieces in dtPieces.Rows)
            {
                if (kitID != drPieces["ID"].ToString())
                {
                    tv_Kits.Nodes.Add(nodeKit);
                    kitName = "";
                    kitID = drPieces["ID"].ToString();
                    if (drPieces["type"].ToString().Contains("MODULE"))
                    {
                        kitName = drPieces["Type"] + " - ";
                    }
                    kitName += drPieces["KitName"] + @" - " + drPieces["kPrice"];
                    nodeKit = new TreeNode
                    {
                        Text = kitName,
                        Tag = kitID
                    };
                }

                var nodePiece = new TreeNode
                {
                    Text = drPieces["PiecesID"] + @" - " + ReplaceApostrophes(drPieces["Description"].ToString()) + @" -  Qty: " + drPieces["Amount"] + @" - Total Price :" + (Convert.ToDecimal(drPieces["Price"]) * Convert.ToDecimal(drPieces["Amount"])).ToString("0.00"),
                    Tag = drPieces["PiecesID"].ToString()
                };
                nodeKit.Nodes.Add(nodePiece);
            }
            tv_Kits.Nodes.Add(nodeKit);
        }

        private void cmb_Types_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtMachinesFound = Query.Select("Select * from Machine where MachineType = '" + cmb_Types.Text + "' order by MachineName");
            cmb_Unit.Items.Clear();
            foreach (DataRow row in dtMachinesFound.Rows)
            {
                cmb_Unit.Items.Add(row["MachineName"]);
            }
            switch (cmb_Types.Text)
            {
                case ("Condensing Unit"):
                    grpInfoCU.Visible = true;
                    grpNameCU.Visible = true;
                    grpInfo2CU.Visible = true;
                    grpCoil.Visible = true;
                    break;
                default:
                    grpInfoCU.Visible = false;
                    grpInfo2CU.Visible = false;
                    grpNameCU.Visible = false;
                    grpCoil.Visible = false;
                    break;
            }
        }

        private void tv_Kits_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (((TreeNode) e.Item).Parent != null)
            {
                Public.LanguageBox("You cannot move an item inside a kit to a machine.  Please select the kit itself. Thank you", "Vous ne pouvez ajouter un élément d'une trousse à une machine.  Veuillez sélectionner la trousse elle-même. Merci");
            }
            else
            {
             
                _draggedName =
                    (((TreeNode)e.Item).Text.Substring(0, ((TreeNode)e.Item).Text.LastIndexOf(" - ", StringComparison.Ordinal)));
                _draggedPrice =
                    (((TreeNode)e.Item).Text.Substring(((TreeNode)e.Item).Text.LastIndexOf(" - ", StringComparison.Ordinal) + 3));
                tv_Kits.DoDragDrop(e.Item,DragDropEffects.Copy);

            }
        }



        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string name = _draggedName.Substring(_draggedName.IndexOf(" - ", StringComparison.Ordinal) + 3);
            string type = _draggedName.Substring(0, _draggedName.IndexOf(" - ", StringComparison.Ordinal));
            Boolean existing = false;
            foreach (ListViewItem litem in lv_Pieces.Items)
            {
                if (litem.SubItems[1].Text == name)
                {
                    existing = true;
                    litem.SubItems[3].Text = (Convert.ToDecimal(litem.SubItems[3].Text) + 1).ToString(CultureInfo.InvariantCulture);
                    litem.SubItems[4].Text =
                        (Convert.ToDecimal(litem.SubItems[3].Text) * Convert.ToDecimal(litem.SubItems[2].Text)).ToString(CultureInfo.InvariantCulture);
                    
                }
            }
            if(!existing)
            {
                var myItem = new ListViewItem(type);
                myItem.SubItems.Add(name);
                myItem.SubItems.Add(_draggedPrice);
                myItem.SubItems.Add("1");
                myItem.SubItems.Add(_draggedPrice);
                lv_Pieces.Items.Add(myItem);
                
                if (cmb_Types.Text.Contains("Condensing Unit") && type.Contains("COMPRESSOR"))
                {
                    DataTable compressor = Query.Select("Select * from moduleCompressorLogic where moduleID = (Select kitID from kitInfo where kitname like '%" + name + "%')");

                    // if the compressor rows here == 0, means the voltage or refrigerant id is NOT ok for the compressor chosen
                    if (compressor.Rows.Count != 0)
                    {
                        DataTable pieces =
                            Query.Select(
                                "Select PieceName from MachinePieces where machineID = (Select machineID from machine where machineName = '" +
                                _loadedMachineName + "')");
                        var receiverNames = new List<string>();
                        foreach (DataRow piece in pieces.Rows)
                        {
                            if (piece["PieceName"].ToString().Contains("RECEIVER"))
                            {
                                receiverNames.Add(piece["PieceName"].ToString().Substring(22));
                            }
                        }
                        string receiverSize;
                        if (receiverNames.Count > 0)
                        {
                            DataTable receiver =
                                Query.Select(
                                    "Select * from moduleReceiverLogic where moduleID = (Select kitID from kitInfo where kitName like '%" +
                                    receiverNames[0] + "')");
                             receiverSize = receiver.Rows.Count == 0
                                ? "NONE"
                                : receiver.Rows[0]["Size"].ToString();
                        }
                        else
                        {
                            receiverSize = "??";
                        }

                        var myComp = new GLItem(lvCompressor);
                            myComp.SubItems[0].Text = compressor.Rows[0]["CompressorName"].ToString();
                            myComp.SubItems[1].Text = compressor.Rows[0]["voltageID"].ToString();
                            myComp.SubItems[2].Text = compressor.Rows[0]["RefrigerantID"].ToString(); 
                            myComp.SubItems[3].Text = compressor.Rows[0]["LiquidValue"].ToString();
                            myComp.SubItems[4].Text = compressor.Rows[0]["SuctionValue"].ToString();
                            myComp.SubItems[5].Text = compressor.Rows[0]["DischargeValue"].ToString();
                            myComp.SubItems[6].Text = receiverSize;
                            var frmRatio = new FrmRatio();
                            frmRatio.ShowDialog();
                            myComp.SubItems[7].Text = frmRatio.GetRatio().ToString(CultureInfo.InvariantCulture);
                            var toAdd = new Pair(myComp.SubItems[7].Text, myComp.SubItems[0].Text);
                            _compressorRatiosForCondensingUnits.Add(toAdd);
                            lvCompressor.Items.Add(myComp);
                            lvCompressor.Refresh();
                            frmRatio.Close();

                    }
                }

                
                _draggedName = "";
                _draggedPrice = "";
                lv_Pieces.Refresh();
            }
            if (cmb_Types.Text == @"Condensing Unit" && (type.Contains("COMPRESSOR") || type.Contains("COIL") || type.Contains("MOTOR")))
            {
                lvBalancing.Items.Clear();
                lvSecondaryTable.Items.Clear();
                _globalBalancing = null;
                lvBalancing.Refresh();
                lvSecondaryTable.Refresh();
            }
            GenerateTechnical();
            UpdatePrices(GetMaterialCost());
            if (comboBox1.Text == @"A")
            {
                num_Weight.Value = CalculateWeight();
                comboBox1.Text = @"A";
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (lv_Pieces.SelectedItems.Count == 0 && (e.KeyCode == Keys.Add ||e.KeyCode == Keys.Subtract ||e.KeyCode == Keys.Delete ) )
            {
                Public.LanguageBox("Please select a unit before using a shortcut key.  Thank you",
                    "Veuillez sélectionner une unité avant d'utiliser une touche clavier.  Merci!");
            }
            else
            {
                switch (e.KeyCode)
                {
                    case (Keys.Add):
                        PlusOneOnSelected();
                        break;
                    case (Keys.Subtract):
                        MinusOneOnSelected();
                        break;
                    case (Keys.Delete):
                        if (lv_Pieces.SelectedItems[0].SubItems[0].ToString().Contains("COMPRESSOR") &&
                            cmb_Types.Text.Contains("Condensing Unit"))
                        {
                            if (lvCompressor.Items.Count == 1 || lvCompressor.Items.Count == 0)
                            {
                                lvCompressor.Items.Clear();
                                _compressorRatiosForCondensingUnits.Clear();
                                lvCompressor.Refresh();
                            }
                            else
                            {
                                DataTable compressor =
                                    Query.Select(
                                        "Select * from moduleCompressorLogic where moduleID = (Select kitID from kitInfo where kitname like '%" +
                                        lv_Pieces.SelectedItems[0].SubItems[1].Text + "%')");
                                int indexToRemove = 0;
                                int toRemove = Convert.ToInt32(lv_Pieces.SelectedItems[0].SubItems[3].Text);
                                for (int i = 0; i < toRemove; ++i)
                                {
                                    int j = 0;
                                    foreach (GLItem itm in lvCompressor.Items)
                                    {
                                        if (itm.Text == compressor.Rows[0]["compressorName"].ToString())
                                        {
                                            indexToRemove = j;
                                            break;

                                        }
                                        ++j;
                                    }
                                    lvCompressor.Items.RemoveAt(indexToRemove);
                                    var pairToRemove = new Pair();
                                    foreach (Pair ratio in _compressorRatiosForCondensingUnits)
                                    {
                                        if (ratio.Second.ToString() == compressor.Rows[0]["compressorName"].ToString())
                                        {
                                            pairToRemove = ratio;
                                            break;
                                        }
                                    }
                                    _compressorRatiosForCondensingUnits.Remove(pairToRemove);
                                }
                                lvCompressor.Refresh();
                            }
                        }
                        if ((lv_Pieces.SelectedItems[0].SubItems[0].ToString().Contains("COMPRESSOR") ||
                             lv_Pieces.SelectedItems[0].SubItems[0].ToString().Contains("COIL") ||
                             lv_Pieces.SelectedItems[0].SubItems[0].ToString().Contains("MOTOR")) &&
                            cmb_Types.Text.Contains("Condensing Unit"))
                        {
                            lvBalancing.Items.Clear();
                            lvSecondaryTable.Items.Clear();
                            
                            lvBalancing.Refresh();
                            lvSecondaryTable.Refresh();

                        }
                        lv_Pieces.SelectedItems[0].Remove();
                        ResetCondensing();
                        GenerateTechnical();

                        break;
                }

                if (comboBox1.Text == @"A")
                {
                    num_Weight.Value = CalculateWeight();
                    comboBox1.Text = @"A";
                }

                UpdatePrices(GetMaterialCost());
            }
        }

        private void MinusOneOnSelected()
        {
            string savedType = lv_Pieces.SelectedItems[0].SubItems[0].ToString();
            if (lv_Pieces.SelectedItems[0].SubItems[3].Text == @"1")
            {
                if (Public.LanguageQuestionBox("Do you really want to remove this module from the machine?", "Voulez-vous vraiment enlever ce module de la machine?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (lv_Pieces.SelectedItems[0].SubItems[0].ToString().Contains("COMPRESSOR") &&
                        cmb_Types.Text.Contains("Condensing Unit"))
                    {
                        if (lvCompressor.Items.Count == 1)
                        {
                            lvCompressor.Items.Clear();
                        }
                        else
                        {
                            DataTable compressor = Query.Select("Select * from moduleCompressorLogic where moduleID = (Select kitID from kitInfo where kitname like '%" + lv_Pieces.SelectedItems[0].SubItems[1] + "%')");
                            foreach (ListViewItem itm in lvCompressor.Items)
                            {
                                if (itm.SubItems[0].ToString() == compressor.Rows[0]["compressorName"].ToString())
                                {
                                    itm.Remove();
                                }
                            }
                        }
                    }
                    lv_Pieces.SelectedItems[0].Remove();

                }
            }
            else
            {
                lv_Pieces.SelectedItems[0].SubItems[3].Text = (Convert.ToDecimal(lv_Pieces.SelectedItems[0].SubItems[3].Text) - 1).ToString(CultureInfo.InvariantCulture);
                lv_Pieces.SelectedItems[0].SubItems[4].Text = (Convert.ToDecimal(lv_Pieces.SelectedItems[0].SubItems[3].Text) * Convert.ToDecimal(lv_Pieces.SelectedItems[0].SubItems[2].Text)).ToString(CultureInfo.InvariantCulture);
                UpdatePrices(GetMaterialCost());
                //if the piece we just removed was a compressor and that we are in the condensing unit type, we need to remove compressors to the list of compressors (Glacial Items)
                if (lv_Pieces.SelectedItems[0].SubItems[0].Text.Contains("COMPRESSOR") &&
                    cmb_Types.Text.Contains("Condensing Unit"))
                {
                    DataTable compressor = Query.Select("Select * from moduleCompressorLogic where moduleID = (Select KitID from kitInfo where kitName = '" + lv_Pieces.SelectedItems[0].SubItems[1].Text + "')");
                    RemoveOneCompressor(compressor.Rows[0]["compressorName"].ToString());
                    
                }
            }
            if ((savedType.Contains("COMPRESSOR") || savedType.Contains("MOTOR") || savedType.Contains("COIL")) &&
                    cmb_Types.Text.Contains("Condensing Unit"))
            {
                lvBalancing.Items.Clear();
                lvSecondaryTable.Items.Clear();
                _globalBalancing = null;
                lvBalancing.Refresh();
                lvSecondaryTable.Refresh();
            }
            UpdatePrices(GetMaterialCost());
            GenerateTechnical();

        }
        private void PlusOneOnSelected()
        {
            lv_Pieces.SelectedItems[0].SubItems[3].Text = (Convert.ToDecimal(lv_Pieces.SelectedItems[0].SubItems[3].Text) + 1).ToString(CultureInfo.InvariantCulture);
            lv_Pieces.SelectedItems[0].SubItems[4].Text = (Convert.ToDecimal(lv_Pieces.SelectedItems[0].SubItems[3].Text) * Convert.ToDecimal(lv_Pieces.SelectedItems[0].SubItems[2].Text)).ToString(CultureInfo.InvariantCulture);
            UpdatePrices(GetMaterialCost());

            //if the piece we just added was a compressor and that we are in the condensing unit type, we need to add compressors to the list of compressors (Glacial Items)
            if (lv_Pieces.SelectedItems[0].SubItems[0].Text.Contains("COMPRESSOR") &&
                cmb_Types.Text.Contains("Condensing Unit"))
            {
                DataTable compressor = Query.Select("Select * from moduleCompressorLogic where moduleID = (Select KitID from kitInfo where kitName = '" + lv_Pieces.SelectedItems[0].SubItems[1].Text + "')");
                AddOneCompressor(compressor.Rows[0]["compressorName"].ToString());

            }
            if ((lv_Pieces.SelectedItems[0].SubItems[0].Text.Contains("COMPRESSOR")  || lv_Pieces.SelectedItems[0].SubItems[0].Text.Contains("MOTOR") || lv_Pieces.SelectedItems[0].SubItems[0].Text.Contains("COIL"))  &&
                cmb_Types.Text.Contains("Condensing Unit"))
            {
                lvBalancing.Items.Clear();
                lvSecondaryTable.Items.Clear();
                _globalBalancing = null;
                lvBalancing.Refresh();
                lvSecondaryTable.Refresh();
            }
            GenerateTechnical();
        }

        private void GenerateTechnical()
        {
            switch (cmb_Types.Text)
            {
                case("Condensing Unit"):
                    GenerateTechnicalCondensing();
                    break;
            }
        }

        private void AddOneCompressor(string compressorName)
        {
            var toCopy = new GLItem(lvCompressor);
            int ratio = 0;
            int amount = 0;
            foreach (GLItem itm in lvCompressor.Items)
            {
                if (itm.Text == compressorName)
                {
                    toCopy = itm;
                    ratio = Convert.ToInt32(itm.SubItems[7].Text);
                    amount++;
                }
            }

            //This it to get a more precise ratio.  If we had 2 units at 50, we now have 3 at 33.
            ratio = ratio * (amount) / (amount + 1);
            toCopy.SubItems[7].Text = ratio.ToString(CultureInfo.InvariantCulture);

            var myItem = new GLItem(lvCompressor);
            myItem.SubItems[0].Text = toCopy.SubItems[0].Text;
            myItem.SubItems[1].Text = toCopy.SubItems[1].Text;
            myItem.SubItems[2].Text = toCopy.SubItems[2].Text;
            myItem.SubItems[3].Text = toCopy.SubItems[3].Text;
            myItem.SubItems[4].Text = toCopy.SubItems[4].Text;
            myItem.SubItems[5].Text = toCopy.SubItems[5].Text;
            myItem.SubItems[6].Text = toCopy.SubItems[6].Text;
            myItem.SubItems[7].Text = toCopy.SubItems[7].Text;

            lvCompressor.Items.Add(myItem);
            var toAdd = new Pair(ratio.ToString(CultureInfo.InvariantCulture), myItem.SubItems[0].Text);
            _compressorRatiosForCondensingUnits.Add(toAdd);
            
            foreach (GLItem itm in lvCompressor.Items)
            {
                if (itm.Text == compressorName)
                {
                    itm.SubItems[7].Text = ratio.ToString(CultureInfo.InvariantCulture);
                    foreach (Pair pair in _compressorRatiosForCondensingUnits)
                    {
                        if (pair.Second.ToString() == compressorName)
                        {
                            pair.First = ratio.ToString(CultureInfo.InvariantCulture);
                        }
                    }
                }
            }
            lvCompressor.Refresh();

        }

        private void RemoveOneCompressor(string compressorName)
        {
            var toDelete = new GLItem(lvCompressor);
            int ratio = 0;
            int amount = 0;
            Boolean removed = false;
            foreach (GLItem itm in lvCompressor.Items)
            {
                if (itm.Text == compressorName)
                {
                    
                    ratio = Convert.ToInt32(itm.SubItems[7].Text);
                    amount++;
                    if(!removed)
                    {
                        toDelete = itm;
                        removed = true;
                    }
                }
                
            }
            var toRemove = new Pair();
            foreach (Pair pair in _compressorRatiosForCondensingUnits)
            {
                if (pair.Second.ToString() == compressorName)
                {
                    toRemove = pair;
                }
            }
            _compressorRatiosForCondensingUnits.Remove(toRemove);

            lvCompressor.Items.Remove(toDelete);
            //This it to get a more precise ratio.  If we had 2 units at 50, we now have 3 at 33.
            if(amount > 1)
            {
                ratio = ratio * (amount) / (amount -1);
            
                foreach (GLItem itm in lvCompressor.Items)
                {
                    if (itm.Text == compressorName)
                    {
                        itm.SubItems[7].Text = ratio.ToString(CultureInfo.InvariantCulture);
                        foreach (Pair pair in _compressorRatiosForCondensingUnits)
                        {
                            if (pair.Second.ToString() == compressorName)
                            {
                                pair.First = ratio.ToString(CultureInfo.InvariantCulture);
                            }
                        }
                    }
                    
                }
            }
            lvCompressor.Refresh();

        }
        private void tv_Kits_DoubleClick(object sender, EventArgs e)
        {
            if(tv_Kits.SelectedNode != null)
            {
                if (tv_Kits.SelectedNode.Parent != null)
                {
                    Public.LanguageBox("You cannot move an item inside a kit to a machine.  Please select the kit itself. Thank you", "Vous ne pouvez ajouter un élément d'une trousse à une machine.  Veuillez sélectionner la trousse elle-même. Merci");
                }
                else
                {
                    string type = tv_Kits.SelectedNode.Text.Substring(0, (tv_Kits.SelectedNode.Text.LastIndexOf(" - ", StringComparison.Ordinal))).Substring(0, tv_Kits.SelectedNode.Text.IndexOf(" - ", StringComparison.Ordinal));
                    string name =
                        tv_Kits.SelectedNode.Text.Substring(0,
                            (tv_Kits.SelectedNode.Text.LastIndexOf(" - ", StringComparison.Ordinal)))
                            .Substring(tv_Kits.SelectedNode.Text.IndexOf(" - ", StringComparison.Ordinal) + 3);
                    string price = tv_Kits.SelectedNode.Text.Substring((tv_Kits.SelectedNode.Text.LastIndexOf(" - ", StringComparison.Ordinal) + 3));
                    Boolean existing = false;
                    foreach (ListViewItem litem in lv_Pieces.Items)
                    {
                        if (litem.SubItems[1].Text == name)
                        {
                            existing = true;
                            litem.SubItems[3].Text = (Convert.ToDecimal(litem.SubItems[3].Text) + 1).ToString(CultureInfo.InvariantCulture);
                            litem.SubItems[4].Text =
                                (Convert.ToDecimal(litem.SubItems[3].Text) * Convert.ToDecimal(litem.SubItems[2].Text)).ToString(CultureInfo.InvariantCulture);
                        }
                    }
                    if (!existing)
                    {
                        var myItem = new ListViewItem(type);
                        myItem.SubItems.Add(name);
                        myItem.SubItems.Add(price);
                        myItem.SubItems.Add("1");
                        myItem.SubItems.Add(price);
                        lv_Pieces.Items.Add(myItem);
                        
                        if (cmb_Types.Text.Contains("Condensing Unit") && type.Contains("COMPRESSOR"))
                        {
                            DataTable compressor = Query.Select("Select * from moduleCompressorLogic where moduleID = (Select kitID from kitInfo where kitname like '%" + name + "%')");

                            // if the compressor rows here == 0, means the voltage or refrigerant id is NOT ok for the compressor chosen
                            if (compressor.Rows.Count != 0)
                            {
                                var receiverNames = new List<string>();
                                foreach (ListViewItem piece in lv_Pieces.Items)
                                {
                                    if (piece.SubItems[0].Text.Contains("RECEIVER"))
                                    {
                                        receiverNames.Add(piece.SubItems[1].Text);
                                        break;
                                    }
                                }
                                string receiverSize;
                                if (receiverNames.Count != 0)
                                {
                                    DataTable receiver =
                                        Query.Select(
                                            "Select * from moduleReceiverLogic where moduleID = (Select kitID from kitInfo where kitName like '%" +
                                            receiverNames[0] + "')");
                                     receiverSize = receiver.Rows.Count == 0
                                        ? "NONE"
                                        : receiver.Rows[0]["Size"].ToString();
                                }
                                                        
                                 else
                                 {
                                     receiverSize = "??";
                                    }
                                var myComp = new GLItem(lvCompressor);
                                    myComp.SubItems[0].Text = compressor.Rows[0]["CompressorName"].ToString();
                                    myComp.SubItems[1].Text = _loadedMachineName[12].ToString(CultureInfo.InvariantCulture);
                                    myComp.SubItems[2].Text = _loadedMachineName[10].ToString(CultureInfo.InvariantCulture);
                                    myComp.SubItems[3].Text = compressor.Rows[0]["LiquidValue"].ToString();
                                    myComp.SubItems[4].Text = compressor.Rows[0]["SuctionValue"].ToString();
                                    myComp.SubItems[5].Text = compressor.Rows[0]["DischargeValue"].ToString();
                                    myComp.SubItems[6].Text = receiverSize;
                                    var frmRatio = new FrmRatio();
                                    frmRatio.ShowDialog();
                                    myComp.SubItems[7].Text = frmRatio.GetRatio().ToString(CultureInfo.InvariantCulture);
                                    var toAdd = new Pair(myComp.SubItems[7].Text, myComp.SubItems[0].Text);
                                    _compressorRatiosForCondensingUnits.Add(toAdd);
                                    lvCompressor.Items.Add(myComp);
                                    lvCompressor.Refresh();
                                    frmRatio.Close();
                                
                            }
                        }

                    }
                    if (!string.IsNullOrEmpty(_loadedMachineName) && cmb_Types.Text == @"Condensing Unit" && (type.Contains("COMPRESSOR") || type.Contains("COIL") || type.Contains("MOTOR")))
                    {
                        lvSecondaryTable.Items.Clear();
                        lvBalancing.Items.Clear();
                        _globalBalancing = null;
                        lvBalancing.Refresh();
                        lvSecondaryTable.Refresh();
                    }
                    lv_Pieces.Refresh();
                    UpdatePrices(GetMaterialCost());
                    if (comboBox1.Text == @"A")
                    {
                        num_Weight.Value = CalculateWeight();
                        comboBox1.Text = @"A";
                    }
                    GenerateTechnicalCondensing();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var oP = new FrmOptionPack();
            oP.ShowDialog();
            RefreshForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lv_Pieces.SelectedItems.Count == 0)
            {
                Public.LanguageBox("Please select a unit before clicking on this button.  Thank you", "Veuillez sélectionner une unité avant de cliquer ici.  Merci!");
            }
            else
            {
                ViewDetails();    
            }
            
        }

        private void ViewDetails()
        {
            string modelName = lv_Pieces.SelectedItems[0].SubItems[1].Text;

            for (int i = 0; i < tv_Kits.Nodes.Count; ++i)
            {
                tv_Kits.CollapseAll();
                if (tv_Kits.Nodes[i].Text.Contains(modelName))
                {
                    tv_Kits.Focus();
                    tv_Kits.SelectedNode = tv_Kits.Nodes[i];
                    tv_Kits.SelectedNode.Expand();
                    tv_Kits.Nodes[i].Checked = true;
                    break;
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if(tv_Kits.SelectedNode.Parent == null)
            {
                var eC = new FrmEditChoice(tv_Kits.SelectedNode.Text.Substring(0, tv_Kits.SelectedNode.Text.LastIndexOf(" - ", StringComparison.Ordinal)));
                eC.Show();
            }
            else
            {
                Public.LanguageBox(
                    "To edit a module, please make sure you selected a module and not a piece from the list, thank you!",
                    "Pour modifier un module, veuillez vous assurer que vous avez sélectionné un module de la liste et non pas une pièce.  Merci!");
            }
        }

        private void LoadUnit(string unitName)
        {
            if (unitName == "")
            {
                
            }
            else
            {
                //query the table for the modules used, and then update the ListView with them
                switch (cmb_Types.Text)
                {
                    case("Condensing Unit"):
                        LoadCondensing();
                        break;
                }



                UpdatePrices(GetMaterialCost());
            }
        }

        private void LoadCondensing()
        {
            _compressorRatiosForCondensingUnits.Clear();
            if (cmb_Unit.Text != "")
            {
                comboBox1.Text = "";
                var compressors = new List<string>();
                lvCompressor.Items.Clear();
                lv_Pieces.Items.Clear();
                _loadedMachineName = cmb_Unit.Text;
                DataTable machine =
                    Query.Select("Select * from machine where machinename = '" + _loadedMachineName + "'");
                _loadedMachineID = Convert.ToInt32(machine.Rows[0]["MachineID"].ToString());
                nUd_Access.Value = Convert.ToDecimal(machine.Rows[0]["MinimumAccessLevel"].ToString());

                nUd_labBurd.Value = Convert.ToDecimal(machine.Rows[0]["Labour"].ToString());

                nUd_Profit.Value = Convert.ToDecimal(machine.Rows[0]["GrossProfit"].ToString());
                nUd_List.Value = Convert.ToDecimal(machine.Rows[0]["ListFactor"].ToString());
                listPrice_Text.Text = machine.Rows[0]["Price"].ToString();


                DataTable pieces =
                    Query.Select("Select * from machinePieces where machineId = '" + _loadedMachineID + "' order by [index] asc");
                foreach (DataRow piece in pieces.Rows)
                {
                    string pieceName = piece["pieceName"].ToString();
                    var myItem =
                        new ListViewItem(pieceName.Substring(0, pieceName.IndexOf(" - ", StringComparison.Ordinal)));
                    myItem.SubItems.Add(pieceName.Substring(pieceName.IndexOf(" - ", StringComparison.Ordinal) + 3));
                    myItem.SubItems.Add(piece["UnitPriceSaved"].ToString());
                    myItem.SubItems.Add(piece["qty"].ToString());
                    myItem.SubItems.Add(
                        (Convert.ToDecimal(piece["UnitPriceSaved"].ToString()) * Convert.ToInt32(piece["qty"].ToString()))
                            .ToString(CultureInfo.InvariantCulture));
                    lv_Pieces.Items.Add(myItem);
                    if (pieceName.Contains("COMPRESSOR"))
                    {
                        compressors.Add(pieceName);
                    }
                    DataTable newPrice =
                        Query.Select("Select * from KitINfo where kitname = '" + pieceName.Substring(pieceName.IndexOf(" - ", StringComparison.Ordinal) + 3) + "' and Price = " +
                                     piece["unitPriceSaved"]);
                    if (newPrice.Rows.Count == 0)
                    {
                        lv_Pieces.Items[lv_Pieces.Items.Count - 1].BackColor = Color.Red;
                    }
                }
                UpdatePrices(GetMaterialCost());
                DataTable refrigerant = Query.Select("Select Refrigerant from condensingUnitRefrigerant where RefrigerantParameter = " + _loadedMachineName[10]);
                lblRefrigerantValue.Text = refrigerant.Rows.Count != 0 ? refrigerant.Rows[0]["Refrigerant"].ToString() : @"Value not found";
                foreach (string compressor in compressors)
                {
                    string module = compressor.Substring(compressor.LastIndexOf(" - ", StringComparison.Ordinal) + 3);
                    DataTable ratios =
                        Query.Select("Select ratioForCompressor from machinepieces where piecename like '%" + module +
                                     "%' and machineID = (Select MachineID from machine where machineName = '" +
                                     _loadedMachineName + "')");
                    if (ratios.Rows.Count > 0)
                    {
                        DataTable comp = Query.Select("Select * from moduleCompressorLogic where ModuleID = (Select KitID from KitInfo where KitName = '" + module + "')");
                        if (comp.Rows.Count > 0)
                        {
                            var toAdd = new Pair(ratios.Rows[0]["ratioForCompressor"].ToString(), comp.Rows[0]["CompressorName"].ToString());
                            _compressorRatiosForCondensingUnits.Add(toAdd);
                        }
                    }
                }

                DataTable balancingInfo = Query.Select("Select * from MachineCondensingUnit where MachineID = (Select machineID from machine where machineName = '" + _loadedMachineName + "')");

                if (balancingInfo.Rows.Count > 0)
                {
                    num_SSTMax.Value = Convert.ToDecimal(balancingInfo.Rows[0]["maxSST"].ToString());
                    num_SSTMin.Value = Convert.ToDecimal(balancingInfo.Rows[0]["minSST"].ToString());
                    num_BalancingMax.Value = Convert.ToDecimal(balancingInfo.Rows[0]["maxBalancing"].ToString());
                    num_BalancingMin.Value = Convert.ToDecimal(balancingInfo.Rows[0]["minBalancing"].ToString());
                    nUd_CommercialFactorValue.Value = Convert.ToDecimal(balancingInfo.Rows[0]["Factor"].ToString());
                }
                FormatBalancingTable(num_BalancingMin.Value, num_BalancingMax.Value, num_SSTMin.Value, num_SSTMax.Value);
                LoadMachineNameToTextBoxes();
                GenerateTechnicalCondensing();
                
                AutoBalance(num_BalancingMin.Value, num_BalancingMax.Value, num_SSTMin.Value, num_SSTMax.Value);



                if (machine.Rows[0]["WeightManual"].ToString() == "True")
                {
                    if (comboBox1.Text == "")
                    {
                        comboBox1.Text = @"M";
                    }
                }
                else
                {
                    if (comboBox1.Text == "")
                    {
                        comboBox1.Text = @"A";
                    }
                }
                if (comboBox1.Text == @"M")
                {
                    num_Weight.Value = Convert.ToDecimal(machine.Rows[0]["Weight"]);
                    comboBox1.Text = @"M";
                }
                else
                {
                    num_Weight.Value = CalculateWeight();
                }



            }
            else
            {
                Public.LanguageBox("Please select one unit before loading.", "Veuillez sélectionner une unité avant de la charger.");
            }
        }

        private void UpdatePrices(decimal matCost)
        {
            mat_text.Text = matCost.ToString(CultureInfo.InvariantCulture);
            labBurd_Text.Text = (matCost * nUd_labBurd.Value / 100).ToString("0.00");
            matLabBurd_Text.Text = (Convert.ToDecimal(mat_text.Text) + Convert.ToDecimal(labBurd_Text.Text)).ToString("0.00");
            listPrice_Text.Text =
                ((Convert.ToDecimal(nUd_Profit.Value) + 100)/100*Convert.ToDecimal(matLabBurd_Text.Text)*
                 Convert.ToDecimal(nUd_List.Value)).ToString("0.00");

             decimal price = 0;
             string sql = "Select kitname, Price from KitInfo where kitname in ('";
             foreach (ListViewItem itm in lv_Pieces.Items)
             {
                 sql += itm.SubItems[1].Text + "','";
             }
             sql += "')";
             DataTable priceTotal = Query.Select(sql);
            decimal quantity = 1;
             foreach (DataRow row in priceTotal.Rows)
             {
                 foreach (ListViewItem itm in lv_Pieces.Items)
                 {
                     if (itm.SubItems[1].Text == row["kitName"].ToString())
                     {
                         quantity = Convert.ToInt32(itm.SubItems[3].Text);
                         break;
                     }
                 }
                 price += Convert.ToDecimal(row["price"])* quantity;
             }
            decimal updatedMatCost = price;
             txtBoxMaterialUpdated.Text = price.ToString(CultureInfo.InvariantCulture);
            txt_labBurdUpdated.Text = (updatedMatCost*num_LabBurdUpdated.Value/100).ToString("0.00");
            txtMatLabUpdated.Text = (updatedMatCost + Convert.ToDecimal(txt_labBurdUpdated.Text)).ToString("0.00");
            txtListPriceUpdated.Text =
                ((Convert.ToDecimal(nUd_Profit.Value) + 100)/100*Convert.ToDecimal(txtMatLabUpdated.Text)*
                 Convert.ToDecimal(nUd_List.Value)).ToString("0.00");


        }

        private decimal GetMaterialCost()
        {
            decimal total = 0;
            foreach (ListViewItem row in lv_Pieces.Items)
            {
                total += Convert.ToDecimal(row.SubItems[4].Text);
            }
            return total;
        } 



        private void button2_Click(object sender, EventArgs e)
        {
            
                if (cmb_Types.Text == "")
                {
                    Public.LanguageBox("Please select a type for your machine and save again",
                        "Veuillez sélectionner un type pour votre machine et sauvegardez à nouveau");
                }
                else
                {

                    if (CheckMachineSpecificsForSave())
                    {
                        if (VerifyRatioTotal())
                        {
                            _loadedMachineName = GetMachineName();
                            if (_loadedMachineName != "")
                            {
                                bool alreadyExists = false;
                                for (int i = 0; i < cmb_Unit.Items.Count; ++i)
                                {
                                    if (cmb_Unit.Items[i].ToString() == _loadedMachineName)
                                    {
                                        alreadyExists = true;
                                        break;
                                    }
                                }
                                if (!alreadyExists)
                                {
                                    if (TryParseName(_loadedMachineName))
                                    {
                                        DataTable id = Query.Select("Select Max(MachineID) as ID from Machine");
                                        if (id.Rows.Count == 0)
                                        {
                                            _loadedMachineID = 0;
                                        }
                                        else
                                        {
                                            _loadedMachineID = Convert.ToInt32(id.Rows[0]["ID"].ToString()) + 1;
                                        }
                                        if (lv_Pieces.Items.Count == 0)
                                        {
                                            Public.LanguageBox(
                                                "You need at least one module in your unit for it to be saved",
                                                "Vous devez avoir au moins un module dans votre unité pour qu'elle soit sauvegardée");
                                        }
                                        else
                                        {

                                            ThreadProcess.Start("Saving");
                                            Query.Execute("Insert into Machine VALUES(" + _loadedMachineID + ",'" +
                                                          _loadedMachineName + "','" + cmb_Types.Text + "'," +
                                                          nUd_Access.Value + "," + num_Weight.Text + "," +
                                                          listPrice_Text.Text + "," +
                                                          nUd_labBurd.Value + "," + nUd_Profit.Value + "," +
                                                          nUd_List.Value +
                                                          "," + (comboBox1.Text == @"M" ? "1" : "0") + ")");
                                            int indexForRatio = 0;
                                            foreach (ListViewItem item in lv_Pieces.Items)
                                            {
                                                Query.Execute("Insert into MachinePieces VALUES(" + _loadedMachineID +
                                                              ",'" +
                                                              item.SubItems[0].Text + " - " + item.SubItems[1].Text +
                                                              "'," +
                                                              item.SubItems[3].Text + "," + item.SubItems[2].Text + ", " +
                                                              item.Index + ", " +
                                                              (item.SubItems[0].Text.Contains("COMPRESSOR")
                                                                  ? _compressorRatiosForCondensingUnits[indexForRatio].First
                                                                  : "NULL") + ")");
                                                if (item.SubItems[0].Text.Contains("COMPRESSOR"))
                                                {
                                                    indexForRatio++;
                                                }
                                            }
                                            SaveMachine();
                                            ThreadProcess.Stop();
                                            Focus();
                                            Public.LanguageBox("Save successful", "Sauvegarde réussie");



                                        }
                                    }
                                    else
                                    {
                                        Public.LanguageBox(
                                            "Your unit name does not match the type you selected for it.  Please revise, as it didn't save right now",
                                            "Votre nom d'unité ne correspond pas à la nomenclature pour le type d'unité que vous avez sélectionné.  Veuillez réviser, car votre unité n'a pas été sauvegardée");
                                    }
                                }
                                else
                                {
                                    if (
                                        Public.LanguageQuestionBox("Do you want to overwrite this machine?",
                                            "Voulez-vous écraser cette machine avec les nouvelles informations entrées?",
                                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        ThreadProcess.Start("Saving");
                                        Query.Execute("Delete from Machine where MachineID = " + _loadedMachineID);
                                        Query.Execute("Delete from MachinePieces where MachineID = " + _loadedMachineID);

                                        Query.Execute("Insert into Machine VALUES(" + _loadedMachineID + ",'" +
                                                      _loadedMachineName + "','" + cmb_Types.Text + "'," +
                                                      nUd_Access.Value +
                                                      "," + num_Weight.Text + "," + listPrice_Text.Text + "," +
                                                      nUd_labBurd.Value + "," + nUd_Profit.Value + "," + nUd_List.Value +
                                                      "," + (comboBox1.Text == @"M" ? "1" : "0") + ")");
                                        int indexForRatio = 0;
                                        foreach (ListViewItem item in lv_Pieces.Items)
                                        {
                                            Query.Execute("Insert into MachinePieces VALUES(" + _loadedMachineID + ",'" +
                                                          item.SubItems[0].Text + " - " + item.SubItems[1].Text + "'," +
                                                          item.SubItems[3].Text + "," + item.SubItems[2].Text + ", " +
                                                          item.Index + ", " +
                                                          (item.SubItems[0].Text.Contains("COMPRESSOR")
                                                              ? _compressorRatiosForCondensingUnits[indexForRatio].First
                                                              : "NULL") + ")");
                                            if (item.SubItems[0].Text.Contains("COMPRESSOR"))
                                            {
                                                indexForRatio++;
                                            }
                                        }
                                        UpdateMachine();
                                        ThreadProcess.Stop();
                                        Focus();
                                        Public.LanguageBox("Save successful", "Sauvegarde réussie");


                                    }
                                }
                            }
                            else
                            {
                                Public.LanguageBox(
                                    "Your machine isn't named properly in the form, please revise before saving",
                                    "Le nom de la machine que vous créez n'est pas rempli correctement dans la page.  Veuillez corriger puis sauvegarder à nouveau");
                            }

                        }

                        else
                        {
                            Public.LanguageBox(
                                "Your ratios in your condensing unit do not totalize 100.  The system will go compressor by compressor so you can reassign the values.  Thank you!",
                                "Vos ratios totalisés ensembles ne font pas 100%.  Le système passera donc, compresseur par compresseur, pour que vous puissiez réajuster les ratios. Merci!");
                            RedoAllRatios();

                        }
                    }
                    else
                    {
                        Public.LanguageBox("This machine is not complete and therefore cannot be saved",
                            "Cette machine n'est pas complète et ne peut donc pas être sauvegardée");
                    }


                    _loadedMachineName = "";
                }
                string old = cmb_Types.Text;
                cmb_Types.SelectedIndex = cmb_Types.FindString("Evaporator");
                cmb_Types.SelectedIndex = cmb_Types.FindString("Coil");
                cmb_Types.SelectedIndex = cmb_Types.FindString(old);


        }

        //Simply verifying that the total of all the ratios is = 100.
        private bool VerifyRatioTotal()
        {
            int total = 0;
            foreach (Pair ratio in _compressorRatiosForCondensingUnits)
            {
                total += Convert.ToInt32(ratio.First);
            }
            return (total == 100);
        }

        //This reopens the ratio page for EVERYcompressor, so you can reassign them all.
        private void RedoAllRatios()
        {
            foreach (GLItem itm in lvCompressor.Items)
            {
                Public.LanguageBox("This is for compressor : " +itm.Text, "Ceci est pour le compresseur : " + itm.Text);
                var ratio = new FrmRatio();
                ratio.ShowDialog();
                itm.SubItems[7].Text = ratio.GetRatio().ToString(CultureInfo.InvariantCulture);
                foreach (Pair rate in _compressorRatiosForCondensingUnits)
                {
                    if (rate.Second.ToString() == itm.Text)
                    {
                        rate.First = ratio.GetRatio().ToString(CultureInfo.InvariantCulture);
                    }
                }
                ratio.Close();
            }
        }

        private string GetMachineName()
        {
            //it all depends, as usual, on the selected typer of the machine
            switch (cmb_Types.Text)
            {
                case("Condensing Unit"):
                    if (txtFirstPart.Text == "" || txtSecondPart.Text == "" || txtThirdPart.Text == "")
                    {
                        return "";
                    }
                    return txtFirstPart.Text + "-" + txtSecondPart.Text + "-" + txtThirdPart.Text + "-" + txtFourthPart.Text + txtOptions.Text; 
            }
            return "";
        }

        private void nUd_labBurd_ValueChanged(object sender, EventArgs e)
        {
            num_LabBurdUpdated.Value = nUd_labBurd.Value;
            UpdatePrices(GetMaterialCost());
        }

        private void nUd_Profit_ValueChanged(object sender, EventArgs e)
        {
            num_ProfitUpdated.Value = nUd_Profit.Value;
            UpdatePrices(GetMaterialCost());
        }

        private void nUd_List_ValueChanged(object sender, EventArgs e)
        {
            num_FactorUpdated.Value = nUd_List.Value;
            UpdatePrices(GetMaterialCost());
        }

        private void txtFirstPart_Leave(object sender, EventArgs e)
        {

            if (txtFirstPart.TextLength != 3 || !Regex.IsMatch(txtFirstPart.Text, @"^[a-zA-Z]+$"))
            {
                Public.LanguageBox("This textBox should be filled with 3 letters and 3 letters only.", "Cette boîte de texte devrait être remplie avec trois lettres seulement.");
            }
            else
            {
                DataTable type = Query.Select("Select Type from CondensingUnitType where TypeParameter = '" +
                             txtFirstPart.Text.Substring(0, 2) + "'");
                lblTypeValue.Text = type.Rows.Count != 0 ? type.Rows[0]["Type"].ToString() : @"Value not found";
                DataTable compType = Query.Select("Select CompressorType from CondensingUnitCompressorType where CompressorTypeParameter = '" +
                 txtFirstPart.Text.Substring(2) + "'");
                lblCompressorTypeValue.Text = compType.Rows.Count != 0 ? compType.Rows[0]["CompressorType"].ToString() : @"Value not found";
            }
            GenerateTechnical();
        }

        private void txtSecondPart_Leave(object sender, EventArgs e)
        {
            if (txtSecondPart.Text.Length != 3)
            {
                Public.LanguageBox("Please put 3 numbers in this textbox.  thank you!", "Veuillez entrer trouis chiffres dans cette boîte de texte.  Merci!");
            }
            else
            {
                char first = txtSecondPart.Text[0];
                char second = txtSecondPart.Text[1];
                char third = txtSecondPart.Text[2];
                if (char.IsDigit(first) && char.IsDigit(second) && char.IsDigit(third))
                {
                    string hp = first.ToString(CultureInfo.InvariantCulture) + second.ToString(CultureInfo.InvariantCulture) + ".";
                    if ((third == '2' || third == '4') && !(first == '0' && second == '0'))
                    {
                        hp += "0";
                        lblNumberOfCompressorsValue.Text = third.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        hp += third.ToString(CultureInfo.InvariantCulture);
                        lblNumberOfCompressorsValue.Text = @"1";
                    }
                    lblHPValue.Text = hp;
                }
                else
                {
                    Public.LanguageBox("Please make sure only 3 numbers are entered in this text box.  Thank you","Veuillez vous assurer de n'entrer que des chiffres dans cette boîte de texte.  Merci!");
                }
            }
            GenerateTechnical();
        }

        private void txtThirdPart_Leave(object sender, EventArgs e)
        {
            if (txtThirdPart.Text.Length != 3)
            {
                Public.LanguageBox("Please put 3 numbers in this textbox.  thank you!", "Veuillez entrer trouis chiffres dans cette boîte de texte.  Merci!");
            }
            else
            {
                char first = txtThirdPart.Text[0];
                char second = txtThirdPart.Text[1];
                char third = txtThirdPart.Text[2];
                if (Char.IsDigit(first) && Char.IsLetter(second) && Char.IsDigit(third))
                {
                    DataTable manufacturer = Query.Select("Select compressorManufacturer from condensingUnitCompressorManufacturer where compressorManufacturerParameter = " + first);
                    lblCompressorManufacturerValue.Text = manufacturer.Rows.Count != 0 ? manufacturer.Rows[0]["compressorManufacturer"].ToString() : @"Value not found";


                    DataTable application = Query.Select("Select Application from condensingUnitApplication where Parameter = '" + second + "'");
                    lblApplicationValue.Text = application.Rows.Count != 0 ? application.Rows[0]["Application"].ToString() : @"Value not found";
                    DataTable refrigerant = Query.Select("Select Refrigerant from condensingUnitRefrigerant where RefrigerantParameter = " + third);
                    lblRefrigerantValue.Text = refrigerant.Rows.Count != 0 ? refrigerant.Rows[0]["Refrigerant"].ToString() : @"Value not found";

                }
                else
                {
                    Public.LanguageBox("This textBox should be filled with 1 digit, 1 letter, and 1 digit, as such : 1H3", "Cette boîte de texte devrait être remplie avec une lettre, un chiffre, et une lettre, comme suit : 1H3");
                }
            }
            GenerateTechnical();
        }

        private void txtFourthPart_Leave(object sender, EventArgs e)
        {
            if (Char.IsDigit(txtFourthPart.Text[0]))
            {
                DataTable voltage = Query.Select("Select VoltDescription from Voltage where VoltageID = " + txtFourthPart.Text);
                lblVoltageValue.Text = voltage.Rows.Count != 0 ? voltage.Rows[0]["VoltDescription"].ToString() : @"Value not found";
            }
            GenerateTechnical();
        }

        private void txtOptions_Leave(object sender, EventArgs e)
        {
            bool duplicates = false;
            for (int i = 0; i < txtOptions.Text.Length; ++i)
            {
                for (int j = 0; j < txtOptions.Text.Length; ++j)
                {
                    if (j != i && txtOptions.Text[i] == txtOptions.Text[j])
                    {
                        duplicates = true;
                        break;
                    }
                }
            }
            if (duplicates)
            {
                Public.LanguageBox("please make sure the same option isn't entered twice.  Thank you!",
                    "Veuillez valider que la même option n'est pas entrée deux fois.  Merci!");
            }
            else
            {
                txtOptions.Text = Public.SortStringAlphabeticalOrder(txtOptions.Text);
            }
            GenerateTechnical();
        }

        private void btnSeeOptions_Click(object sender, EventArgs e)
        {
            Public.LanguageBox("That logic hasn't been implemented.  This button is just a placeholder.  Sorry!",
                "Cette logique n'a pas encore été créée, ce bouton ne fait aucun traitement pour le moment.  Désolé");
            /*DataTable options = Query.Select("");
            if (options.Rows.Count == 0)
            {
                Public.LanguageBox("No options are available for this machine at this level of access, sorry!", "Aucune option n'est accessible pour cette machine avec ce niveau d'accès.  Désolé!");
            }
            else
            {
                string optionsStr = "";
                foreach (DataRow row in options.Rows)
                {
                    optionsStr += row["optionText"] + "\n";
                }
                Public.LanguageBox("The list of options for users of level : " + nUdOptionsForLevel.Value + " are the following : \n" + optionsStr, "La liste d'options pour un usager de niveau : " + nUdOptionsForLevel.Value + " est la suivante : \n" + optionsStr);
            }*/
        }

        private bool TryParseName(string name)
        {
            switch (cmb_Types.Text)
            {
                case("Condensing Unit"):
                    return TryParseNameForCondensingUnit(name);
            }
            return false;
        }
        //Check if the name is (for instance) "ICH-002-1H3-2"
        private bool TryParseNameForCondensingUnit(string name)
        {
            //Checking every character of the name for it's correct possible values
            if ((name[0] == 'S' || name[0] == 'W' || name[0] == 'M' || name[0] == 'I' || name[0] == 'O') && 
                (name[1] == 'L' || name[1] == 'C' || name[1] =='V') &&
                (name[2] == 'H' || name[2] == 'Z' || name[2] == 'S') &&
                name[3] == '-' &&
                (Char.IsDigit(name[4]) && Char.IsDigit(name[5]) && Char.IsDigit(name[6])) &&
                name[7] == '-' &&
                (name[8] == '1' || name[8] == '2' || name[8] == '5' || name[8] == '3' || name[8] == '6') &&
                (name[9] == 'L' || name[9] == 'M' || name[9] == 'H') &&
                (name[10] == '1' || name[10] == '2' || name[10] == '3' || name[10] == '4' || name[10] == '7') &&
                name[11] == '-' &&
                (name[12] == '1' || name[12] == '2' || name[12] == '5' || name[12] == '8' || name[12] == '9'))
            {
                //if name is longer, means we have options after
                if (name.Length > 13)
                {
                    //checking each option is a capital letter
                    string options = name.Substring(13);
                    foreach (char chr in options)
                    {
                        if (!char.IsUpper(chr))
                        {
                            return false;
                        }
                    }
                    //if we passed every option and there's no non-capital letter, it's the right name
                    return true;
                }
                // if length is 12 and we got here, means the name is ok
                return true;
            }
            // if the first if doesn't pass, the name isn't correct
            return false;
        }

        //when given a typename for a module looked for, this function cycles through the added modules of a machine to confirm it has enough of the needed type.
        //CURRENTLY UNUSED but potentially very useful.  To be kept

        private bool CheckIfModuleExists(string typeNeeded, int howManyNeeded)
        {
            int amountFound = 0;
            foreach (ListViewItem item in lv_Pieces.Items)
            {
                if (item.SubItems[0].ToString().Contains(typeNeeded))
                {
                    amountFound++;
                    if (amountFound == howManyNeeded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private decimal CalculateWeight()
        {
            decimal weight = 0;
            foreach (ListViewItem item in lv_Pieces.Items)
            {
                string selectQuery = "Select weight from ";
                if (item.SubItems[0].Text.Contains("MODULE"))
                {
                    switch (item.SubItems[0].Text)
                    {
                        case ("MODULE(CU)-COMPRESSOR"):
                            selectQuery += "moduleCompressorLogic";
                            break;
                        case ("MODULE(CU)-MOTOR"):
                            selectQuery += "moduleMotorLogic";
                            break;
                        case ("MODULE(CU)-COIL"):
                            selectQuery += "moduleCoilLogic";
                            break;
                        case ("MODULE(CU)-BASE"):
                            selectQuery += "moduleBaseLogic";
                            break;
                        case ("MODULE(CU)-RECEIVER"):
                            selectQuery += "moduleReceiverLogic";
                            break;
                        case ("MODULE(CU)-GENERIC"):
                            selectQuery += "moduleGenericLogic";
                            break;
                        case ("MODULE(CU)-WCC"):
                            selectQuery += "moduleWCCLogic";
                            break;
                    }
                    selectQuery+= " where moduleID = (Select kitID from kitInfo where kitname = '" + item.SubItems[1].Text + "')";
                    DataTable dtWeight = Query.Select(selectQuery);
                    if(dtWeight.Rows.Count != 0)
                    {
                        weight += Convert.ToDecimal(dtWeight.Rows[0]["Weight"].ToString());
                        
                    }
                }
            }

            
            return weight;
        }

        private string ReplaceApostrophes(string str)
        {
            string ret = "";
            foreach (char chr in str)
            {
                if (chr != '\'')
                {
                    ret += chr.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    ret += ' ';
                }
            }
            return ret;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Do you really want to delete this machine?",
                "Voulez-vous vraiment supprimer cette machine?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable moduleID = Query.Select("Select MachineID from machine where MachineName = '" + _loadedMachineName + "'");
                Query.Execute("Delete from machine where machineID = " + moduleID.Rows[0]["MachineID"]);
                Query.Execute("Delete from machinePieces where machineID = " + moduleID.Rows[0]["MachineID"]);
                Public.LanguageBox("Machine deleted!", "Machine effacée!");
                string old = cmb_Types.Text;
                cmb_Types.SelectedIndex = cmb_Types.FindString("Evaporator");
                cmb_Types.SelectedIndex = cmb_Types.FindString("Coil");
                cmb_Types.SelectedIndex = cmb_Types.FindString(old);
            }
        }

        private void GenerateTechnicalCondensing()
        {
            grpInfo2CU.Visible = true;
            grpCoil.Visible = true;
            ResetCondensing();

                string machineName = txtFirstPart.Text + "-" + txtSecondPart.Text + "-" + txtThirdPart.Text + "-" +
                                     txtFourthPart.Text + txtOptions.Text;


                DataTable machine =
                    Query.Select("Select * from Machine where MachineName = '" + _loadedMachineName + "'");

                var compressorName = new List<string>();
                var receiverName = new List<string>();
                var wccName = new List<string>();
                var coilName = new List<string>();
                var motorName = new List<string>();
                foreach (ListViewItem item in lv_Pieces.Items)
                {
                    string moduleType = item.Text
                        .Substring(item.Text.IndexOf("-", StringComparison.Ordinal) + 1)
                        .Trim();
                   switch (moduleType)
                    {
                        case ("COMPRESSOR"):
                            for (int i = 0; i < Convert.ToInt32(item.SubItems[3].Text); ++i)
                            {
                                compressorName.Add(item.SubItems[1].Text);
                            }
                            break;
                        case ("RECEIVER"):
                            receiverName.Add(item.SubItems[1].Text);
                            break;
                        case ("WCC"):
                            wccName.Add(item.SubItems[1].Text);
                            break;
                        case ("COIL"):
                            coilName.Add(item.SubItems[1].Text);
                            break;
                        case ("MOTOR"):
                            motorName.Add(item.SubItems[1].Text);
                            break;
                    }
                }

                //first tab
                if (machine.Rows.Count > 0)
                {
                    if (machine.Rows[0]["weightManual"].ToString() == "True")
                    {
                        if (comboBox1.Text == "")
                        {
                            num_Weight.Value = Convert.ToDecimal(machine.Rows[0]["Weight"]);
                            comboBox1.Text = @"M";
                        }
                    }
                    else
                    {
                        if (comboBox1.Text == "")
                        {
                            num_Weight.Value = CalculateWeight();
                            comboBox1.Text = @"A";
                        }
                    }
                }
                else
                {
                    if (comboBox1.Text == "" || comboBox1.Text == @"A")
                    {
                        num_Weight.Value = CalculateWeight();
                        comboBox1.Text = @"A";
                    }
                }
                lblOptionsValue.Text = "";
                if (machineName.Length > 13)
                {
                    for (int i = 13; i < machineName.Length; ++i)
                    {
                        lblOptionsValue.Text += machineName[i];
                    }
                }
                else
                {
                    lblOptionsValue.Text = @"NONE";
                }

                //second tab
                lvWaterCooledCondenser.Items.Clear();
                if (wccName.Count != 0)
                {
                    DataTable wcc =
                        Query.Select(
                            "Select Model from moduleWCCLogic where moduleID = (Select KitId from KitInfo where kitname like '%" +
                            wccName[0] + "%')");
                    //if no compressor, could be WCC
                    var myItem = new GLItem(lvWaterCooledCondenser);
                    myItem.SubItems[0].Text = wcc.Rows[0]["model"].ToString();
                    lvWaterCooledCondenser.Items.Add(myItem);
                }
                else
                {
                    lvWaterCooledCondenser.Visible = false;
                }


                //For this tab we need the coil and motor on the unit, and from there we can fill up.

                if (compressorName.Count > 0)
                {
                    lvCompressor.Items.Clear();
                    foreach (string name in compressorName)
                    {

                        DataTable compressor =
                            Query.Select(
                                "Select * from moduleCompressorLogic where moduleID = (select kitID from kitInfo where kitname like '%" +
                                name + "%')");
                        if (compressor.Rows.Count != 0 )
                        {
                            string receiverSize;
                            if(receiverName.Count != 0)
                            {
                                DataTable receiver =
                                    Query.Select(
                                        "Select * from moduleReceiverLogic where moduleID = (Select kitID from kitInfo where kitName like '%" +
                                        receiverName[0] + "')");
                                receiverSize = receiver.Rows.Count == 0
                                    ? "NONE"
                                    : receiver.Rows[0]["Size"].ToString();
                            }
                            else
                            {
                                receiverSize = "???";
                            }
                            var myComp = new GLItem(lvCompressor);
                            myComp.SubItems[0].Text = compressor.Rows[0]["CompressorName"].ToString();

                            myComp.SubItems[1].Text = compressor.Rows[0]["voltageID"].ToString();

                            myComp.SubItems[2].Text = compressor.Rows[0]["refrigerantID"].ToString();
                            
                            myComp.SubItems[3].Text = compressor.Rows[0]["LiquidValue"].ToString();
                            myComp.SubItems[4].Text = compressor.Rows[0]["SuctionValue"].ToString();
                            myComp.SubItems[5].Text = compressor.Rows[0]["DischargeValue"].ToString();
                            myComp.SubItems[6].Text = receiverSize;
                            if (_compressorRatiosForCondensingUnits.Count == 0)
                            {
                                var toAdd = new Pair("100", myComp.SubItems[0].Text);
                                _compressorRatiosForCondensingUnits.Add(toAdd);
                            }
                            foreach (Pair ratio in _compressorRatiosForCondensingUnits)
                            {
                                if (ratio.Second.ToString() == myComp.SubItems[0].Text)
                                {
                                    myComp.SubItems[7].Text = ratio.First.ToString();
                                }
                            }

                            lvCompressor.Items.Add(myComp);
                            lvCompressor.Refresh();
                        }
                    }
                }

                //third tab
                if (coilName.Count > 0)
                {
                    DataTable coilLogic =
                        Query.Select(
                            "Select * from moduleCoilLogic where moduleID = (Select kitID from KitINfo where kitName like '%" +
                            coilName[0] + "%')");


                    lblFinTypeValue.Text = coilLogic.Rows[0]["FinType"].ToString();
                    lblFinShapeValue.Text = coilLogic.Rows[0]["FinShape"].ToString();
                    lblCircuitsValue.Text = coilLogic.Rows[0]["Circuits"].ToString();
                    lblFinHeightValue.Text = Convert.ToDecimal(coilLogic.Rows[0]["FinHeight"]).ToString("00.");
                    lblFinLengthValue.Text = Convert.ToDecimal(coilLogic.Rows[0]["FinLength"]).ToString("00.");
                    lblRowsValue.Text = Convert.ToDecimal(coilLogic.Rows[0]["Rows"]).ToString("00.");
                    lblFPIValue.Text = Convert.ToDecimal(coilLogic.Rows[0]["FPI"]).ToString("00.");
                    lblFinMaterialValue.Text = coilLogic.Rows[0]["FinMaterial"].ToString();
                    lblFinThicknessValue.Text = coilLogic.Rows[0]["FinThickness"].ToString();
                    lblTubeMaterialValue.Text = coilLogic.Rows[0]["TubeMaterial"].ToString();
                    lblTubeThicknessValue.Text = coilLogic.Rows[0]["TubeThickness"].ToString();
                    lblFanWideValue.Text = coilLogic.Rows[0]["FanWide"].ToString();
                    lblFanLongValue.Text = coilLogic.Rows[0]["FanLong"].ToString();
                    lblCoilModelValue.Text = CoilModelName();
                }

                //Find the motor to use in the "motor" kit.... no real way... try ALL the names until one hits....

                if (motorName.Count > 0)
                {
                    DataTable piecesForMotorKit =
                        Query.Select(
                            "Select PiecesID, KitID from KitPiecesRelationship where KitID = (Select KitID from KitInfo where KitName like '" +
                            motorName[0] + "')");
                    DataTable allMotors = Query.Select("Select Distinct(MotorID) from MotorModel");
                    foreach (DataRow motor in allMotors.Rows)
                    {
                        foreach (DataRow pieceMotor in piecesForMotorKit.Rows)
                        {
                            if (pieceMotor["PiecesId"].ToString() == motor["MotorID"].ToString() ||
                                ReplaceMinus(pieceMotor["PiecesId"].ToString()) ==
                                ReplaceMinus(motor["MotorID"].ToString()))
                            {
                                lblMotorModelValue.Text = motor["MotorID"].ToString();
                                break;
                            }
                        }
                    }
                    //use the found motor to calculate the CFM
                    DataTable cfm =
                        Query.Select("Select CFM from moduleMotorCFM where moduleID = " +
                                     piecesForMotorKit.Rows[0]["kitID"] +
                                     " and coilName = '" + lblCoilModelValue.Text + "'");
                    int quantity = 0;
                    foreach (ListViewItem piece in lv_Pieces.Items)
                    {
                        if (piece.SubItems[0].Text.Contains("MOTOR"))
                        {
                            quantity = Convert.ToInt32(piece.SubItems[3].Text);
                        }
                    }
                    if (cfm.Rows.Count > 0)
                    {
                        lblCFMValue.Text =(quantity*Convert.ToInt32(cfm.Rows[0]["CFM"])).ToString(CultureInfo.InvariantCulture);
                    }
                }

                //fourth tab
                radCapacity.Checked = true;
            
            
        }

        private string ReplaceMinus(string toReplace)
        {
            string toReturn = "";
            foreach (char chr in toReplace)
            {
                if (chr != '-')
                {
                    toReturn += chr;
                }
            }
            return toReturn;
        }

        private void AutoBalance(decimal balancingMin, decimal balancingMax, decimal sstMin, decimal sstMax)
        {
            try
            {
                if (lvBalancing.Items.Count > 0)
                {
                    if (lvCompressor.Items.Count > 0)
                    {

                        List<Compressor> listCompressors = GetCompressors();

                        if (listCompressors.Count == 0)
                        {
                            Public.LanguageBox("Your compressors don’t seem to exist at that voltage, with that refrigerant.  Try rechecking them and retry balancing", "Vos compresseurs semblent ne pas exister à ce voltage, ou avec ce réfrigérant.  Veuillez confirmer avant de rebalancer.  Merci!");
                        }
                        else
                        {
                            
                        
                            if (CheckIfModuleExists("COIL", 1))
                            {

                                DataTable finMaterial =
                                    Query.Select("Select FinMaterialParameter from CoilFinMaterial where finMaterial = '" +
                                                 lblFinMaterialValue.Text + "'");
                                DataTable tubeMaterial =
                                    Query.Select("Select tubeMaterialParameter, TubeType from CoilTubeMaterial where TubeMaterial = '" +
                                                 lblTubeMaterialValue.Text + "'");
                                //if there is a coil we balance the coil with compressor

                                Fill_BalancindData(
                                    Balancing.CompressorCondenserCoil.GetBalancingData(
                                        balancingMin,
                                        balancingMax,
                                        sstMin,
                                        sstMax,
                                        GetCompressors(),
                                        lblFinTypeValue.Text[0].ToString(CultureInfo.InvariantCulture) + lblFinShapeValue.Text[0],
                                        Convert.ToDecimal(lblFinHeightValue.Text),
                                        Convert.ToDecimal(lblFinLengthValue.Text),
                                        Convert.ToDecimal(lblCFMValue.Text),
                                        lblRefrigerantValue.Text,
                                        Convert.ToDecimal(lblFPIValue.Text),
                                        Convert.ToInt32(lblCircuitsValue.Text),
                                        Convert.ToDecimal(lblRowsValue.Text),
                                        finMaterial.Rows[0]["FinMaterialParameter"].ToString(),
                                        Convert.ToDecimal(lblFinThicknessValue.Text),
                                        tubeMaterial.Rows[0]["TubeMaterialParameter"].ToString(),
                                        Convert.ToDecimal(lblTubeThicknessValue.Text),
                                        tubeMaterial.Rows[0]["tubeType"].ToString()));
                            }
                            else
                            {
                                //no balancing needed we simply run performance of the compressor
                                Fill_BalancindData(
                                    Balancing.CompressorBalancing.GetBalancingData(
                                         balancingMin,
                                        balancingMax,
                                        sstMin,
                                        sstMax,
                                        GetCompressors()));
                            }
                            Focus();
                        }
                    }
                    else
                    {
                        Public.LanguageBox("This unit does not have any compressor(s) configured", "Cette unité n'a aucun compresseur de configuré");
                    }
                }
                else
                {
                    Public.LanguageBox("The table is not set for balancing. It cannot receive data yet.", "Le tableau n'est pas près à recevoir des données. Vérifiez que le format est bien affiché.");
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "frmCondensingUnitModel AutoBalance");
                MessageBox.Show(ex.ToString());
                Public.LanguageBox("An error occured while trying to balance.", "Une erreur est survenue lors du balancement.");
            }
        }


        private void Fill_BalancindData(IEnumerable<BalancingData> bd)
        {
            bool coilPresent = CheckIfModuleExists("COIL", 1);
            if (bd != null)
            {
// ReSharper disable PossibleMultipleEnumeration
                _globalBalancing = bd;
                foreach (BalancingData data in bd)
// ReSharper restore PossibleMultipleEnumeration
                {
                    if (coilPresent)
                    {
                        lvBalancing.Items[GetRowIndex(data.AMBIENT)].SubItems[GetColumnIndex(data.SST)].Text = Math.Round(Convert.ToDecimal(data.CAPACITY / 1000m), 2).ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        lvBalancing.Items[GetRowIndex(data.CONDENSING)].SubItems[GetColumnIndex(data.SST)].Text = Math.Round(Convert.ToDecimal(data.CAPACITY / 1000m), 2).ToString(CultureInfo.InvariantCulture);
                    }
                }
            }

            lvBalancing.Refresh();
        }

        private void FormatBalancingTable(decimal balancingMin, decimal balancingMax, decimal sstMin, decimal sstMax)
        {
            lvBalancing.Items.Clear();
            lvBalancing.Columns.Clear();
            lvBalancing.Refresh();

            //add the header column for sst and ambient
            lvBalancing.Columns.Add(new GLColumn("Balancing \\ SST"));

            //add sst columns
            for (int i = Convert.ToInt32(sstMin); i <= Convert.ToInt32(sstMax); i++)
            {
                var myCol = new GLColumn
                {
                    ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox,
                    Width = Convert.ToInt32(50),
                    Text = i.ToString(CultureInfo.InvariantCulture)
                };
                lvBalancing.Columns.Add(myCol);
            }

            //add rows to contain data for each ambient
            for (int i = Convert.ToInt32(balancingMin); i <= Convert.ToInt32(balancingMax); i++)
            {

                var myItem = new GLItem(lvBalancing);
                myItem.SubItems[0].Text = i.ToString(CultureInfo.InvariantCulture);

                int totalSST = Convert.ToInt32(sstMax) - Convert.ToInt32(sstMin);
                for (int sst = 0; sst <= totalSST; sst++)
                {
                    myItem.SubItems[sst + 1].Text = "";
                }

                lvBalancing.Items.Add(myItem);
            }

            lvBalancing.Refresh();
        }




        //Coil Model Name
        private string CoilModelName()
        {
            //variable that will be return and contian the model name

            //add the prefix
            string strReturnValue = "C";

            //add the fin Type
            strReturnValue = strReturnValue + lblFinTypeValue.Text[0].ToString(CultureInfo.InvariantCulture);

            //add the fin shape
            strReturnValue = strReturnValue + lblFinShapeValue.Text[0].ToString(CultureInfo.InvariantCulture);

            //add a dash
            strReturnValue = strReturnValue + "-";

            DataTable facetube =
                Query.Select("Select Facetube from CoilFinType where fintype = '" + lblFinTypeValue.Text[0].ToString(CultureInfo.InvariantCulture) + "'");
            //add the tubes
            strReturnValue = strReturnValue + Convert.ToInt32(lblFinHeightValue.Text)/Convert.ToInt32(facetube.Rows[0]["FaceTube"].ToString());

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add number of rows (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + lblRowsValue.Text.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add FPI (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + Convert.ToDecimal(lblFPIValue.Text).ToString("0.").PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add fin length (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + Convert.ToDecimal(lblFinLengthValue.Text).ToString("0#.###");

            return strReturnValue;
        }
        private int GetRowIndex(decimal balancing)
        {

            for (int i = 0; i < lvBalancing.Items.Count; i++)
            {
                if (Convert.ToInt32(lvBalancing.Items[i].SubItems[0].Text) == Convert.ToInt32(balancing))
                {
                    return i;
                }
            }

            return lvBalancing.Items.Count;
        }

        private int GetColumnIndex(decimal sst)
        {
            int colIndex = -1;

            //first column is textual so we bypass it
            for (int i = 1; i < lvBalancing.Columns.Count; i++)
            {
                if (Convert.ToInt32(lvBalancing.Columns[i].Text) == Convert.ToInt32(sst))
                {
                    colIndex = i;
                    i = lvBalancing.Columns.Count;
                }
            }

            return colIndex;
        }

        private List<Compressor> GetCompressors()
        {
            var listOfCompressors = new List<Compressor>();

            for (int i = 0; i < lvCompressor.Items.Count; i++)
            {
                DataTable dtCompressorData = Query.Select("Select * from CompressorData where Compressor = '" + lvCompressor.Items[i].SubItems[0].Text + "' AND RefrigerantID = " + lvCompressor.Items[i].SubItems[2].Text + " AND VoltageID = " + lvCompressor.Items[i].SubItems[1].Text);

                if (dtCompressorData.Rows.Count == 0)
                {
                    listOfCompressors.Clear();
                    break;
                }
                listOfCompressors.Add(new Compressor(
                    lvCompressor.Items[i].SubItems[0].Text,
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity1"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity2"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity3"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity4"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity5"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity6"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity7"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity8"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity9"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Capacity10"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power1"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power2"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power3"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power4"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power5"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power6"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power7"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power8"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power9"]),
                    Convert.ToDecimal(dtCompressorData.Rows[0]["Power10"]),
                    0m,
                    ""));
            }

            return listOfCompressors;
        }
        

        private void radCapacity_CheckedChanged_1(object sender, EventArgs e)
        {
            ShowProperCapacityList();
        }

        private void radCommercializedCapacity_CheckedChanged_1(object sender, EventArgs e)
        {
            ShowProperCapacityList();

        }
        //At this point, the lvSecondaryTable is the table shown.  We refill it with the new values, depending on what's checked.  It's slower than having 3 OTHER tables, but
        //Simon wants the emphasis to be on the balancing in terms of speed, not the switch between capacities, which won't happen so often aparently
        private void ReFillViewTable()
        {
            lvSecondaryTable.Items.Clear();
            lvSecondaryTable.Columns.Clear();
            lvSecondaryTable.Refresh();

            foreach (GLColumn colBalancing in lvBalancing.Columns)
            {
                var colCommercialized = new GLColumn
                {
                    Text = colBalancing.Text,
                    Width = colBalancing.Width
                };

                lvSecondaryTable.Columns.Add(colCommercialized);
            }

            foreach (GLItem iBalancing in lvBalancing.Items)
            {
                var iCommercialized = new GLItem(lvSecondaryTable)
                {
                    ForeColor = Color.Blue
                };

                iCommercialized.SubItems[0].Text = iBalancing.SubItems[0].Text;
                for (int iCol = 1; iCol < lvSecondaryTable.Columns.Count; iCol++)
                {
                    //Not ideal... might be better to copy the global and then delete the items as we add them?
                    foreach (BalancingData data in _globalBalancing)
                    {
                        
                        if (data.AMBIENT == Convert.ToDecimal(iCommercialized.SubItems[0].Text) && data.SST.ToString(CultureInfo.InvariantCulture) == lvBalancing.Columns[iCol].Text)
                            {
                            
                            decimal toUse = 0m;
                            if (radCommercializedCapacity.Checked)
                            {
                                toUse = ((data.CAPACITY/1000m) *((100m + nUd_CommercialFactorValue.Value) / 100m));
                            }
                            else if (radCondensing.Checked)
                            {
                                toUse = data.CONDENSING;
                            }
                            else if (radLiquidPressureDrop.Checked)
                            {
                                toUse = data.LIQUIDPRESSUREDROP;
                            }
                     
                            iCommercialized.SubItems[iCol].Text = toUse.ToString(CultureInfo.InvariantCulture);
                                break;
                            }
                    }

                }

                lvSecondaryTable.Items.Add(iCommercialized);
            }

            lvSecondaryTable.Refresh();
        }


        private void ShowProperCapacityList()
        {
            lvBalancing.Visible = false;
            lvSecondaryTable.Visible = false;

            if (radCapacity.Checked)
            {
                lvBalancing.Visible = true;
            }
            
            if (radCommercializedCapacity.Checked || radLiquidPressureDrop.Checked || radCondensing.Checked)
            {
                ReFillViewTable();
                lvSecondaryTable.Visible = true;
            }
        }

        //This function Refills the "view" table, that will refill the secondary table before displaying it.
        

        private void btnBalance_Click(object sender, EventArgs e)
        {
                if (CheckIfModuleExists("COIL", 1) && CheckIfModuleExists("COMPRESSOR", 1) && CheckIfModuleExists("MOTOR", 1))
            {
                if(VerifyRatioTotal())
                {
                    FormatBalancingTable(Convert.ToDecimal(num_BalancingMin.Value), Convert.ToDecimal(num_BalancingMax.Value), Convert.ToDecimal(num_SSTMin.Value), Convert.ToDecimal(num_SSTMax.Value));
                    AutoBalance(Convert.ToDecimal(num_BalancingMin.Value), Convert.ToDecimal(num_BalancingMax.Value), Convert.ToDecimal(num_SSTMin.Value), Convert.ToDecimal(num_SSTMax.Value));
                    radCapacity.Checked = true;
                }
                else
                {
                    Public.LanguageBox("Your ratios in your condensing unit do not totalize 100.  The system will go compressor by compressor so you can reassign the values.  Thank you!", "Vos ratios totalisés ensembles ne font pas 100%.  Le système passera donc, compresseur par compresseur, pour que vous puissiez réajuster les ratios. Merci!");
                    RedoAllRatios();
                }
            }
            else
            {
                Public.LanguageBox(
                    "Your unit does not have all it needs to balance.  Make sure you have a Coil, a Motor, and a compressor, before balancing.  Thank you!",
                    "Votre unité ne peut pas être balancée, car il manque au moins un module.  Validez que vous avez bien un serpentin, un moteur, et un compresseur.  Merci!");
            }
        }

        private bool CheckMachineSpecificsForSave()
        {
            switch (cmb_Types.Text)
            {
                case ("Condensing Unit"):
                    if (lvCompressor.Items.Count == 0 || lvBalancing.Items.Count == 0 || !CheckIfModuleExists("COIL", 1)||!CheckIfModuleExists("COMPRESSOR",1)||!CheckIfModuleExists("MOTOR",1))
                    {
                        return false;
                    }
                    return true;
                    
                default:
                    return true;
            }
        }
        private void SaveMachine()
        {
            switch (cmb_Types.Text)
            {
                case ("Condensing Unit"):
                    SaveCondensing();
                    break;
            }
        }
        private void UpdateMachine()
        {
            switch (cmb_Types.Text)
            {
                case ("Condensing Unit"):
                    DeleteCondensing();
                    SaveCondensing();
                    break;
            }
        }

        public void SaveCondensing()
        {
            string model = _loadedMachineName;
            string minBalancing = num_BalancingMin.Text;
            string maxBalancing = num_BalancingMax.Text;
            string minSST = num_SSTMin.Text;
            string maxSST = num_SSTMax.Text;

   

            for (int j = 0; j < Convert.ToInt32(Convert.ToDecimal(maxBalancing).ToString("00.")) - Convert.ToInt32(Convert.ToDecimal(minBalancing).ToString("00.")) +1 ; ++j)
            {
                for (int k = 0; k < Convert.ToInt32(Convert.ToDecimal(maxSST).ToString("00.")) - Convert.ToInt32(Convert.ToDecimal(minSST).ToString("00.")) +1 ; ++k)
                {
                    Query.Execute("Insert into condensingUnitBalancingTest  VALUES('" + model + "'," + (Convert.ToInt32(Convert.ToDecimal(minBalancing).ToString("00.")) + j) + "," + (Convert.ToInt32(Convert.ToDecimal(minSST).ToString("00.")) + k) +
                              "," + lvBalancing.Items[j].SubItems[k+1].Text + ")");
                }
            }
            
            Query.Execute("Insert into MachineCondensingUnit Values ("+ _loadedMachineID + "," + num_BalancingMin.Value + "," +
                          num_BalancingMax.Value + "," + num_SSTMin.Value + "," + num_SSTMax.Value + "," +
                          nUd_CommercialFactorValue.Value + ")");
        }

    

        public void DeleteCondensing()
        {
            Query.Execute("Delete from condensingUnitBalancingTest where model = '" + _loadedMachineName + "'");
            Query.Execute(
                "Delete from machineCondensingUnit where machineID = (Select MachineID from machine where machineName = '" +
                _loadedMachineName + "')");
        }

        private void ResetCondensing()
        {
           
            lblCFMValue.Text = "";
            lblCoilModelValue.Text = "";
            lblFPIValue.Text = "";
            lblFanLongValue.Text = "";
            lblFanWideValue.Text = "";
            lblFinHeightValue.Text = "";
            lblFinLengthValue.Text = "";
            lblFinMaterialValue.Text = "";
            lblFinShapeValue.Text = "";
            lblFinTypeValue.Text = "";
            lblMotorModelValue.Text = "";
            lblCircuitsValue.Text = "";
            lblOptionsValue.Text = "";
            lblRowsValue.Text = "";
            lblTubeMaterialValue.Text = "";
            lblTubeThicknessValue.Text = "";
            lblOptionsValue.Text = "";
            lblFinThicknessValue.Text = "";

        }

        private void num_Weight_ValueChanged(object sender, EventArgs e)
        {
            comboBox1.Text = @"M";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == @"A")
            {
                num_Weight.Value = CalculateWeight();
                comboBox1.Text = @"A";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lv_Pieces.SelectedItems.Count == 0)
            {
                Public.LanguageBox("Please select a unit before clicking on this button.  Thank you",
                    "Veuillez sélectionner une unité avant de cliquer ici.  Merci!");
            }
            else
            {
                var currentIndex = lv_Pieces.SelectedItems[0].Index;
                var item = lv_Pieces.Items[currentIndex];
                if (currentIndex > 0)
                {
                    lv_Pieces.Items.RemoveAt(currentIndex);
                    lv_Pieces.Items.Insert(currentIndex - 1, item);
                    lv_Pieces.Items[currentIndex - 1].Selected = true;
                    lv_Pieces.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lv_Pieces.SelectedItems.Count == 0)
            {
                Public.LanguageBox("Please select a unit before clicking on this button.  Thank you",
                    "Veuillez sélectionner une unité avant de cliquer ici.  Merci!");
            }
            else
            {
                var currentIndex = lv_Pieces.SelectedItems[0].Index;
                var item = lv_Pieces.Items[currentIndex];
                if (currentIndex < lv_Pieces.Items.Count - 1)
                {
                    lv_Pieces.Items.RemoveAt(currentIndex);
                    lv_Pieces.Items.Insert(currentIndex + 1, item);
                    lv_Pieces.Items[currentIndex + 1].Selected = true;
                    lv_Pieces.Focus();
                }
            }
        }

        private void txtFirstPart_Enter(object sender, EventArgs e)
        {
            txtFirstPart.SelectAll();
        }

        private void txtSecondPart_Enter(object sender, EventArgs e)
        {
            txtSecondPart.SelectAll();
        }

        private void txtThirdPart_Enter(object sender, EventArgs e)
        {
            txtThirdPart.SelectAll();
        }

        private void txtFourthPart_Enter(object sender, EventArgs e)
        {
            txtFourthPart.SelectAll();
        }

        private void txtOptions_Enter(object sender, EventArgs e)
        {
            txtOptions.SelectAll();
        }

        private void nUdOptionsForLevel_Enter(object sender, EventArgs e)
        {
            nUdOptionsForLevel.Select(0, nUdOptionsForLevel.Text.Length);
        }

        private void nUd_Access_Enter(object sender, EventArgs e)
        {
            nUd_Access.Select(0, nUd_Access.Text.Length);
        }

        private void nUd_labBurd_Enter(object sender, EventArgs e)
        {
            nUd_labBurd.Select(0, nUd_labBurd.Text.Length);
        }

        private void nUd_Profit_Enter(object sender, EventArgs e)
        {
            nUd_Profit.Select(0, nUd_Profit.Text.Length);
        }

        private void nUd_List_Enter(object sender, EventArgs e)
        {
            nUd_List.Select(0, nUd_List.Text.Length);
        }

        private void num_Weight_Enter(object sender, EventArgs e)
        {
            num_Weight.Select(0, num_Weight.Text.Length);
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.SelectAll();
        }

        private void num_BalancingMin_Enter(object sender, EventArgs e)
        {
            num_BalancingMin.Select(0, num_BalancingMin.Text.Length);
        }

        private void num_BalancingMax_Enter(object sender, EventArgs e)
        {
            num_BalancingMax.Select(0, num_BalancingMax.Text.Length);
        }

        private void num_SSTMin_Enter(object sender, EventArgs e)
        {
            num_SSTMin.Select(0, num_SSTMin.Text.Length);
        }

        private void num_SSTMax_Enter(object sender, EventArgs e)
        {
            num_SSTMax.Select(0, num_SSTMax.Text.Length);
        }

        private void nUd_CommercialFactorValue_Enter(object sender, EventArgs e)
        {
            nUd_CommercialFactorValue.Select(0, nUd_CommercialFactorValue.Text.Length);
        }
        private void LoadMachineNameToTextBoxes()
        {
            switch (cmb_Types.Text)
            {
                case ("Condensing Unit"):
                    txtFirstPart.Text = _loadedMachineName.Substring(0, 3);
                    txtSecondPart.Text = _loadedMachineName.Substring(4, 3);
                    txtThirdPart.Text = _loadedMachineName.Substring(8, 3);
                    txtFourthPart.Text = _loadedMachineName.Substring(12, 1);
                    txtOptions.Text = _loadedMachineName.Length > 13 ? _loadedMachineName.Substring(13) : "";
                    txtFirstPart.Focus();
                    txtSecondPart.Focus();
                    txtThirdPart.Focus();
                    txtFourthPart.Focus();
                    txtOptions.Focus();
                    cmb_Unit.Focus();
                    break;
            }
        }

        private void lvCompressor_DoubleClick(object sender, EventArgs e)
        {
            if (lvCompressor.SelectedItems.Count > 0)
            {
                var ratio = new FrmRatio();
                ratio.ShowDialog();
                GLItem myItem = lvCompressor.Items[Convert.ToInt32(lvCompressor.SelectedIndicies[0].ToString())];
                myItem.SubItems[7].Text = ratio.GetRatio().ToString(CultureInfo.InvariantCulture);
                foreach (Pair rate in _compressorRatiosForCondensingUnits)
                {
                    if (rate.Second.ToString() ==
                        lvCompressor.Items[Convert.ToInt32(lvCompressor.SelectedIndicies[0].ToString())].Text)
                    {
                        rate.First = ratio.GetRatio().ToString(CultureInfo.InvariantCulture);
                    }
                }
            }
            else
            {
                Public.LanguageBox("Please select a unit before double-clicking.  Thank you", "Veuillez sélectionner une unité avant de double-clicker.  Merci!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_loadedMachineName == "")
            {
                Public.LanguageBox(
                    "You can't update prices when you haven't loaded a machine yet.  Please load a machine.",
                    "Vous ne pouvez mettre à jour les prix pour une machine sans avoir préalablement chargé de machine.  Veuillez corriger.");
            }
            else
            {
                foreach (ListViewItem piece in lv_Pieces.Items)
                {
                    Query.Execute("Update MachinePieces set UnitPriceSaved = (Select price from kitInfo where kitName = '" +
                                  piece.SubItems[1].Text + "') where piecename like '%" + piece.SubItems[1].Text +
                                  "%' and machineID = (Select machineID from machine where machineName = '" +
                                  _loadedMachineName + "')");
                }
                decimal newPrice;
                if (grossProfit.Checked)
                {
                    Query.Execute("Update Machine set grossProfit = " + grossProfit.Text + " where MachineName = '" +
                                  _loadedMachineName + "'");
                    newPrice = Convert.ToDecimal(txtListPriceUpdated.Text);
                }
                else
                {
                    newPrice = Convert.ToDecimal(listPrice_Text.Text);
                }
                Query.Execute("Update Machine set Price = " + newPrice + " where MachineName = '" +_loadedMachineName + "'");
                LoadUnit(_loadedMachineName);
            }
        }

        private void btnBacklog_Click(object sender, EventArgs e)
        {
            var frmBacklog = new FrmBacklog();
            frmBacklog.Show();
        }

        private void cmb_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThreadProcess.Start("Loading machine");
            LoadUnit(cmb_Unit.Text);
            ThreadProcess.Stop();
            decimal grossProfitNeeded = 0;


            if (Convert.ToDecimal(txtMatLabUpdated.Text) != 0m && num_FactorUpdated.Value != 0m)
            {
                grossProfitNeeded = (Convert.ToDecimal(listPrice_Text.Text) /
                                (Convert.ToDecimal(txtMatLabUpdated.Text) * num_FactorUpdated.Value));
                grossProfitNeeded = (grossProfitNeeded - 1) * 100;
            }

            grossProfit.Text = grossProfitNeeded.ToString("0.00000");
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This starts by evaluating what's in the textbox next to it, then calculates the value of gross profit needed to get to that list price with the material cost and burden ratio we have, before putting that value in the gross profit numerical Up Down
            decimal test;
            //checking that we have a number
            if (Decimal.TryParse(txtTargetList.Text, out test))
            {
                decimal profitNeeded = ((Convert.ToDecimal(txtTargetList.Text)/
                                         (Convert.ToDecimal(matLabBurd_Text.Text)*nUd_List.Value)) -1) * 100;
                if(profitNeeded < 0)
                {
                    Public.LanguageBox("To obtain your target, we need a negative profit value.  Try to boost your target to at least : " + (Convert.ToDecimal(matLabBurd_Text.Text) * nUd_List.Value), "Pour atteindre votre cible, le profit doit être négatif.  Essayez de monter votre cible à ce chiffre au minimum : " + (Convert.ToDecimal(matLabBurd_Text.Text) * nUd_List.Value));
                }
                else
                {
                    nUd_Profit.Text = profitNeeded.ToString("0.00000");
                }
            }
            else
            {
                Public.LanguageBox("Your target is not a number, therefore it's impossible to calculate.","Votre prix cible n'est pas un nombre, donc il est impossible de calculer le profit nécessaire");
            }
            txtTargetList.Text = "";
        }

        private void NewUnit()
        {
            lv_Pieces.Items.Clear();
            cmb_Unit.Text = "";
            nUd_Profit.Value = 30.00000m;
            nUd_labBurd.Value = 25m;
            nUd_List.Value = 3.39m;
            grossProfit.Text = "";
            switch (cmb_Types.Text)
            {
                case ("Condensing Unit"):
                    _compressorRatiosForCondensingUnits.Clear();
                     lblTypeValue.Text = "";
                    lblCompressorTypeValue.Text = "";
                    lblCompressorManufacturerValue.Text = "";
                    lblApplicationValue.Text = "";
                    lblRefrigerantValue.Text = "";
                    lblVoltageValue.Text = "";
                    lblHPValue.Text = "";
                    lblNumberOfCompressorsValue.Text = "";
                    lvCompressor.Items.Clear();
                    lvBalancing.Items.Clear();
                    _globalBalancing = null;
                    lvSecondaryTable.Items.Clear();
                    num_Weight.Value = 0.00m;
                    comboBox1.Text = @"A";
                    num_BalancingMin.Value = 90.00m;
                    num_BalancingMax.Value = 105.00m;
                    num_SSTMin.Value = 25.00m;
                    num_SSTMax.Value = 45.00m;
                    nUd_CommercialFactorValue.Value = 0.00m;
                    ResetCondensing();
                    txtFirstPart.Text = "";
                    txtSecondPart.Text = "";
                    txtThirdPart.Text = "";
                    txtFourthPart.Text = "";
                    txtOptions.Text = "";
                    lvCompressor.Refresh();
                    lvBalancing.Refresh();
                    lvSecondaryTable.Refresh();
                    break;
            }
            UpdatePrices(GetMaterialCost());
        }
        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            NewUnit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ShowProperCapacityList();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ShowProperCapacityList();
        }
    }
}
