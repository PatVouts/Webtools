using System;
using System.Collections;

namespace RefplusWebtools.QuickControlPanel
{
    public class ValveList
    {
        private const float MaxPressureDrop=6.8f; //constant value for max gpm range
        private const float MinPressureDrop=2.77f;//constant value for min gpm range

        private readonly ArrayList _al2WayHwValveList; //object creation
        private readonly ArrayList _al3WayHwValveList;
        private readonly ArrayList _al2WayScValveList;

        public ValveList(float parFgpm){//valvelist constructor used for Hot Water coils
            
            _al2WayHwValveList = Fill2WayHWValves(parFgpm);//pass the GPM we are looking for 2 way
            _al3WayHwValveList = Fill3WayHWValves(parFgpm);//pass the GPM we are looking for 3 way
            
        }
        public ValveList()
        {
            _al2WayScValveList = Fill2WaySCValves();//fills array list
        }
        public Valve Get3WayHWValveSelection(float parFgpm)
        {
            Valve v = GetHWValveSelection(parFgpm, _al3WayHwValveList);//returns selection of the 3 way HW valve
            return v;
        }
        public Valve Get2WayHWValveSelection(float parFgpm)
        {
            Valve v = GetHWValveSelection(parFgpm, _al2WayHwValveList);//returns the selectionof the 2 way HW valve
            return v;
        }
        public Valve Get2WaySCValveSelection(int parImbh, int parIpsi)
        {
            Valve v = GetSCValveSelection(parImbh, parIpsi, _al2WayScValveList);//returns the selectionof the 2 way SC valve
            return v;
        }

        private static Valve GetSCValveSelection(int parImbh,int parIpsi, ArrayList al)
        {
            var tempValve = new Valve(0, 0, 0f, 0f, "", "", 0);//initialize temp values
            foreach (Valve v in al)//cycle throught each object
            {
                if (v.IsMBHinRange(parImbh, parIpsi))//check load range and the PSI allowed
                {
                    tempValve = v;//assign valve value
                }
            }
            return tempValve;
        }

        private static Valve GetHWValveSelection(float parFgpm, ArrayList al)
        {
            var tempValve = new Valve(0,0,0f,0f,"","",0f);
            const float fMidPoint = MinPressureDrop + (MaxPressureDrop - MinPressureDrop)/2;
            foreach( Valve v in al){
                if (v.IsGPMinRange(parFgpm))
                {
                    if (v.GetPressureDrop() >= MinPressureDrop && v.GetPressureDrop() <= MaxPressureDrop)
                    {
                        if (Math.Abs(fMidPoint-v.GetPressureDrop())<Math.Abs(fMidPoint-tempValve.GetPressureDrop()))
                        {
                            tempValve = v;
                        }
                    }
                }
            }
            return tempValve;
        }
        private static ArrayList Fill2WaySCValves()
        {
            var al2WaySC = new ArrayList
            {
                new Valve(1, 100, .5f, "G215S", "Globe", 5),
                new Valve(100, 173, .75f, "G220S", "Globe", 5),
                new Valve(173, 322, 1.0f, "G225S", "Globe", 5),
                new Valve(322, 460, 1.25f, "G232S", "Globe", 5),
                new Valve(460, 644, 1.5f, "G240S", "Globe", 5),
                new Valve(644, 920, 2.0f, "G250S", "Globe", 5),
                new Valve(920, 1496, 2.5f, "G665", "Globe", 5),
                new Valve(1496, 2070, 3.0f, "G680", "Globe", 5),
                new Valve(2070, 3914, 4.0f, "G6100", "Globe", 5),
                new Valve(1, 63, .5f, "G215S", "Globe", 2),
                new Valve(63, 108, .75f, "G220S", "Globe", 2),
                new Valve(108, 201, 1.0f, "G225S", "Globe", 2),
                new Valve(201, 286, 1.25f, "G232S", "Globe", 2),
                new Valve(286, 400, 1.5f, "G240S", "Globe", 2),
                new Valve(400, 572, 2.0f, "G250S", "Globe", 2),
                new Valve(572, 930, 2.5f, "G665", "Globe", 2),
                new Valve(930, 1287, 3.0f, "G680", "Globe", 2),
                new Valve(1287, 2430, 4.0f, "G6100", "Globe", 2),
                new Valve(2430, 3760, 5.0f, "", "Globe", 2)
            };

            return al2WaySC;
        }
        private static ArrayList Fill3WayHWValves(float parFgpm)
        {
            var al3WayHW = new ArrayList
            {
                new Valve(1, 11, .5f, .8f, "B309", "Ball", parFgpm),
                new Valve(1, 11, .5f, 1.2f, "B310", "Ball", parFgpm),
                new Valve(1, 11, .5f, 1.9f, "B311", "Ball", parFgpm),
                new Valve(1, 11, .5f, 3f, "B312", "Ball", parFgpm),
                new Valve(1, 11, .5f, 4.7f, "B313", "Ball", parFgpm),
                new Valve(12, 17, .75f, 4.7f, "B317", "Ball", parFgpm),
                new Valve(12, 17, .75f, 7.4f, "B318", "Ball", parFgpm),
                new Valve(18, 24, 1.0f, 7.4f, "B322", "Ball", parFgpm),
                new Valve(18, 24, 1.0f, 10.0f, "B323", "Ball", parFgpm),
                new Valve(25, 36, 1.0f, 15.0f, "G325D", "Globe", parFgpm),
                new Valve(37, 70, 1.5f, 19.0f, "B338", "Ball", parFgpm),
                new Valve(37, 70, 1.5f, 29.0f, "B339", "Ball", parFgpm),
                new Valve(71, 117, 2.0f, 29.0f, "B348", "Ball", parFgpm),
                new Valve(71, 117, 2.0f, 46.0f, "B349", "Ball", parFgpm),
                new Valve(118, 160, 2.5f, 68.0f, "G765", "Globe", parFgpm),
                new Valve(161, 250, 3.0f, 91.0f, "G780", "Globe", parFgpm),
                new Valve(251, 460, 4.0f, 190.0f, "G7100", "Globe", parFgpm)
            };
            return al3WayHW;
        }


        private static ArrayList Fill2WayHWValves(float parFgpm)
        {
            var al2WayHW = new ArrayList
            {
                new Valve(1, 11, .5f, .3f, "B207B", "Ball", parFgpm),
                new Valve(1, 11, .5f, .46f, "B208B", "Ball", parFgpm),
                new Valve(1, 11, .5f, .8f, "B209B", "Ball", parFgpm),
                new Valve(1, 11, .5f, 1.2f, "B210B", "Ball", parFgpm),
                new Valve(1, 11, .5f, 1.9f, "B211B", "Ball", parFgpm),
                new Valve(1, 11, .5f, 3.0f, "B212B", "Ball", parFgpm),
                new Valve(1, 11, .5f, 4.7f, "B213B", "Ball", parFgpm),
                new Valve(1, 11, .5f, 7.4f, "B214B", "Ball", parFgpm),
                new Valve(12, 17, .75f, 4.7f, "B217B", "Ball", parFgpm),
                new Valve(12, 17, .75f, 7.4f, "B218B", "Ball", parFgpm),
                new Valve(12, 17, .75f, 10.0f, "B219B", "Ball", parFgpm),
                new Valve(18, 36, 1.0f, 7.4f, "B222B", "Ball", parFgpm),
                new Valve(18, 36, 1.0f, 10.0f, "B223B", "Ball", parFgpm),
                new Valve(18, 36, 1.0f, 19.0f, "B224B", "Ball", parFgpm),
                new Valve(37, 70, 1.5f, 19.0f, "B238B", "Ball", parFgpm),
                new Valve(37, 70, 1.5f, 29.0f, "B239B", "Ball", parFgpm),
                new Valve(71, 117, 2.0f, 29.0f, "B248B", "Ball", parFgpm),
                new Valve(71, 117, 2.0f, 46.0f, "B249B", "Ball", parFgpm)
            };
            return al2WayHW;
        }
        public string OutputString()
        {
            string strOutPut = "";
            Object[] arrValve;
            if (_al3WayHwValveList != null)
            {
                arrValve = _al3WayHwValveList.ToArray();
                for (int idx = 0; idx < arrValve.Length; idx++)
                {
                    strOutPut += ((Valve)(arrValve[idx])).OutputString() + "\n";
                }
            }
            if (_al2WayHwValveList != null)
            {
                arrValve = _al2WayHwValveList.ToArray();
                for (int idx = 0; idx < arrValve.Length; idx++)
                {
                    strOutPut += ((Valve)(arrValve[idx])).OutputString() + "\n";
                }
            }
            if (_al2WayScValveList != null)
            {
                arrValve = _al2WayScValveList.ToArray();
                for (int idx = 0; idx < arrValve.Length; idx++)
                {
                    strOutPut += ((Valve)(arrValve[idx])).OutputString() + "\n";
                }
            }
            return strOutPut;
        }
    }
}
