﻿#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_StockPPRec
//   Form Name    : 공정 재고 입출 이력 관리
//   Name Space   : KFQS_Form
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class PP_StockPPRec : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public PP_StockPPRec()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_StockPPRec_Load(object sender, EventArgs e)
        {
            Common _Common          = new Common();
            string plantCode        = LoginInfo.PlantCode;

            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"  ,"공장",       true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO"   ,   "LOTNO",      true, GridColDataType_emu.VarChar,    160, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE"   ,"품목",       true, GridColDataType_emu.VarChar,    140, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME"   ,"품명",       true, GridColDataType_emu.VarChar,    150, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTDATE"  ,"입/출일자",  true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE"     ,"창고",       true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTCODE"  ,"입출유형",   true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTFLAG"  ,"입출구분",   true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTQTY"   ,"입출수량",   true, GridColDataType_emu.Double,     100, 120, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT"   ,"단위",       true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"      ,"등록자",     true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"   ,"등록일시",   true, GridColDataType_emu.DateTime24, 160, 120, Infragistics.Win.HAlign.Left,   true, false);




            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
             
            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("ROH");
            Common.FillComboboxMaster(this.cboItemCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            rtnDtTemp = _Common.Standard_CODE("WHCODE");     //창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("INOUTCODE");     //입출유형
            UltraGridUtil.SetComboUltraGrid(this.grid1, "INOUTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("INOUTFLAG");     //입출 구분 
            UltraGridUtil.SetComboUltraGrid(this.grid1, "INOUTFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            { 
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode  = Convert.ToString(this.cboItemCode.Value); 
                string sLotNo     = Convert.ToString(txtLotNo.Text );
                string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

                rtnDtTemp = helper.FillTable("00PP_StockPPRec_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMCODE",  sItemCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("LOTNO",     sLotNo,     DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STARTDATE", sStartdate, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ENDDATE",   sEndDate,   DbType.String, ParameterDirection.Input)
                                    );
                 
                this.grid1.DataSource = rtnDtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
        }
        #endregion 
    }
}




