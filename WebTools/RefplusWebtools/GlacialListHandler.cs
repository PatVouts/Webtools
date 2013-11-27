
namespace RefplusWebtools
{
    class GlacialListHandler
    {
        /// <summary>
        /// Get the index of the column by and x point.
        /// useful for Click event using the mousepointer.x
        /// </summary>
        /// <param name="list">the list</param>
        /// <param name="x">the x point</param>
        /// <returns></returns>
        public static int GetColumnByPoint(GlacialComponents.Controls.GlacialList list, int x)
        {
            //index that will be return
            int iCol = -1;

            //this will total up the width of column
            //this is how we know where the x end up
            int totalWidth = 0;

            //make sure list have columns
            if (list.Columns.Count > 0)
            {
                //for each column
                for (int i = 0; i < list.Columns.Count; i++)
                {
                    //we total the width
                    totalWidth += list.Columns[i].Width;

                    //if the total width surpass the x point then
                    //the current column is the good one so we save it
                    //doing it like so will prevent click after the last column
                    //(in case of low amount of column and large list object)
                    //to be interpreted as last column
                    if (totalWidth > x && iCol == -1)
                    {
                        //save the column we are at
                        iCol = i;
                    }
                }
            }            

            //return the column
            return iCol;
        }
    }
}
