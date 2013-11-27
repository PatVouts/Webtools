
namespace DLLHeatPipeReport
{
    public class HeatPipeReportTranslation
    {
        public static void setReportLanguage(HeatPipeSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtTitle"]).Text = language == "EN" ? "HEAT PIPE SPECIFICATIONS" : "SP�CIFICATIONS CALODUCS";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtTitle2"]).Text = language == "EN" ? "HEAT PIPE SPECIFICATIONS" : "SP�CIFICATIONS CALODUCS";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtInputs"]).Text = language == "EN" ? "INPUTS" : "ENTR�ES";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtModel"]).Text = language == "EN" ? "Model" : "Mod�le";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAirFlowSupply"]).Text = language == "EN" ? "Air Flow Supply" : "D�bit d'Air d'Approvisionnement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAirFlowExhaust"]).Text = language == "EN" ? "Air Flow Exhaust" : "D�bit d'Air d'�chappement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSymmetrical"]).Text = language == "EN" ? "Symmetrical" : "Sym�trique";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAltitude"]).Text = "Altitude";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOutAirDryBulb"]).Text = language == "EN" ? "Outside Air Dry Bulb" : "Bulbe S�che ext�rieur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOutAirWetBulb"]).Text = language == "EN" ? "Outside Air Wet Bulb" : "Bulbe Humide ext�rieur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOutAirRH"]).Text = language == "EN" ? "Outside Air Relative Humidity" : "Humidit� Relative Ext�rieur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtReturnAirDryBulb"]).Text = language == "EN" ? "Return Air Dry Bulb" : "Bulbe S�che de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtReturnAirWetBulb"]).Text = language == "EN" ? "Return Air Wet Bulb" : "Bulbe Humide de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtReturnAirRH"]).Text = language == "EN" ? "Return Air Relative Humidity" : "Humidit� Relative de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinType"]).Text = language == "EN" ? "Fin Type" : "Type d'Ailettes" ;
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinHeight"]).Text = language == "EN" ? "Fin Height" : "Hauteur des Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinLength"]).Text = language == "EN" ? "Fin Length" : "Longueur d'Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFPI"]).Text = language == "EN" ? "Fins per Inch" : "Ailettes par Pouce";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtShape"]).Text = language == "EN" ? "Shape" : "Forme";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAtmosphericPressure"]).Text = language == "EN" ? "Atmospheric Pressure" : "Pression Atmosph�rique";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFlowType"]).Text = language == "EN" ? "Flow Type" : "Type de Circulation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTiltAngle"]).Text = language == "EN" ? "Tilt Angle" : "Angle d'Inclinaison";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDefrostSetPoint"]).Text = language == "EN" ? "Defrost Set Point" : "Point de D�congelation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilDesc"]).Text = language == "EN" ? "Coils are individuallly designed for a high heat transfer performance, low initial cost and long life durability. The staggered tube provides a turbulent air flow through the coil." : "Les bobines sont con�ues individuellement pour un transfert de chaleur �lev�e, faible co�t initial et longue dur�e de vie. Le tube �chelonn�e fournit un flux d'air turbulent � travers la bobine.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTubeDesc"]).Text = language == "EN" ? "Tubes are grooved, seamless copper (G = 5/8\" [51mm], P = 1-1/8\" [62mm], manufactured to ASME specifications. Tube are mechanically expanded into fin collars for permanent bond." : "Les tubes sont rainur�s, sans soudure en cuivre (G = 5 / 8 \"[51 mm], P = 1-1/8\" [62 mm], construit � la norme ASME cahier des charges. Tube sont m�caniquement �largi en fin de colliers lien permanent.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinDesc"]).Text = language == "EN" ? "Fins are aluminum, die formed plate type. They are flat or sine wave to match any application. Fin configuration promotes maximum heat transfer effectiveness with minimum air friction. Full fin collar provide accurate fin spacing and full coverage over the tubes." : "Les ailettes sont en aluminium, meurent de type plaque form�e. Ils sont � plat ou � onde sinuso�dale pour correspondre � n'importe quelle application. Fin de configuration favorise au maximum l'efficacit� de transfert de chaleur par friction minimale de l'air. Plein col fin d'assurer l'espacement fin pr�cise et une couverture compl�te sur les tubes.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFramesDesc"]).Text = language == "EN" ? "Frames are heavy-gauge galvanized steel. Top and bottom plates have double bends for more rigidity. Tube sheets have die formed extruded tube holes for maximum tube support. Intermediate tube sheet is provided to avoid air bypass. Optional material: Extra heavy-gauge galvanized steel, aluminum, stainless steel, brass or copper." : "Les cadres sont de gros calibre en acier galvanis�. plaques sup�rieure et inf�rieure de courbures doubles pour plus de rigidit�. Tube feuilles ont form� mourir extrud� trous tube pour tube de soutien maximum. fiche tube interm�diaire est pr�vu pour �viter de d�rivation d'air. mati�res en option: Extra gros calibre en acier galvanis�, aluminium, inox, laiton ou cuivre.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtBrazingAlloysDesc"]).Text = language == "EN" ? "Brazing Alloys are manufactured to AWS specifications. All coil joints are hand brazed with high temperature brazing filler metal." : "Brasures sont fabriqu�s selon les sp�cifications de l'AWS. Tous les joints sont bobine main bras�es � haute temp�rature de brasage m�tal d'apport.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTestingDesc"]).Text = language == "EN" ? "Testing: All coils are tested with 400 psig - 40�F dew points dry air under warm water." : "Test: Toutes les batteries sont test�es � 400 psig - 40 � F points de ros�e de l'air sec sous l'eau chaude.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOutputs"]).Text = language == "EN" ? "OUTPUTS" : "SORTIES";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFaceTubes"]).Text = language == "EN" ? "Face Tubes" : "Tubes � la face";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinLengthSupply"]).Text = language == "EN" ? "Fin Length Supply Side" : "Longueur des ailettes du c�t� de l�alimentation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinLengthReturn"]).Text = language == "EN" ? "Fin Length Return Side" : "Longueur des ailettes du c�t� du retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtWeight"]).Text = language == "EN" ? "Weight" : "Poids";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCondensate"]).Text = language == "EN" ? "Condensate" : "Condensat";
            //((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMixingAirSupply"]).Text = language == "EN" ? "Mixing Air Flow Supply" : "�coulement du m�lange d�air � l�alimentation";
            //((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAirFlowSupplyBypass"]).Text = language == "EN" ? "Air Flow Supply Bypass" : "D�tournement du m�lange d�air � l�alimentation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeatPipeEfficiency"]).Text = language == "EN" ? "Heat Pipe Efficiency" : "Efficacit� du caloduc";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeatPipeSensible"]).Text = language == "EN" ? "Sensible Effectiveness" : "Efficacit� sensible";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeatPipeLatent"]).Text = language == "EN" ? "Latent Effectiveness" : "Efficacit� latent";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeatPipeTotal"]).Text = language == "EN" ? "Total Effectiveness" : "Efficacit� totale";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoolingCoilEfficiency"]).Text = language == "EN" ? "Cooling Coil Efficiency" : "Efficacit� du serpentin de refroidissement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoolingSensible"]).Text = language == "EN" ? "Sensible Effectiveness" : "Efficacit� sensible";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoolingTotal"]).Text = language == "EN" ? "Cooling Effectiveness" : "Efficacit� de refroidissement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyTitle"]).Text = language == "EN" ? "Entering Supply Air (T1)" : "Entr� d�air � l�alimentation (T1)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringSupplyEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyTitle"]).Text = language == "EN" ? "Leaving Supply Air (T2)" : "Sortie d�air � l�alimentation (T2)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingSupplyDrop"]).Text = language == "EN" ? "Pressure Drop" : "Chute de pression";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustTitle"]).Text = language == "EN" ? "Leaving Exhaust Air (T4)" : "Sortie d�air � l��vacuation (T4)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLeavingExhaustDrop"]).Text = language == "EN" ? "Pressure Drop" : "Chute de pression";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustTitle"]).Text = language == "EN" ? "Entering Exhaust Air (T3)" : "Entr� d�air � l��vacuation (T3)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEnteringExhaustEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtTested"]).Text = language == "EN" ? "Tested in accordance with ARI standards" : "Test� en conformit� avec les normes ARI";

            //winter
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterInputs"]).Text = language == "EN" ? "INPUTS" : "ENTR�ES";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterModel"]).Text = language == "EN" ? "Model" : "Mod�le";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterAirFlowSupply"]).Text = language == "EN" ? "Air Flow Supply" : "D�bit d'Air d'Approvisionnement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterAirFlowExhaust"]).Text = language == "EN" ? "Air Flow Exhaust" : "D�bit d'Air d'�chappement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterSymmetrical"]).Text = language == "EN" ? "Symmetrical" : "Sym�trique";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterAltitude"]).Text = "Altitude";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterOutAirDryBulb"]).Text = language == "EN" ? "Outside Air Dry Bulb" : "Bulbe S�che ext�rieur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterOutAirWetBulb"]).Text = language == "EN" ? "Outside Air Wet Bulb" : "Bulbe Humide ext�rieur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterOutAirRelativeHumidity"]).Text = language == "EN" ? "Outside Air Relative Humidity" : "Humidit� Relative Ext�rieur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterReturnAirDryBulb"]).Text = language == "EN" ? "Return Air Dry Bulb" : "Bulbe S�che de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterReturnAirWetBulb"]).Text = language == "EN" ? "Return Air Wet Bulb" : "Bulbe Humide de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterReturnAirRelativeHumidity"]).Text = language == "EN" ? "Return Air Relative Humidity" : "Humidit� Relative de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFinType"]).Text = language == "EN" ? "Fin Type" : "Type d'Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFinHeight"]).Text = language == "EN" ? "Fin Height" : "Hauteur des Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFinLength"]).Text = language == "EN" ? "Fin Length" : "Longueur d'Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFPI"]).Text = language == "EN" ? "Fins per Inch" : "Ailettes par Pouce";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterShape"]).Text = language == "EN" ? "Shape" : "Forme";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterAtmosphericPressure"]).Text = language == "EN" ? "Atmospheric Pressure" : "Pression Atmosph�rique";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFlowType"]).Text = language == "EN" ? "Flow Type" : "Type de Circulation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterTiltAngle"]).Text = language == "EN" ? "Tilt Angle" : "Angle d'Inclinaison";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterDefrostSetPoint"]).Text = language == "EN" ? "Defrost Set Point" : "Point de D�congelation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterCoilDesc"]).Text = language == "EN" ? "Coils are individuallly designed for a high heat transfer performance, low initial cost and long life durability. The staggered tube provides a turbulent air flow through the coil." : "Les bobines sont con�ues individuellement pour un transfert de chaleur �lev�e, faible co�t initial et longue dur�e de vie. Le tube �chelonn�e fournit un flux d'air turbulent � travers la bobine.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterTubesDesc"]).Text = language == "EN" ? "Tubes are grooved, seamless copper (G = 5/8\" [51mm], P = 1-1/8\" [62mm], manufactured to ASME specifications. Tube are mechanically expanded into fin collars for permanent bond." : "Les tubes sont rainur�s, sans soudure en cuivre (G = 5 / 8 \"[51 mm], P = 1-1/8\" [62 mm], construit � la norme ASME cahier des charges. Tube sont m�caniquement �largi en fin de colliers lien permanent.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFinsDesc"]).Text = language == "EN" ? "Fins are aluminum, die formed plate type. They are flat or sine wave to match any application. Fin configuration promotes maximum heat transfer effectiveness with minimum air friction. Full fin collar provide accurate fin spacing and full coverage over the tubes." : "Les ailettes sont en aluminium, meurent de type plaque form�e. Ils sont � plat ou � onde sinuso�dale pour correspondre � n'importe quelle application. Fin de configuration favorise au maximum l'efficacit� de transfert de chaleur par friction minimale de l'air. Plein col fin d'assurer l'espacement fin pr�cise et une couverture compl�te sur les tubes.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFramesDesc"]).Text = language == "EN" ? "Frames are heavy-gauge galvanized steel. Top and bottom plates have double bends for more rigidity. Tube sheets have die formed extruded tube holes for maximum tube support. Intermediate tube sheet is provided to avoid air bypass. Optional material: Extra heavy-gauge galvanized steel, aluminum, stainless steel, brass or copper." : "Les cadres sont de gros calibre en acier galvanis�. plaques sup�rieure et inf�rieure de courbures doubles pour plus de rigidit�. Tube feuilles ont form� mourir extrud� trous tube pour tube de soutien maximum. fiche tube interm�diaire est pr�vu pour �viter de d�rivation d'air. mati�res en option: Extra gros calibre en acier galvanis�, aluminium, inox, laiton ou cuivre.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterBrazingAlloysDesc"]).Text = language == "EN" ? "Brazing Alloys are manufactured to AWS specifications. All coil joints are hand brazed with high temperature brazing filler metal." : "Brasures sont fabriqu�s selon les sp�cifications de l'AWS. Tous les joints sont bobine main bras�es � haute temp�rature de brasage m�tal d'apport.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterTestingDesc"]).Text = language == "EN" ? "Testing: All coils are tested with 400 psig - 40�F dew points dry air under warm water." : "Test: Toutes les batteries sont test�es � 400 psig - 40 � F points de ros�e de l'air sec sous l'eau chaude.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterOutputs"]).Text = language == "EN" ? "OUTPUTS" : "SORTIES";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFaceTubes"]).Text = language == "EN" ? "Face Tubes" : "Tubes � la face";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFinLengthSupply"]).Text = language == "EN" ? "Fin Length Supply Side" : "Longueur des ailettes du c�t� de l�alimentation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterFinLengthReturn"]).Text = language == "EN" ? "Fin Length Return Side" : "Longueur des ailettes du c�t� du retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterWeight"]).Text = language == "EN" ? "Weight" : "Poids";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterCapacity"]).Text = language == "EN" ? "Capacity" : "Capacit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterCondensate"]).Text = language == "EN" ? "Condensate" : "Condensat";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterMixingAirFlowSupply"]).Text = language == "EN" ? "Mixing Air Flow Supply" : "�coulement du m�lange d�air � l�alimentation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterAirFlowSupplyBypass"]).Text = language == "EN" ? "Air Flow Supply Bypass" : "D�tournement du m�lange d�air � l�alimentation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterHeatPipeEfficiency"]).Text = language == "EN" ? "Heat Pipe Efficiency" : "Efficacit� du caloduc";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterHeatPipeSensible"]).Text = language == "EN" ? "Sensible Effectiveness" : "Efficacit� sensible";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLatent"]).Text = language == "EN" ? "Latent Effectiveness" : "Efficacit� latent";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterTotal"]).Text = language == "EN" ? "Total Effectiveness" : "Efficacit� totale";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterCoolingCoilEfficiency"]).Text = language == "EN" ? "Cooling Coil Efficiency" : "Efficacit� du serpentin de refroidissement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterCoolingSensible"]).Text = language == "EN" ? "Sensible Effectiveness" : "Efficacit� sensible";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterCoolingTotal"]).Text = language == "EN" ? "Cooling Effectiveness" : "Efficacit� de refroidissement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyTitle"]).Text = language == "EN" ? "Entering Supply Air (T1)" : "Entr� d�air � l�alimentation (T1)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringSupplyEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyTitle"]).Text = language == "EN" ? "Leaving Supply Air (T2)" : "Sortie d�air � l�alimentation (T2)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingSupplyDrop"]).Text = language == "EN" ? "Pressure Drop" : "Chute de pression";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustTitle"]).Text = language == "EN" ? "Leaving Exhaust Air (T4)" : "Sortie d�air � l��vacuation (T4)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterLeavingExhaustDrop"]).Text = language == "EN" ? "Pressure Drop" : "Chute de pression";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustTitle"]).Text = language == "EN" ? "Entering Exhaust Air (T3)" : "Entr� d�air � l��vacuation (T3)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustVelocity"]).Text = language == "EN" ? "Velocity" : "V�locit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustDB"]).Text = "DB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustWB"]).Text = "WB";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustRH"]).Text = "RH";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustGrains"]).Text = "Grains";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection1.ReportObjects["txtWinterEnteringExhaustEnthalpy"]).Text = language == "EN" ? "Enthalpy" : "Enthalpie";

            
        }
    }
}
