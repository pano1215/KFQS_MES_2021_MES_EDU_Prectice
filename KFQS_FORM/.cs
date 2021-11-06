using DC_POPUP;
using DC00_assm;
using DC00_WinForm;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KFQS_Form
{
    public partial class WM_StockOUTWM : DC00_WinForm.BaseMDIChildForm
    {
        //그리드 셋팅 할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtill = new UltraGridUtil();
        //공장 변수 입력
        //private sPlantCode = LoginInfo
        public WM_StockOUTWM()
        {
            InitializeComponent();
        }
        private void WM_StockOUTWM_Load(object sender, EventArgs e)
        {   // 그리드 셋팅하고 시작한다.
            try
            {
                #region GRID SETTING
                _GridUtill.InitializeGrid(this.grid1, false, true, false, "", false); //그리드1 의 기본 설정 내용
                // PLANTCODE값을 보여줄때는 공장으로, null값 허용, varchar형식, 130,130, 문자열은 왼쪽 정렬, 보여주고 수정은X)
                _GridUtill.InitColumnUltraGrid(grid1, "CHK"         , "출고등록"   , true, GridColDataType_emu.CheckBox   , 80 , 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtill.InitColumnUltraGrid(grid1, "PLANTCODE"   , "공장"       , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "SHIPNO"      , "상차번호"   , true, GridColDataType_emu.VarChar    , 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "SHIPDATE"    , "상차일자"   , true, GridColDataType_emu.VarChar    , 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "CARNO"       , "차량번호"   , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "CUSTCODE"    , "거래처코드" , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "CUSTNAME"    , "거래처명"   , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "WORKER"      , "상차자"     , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "TRADINGNO"   , "명세서번호" , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "TRADINGDATE", "출고일자"    , true, GridColDataType_emu.VarChar    , 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "MAKEDATE"    , "등록일시"   , true, GridColDataType_emu.DateTime24 , 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "MAKER"       , "등록자"     , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "EDITDATE"    , "수정일시"   , true, GridColDataType_emu.DateTime24 , 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtill.InitColumnUltraGrid(grid1, "EDITOR"      , "수정자"     , true, GridColDataType_emu.VarChar    , 120, 130, Infragistics.Win.HAlign.Left, true, false);

                //셋팅 내역을 바인딩
                _GridUtill.SetInitUltraGridBind(grid1);

                _GridUtill.InitializeGrid(this.grid2, false, true, false, "", false); //그리드1 의 기본 설정 내용
                // PLANTCODE값을 보여줄때는 공장으로, null값 허용, varchar형식, 130,130, 문자열은 왼쪽 정렬, 보여주고 수정은X)
                _GridUtill.InitColumnUltraGrid(grid2, "PLANTCODE" , "공장"    , true, GridColDataType_emu.VarChar , 120, 130, Infragistics.Win.HAlign.Left  , false, true);
                _GridUtill.InitColumnUltraGrid(grid2, "SHIPNO"    , "상차번호", true, GridColDataType_emu.VarChar , 140, 130, Infragistics.Win.HAlign.Left  , false, true);
                _GridUtill.InitColumnUltraGrid(grid2, "SHIPSEQ"   , "상차순번", true, GridColDataType_emu.VarChar , 80 , 130, Infragistics.Win.HAlign.Center, true , true);
                _GridUtill.InitColumnUltraGrid(grid2, "LOTNO"     , "LOTNO"   , true, GridColDataType_emu.VarChar , 120, 130, Infragistics.Win.HAlign.Left  , true , true);
                _GridUtill.InitColumnUltraGrid(grid2, "ITEMCODE"  , "품목"    , true, GridColDataType_emu.VarChar , 120, 130, Infragistics.Win.HAlign.Left  , true , true);
                _GridUtill.InitColumnUltraGrid(grid2, "ITEMNAME"  , "품명"    , true, GridColDataType_emu.VarChar , 150, 130, Infragistics.Win.HAlign.Left  , true , true);
                _GridUtill.InitColumnUltraGrid(grid2, "SHIPQTY"   , "상차수량", true, GridColDataType_emu.Double  , 170, 130, Infragistics.Win.HAlign.Right , true , true);
                _GridUtill.InitColumnUltraGrid(grid2, "UNITCODE"  , "단위"    , true, GridColDataType_emu.VarChar , 170, 130, Infragistics.Win.HAlign.Left  , true , true);

                //셋팅 내역을 바인딩
                _GridUtill.SetInitUltraGridBind(grid2);
                //콤보 박스 셋팅
                Common _Common = new Common();
                DataTable dtTemp = new DataTable();
                //PLANTCODE 기준정보 가져와서 데이터 테이블에 추가
                dtTemp = _Common.Standard_CODE("PLANTCODE");
                //데이터 테이블에 있는 데이터를 해당 콤보박스에 추가
                Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");
                cboPlantCode_H.Value = "1000";

                dtTemp = _Common.Standard_CODE("UNITCODE");   //단위
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", dtTemp, "CODE_ID", "CODE_NAME"); 
                #endregion

                #region POP UP
                BizTextBoxManager btbManager = new BizTextBoxManager();
                btbManager.PopUpAdd(txtCustCode, txtCustName, "CUST_MASTER", new object[] { cboPlantCode_H, "", "", "" }); 
                #endregion
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
        }
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtill.Grid_Clear(grid1);
                _GridUtill.Grid_Clear(grid2);

                string sPlantcode = cboPlantCode_H.Value.ToString();
                string sCustcode  = txtCustCode.Text.ToString();
                string sShipNo    = txtShipNo.Text.ToString();
                string sCarNo     = txtCarNo.Text.ToString();
                string sStart     = string.Format("{0:yyyy-MM-01}", dtpStart.Value);
                string sEnd       = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);




                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("19WM_StockOUTWM_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE", sPlantcode , DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("STARTDATE", sStart     , DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ENDDATE"  , sEnd       , DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("SHIPNO"   , sShipNo    , DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("CARNO"    , sCarNo     , DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("CUSTCODE" , sCustcode  , DbType.String, ParameterDirection.Input)
                                        );

               

                this.ClosePrgForm();
                //조회중이라고 뜨는 동그란 표시를 꺼주는 코드 base 내에 설정되어있음

                if (dtTemp.Rows.Count > 0) // 데이터가 있으면 바인딩해서 그리드에 출력
                {
                    grid1.DataSource = dtTemp;
                    grid1.DataBinds(dtTemp);
                    
                }
                else
                {
                    _GridUtill.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally { helper.Close(); }

        }

        public override void DoSave()
        {
            this.grid1.UpdateData();
            DataTable dt = grid1.chkChange();
            #region VALIDATION CHK 
            // CARNO가 일치하는지 체크, 체크를 눌렀다가 취소하는 경우도 체크
            if (dt == null)
                return;
            string sCarNo = Convert.ToString(dt.Rows[0]["CARNO"]);
            int ChkCount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToString(dt.Rows[i]["CHK"]) != "1") continue;
                if (sCarNo != Convert.ToString(dt.Rows[i]["CARNO"]))
                {
                    ShowDialog("차량 번호가 동일하지 않은 출고 등록 및 거래명세서는 발행 할 수 없습니다.", DialogForm.DialogType.OK);
                    return;
                }
                ChkCount += 1;
            }
            if (ChkCount == 0)
            {
                ShowDialog("선택된 출고 내역이 없습니다.", DialogForm.DialogType.OK);
                return;
            }  
            #endregion
            DBHelper helper = new DBHelper("", true);
            try
            {
                // 동일한 차량 번호만 선택 하였는지 확인!

                if (this.ShowDialog("선택하신 내역을 출고 등록 하시겠습니까 ?") == System.Windows.Forms.DialogResult.Cancel) return;

                string sTradingNo = string.Empty;
                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정 
                            if (Convert.ToString(drRow["CHK"]) != "1") continue;
                            helper.ExecuteNoneQuery("19WM_StockOutWM_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE" , Convert.ToString(drRow["PLANTCODE"]) , DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("SHIPNO"    , Convert.ToString(drRow["SHIPNO"])    , DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("TRADINGNO" , sTradingNo                           , DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("MAKER"     , LoginInfo.UserID                     , DbType.String, ParameterDirection.Input)
                                                  );

                            if (helper.RSCODE == "S")
                            {
                                sTradingNo = helper.RSMSG;
                            }
                            else break;
                            #endregion
                            break;
                    }
                    if (helper.RSCODE != "S") break;
                }
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgForm();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    return;
                }
                helper.Commit();
                this.ClosePrgForm();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }



        }

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            string sPlantcode = cboPlantCode_H.Value.ToString();
            string shipno = Convert.ToString(grid1.ActiveRow.Cells["SHIPNO"].Value);

            DBHelper helper = new DBHelper(false);
            try
            {

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("19WM_StockOUTWM_S2", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("SHIPNO", shipno, DbType.String, ParameterDirection.Input)
                                              );
                if (dtTemp.Rows.Count > 0)
                {
                    this.grid2.DataSource = dtTemp;
                    this.grid2.DataBinds(dtTemp);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally { helper.Close(); }
        }



    }

}