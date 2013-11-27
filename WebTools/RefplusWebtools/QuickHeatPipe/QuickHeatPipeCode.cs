using System;
using System.Globalization;

namespace RefplusWebtools.QuickHeatPipe
{
    class QuickHeatPipeCode
    {
        //this is the max fin height for the coils
        public const decimal DecMaxFinHeight = 200m;

        //this is the minimum height of a coil for now it's 2 face tubes
        //so for a 3 inch face tube the min height will be 6 inch
        public const decimal DecMinHeightInFaceTubes = 2;


        public string FinHeightSelectClosestValueOfPreviouslySelectedOne(decimal decSelectedHeight, decimal decFaceTubes)
        {
            //this is the Result of the division to know how much time we will
            //approximately need the new face tubes to be close ot the new value
            decimal decResult = decSelectedHeight / decFaceTubes;
            //essentially the Division result rounded so we get the height
            //the closest to our previous selected one. and so the value is good
            //for our selection
            decimal decIterance = Math.Round(decResult, 0);
            //if the nubmer of iterance is lower than the min number of face tube allow
            //bump up the value
            if (decIterance < DecMinHeightInFaceTubes)
            {
                decIterance = DecMinHeightInFaceTubes;
            }
            //so to have the height we are looking for it's Iterance X Face Tube
            decSelectedHeight = decIterance * decFaceTubes;
            return decSelectedHeight.ToString(CultureInfo.InvariantCulture);
        }
    }
}
