using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace JxIntraWeb.App_DataEngine
{
    public class GlobalDataPattern
    {
        public DataTable CreateDataTableMaintainCollection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);
            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MnDesc"
            };
            myDataTable.Columns.Add(myDataColumn1);
            //Table Properties
            myDataTable.TableName = "TBL_MN_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainCollection(string MNDescriptionDta, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["MnDesc"] = MNDescriptionDta;
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }
        public DataTable CreateDataTableMaintainWheelCollection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);
            //
            DataColumn myDataColumn0x = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "W_POS"
            };
            myDataTable.Columns.Add(myDataColumn0x);
            //
            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MnRemark"
            };
            myDataTable.Columns.Add(myDataColumn1);
            //
            DataColumn myDataColumn2 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageArea1"
            };
            myDataTable.Columns.Add(myDataColumn2);
            //
            DataColumn myDataColumn3 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageArea2"
            };
            myDataTable.Columns.Add(myDataColumn3);
            //
            DataColumn myDataColumn4 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageArea3"
            };
            myDataTable.Columns.Add(myDataColumn4);
            //
            DataColumn myDataColumn5 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageArea4"
            };
            myDataTable.Columns.Add(myDataColumn5);
            //-------------------------------------------
            //
            DataColumn myDataColumn6 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageType1"
            };
            myDataTable.Columns.Add(myDataColumn6);
            //
            DataColumn myDataColumn7 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageType2"
            };
            myDataTable.Columns.Add(myDataColumn7);
            //
            DataColumn myDataColumn8 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageType3"
            };
            myDataTable.Columns.Add(myDataColumn8);
            //
            DataColumn myDataColumn9 = new DataColumn
            {
                DataType = Type.GetType("System.Boolean"),
                ColumnName = "DamageType4"
            };
            myDataTable.Columns.Add(myDataColumn9);
            //
            DataColumn myDataColumn10 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "DamageAreaAno"
            };
            myDataTable.Columns.Add(myDataColumn10);
            //
            DataColumn myDataColumn11 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "DamageTypeAno"
            };
            myDataTable.Columns.Add(myDataColumn11);
            //
            DataColumn myDataColumn12 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Serial"
            };
            myDataTable.Columns.Add(myDataColumn12);
            DataColumn myDataColumn13 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "RMile"
            };
            myDataTable.Columns.Add(myDataColumn13);
            DataColumn myDataColumn14 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "WhlSize"
            };
            myDataTable.Columns.Add(myDataColumn14);
            //Table Properties
            myDataTable.TableName = "TBL_MNWHEEL_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainWheelCollection(string W_POS,string MnRemark,
                                                          Boolean DamageArea1, Boolean DamageArea2, Boolean DamageArea3, Boolean DamageArea4,
                                                          Boolean DamageType1, Boolean DamageType2, Boolean DamageType3, Boolean DamageType4,
                                                          string DamageAreaAno,string DamageTypeAno,string Serial,string RMile,string WhlSize,
                                                          DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["W_POS"] = W_POS;
            row["MnRemark"] = MnRemark;
            row["DamageArea1"] = DamageArea1;
            row["DamageArea2"] = DamageArea2;
            row["DamageArea3"] = DamageArea3;
            row["DamageArea4"] = DamageArea4;
            //
            row["DamageType1"] = DamageType1;
            row["DamageType2"] = DamageType2;
            row["DamageType3"] = DamageType3;
            row["DamageType4"] = DamageType4;
            //
            row["DamageAreaAno"] = DamageAreaAno;
            row["DamageTypeAno"] = DamageTypeAno;
            //
            row["Serial"] = Serial;
            row["RMile"] = RMile;
            row["WhlSize"] = WhlSize;
            //
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }
        public DataTable CreateDataTableMaintainCostCollection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);
            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MnDesc"
            };
            myDataTable.Columns.Add(myDataColumn1);
            DataColumn myDataColumn2 = new DataColumn
            {
                DataType = Type.GetType("System.Single"),
                ColumnName = "MnCost"
            };
            myDataTable.Columns.Add(myDataColumn2);
            DataColumn myDataColumn3 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MnServicer"
            };
            myDataTable.Columns.Add(myDataColumn3);
            //
            //Table Properties
            myDataTable.TableName = "TBL_MN_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainCostCollection(string MNDescriptionDta, float MnCostDta,string MnServicerDta, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["MnDesc"] = MNDescriptionDta;
            row["MnCost"] = MnCostDta;
            row["MnServicer"] = MnServicerDta;
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }


        public DataTable CreateDataTableMaintainPartCollection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);

            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MnDesc"
            };
            myDataTable.Columns.Add(myDataColumn1);

            DataColumn myDataColumn2 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "MnAmt"
            };
            myDataTable.Columns.Add(myDataColumn2);

            //Add 30012023
            DataColumn myDataColumn3 = new DataColumn
            {
                DataType = Type.GetType("System.Double"),
                ColumnName = "MnPrice",
                DefaultValue = 0.00
            };
            myDataTable.Columns.Add(myDataColumn3);
            //

            //Table Properties
            myDataTable.TableName = "TBL_MN_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainPartCollection(string MNDescriptionDta, int MnAmtDta,double MnPrice, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["MnDesc"] = MNDescriptionDta;
            row["MnAmt"] = MnAmtDta;
            //ADD 30012023
            row["MnPrice"] = MnPrice;
            //
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }
        public DataTable CreateDataTableMaintainL2Collection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);
            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MnDesc"
            };
            myDataTable.Columns.Add(myDataColumn1);
            //Table Properties
            myDataTable.TableName = "TBL_MN_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainL2Collection(string MNDescriptionDta, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["MnDesc"] = MNDescriptionDta;
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }
        //
        public DataTable CreateDataTableMaintainCommentCollection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);
            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "DATE_NOTE"
            };
            myDataTable.Columns.Add(myDataColumn1);

            DataColumn myDataColumn2 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "DESC_NOTE"
            };
            myDataTable.Columns.Add(myDataColumn2);
            DataColumn myDataColumn3 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "MILEDGE_NOTE"
            };
            myDataTable.Columns.Add(myDataColumn3);
            DataColumn myDataColumn4 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "PRICE_NOTE"
            };
            myDataTable.Columns.Add(myDataColumn4);
            DataColumn myDataColumn5 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "SERVICER_NOTE"
            };
            myDataTable.Columns.Add(myDataColumn5);
            //
            //Table Properties
            myDataTable.TableName = "TBL_MN_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainCommentCollection(string DATE_NOTE, string DESC_NOTE, string MILEDGE_NOTE, 
                                                            string PRICE_NOTE, string SERVICER_NOTE, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["DATE_NOTE"] = DATE_NOTE;
            row["DESC_NOTE"] = DESC_NOTE;
            row["MILEDGE_NOTE"] = MILEDGE_NOTE;
            row["PRICE_NOTE"] = PRICE_NOTE;
            row["SERVICER_NOTE"] = SERVICER_NOTE;
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }

        //
        public DataTable CreateDataTableMaintainImageCollection()
        {
            //Table
            DataTable myDataTable = new DataTable();
            //Table::Columns
            DataColumn myDataColumn0 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "IDx",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            myDataTable.Columns.Add(myDataColumn0);

            DataColumn myDataColumn1 = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Image_ILx"
            };
            myDataTable.Columns.Add(myDataColumn1);

            DataColumn myDataColumn2 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Image_File"
            };
            myDataTable.Columns.Add(myDataColumn2);

            DataColumn myDataColumn2_1 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Image_FileActual"
            };
            myDataTable.Columns.Add(myDataColumn2_1);


            DataColumn myDataColumn3 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Image_Note"
            };
            myDataTable.Columns.Add(myDataColumn3);


            DataColumn myDataColumn4 = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "ImageURL"
            };
            myDataTable.Columns.Add(myDataColumn4);


            //
            //Table Properties
            myDataTable.TableName = "TBL_IMG_COLLECTION";
            //
            return myDataTable;
        }
        public void AddDataToTableMaintainImageCollection(int Image_ILx, string Image_File,string Image_FileActual, string Image_Note,string ImageURL, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();
            row["Image_ILx"] = Image_ILx;
            row["Image_File"] = Image_File;
            row["Image_FileActual"] = Image_FileActual;
            row["Image_Note"] = Image_Note;
            row["ImageURL"] = ImageURL;
            myTable.Rows.Add(row);
            myTable.AcceptChanges();
        }

    }
}