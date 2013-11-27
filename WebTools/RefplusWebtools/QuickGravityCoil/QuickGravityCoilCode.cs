using System;
using System.Data;

namespace RefplusWebtools.QuickGravityCoil
{
    class QuickGravityCoilCode
    {
        public DataTable RunSelection(DataTable dtGravityCoil, string faceTubeFilter, decimal minCapacity, decimal maxCapacity, int capacityInput, int tdInput, string ratingParameter, string model)
        {
            DataTable dtFilteredSelection;
            if (ratingParameter == "ALL")
            {
                DataTable dtFilteredFaceTubes = FilterFaceTubes(dtGravityCoil, faceTubeFilter);
                if (!dtFilteredFaceTubes.Columns.Contains("CurrentCapacity"))
                {
                    dtFilteredFaceTubes.Columns.Add("CurrentCapacity", typeof(decimal));
                }
                for (int i = 0; i < dtFilteredFaceTubes.Rows.Count; i++)
                {
                    dtFilteredFaceTubes.Rows[i]["CurrentCapacity"] = Convert.ToDecimal(Convert.ToDecimal(dtFilteredFaceTubes.Rows[i]["CapacityPerTD"].ToString()) * tdInput);
                }
                dtFilteredSelection = FilterCapacity(dtFilteredFaceTubes, minCapacity, maxCapacity);
            }
            else
            {
                DataTable dtFilteredModel = FilterModel(dtGravityCoil, model, ratingParameter);
                if (!dtFilteredModel.Columns.Contains("CurrentCapacity"))
                {
                    dtFilteredModel.Columns.Add("CurrentCapacity", typeof(decimal));
                }
                for (int i = 0; i < dtFilteredModel.Rows.Count; i++)
                {
                    dtFilteredModel.Rows[i]["CurrentCapacity"] = Convert.ToDecimal(Convert.ToDecimal(dtFilteredModel.Rows[i]["CapacityPerTD"].ToString()) * tdInput);
                }
                dtFilteredSelection = FilterCapacity(dtFilteredModel, Convert.ToDecimal(dtFilteredModel.Rows[0]["CurrentCapacity"].ToString()), Convert.ToDecimal(dtFilteredModel.Rows[0]["CurrentCapacity"].ToString()));
            }

            return Public.SortTable(dtFilteredSelection, "currentcapacity, facetubes, model");
        }

        private static DataTable FilterCapacity(DataTable dtGravityCoil, decimal minCapacity, decimal maxCapacity)
        {
            DataTable dtFilteredTable = dtGravityCoil.Copy();
            DataRow[] drFilteredRow = dtGravityCoil.Select("CurrentCapacity >= " + minCapacity + " and CurrentCapacity <= " + maxCapacity);

            dtFilteredTable.Clear();

            for (int i = 0; i < drFilteredRow.Length; i++)
            {
                dtFilteredTable.Rows.Add(drFilteredRow[i].ItemArray);
            }

            return dtFilteredTable;
        }

        private static DataTable FilterFaceTubes(DataTable dtGravityCoil, string faceTubeFilter)
        {
            string whereClause = "";
            string[] tubes = faceTubeFilter.Split(',');

            
            for (int i = 0; i <= tubes.Length - 1; i++)
            {
                whereClause += " or FaceTubes = '" + tubes[i] + "'";
            }
            
            whereClause = "(" + whereClause.Substring(4) + ")";

            return Public.SelectAndSortTable(dtGravityCoil, whereClause, "");
        }

        private static DataTable FilterModel(DataTable dtModel, string model, string ratingParameter)
        {
            string[] rating = ratingParameter.Split(',');
            DataTable dtSelection = dtModel.Copy();

            DataRow[] drSelection = dtModel.Select("Model = '" + model + "' and evaporator = '" + rating[0] + "' and gravity = '" + rating[1] + "' and airdefrost = '" + rating[2] + "' and facetubes = '" + rating[3] + "' and slab = '" + rating[4] + "' and fpi = '" + rating[5] + "' and finpattern = '" + rating[6] + "' and finlength = '" + rating[7] + "'");
            dtSelection.Clear();

            for (int i = 0; i < drSelection.Length; i++)
            {
                dtSelection.Rows.Add(drSelection[i].ItemArray);
            }
            return dtSelection;
        }
    }
}
