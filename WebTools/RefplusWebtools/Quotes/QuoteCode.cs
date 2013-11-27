using System;
using System.Data;

namespace RefplusWebtools.Quotes
{
    class QuoteCode
    {
        public int GenerateNewQuoteID()
        {
            //put new quote id equal -1 in case of error we will be able to stop the whole progress
            int newQuoteID = -1;

            //if the attribution works
            if (Query.Execute("INSERT INTO QuoteIDAttribution (Username) VALUES ('" + UserInformation.UserName + "')"))
            {
                //get the id automaticly generated from software.
                DataTable dtQuoteId = Query.Select("SELECT * FROM QuoteIDAttribution WHERE Username = '" + UserInformation.UserName + "' ORDER BY CreatedDate DESC");

                //we check for record count just in case
                if (dtQuoteId.Rows.Count > 0)
                {
                    //save the new quote id so we can return it
                    newQuoteID = Convert.ToInt32(dtQuoteId.Rows[0]["QuoteID"]);
                }
            }

            return newQuoteID;
        }

        public int GetLatestRevisionID(int quoteID)
        {
            //get all revision to the quote order by most recent revision number
            DataTable dtRevisionID = Query.Select("SELECT * FROM QuoteData WHERE QuoteID = " + quoteID + " ORDER BY QuoteRevision DESC");

            //if we have match
            if (dtRevisionID.Rows.Count > 0)
            {
                //revision to return
                return Convert.ToInt32(dtRevisionID.Rows[0]["QuoteRevision"]);
            }

            return 0;
        }

        public int GetNewRevisionID(int quoteID)
        {
            return GetLatestRevisionID(quoteID) + 1;
        }
    }
}
