<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CR_MA_ORD.aspx.cs" Inherits="JxIntraWeb.App_Pages.CR_MA_ORD"%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
      		<div class="panel panel-default">
			    <div class="panel-heading">
					<h4 class="panel-title">
						<strong>Infomation Technology Dept.</strong>      Maintainance (CR) Management System - สั่งซ่อม
					</h4>
				</div>
				<div class="panel-body">
                    <div class="col-sm-10">
                       <div class="w3-container w3-white w3-cell">
                           <asp:MultiView ID="MultiView1" runat="server">
                       
                              <asp:View ID="View0x" runat="server">
                                <table style="width:100%;">
                                    <tr>
	                                    <td colspan="12" style="text-align:right">
 		                                    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
 		                                    <asp:ImageButton ID="imgBtnORD0" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtnORD0_Click" />
  	                                    </td>
                                    </tr>

                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;1.รายการเอกสารใบแจ้งซ่อม : <font color="#000080">เอกสารรอพิจารณาอนุมัติ&nbsp;</font></td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">** รอพิจารณาสั่งซ่อม &nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">
                                                                      &nbsp;&nbsp; &nbsp;กรองข้อมูล ศูนย์/สาขา|เลขรถ|ทะเบียน|ใบแจ้งซ่อม :<asp:TextBox ID="TxtKeyS1" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="" type="text"></asp:TextBox>
                                                                      <asp:ImageButton ID="ImbS1" runat="server" ImageUrl="~/App_Images/page_white_magnify.png" OnClick="ImbS1_Click" />
                                                                      &nbsp;<asp:CheckBox ID="ChBA1" runat="server" AutoPostBack="True" Font-Bold="False" Font-Names="Alef" Font-Size="Small" OnCheckedChanged="ChBA1_CheckedChanged" Text="*" Checked="True" />แสดงรายการขอซ่อม
                                                                  </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">&nbsp;</td>
                                                              </tr>
                                                                 <tr>
                                                                     <td colspan="3">
                                                                         <asp:GridView ID="GrdRepairOrderAct1" runat="server" AutoGenerateColumns="False" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct1_SelectedIndexChanged" Width="100%">
                                                                             <Columns>
                                                                                 <asp:ButtonField ButtonType="Image" CommandName="Select" ImageUrl="~/App_Images/embedsemantic.png">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" />
                                                                                 </asp:ButtonField>
                                                                                 <asp:TemplateField HeaderText="ลำดับ">
                                                                                     <ItemTemplate>
                                                                                         <%# Container.DataItemIndex + 1 %>
                                                                                     </ItemTemplate>
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                                     <ItemStyle Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" />
                                                                                 </asp:TemplateField>
                                                                                 <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" วันที่">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="BR_NAME" HeaderText="ศูนย์/สาขา">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="100px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                                 <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="85px" BackColor="#F0F0F0" Font-Bold="False"  />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="85px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="REQ_INFO" HeaderText="รายการขอซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderWidth="1px" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                                 <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="OP_SHT_NAME" HeaderText="ผู้แจ้งซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_ASSET_ID">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="XX-Small" Width="1px" />
                                                                                 <ItemStyle Font-Size="XX-Small" ForeColor="White" HorizontalAlign="Center" Width="1px" BorderColor="#CCCCCC" />
                                                                                 </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                               <asp:BoundField DataField="ORD_VEH_MILEDGE" DataFormatString="{0:N2}" HeaderText="เลขไมล์">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                             </Columns>
                                                                         </asp:GridView>
                                                                     </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td style="text-align:left; height: 18px;">&nbsp;</td>
                                                                  <td style="height: 18px"></td>
                                                                  <td style="text-align:right; height: 18px;"></td>
                                                              </tr>
                                                      </table> 
                              </asp:View>
                              <asp:View ID="View1x" runat="server">
                                        <table style="width:100%;">
                                            <tr>
	                                            <td colspan="12" style="text-align:right">
 		                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
 		                                            <asp:ImageButton ID="imgBtnORD2" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtnORD2_Click" />
  	                                            </td>
                                            </tr>
                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;2.รายการเอกสารใบแจ้งซ่อม : รายการขอรายละเอียดเพิ่มเติม &nbsp; </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">**&nbsp; &nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdRepairOrderAct2" runat="server" AutoGenerateColumns="False" Width="100%" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct2_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" />
                                                                              <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" />
                                                                              </asp:ButtonField>
                                                                              <asp:TemplateField HeaderText="ลำดับ">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                              </asp:TemplateField>
                                                                              <asp:BoundField DataField="MNT_ORD_DATE" HeaderText=" วันที่" DataFormatString="{0:dd/MM/yyyy}">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="BR_NAME" HeaderText="ศูนย์/สาขา">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="135px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="85px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="ReqMN_INFO" HeaderText="รายการขอซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderWidth="1px" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="100px" Wrap="False" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_ASSET_ID">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" Width="2px" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" ForeColor="White" Width="2px" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                               <asp:BoundField DataField="ORD_VEH_MILEDGE" DataFormatString="{0:N2}" HeaderText="เลขไมล์">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                          </Columns>
                                                                      </asp:GridView>
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                  <td style="text-align:left; height: 18px;">&nbsp;</td>
                                                                  <td style="height: 18px"></td>
                                                                  <td style="text-align:right; height: 18px;"></td>
                                                              </tr>
                                                      </table>     
                              </asp:View>
                              <asp:View ID="View2x" runat="server">
                                        <table style="width:100%;">
                                                <tr>
	                                                <td colspan="12" style="text-align:right">
 		                                                <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
 		                                                <asp:ImageButton ID="imgBtnORD3" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtnORD3_Click" />
  	                                                </td>
                                                </tr>
                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;3.รายการเอกสารใบแจ้งซ่อม : รายการที่อยู่ระหว่างการซ่อม </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">**&nbsp; &nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0;">
                                                                      &nbsp;วันที่แจ้งซ่อม -&gt; จากวันที่ :<asp:TextBox ID="TxtSDate" runat="server" Width="100px" Font-Size="Small" Height="18px"></asp:TextBox>
                                                                      <ajaxToolkit:CalendarExtender ID="TxtSDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate" TargetControlID="TxtSDate" />
                                                                      <asp:ImageButton ID="imgOrderDate" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" ToolTip="เลือกวันที่" Width="16px" />
                                                                      &nbsp;&nbsp; ถึงวันที่ :<asp:TextBox ID="TxtEDate" runat="server" Width="100px" Font-Size="Small" Height="18px"></asp:TextBox>
                                                                      <ajaxToolkit:CalendarExtender ID="TxtEDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate3" TargetControlID="TxtEDate" />
                                                                      <asp:ImageButton ID="imgOrderDate3" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" ToolTip="เลือกวันที่" Width="16px" />
                                                                      &nbsp;</td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">
                                                                      <asp:Button ID="CmdSearchRQ" runat="server" ForeColor="Black" OnClick="CmdSearchRQ_Click" Text="ค้นหา" Width="70px" />
                                                                  </td>
                                                              </tr>
                                                                 <tr>
                                                                     <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; รายการซ่อม :&nbsp;<asp:TextBox ID="TxtKeyMNx" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" OnTextChanged="TxtKeyMNx_TextChanged" Text="" type="text" Width="120px"></asp:TextBox>
                                                                         &nbsp; ขอซ่อม :<asp:TextBox ID="TxtKeyMNz" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" OnTextChanged="TxtKeyMNx_TextChanged" Text="" type="text" Width="120px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">&nbsp;</td>
                                                                 </tr>
                                                                 <tr>
                                                                     <td colspan="3">
                                                                         <asp:GridView ID="GrdRepairOrderAct3" runat="server" AutoGenerateColumns="False" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct3_SelectedIndexChanged" Width="100%">
                                                                             <Columns>
                                                                                 <asp:ButtonField ButtonType="Image" CommandName="Select" ImageUrl="~/App_Images/embedsemantic.png">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" BorderColor="#CCCCCC" />
                                                                                 </asp:ButtonField>
                                                                                 <asp:TemplateField HeaderText="ลำดับ">
                                                                                     <ItemTemplate>
                                                                                         <%# Container.DataItemIndex + 1 %>
                                                                                     </ItemTemplate>
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                                     <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                                 </asp:TemplateField>
                                                                                 <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" วันที่">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="BR_NAME" HeaderText="ศูนย์/สาขา">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="135px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="85px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="100px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="ReqMN_INFO" HeaderText="ขอซ่อม">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                                                     <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="ActualMN_INFO" HeaderText="รายการซ่อม">
                                                                                     <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                                                     <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="DescFixMN_INFO" HeaderText="รายละเอียดการซ่อม">
                                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                                                       <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" />
                                                                                   </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_TOTAL_PRICE" DataFormatString="{0:N2}" HeaderText="ค่าซ่อม (บาท)">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                                                 <ItemStyle Font-Size="Small" HorizontalAlign="Right" BorderColor="#CCCCCC" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_ASSET_ID">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                                                 <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="35px" BorderColor="#CCCCCC" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                               <asp:BoundField DataField="ORD_VEH_MILEDGE" DataFormatString="{0:N2}" HeaderText="เลขไมล์">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                             </Columns>
                                                                         </asp:GridView>
                                                                     </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td style="text-align:left; height: 18px;">&nbsp;</td>
                                                                  <td style="height: 18px"></td>
                                                                  <td style="text-align:right; height: 18px;"></td>
                                                              </tr>
                                                      </table>  
                               </asp:View>
                              <asp:View ID="View3x" runat="server">
                                   <table style="width:100%;">
                                        <tr>
	                                        <td colspan="12" style="text-align:right">
 		                                        <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
 		                                        <asp:ImageButton ID="imgBtnORD4" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtnORD4_Click" />
  	                                        </td>
                                        </tr>
                                       <tr>
                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;4.รายการเอกสารใบแจ้งซ่อม : รายการที่ปิดงานซ่อมเรียบร้อยแล้ว&nbsp; </td>
                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">**&nbsp; &nbsp; </td>
                                       </tr>
                                       <tr>
                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;วันที่แจ้งซ่อม -&gt; จากวันที่&nbsp;:<asp:TextBox ID="TxtSDate0" runat="server" Font-Size="Small" Height="18px" Width="100px"></asp:TextBox>
                                               <ajaxToolkit:CalendarExtender ID="TxtSDate0_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate4" TargetControlID="TxtSDate0" />
                                               <asp:ImageButton ID="imgOrderDate4" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" ToolTip="เลือกวันที่" Width="16px" />
                                               &nbsp;&nbsp; ถึงวันที่ :<asp:TextBox ID="TxtEDate0" runat="server" Font-Size="Small" Height="18px" Width="100px"></asp:TextBox>
                                               <ajaxToolkit:CalendarExtender ID="TxtEDate0_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate5" TargetControlID="TxtEDate0" />
                                               <asp:ImageButton ID="imgOrderDate5" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" ToolTip="เลือกวันที่" Width="16px" />
                                               &nbsp;รายการซ่อม :<asp:TextBox ID="TxtKeyMN" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="" type="text" Width="120px"></asp:TextBox>
                                               &nbsp; ขอซ่อม :<asp:TextBox ID="TxtKeyMNy" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="" type="text" Width="120px"></asp:TextBox>
                                           </td>
                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">
                                               <asp:Button ID="CmdSearchRQ0" runat="server" ForeColor="Black" OnClick="CmdSearchRQ0_Click" Text="ค้นหา" Width="70px" />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td colspan="3">
                                               <asp:GridView ID="GrdRepairOrderAct4" runat="server" AutoGenerateColumns="False" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct4_SelectedIndexChanged" Width="100%">
                                                   <Columns>
                                                       <asp:ButtonField ButtonType="Image" CommandName="Select" ImageUrl="~/App_Images/embedsemantic.png">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                           <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" BorderColor="#CCCCCC" />
                                                       </asp:ButtonField>
                                                       <asp:TemplateField HeaderText="ลำดับ">
                                                           <ItemTemplate>
                                                               <%# Container.DataItemIndex + 1 %>
                                                           </ItemTemplate>
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" Width="35px" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" VerticalAlign="Top" />
                                                       </asp:TemplateField>
                                                       <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" วันที่แจ้งซ่อม" ReadOnly="True">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center"      Width="80px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="CLOSE_ORD_DTIME" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ซ่อมเสร็จ" ReadOnly="True">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="BR_NAME" HeaderText="ศูนย์/สาขา">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="135px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="85px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" HorizontalAlign="Left" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="MNT_CLOSE_ORD" HeaderText="ผู้ปิดงาน">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="100px" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="ReqMN_INFO" HeaderText="ขอซ่อม">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="ActualMN_INFO" HeaderText="รายการซ่อม">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="DescFixMN_INFO" HeaderText="รายละเอียดการซ่อม">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="MNT_TOTAL_PRICE" DataFormatString="{0:N2}" HeaderText="ค่าซ่อม (บาท)">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="35px" BorderColor="#CCCCCC" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="VEH_ASSET_ID">
                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="1px" BorderColor="#CCCCCC" ForeColor="White" VerticalAlign="Top" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="MNT_TYPE">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                           <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="ORD_VEH_MILEDGE" DataFormatString="{0:N2}" HeaderText="เลขไมล์">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                           <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                       </asp:BoundField>
                                                   </Columns>
                                               </asp:GridView>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td style="text-align:left; height: 18px;">&nbsp;</td>
                                           <td style="height: 18px"></td>
                                           <td style="text-align:right; height: 18px;"></td>
                                       </tr>
                                   </table>
                               </asp:View>
                              <asp:View ID="View4x" runat="server">
                                   ---&gt;
                               </asp:View>
                              <asp:View ID="View5x" runat="server">
                                  <div class="w3-container">
                                        <table class="w3-table w3-border">
                                            <tr style="background-color: #F0F0F0">
                                              <td style="text-align:left;">บริษัท ไทยพาร์เซิล จำกัด (มหาชน)</td>
                                              <td></td>
                                              <td style="text-align:right;" >-    </td>
                            
                                            </tr>
                                            <tr>
                                              <td style="text-align:left;">วันที่แจ้งซ่อม :<asp:TextBox ID="TxtOrderDate" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Text="-" type="text" Width="100px" ReadOnly="True"></asp:TextBox>
                                                </td>
                                              <td>
                                                  <asp:RadioButton ID="RdoCR" runat="server" Font-Bold="False" ForeColor="#999999" GroupName="string" Text="งานซ่อมทั่ว (CR)" />
                                                  <asp:RadioButton ID="RdoPM" runat="server" Font-Bold="False" ForeColor="#999999" GroupName="string" Text="PM" />
                                                </td>
                                              <td style="text-align:right;" >เลขที่เอกสาร :<asp:TextBox ID="TxtOrderNo"  class="w3-border-bottom" type="text"  runat="server"  BorderStyle="None" Text="-" Width="140px" Font-Size="Small" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                            
                                            </tr>
                                          </table>
                                        <table class="w3-table w3-border">
                                                  <tr style="font-size: small">
                                                  <td style="text-align:left; ">รหัสรถยนต์<br><asp:TextBox ID="TxtVehCode" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="-" type="text" ReadOnly="True" Font-Size="Small"></asp:TextBox></td>
                                                  <td style="text-align:left; ">ทะเบียน<br><asp:TextBox ID="TxtVehLicense" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="-" type="text" ReadOnly="True" OnTextChanged="TxtVehLicense_TextChanged" Font-Size="Small"></asp:TextBox>
                                                      <br>
                                                      </td>
                                                  <td style="text-align:left;">ยี่ห้อ<br><asp:TextBox ID="TxtVehBrand" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="-" type="text" ReadOnly="True" Font-Size="Small"></asp:TextBox>
                                                      <br></td>
                                                  <td style="text-align:left; ">รุ่นรถ<br><asp:TextBox ID="TxtVehModel" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="-" type="text" ReadOnly="True" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                  <td style="text-align:left;">
                                                      <asp:HiddenField ID="HideVehID" runat="server" />
                                                      </td>
                                                    <td style="text-align:left; ">
                                                        <asp:HiddenField ID="HideModeOperate" runat="server" />
                                                      </td>
                                                    <td style="text-align:right; height: 25px;">
                                                        </td>
                                                </tr>
                                                  <tr>
                                                      <td style="font-size: small;">เลขไมล์ <br><asp:TextBox ID="TxtVehMiledge" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" style="text-align:right;" Text="0.00" type="text" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small;">ประเภทรถ<br><asp:TextBox ID="TxtVehType" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="-" type="text" ReadOnly="True" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small;">อายุรถ<br><asp:TextBox ID="TxtVehAge" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" style="text-align:right;" Text="0" type="text" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small;">เชื่อเพลิง<br><asp:TextBox ID="TxtVehFuel" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="-" type="text" ReadOnly="True" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small;">
                                                          <asp:HiddenField ID="HideGarageID" runat="server" />
                                                      </td>
                                                      <td style="font-size: small; ">
                                                          <asp:HiddenField ID="HideRecRefNo" runat="server" />
                                                      </td>
                                                      <td style="font-size: small; ">
                                                          &nbsp;</td>
                                                  </tr>
                                                  <tr>
                                                      <td style="font-size: small;text-align:right">บริษัท/อู่ :</td>
                                                      <td colspan="3" style="font-size: small;">
                                                          <asp:TextBox ID="TxtGarageName" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" ReadOnly="True" Text="-" type="text" Width="94%" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                  </tr>
                                                  <tr>
                                                      <td style="font-size: small;text-align:right;">ที่อยู่ :</td>
                                                      <td colspan="3" style="font-size: small;">
                                                          <asp:TextBox ID="TxtGarageAddr" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" ReadOnly="True" Text="-" type="text" Width="94%" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                  </tr>
                                                  <tr>
                                                      <td style="font-size: small;text-align:right">ติดต่อ :</td>
                                                      <td colspan="3" style="font-size: small;">
                                                          <asp:TextBox ID="TxtGarageContact" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" ReadOnly="True" Text="-" type="text" Width="94%" Font-Size="Small"></asp:TextBox>
                                                      </td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                      <td style="font-size: small; ">&nbsp;</td>
                                                  </tr>
                                         </table>
                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td>รายการซ่อม :</td>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:right;vertical-align: top;" colspan="3">
                                                           <asp:GridView ID="GrdRepairDesc" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdRepairDesc_SelectedIndexChanged" Width="100%" DataKeyNames="IDx" Font-Size="Small">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                   <HeaderStyle Width="20px" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:ButtonField>
                                                                   <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Width="35px" />
                                                                       <ItemStyle HorizontalAlign="Right" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" Visible="False" >
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="20px" />
                                                                   <ItemStyle HorizontalAlign="Right" Width="25px" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TxtDescription" runat="server" BorderStyle="None" Width="100%" Text='<%# Bind("MnDesc") %>'></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>&nbsp;</td>
                                                       <td style="text-align:right;">
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>



                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td style="width: 388px">รูปภาพอ้างอิง :</td>
                                                       <td style="width: 895px">&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                  <tr>
                                                       <td colspan="3">
                                                           <asp:GridView ID="GrdOrderImage" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" Width="100%">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ" Visible="False">
                                                                   <HeaderStyle Width="20px" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:ButtonField>
                                                                   <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Right" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="Image_ILx" HeaderText="เลขระเบียน" Visible="False">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:BoundField>
                                                                   <asp:BoundField DataField="Image_Note" HeaderText="รายละเอียด" >
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รูปภาพ">
                                                                       <ItemTemplate>
                                                                           <asp:Label ID="LblFileName" runat="server" Text='<%# Bind("Image_FileActual") %>' Font-Size="Small"></asp:Label>
                                                                           <br />
                                                                           <asp:Image ID="Image1" runat="server" Height="202px" ImageUrl='<%# Bind("ImageURL") %>' Width="366px" />
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                 </tr>
                                                  <tr>
                                                       <td colspan="3">
                                                       </td>
                                                 </tr>
                                        </table>

                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:left;vertical-align: top;" colspan="2">
                                                           <asp:ImageMap ID="ImageMap1" runat="server" HotSpotMode="PostBack" ImageUrl="~/App_Images/messageImage_1620980590191.jpg" OnClick="ImageMap1_Click">
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="30" PostBackValue="L2" Right="85" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" Left="30" PostBackValue="L1" Right="85" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="125" PostBackValue="L4" Right="180" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="125" PostBackValue="L3" Right="180" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="220" PostBackValue="L2x" Right="290" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="220" PostBackValue="L1x" Right="290" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="327" PostBackValue="L6" Right="400" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="327" PostBackValue="L5" Right="400" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="327" PostBackValue="L4x" Right="400" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="327" PostBackValue="L3x" Right="400" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="410" PostBackValue="L10" Right="482" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="410" PostBackValue="L9" Right="482" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="410" PostBackValue="L8" Right="482" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="410" PostBackValue="L7" Right="482" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="625" PostBackValue="L14" Right="697" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="625" PostBackValue="L13" Right="697" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="625" PostBackValue="L12" Right="697" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="625" PostBackValue="L11" Right="697" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" Left="715" PostBackValue="L18" Right="795" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" Left="715" PostBackValue="L17" Right="795" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="715" PostBackValue="L16" Right="795" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="715" PostBackValue="L15" Right="795" Top="140" />
                                                           </asp:ImageMap>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="height: 1px; color: #C0C0C0;"></td>
                                                       <td style="height: 1px"></td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           <asp:GridView ID="GrdWheelPos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" Width="100%" DataKeyNames="IDx">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                   <HeaderStyle Width="25px" BackColor="WhiteSmoke" />
                                                                   <ItemStyle Font-Size="Small" VerticalAlign="Top" />
                                                                   </asp:ButtonField>
                                                             <%--      <asp:BoundField DataField="IDx" HeaderText="ลำดับ">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="25px" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                                   </asp:BoundField>--%>
                                                                     <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="WhiteSmoke" />
                                                                       <ItemStyle HorizontalAlign="Right" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="W_POS" HeaderText="ตำแหน่ง">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="30px" BackColor="WhiteSmoke" />
                                                                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Font-Size="Small" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <table style="width:100%;">
                                                                               <tr>
                                                                                   <td style="width: 168px; text-align:right;">เหตุผลที่แจ้งซ่อม :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtWRepairReason" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("MnRemark") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td style="width: 90px">&nbsp;</td>
                                                                                   <td style="width: 197px">&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 168px ; text-align:right;">บริเวณความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageArea1" runat="server" Checked='<%# Bind("DamageArea1") %>' Font-Bold="False" Font-Underline="False" Text="[หน้ายาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea2" runat="server" Checked='<%# Bind("DamageArea2") %>' Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Text="[ไหล่ยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea3" runat="server" Checked='<%# Bind("DamageArea3") %>' Font-Bold="True" Font-Italic="False" Text="[ขอบยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea4" runat="server" Checked='<%# Bind("DamageArea4") %>' Font-Bold="False" Text="[แก้มยาง]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #C0C0C0; text-align:right; background-color: whitesmoke; width: 90px;">ซีเรียล:</td>
                                                                                   <td style="border: 1px solid #CCCCCC; width: 197px;">
                                                                                       <asp:TextBox ID="TxtSN" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" ReadOnly="True" Text='<%# Bind("Serial") %>' type="text" Width="150px"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 168px ; text-align:right;">อื่นๆ :</td>
                                                                                   <td><asp:TextBox ID="TxtDamageAreaOther" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("DamageAreaAno") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td style="border: 1px solid #C0C0C0; text-align:right; background-color: whitesmoke; width: 90px;">มิลยาง :</td>
                                                                                   <td style="border: 1px solid #CCCCCC; width: 197px;">
                                                                                       <asp:TextBox ID="TxtRubberMil" runat="server" MaxLength="20" ReadOnly="True" Text='<%# Bind("RMile") %>' Width="50px" BorderStyle="None"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 168px ; text-align:right;">ลักษณะความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageType1" runat="server" Checked='<%# Bind("DamageType1") %>' Font-Bold="False" Text="[รัั่ว]" />
                                                                                       <asp:CheckBox ID="ChkDamageType2" runat="server" Checked='<%# Bind("DamageType2") %>' Font-Bold="False" Text="[หมดดอก]" />
                                                                                       <asp:CheckBox ID="ChkDamageType3" runat="server" Checked='<%# Bind("DamageType3") %>' Font-Bold="False" Text="[แตก/ฉีก]" />
                                                                                       <asp:CheckBox ID="ChkDamageType4" runat="server" Checked='<%# Bind("DamageType4") %>' Font-Bold="False" Text="[บวม]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #C0C0C0; text-align:right; background-color: whitesmoke; width: 90px;">ขอบยาง :</td>
                                                                                   <td style="border: 1px solid #CCCCCC; width: 197px;">
                                                                                       <asp:TextBox ID="TxtWhellSize" runat="server" MaxLength="20" ReadOnly="True" Text='<%# Bind("WhlSize") %>' Width="50px" BorderStyle="None"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 168px ; text-align:right;">อื่นๆ :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtDamageTypeAno" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("DamageTypeAno") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td style="width: 90px">&nbsp;</td>
                                                                                   <td style="width: 197px">&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                           </table>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="WhiteSmoke" />
                                                                       <ItemStyle Font-Bold="False" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" Visible="False">
                                                                   <HeaderStyle Width="25px" BackColor="WhiteSmoke" />
                                                                   </asp:BoundField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                              <table style="width:100%;">
                                                                             <tr style="background-color: #F0F0F0">
                                                                                    <td style="border-top-style: solid; border-bottom-style: solid; border-left-style: solid; border-top-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-top-color: #C0C0C0; border-bottom-color: #C0C0C0; border-left-color: #C0C0C0;">ประวัติการซ่อมและความคิดเห็นแผนกซ่อมบำรุงยานพาหนะส่วนกลาง </td>
                                                                                    <td style="border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-top-color: #C0C0C0; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;">&nbsp;</td>
                                                                              </tr> 
                                                                              <tr style="background-color: #F0F0F0">
                                                                                    <td style="border-top-style: solid; border-bottom-style: solid; border-left-style: solid; border-top-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-top-color: #C0C0C0; border-bottom-color: #C0C0C0; border-left-color: #C0C0C0;">ประวัติการซ่อม :</td>
                                                                                     <td style="border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-top-color: #C0C0C0; border-right-color: #C0C0C0; border-bottom-color: #C0C0C0;"></td>
                                                                               </tr> 
                                                                        <tr>
                                                                        <td colspan="2" style="border: 1px solid #C0C0C0">
                                                                            <asp:GridView ID="GrdRepairDesc4x" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairDesc4x_SelectedIndexChanged" >
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ซ่อม">
                                                                                    <HeaderStyle Font-Size="Smaller" Width="80px" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_ORD_NO" HeaderText="เลขที่">
                                                                                    <HeaderStyle Font-Size="Small" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="เลขไมล์">
                                                                                    <HeaderStyle Font-Size="Smaller" Width="80px" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_TOTAL_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคาซ่อม" >
                                                                                    <HeaderStyle Font-Size="Small" Width="80px" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="center"  />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField ShowHeader="False">
                                                                                        <ItemTemplate>
                                                                                            <asp:Button ID="CmdShowDetail" runat="server" CausesValidation="false" CommandName="Select" Text="รายละเอียด" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Width="80px" Font-Bold="False" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="ผู้บริการ" DataField="GARAGE_NAME">
                                                                                    <HeaderStyle Font-Size="Small" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                </tr>

                                                              </table>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                            <tr>
                                                <td>
                                                    สาเหตุการซ่อม : 
                                                <asp:CheckBoxList ID="cblAccident" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="อุบัติเหตุ" Value="1" onclick="MutExChkList(this);" />
                                                    <asp:ListItem Text="เสื่อมสภาพ" Value="2" onclick="MutExChkList(this);" />
                                                </asp:CheckBoxList>
                                                    <%--<input type="checkbox" id="vehicle1" name="vehicle1" class="accident" value="1">--%>
                                                    
                                                    <%--<label for="vehicle1"> อุบัติเหตุ</label>--%>
                                                    <%--<input type="checkbox" id="vehicle2" name="vehicle2" class="accident" value="2">--%>
                                                    
                                                    <%--<label for="vehicle2"> เสื่อมสภาพ</label>--%>
                                                </td>
                                            </tr>
                                                   <tr>
                                                       <td>หมายเหตุ (แผนกซ่อมบำรุง) :
                                                           <asp:TextBox ID="TxtMNHeadRem" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" Text="-" type="text" Width="90%"></asp:TextBox>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                               </table>
                                               <table style="width:100%;">
                                                        <tr style="background-color: #F0F0F0">
                                                           <td style="text-align:left;">
                                                               <asp:Button ID="CmdOrderInApprove" runat="server" Text="ไม่ให้ซ่อม !" Width="110px" OnClick="CmdOrderInApprove_Click" ForeColor="Red" />&nbsp;<asp:Button ID="CmdOrderReqReason" runat="server" Text="ขอรายละเอียดเพิ่มเติม" Width="161px" OnClick="CmdOrderReqReason_Click" />
                                                               &nbsp;<asp:Button ID="CmdPrintX1" runat="server" ForeColor="Black" OnClick="CmdPrintX1_Click" Text="พิมพ์" Width="104px" />
                                                               <asp:Button ID="CmdAdjOrder" runat="server" ForeColor="Black" OnClick="CmdAdjOrder_Click" Text="บันทึกข้อมูลเพิ่มเติม  ..." Width="188px" />
                                                           </td>
                                                           <td>&nbsp;</td>
                                                           <td style="text-align:right;">
                                                               &nbsp;<asp:Button ID="CmdOrderApprove" runat="server" Text="อนุมัติซ่อม." Width="104px" OnClick="CmdOrderApprove_Click" ForeColor="#009900" />&nbsp;&nbsp;
                                                           </td>
                                                           </tr>
                                                                <tr>
                                                                       <td>&nbsp;</td>
                                                                       <td>&nbsp;</td>
                                                                       <td>&nbsp;</td>
                                                               </tr>
                                             </table>
                                                       
                           
                                    </div>
                                  <script type="text/javascript">
                                      $(document).ready(function () {
                                          console.log("Hello World");
                                          //$('#chkSource').click(function () {
                                          //    $('#chkSource').not(this).prop('checked', false);
                                          //});
                                      })

                                      function MutExChkList(chk) {
                                          var chkList = chk.parentNode.parentNode.parentNode;
                                          var chks = chkList.getElementsByTagName("input");
                                          for (var i = 0; i < chks.length; i++) {
                                              if (chks[i] != chk && chk.checked) {
                                                  chks[i].checked = false;
                                              }
                                          }
                                      }
                                  </script>
                                  
                               </asp:View>
                              <asp:View ID="View6x" runat="server">
                                  <div class="w3-container">
                                        <table class="w3-table w3-border">
                                            <tr style="background-color: #F0F0F0">
                                              <td style="text-align:left;">บริษัท ไทยพาร์เซิล จำกัด (มหาชน)</td>
                                              <td></td>
                                              <td style="text-align:right;" >-    </td>
                            
                                            </tr>
                                            <tr>
                                              <td style="text-align:left;">วันที่แจ้งซ่อม :<asp:TextBox ID="TxtOrderDate2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Text="-" type="text" Width="100px" OnTextChanged="TxtOrderDate2_TextChanged"></asp:TextBox>
                                                  <ajaxToolkit:CalendarExtender ID="TxtOrderDate2_CalendarExtender" runat="server" BehaviorID="TxtOrderDate2_CalendarExtender" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate2" TargetControlID="TxtOrderDate2" />
                                                  <asp:ImageButton ID="imgOrderDate2" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png"  ToolTip="เลือกวันที่" Width="16px" />
                                                </td>
                                              <td>
                                                  <asp:RadioButton ID="RdoCR0" runat="server" Font-Bold="False" GroupName="string" Text="งานซ่อมทั่ว (CR)" />
                                                  <asp:RadioButton ID="RdoPM0" runat="server" Font-Bold="False" GroupName="string" Text="PM" />
                                                  -</td>
                                              <td style="text-align:right;" >เลขที่เอกสาร :<asp:TextBox ID="TxtOrderNo2"  class="w3-border-bottom" type="text"  runat="server"  BorderStyle="None" Text="-" Width="140px" Font-Size="Small" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                            
                                            </tr>
                                          </table>
                                        <table class="w3-table w3-border">
                                                  <tr>
                                                  <td style="text-align:left; font-size: small; ">รหัสรถยนต์<br><asp:TextBox ID="TxtVehCode2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" OnTextChanged="TxtVehCode2_TextChanged"></asp:TextBox></td>
                                                  <td style="text-align:left; font-size: small;">ทะเบียน<br><asp:TextBox ID="TxtVehLicense2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      <br>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; ">ยี่ห้อ<br><asp:TextBox ID="TxtVehBrand2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      <br></td>
                                                  <td style="text-align:left; font-size: small; ">รุ่นรถ<br><asp:TextBox ID="TxtVehModel2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" OnTextChanged="TxtVehModel2_TextChanged"></asp:TextBox>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; ">
                                                      <asp:HiddenField ID="HideVehID2" runat="server" />
                                                      </td>
                                                    <td style="text-align:left; font-size: small; "></td>
                                                    <td style="text-align:right; height: 25px;">
                                                        </td>
                                                </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">เลขไมล์ <br><asp:TextBox ID="TxtVehMiledge2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" style="text-align:right;" Text="0.00" type="text"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">ประเภทรถ<br><asp:TextBox ID="TxtVehType2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">อายุรถ<br><asp:TextBox ID="TxtVehAge2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" style="text-align:right;" Text="0" type="text"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">เชื่อเพลิง<br><asp:TextBox ID="TxtVehFuel2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          <asp:HiddenField ID="HideGarageID2" runat="server" />
                                                      </td>
                                                      <td style="text-align:left; font-size: small; "></td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          &nbsp;</td>
                                                  </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">บริษัท/อู่ <br>
                                                         <asp:TextBox ID="TxtGarageName2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; " colspan="2">ที่อยู่<br><asp:TextBox ID="TxtGarageAddr2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" Width="90%" ReadOnly="True"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; ">ติดต่อ<br><asp:TextBox ID="TxtGarageContact2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text"  ReadOnly="True" OnTextChanged="TxtGarageContact2_TextChanged"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          <asp:HiddenField ID="HideModeOperate2" runat="server" />
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          <asp:HiddenField ID="HideRecRefNo2" runat="server" />
                                                      </td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          &nbsp;</td>
                                                  </tr>
                                         </table>
                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td>รายการซ่อม :</td>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:right;vertical-align: top;" colspan="3">
                                                           <asp:GridView ID="GrdRepairDesc2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdRepairDesc_SelectedIndexChanged" Width="100%" DataKeyNames="IDx">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                   <HeaderStyle Width="20px" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:ButtonField>
                                                                   <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" ForeColor="Black" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" Visible="False" >
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="20px" ForeColor="Black" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="25px" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TxtDescription" runat="server" BorderStyle="None" Width="100%" Text='<%# Bind("MnDesc") %>' ForeColor="Black"></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Font-Size="Small" ForeColor="Black" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>&nbsp;</td>
                                                       <td style="text-align:right;">
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>

                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td style="width: 388px">รูปภาพอ้างอิง :</td>
                                                       <td style="width: 895px">&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                  <tr>
                                                       <td colspan="3">
                                                           <asp:GridView ID="GrdOrderImage2" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" Width="100%">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ" Visible="False">
                                                                   <HeaderStyle Width="20px" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:ButtonField>
                                                                   <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="Image_ILx" HeaderText="เลขระเบียน" Visible="False">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:BoundField>
                                                                   <asp:BoundField DataField="Image_Note" HeaderText="รายละเอียด" >
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รูปภาพ">
                                                                       <ItemTemplate>
                                                                           <asp:Label ID="LblFileName" runat="server" Text='<%# Bind("Image_FileActual") %>' Font-Size="Small"></asp:Label>
                                                                           <br />
                                                                           <asp:Image ID="Image1" runat="server" Height="202px" ImageUrl='<%# Bind("ImageURL") %>' Width="366px" />
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                 </tr>
                                                  <tr>
                                                       <td colspan="3">
                                                       </td>
                                                 </tr>
                                        </table>



                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td style="width:100px;">ระบบยาง :</td>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:left;vertical-align: top;" colspan="3">
                                                           <asp:ImageMap ID="ImageMap2" runat="server" HotSpotMode="PostBack" ImageUrl="~/App_Images/messageImage_1620980590191.jpg" OnClick="ImageMap1_Click">
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="30" PostBackValue="L2" Right="85" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" Left="30" PostBackValue="L1" Right="85" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="125" PostBackValue="L4" Right="180" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="125" PostBackValue="L3" Right="180" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="220" PostBackValue="L2x" Right="290" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="220" PostBackValue="L1x" Right="290" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="327" PostBackValue="L6" Right="400" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="327" PostBackValue="L5" Right="400" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="327" PostBackValue="L4x" Right="400" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="327" PostBackValue="L3x" Right="400" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="410" PostBackValue="L10" Right="482" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="410" PostBackValue="L9" Right="482" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="410" PostBackValue="L8" Right="482" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="410" PostBackValue="L7" Right="482" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="625" PostBackValue="L14" Right="697" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="625" PostBackValue="L13" Right="697" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="625" PostBackValue="L12" Right="697" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="625" PostBackValue="L11" Right="697" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" Left="715" PostBackValue="L18" Right="795" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" Left="715" PostBackValue="L17" Right="795" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="715" PostBackValue="L16" Right="795" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="715" PostBackValue="L15" Right="795" Top="140" />
                                                           </asp:ImageMap>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="height: 6px; color: #C0C0C0;" colspan="2"><small>**Click เลือกที่ตำแหน่งยางเพื่อเพิ่มรายการ</small></td>
                                                       <td style="height: 6px"></td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="2">
                                                           <asp:GridView ID="GrdWheelPos2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" Width="100%" DataKeyNames="IDx">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ" Visible="False">
                                                                   <HeaderStyle Width="25px" />
                                                                   <ItemStyle Font-Size="Small" VerticalAlign="Top" />
                                                                   </asp:ButtonField>
                                                             <%--      <asp:BoundField DataField="IDx" HeaderText="ลำดับ">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="25px" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                                   </asp:BoundField>--%>
                                                                     <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" ForeColor="Black" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="W_POS" HeaderText="ตำแหน่ง">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="30px" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" ForeColor="Black" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <table style="width:100%;">
                                                                               <tr>
                                                                                   <td style="width: 150px;text-align:right;">เหตุผลที่แจ้งซ่อม :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtWRepairReason" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("MnRemark") %>' type="text" Width="100%" ForeColor="Black"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">บริเวณความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageArea1" runat="server" Checked='<%# Bind("DamageArea1") %>' Font-Bold="False" Font-Underline="False" Text="[หน้ายาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea2" runat="server" Checked='<%# Bind("DamageArea2") %>' Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Text="[ไหล่ยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea3" runat="server" Checked='<%# Bind("DamageArea3") %>' Font-Bold="True" Font-Italic="False" Text="[ขอบยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea4" runat="server" Checked='<%# Bind("DamageArea4") %>' Font-Bold="False" Text="[แก้มยาง]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #CCCCCC; text-align:right;">ซีเรียล:</td>
                                                                                   <td style="border: 1px solid #CCCCCC">
                                                                                       <asp:TextBox ID="TxtSN" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text='<%# Bind("Serial") %>' type="text" Width="150px" ReadOnly="True"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">อื่นๆ :</td>
                                                                                   <td><asp:TextBox ID="TxtDamageAreaOther" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("DamageAreaAno") %>' type="text" Width="100%" ForeColor="Black"></asp:TextBox>
                                                                                   </td>
                                                                                   <td style="border: 1px solid #CCCCCC; text-align:right;">มิลยาง :</td>
                                                                                   <td style="border: 1px solid #CCCCCC">
                                                                                       <asp:TextBox ID="TxtRubberMil" runat="server" MaxLength="20" Text='<%# Bind("RMile") %>' Width="50px" ReadOnly="True"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">ลักษณะความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageType1" runat="server" Checked='<%# Bind("DamageType1") %>' Font-Bold="False" Text="[รัั่ว]" />
                                                                                       <asp:CheckBox ID="ChkDamageType2" runat="server" Checked='<%# Bind("DamageType2") %>' Font-Bold="False" Text="[หมดดอก]" />
                                                                                       <asp:CheckBox ID="ChkDamageType3" runat="server" Checked='<%# Bind("DamageType3") %>' Font-Bold="False" Text="[แตก/ฉีก]" />
                                                                                       <asp:CheckBox ID="ChkDamageType4" runat="server" Checked='<%# Bind("DamageType4") %>' Font-Bold="False" Text="[บวม]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #CCCCCC; text-align:right;">ขอบยาง :</td>
                                                                                   <td style="border: 1px solid #CCCCCC">
                                                                                       <asp:TextBox ID="TxtWhellSize" runat="server" MaxLength="20" Text='<%# Bind("WhlSize") %>' Width="50px" ReadOnly="True"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">อื่นๆ :</td>
                                                                                   <td><asp:TextBox ID="TxtDamageTypeAno" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("DamageTypeAno") %>' type="text" Width="100%" ForeColor="Black"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                           </table>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" Visible="False">
                                                                   <HeaderStyle Width="25px" />
                                                                   </asp:BoundField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="3">

                                                              <table style="width:100%;" class="w3-table w3-border";>
                                                               <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">ประวัติการซ่อมและความคิดเห็นแผนกซ่อมบำรุงยานพาหนะส่วนกลาง </td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">&nbsp;</td>
                                                               </tr> 
                                                                   <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">ประวัติการซ่อม(1) :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0"></td>
                                                               </tr> 
                                                               <tr>
                                                                        <td colspan="3">
                                                                            <asp:GridView ID="GrdRepairDesc4" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairDesc4_SelectedIndexChanged">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ซ่อม">
                                                                                    <HeaderStyle Font-Size="Smaller" Width="80px" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_ORD_NO" HeaderText="เลขที่">
                                                                                    <HeaderStyle Font-Size="Small" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="เลขไมล์">
                                                                                    <HeaderStyle Font-Size="Smaller" Width="80px" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_TOTAL_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="ราคาซ่อม">
                                                                                    <HeaderStyle Font-Size="Small" HorizontalAlign="Right" Width="80px" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Right" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField ShowHeader="False">
                                                                                        <ItemTemplate>
                                                                                            <asp:Button ID="CmdShowDetail" runat="server" CausesValidation="false" CommandName="Select" Text="รายละเอียด" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Width="80px" Font-Bold="False" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="ผู้บริการ" DataField="GARAGE_NAME">
                                                                                    <HeaderStyle Font-Size="Small" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                </tr>
                                                    
                                                                  <tr style="background-color: #F0F0F0">
                                                                      <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">ประวัติการซ่อม(2) :</td>
                                                                      <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0"></td>
                                                                  </tr>
                                                               <tr>
                                                                        <td colspan="3">
                                                                            <asp:GridView ID="GrdVehDeptComment" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="IDx" OnSelectedIndexChanged="GrdVehDeptComment_SelectedIndexChanged">
                                                                                <Columns>
                                                                                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                                    <HeaderStyle Width="35px" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:ButtonField>

                                                                                      <asp:TemplateField HeaderText="ลำดับ">
                                                                                      <ItemTemplate>
                                                                                          <%# Container.DataItemIndex + 1 %>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                                      <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" />
                                                                                  </asp:TemplateField>


                                                                                    <asp:BoundField DataField="IDx" Visible="False" />
                                                                                    <asp:TemplateField HeaderText="วันที่ซ่อม">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtDATE_NOTE" runat="server" Text='<%# Bind("DATE_NOTE") %>' Width="90px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Smaller" Width="80px" />
                                                                                        <ItemStyle Font-Size="Small" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="รายละเอียด">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtDESC_NOTE" runat="server" Text='<%# Bind("DESC_NOTE") %>' Width="100%"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="100%" />
                                                                                        <ItemStyle Font-Size="Small" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="เลขไมล์">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtMILEDGE_NOTE" runat="server" Text='<%# Bind("MILEDGE_NOTE") %>' Width="80px" OnTextChanged="TxtMILEDGE_NOTE_TextChanged"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Smaller" Width="80px" />
                                                                                        <ItemStyle Font-Size="Small" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ราคาซ่อม">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtPRICE_NOTE" runat="server" Text='<%# Bind("PRICE_NOTE") %>' Width="70px" style="text-align:right;" OnTextChanged="TxtPRICE_NOTE_TextChanged"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Right" Width="80px" />
                                                                                        <ItemStyle Font-Size="Small" HorizontalAlign="Right" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ผู้บริการ">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtSERVICER_NOTE" runat="server" Text='<%# Bind("SERVICER_NOTE") %>' Width="150px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                        <ItemStyle Font-Size="Small" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                </tr>





                                                                  <tr>
                                                                      <td>&nbsp;</td>
                                                                      <td>&nbsp;</td>
                                                                      <td style="text-align:right;">
                                                                          <asp:Button ID="CmdAddDesc" runat="server"  Text="เพิ่มรายการ " Width="100px" OnClick="CmdAddDesc_Click" />
                                                                      </td>
                                                                  </tr>
                                                    
                                                                <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายการซ่อมครั้งนี้ :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                               </tr>
                                                               <tr>
                                                                        <td colspan="3">
                                                                            <asp:GridView ID="GrdRepairDesc3" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" OnSelectedIndexChanged="GrdRepairDesc3_SelectedIndexChanged" Width="100%">
                                                                                <Columns>
                                                                                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                                    <HeaderStyle Width="20px" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:ButtonField>
                                                                                    <asp:TemplateField HeaderText="ลำดับ">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                                        <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="IDx" Visible="False">
                                                                                    <HeaderStyle Font-Bold="False" Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" Width="20px" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="25px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="รายละเอียด">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtDescription3" runat="server" BorderStyle="None" ForeColor="Black" Text='<%# Bind("MnDesc") %>' Width="100%"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                        <ItemStyle Font-Size="Small" ForeColor="Black" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ราคาซ่อม">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtDescription3Price" runat="server" style="text-align:right;" BackColor="#FFFFCC" BorderStyle="None" Font-Size="Small" ForeColor="Black" MaxLength="10" Text='<%# Bind("MnCost","{0:N2}") %>' Width="100px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                        <ItemStyle Width="120px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ผู้บริการ">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="TxtDescription3Servicer" runat="server" BorderStyle="None" ForeColor="Black" Text='<%# Bind("MnServicer") %>' Width="100%"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                        <ItemStyle Font-Size="Small" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                               </tr>
                                                               <tr>
                                                                   <td>&nbsp;</td>
                                                                   <td>ค่าซ่อมรวม :<asp:TextBox ID="TxtTotalPrice" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" OnTextChanged="TxtTotalPrice_TextChanged" ReadOnly="True" style="text-align:right;" Text="0.00" type="text"></asp:TextBox>
                                                                       &nbsp;บาท&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                       <asp:Button ID="CmdAddDescLine0" runat="server" OnClick="CmdAddDescLine0_Click" Text="ค่าซ่อมรวม=?" Width="105px" />
                                                                   </td>
                                                                   <td style="text-align:right;">
                                                                       <asp:Button ID="CmdAddDescLine" runat="server" OnClick="CmdAddDescLine_Click" Text="เพิ่มรายการ " Width="100px" />
                                                                   </td>
                                                                </tr>
                                                                  <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายการเบิกอะไหล่ :</td>
                                                                   <td style="text-align: right;">ดึงข้อมูลใบจ่ายอะไหล่เข้าระบบ :<asp:TextBox ID="TxtPartRequestionNo" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" Width="178px"></asp:TextBox>
                                                                       &nbsp;<asp:Button ID="CmdPartRequisitionGet" runat="server" OnClick="CmdPartRequisitionGet_Click" Text="ดึงข้อมูล" />
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td colspan="3">
                                                                          <asp:GridView ID="GrdRepairPart" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" OnSelectedIndexChanged="GrdRepairPart_SelectedIndexChanged" Width="100%">
                                                                              <Columns>
                                                                                  <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                                  <HeaderStyle Width="20px" />
                                                                                  <ItemStyle Font-Size="Small" />
                                                                                  </asp:ButtonField>
                                                                                  <asp:TemplateField HeaderText="ลำดับ">
                                                                                      <ItemTemplate>
                                                                                          <%# Container.DataItemIndex + 1 %>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                                      <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" />
                                                                                  </asp:TemplateField>
                                                                                  <asp:BoundField DataField="IDx" Visible="False">
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" Width="20px" />
                                                                                  <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="25px" />
                                                                                  </asp:BoundField>
                                                                                  <asp:TemplateField HeaderText="รายละเอียด/ชื่ออะไหล่">
                                                                                      <ItemTemplate>
                                                                                          <asp:TextBox ID="TxtDescriptionPart" runat="server" BorderStyle="None" ForeColor="Black" Text='<%# Bind("MnDesc") %>' Width="100%"></asp:TextBox>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                      <ItemStyle Font-Size="Small" ForeColor="Black" />
                                                                                  </asp:TemplateField>
                                                                                  <asp:TemplateField HeaderText="จำนวน">
                                                                                      <ItemTemplate>
                                                                                          <asp:TextBox ID="TxtDescriptionPartAmt" runat="server" BackColor="#FFFFCC" BorderStyle="None" Font-Size="Small" ForeColor="Black" MaxLength="10" style="text-align:right;" Text='<%# Bind("MnAmt","{0:N0}") %>' Width="100px"></asp:TextBox>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                      <ItemStyle Width="120px" />
                                                                                  </asp:TemplateField>
                                                                                  <asp:TemplateField HeaderText="มูลค่า">
                                                                                      <ItemTemplate>
                                                                                          <asp:TextBox ID="txtDescPrice" runat="server" BackColor="#FFFFCC" BorderStyle="None" Font-Size="Small" ForeColor="Black" MaxLength="10" style="text-align:right;" Text ='<%# Bind("MnPrice","{0:N2}") %>' AutoPostBack="True" OnTextChanged="txtDescPrice_TextChanged"></asp:TextBox>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle />
                                                                                      <ItemStyle />
                                                                                  </asp:TemplateField>

                                                                              </Columns>
                                                                          </asp:GridView>
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td>&nbsp;</td>
                                                                      <td>
                                                                          <asp:Label ID="Label1" runat="server" Text="มูลค่ารวม : "></asp:Label>
                                                                          <asp:Label ID="lblAmtPrice" runat="server" Text=""></asp:Label>
                                                                          <asp:Label ID="Label2" runat="server" Text=" บาท"></asp:Label>
                                                                      </td>
                                                                      <td style="text-align:right;">
                                                                          <asp:Button ID="CmdAddPart" runat="server" OnClick="CmdAddPart_Click" Text="เพิ่มรายการ " Width="100px" />
                                                                      </td>
                                                                  </tr>
                                                                   <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายละเอียดงานซ่อม :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                                  </tr>

                                                                  <tr>
                                                                      <td colspan="3">
                                                                          <asp:GridView ID="GrdRepairDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" OnSelectedIndexChanged="GrdRepairDetail_SelectedIndexChanged" Width="100%">
                                                                              <Columns>
                                                                                  <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
                                                                                  <HeaderStyle Width="20px" />
                                                                                  <ItemStyle Font-Size="Small" />
                                                                                  </asp:ButtonField>
                                                                                  <asp:TemplateField HeaderText="ลำดับ">
                                                                                      <ItemTemplate>
                                                                                          <%# Container.DataItemIndex + 1 %>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                                      <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" />
                                                                                  </asp:TemplateField>
                                                                                  <asp:BoundField DataField="IDx" Visible="False">
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" Width="20px" />
                                                                                  <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="25px" />
                                                                                  </asp:BoundField>
                                                                                  <asp:TemplateField HeaderText="รายละเอียดงานซ่อม">
                                                                                      <ItemTemplate>
                                                                                          <asp:TextBox ID="TxtDescriptionDet" runat="server" BorderStyle="None" ForeColor="Black" Text='<%# Bind("MnDesc") %>' Width="100%"></asp:TextBox>
                                                                                      </ItemTemplate>
                                                                                      <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                      <ItemStyle Font-Size="Small" ForeColor="Black" />
                                                                                  </asp:TemplateField>
                                                                              </Columns>
                                                                          </asp:GridView>
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td>&nbsp;</td>
                                                                      <td>&nbsp;</td>
                                                                      <td style="text-align:right;">
                                                                          <asp:Button ID="CmdDetail" runat="server" OnClick="CmdDetail_Click" Text="เพิ่มรายการ " Width="100px" />
                                                                      </td>
                                                                  </tr>
                                                          </table>





                                                       </td>
                                                   </tr>
                                            
                                       </table>
                              
                          
                                    </div>
                                  
                                  <div class="w3-container">
                                      <table style="width:100%;">
                                              <tr >
                                                                   <td style="height: 5px" >
                                                                   </td>
                                                                   <td style="text-align: right; height: 5px;" >
                                                                   </td>
                                                               </tr>
                                              <tr>
                                                  <td>
                                                      
                                                      <asp:Panel ID="Panel1" runat="server" Height="16px" Width="250px">
                                                          &nbsp;&nbsp; ผลการซ่อม :
                                                          <asp:RadioButton ID="RdoFail" runat="server" AutoPostBack="True" Font-Bold="False" Font-Size="Small" ForeColor="#990000" OnCheckedChanged="RdoFail_CheckedChanged" Text="ซ่อมไม่ได้" />
                                                          <asp:RadioButton ID="RdoSuccess" runat="server" AutoPostBack="True" Checked="True" Font-Bold="True" Font-Size="Small" ForeColor="#006600" OnCheckedChanged="RdoSuccess_CheckedChanged" Text="ซ่อมได้" />
                                                      </asp:Panel>
                                                  </td>
                                                  <td style="text-align: right">
                                                      <asp:Button ID="CmdPrint" runat="server" ForeColor="Black" OnClick="CmdPrint_Click" Text="พิมพ์" Width="104px" />
                                                      <asp:Button ID="CmdSave" runat="server" ForeColor="Black" OnClick="CmdSave_Click" Text="บันทึก" Width="104px" />
                                                      &nbsp;&nbsp;&nbsp; กำหนดวันที่ปิดงาน:&nbsp;<asp:TextBox ID="TxtCloseDateSet" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" OnTextChanged="TxtCloseDateSet_TextChanged" Text="-" type="text" Width="119px"></asp:TextBox>
                                                      <ajaxToolkit:CalendarExtender ID="TxtCloseDateSet_CalendarExtender" runat="server" BehaviorID="TxtCloseDateSet_CalendarExtender" Format="dd/MM/yyyy" PopupButtonID="imgCloseDateSet" PopupPosition="TopLeft" TargetControlID="TxtCloseDateSet" />
                                                      <asp:ImageButton ID="imgCloseDateSet" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png"  ToolTip="เลือกวันที่" Width="16px"  />
                                                      &nbsp;<asp:Button ID="CmdSaveClose" runat="server" ForeColor="#006600" Text="บันทึกและปิดงาน" Width="130px" OnClick="CmdSaveClose_Click" />
                                                  </td>
                                              </tr>
                                   </table>
                                  </div>
                              </asp:View>
                              <asp:View ID="View7" runat="server">
                                   <table style="width:100%;">
                                       <tr>
                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;A.รายการอู่ซ่อม : &nbsp; </td>
                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #000000;">ชื่ออู่ /เบอร์โทร :<asp:TextBox ID="TGarageKey" runat="server" OnTextChanged="TGarageKey_TextChanged"></asp:TextBox>
                                               <asp:Button ID="CmdSearchGarage" runat="server" ForeColor="Black" Text="ค้นหา" OnClick="CmdSearchGarage_Click1"  />
                                               <asp:Button ID="CmdAddGarage" runat="server" ForeColor="Black" Text="เพิ่มอู่ .." OnClick="CmdAddGarage_Click"   />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td colspan="3">

                                               <asp:GridView ID="GrdGarageSelector" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdGarageSelector_SelectedIndexChanged" Width="100%">
                                                   <Columns>
                                                       <asp:ButtonField ButtonType="Image" CommandName="Select" ImageUrl="~/App_Images/embedsemantic.png">
                                                       <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                       <ItemStyle HorizontalAlign="Center" />
                                                       </asp:ButtonField>
                                                       <asp:BoundField DataField="GARAGE_ID" HeaderText="รหัส">
                                                       <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="GARAGE_NAME" HeaderText="ชื่ออู่">
                                                       <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                       <ItemStyle Font-Size="Small" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="GARAGE_ADDR" HeaderText="ที่อยู่">
                                                       <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                       <ItemStyle Font-Size="Small" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ">
                                                       <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Left" />
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="GARAGE_TEL" HeaderText="โทรศัพท์">
                                                       <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                       <ItemStyle Font-Size="Small" />
                                                       </asp:BoundField>
                                                   </Columns>
                                               </asp:GridView>

                                               <asp:Panel ID="Panel3" runat="server" Visible="False">
                                                   <br />
                                                   <table style="width:100%;">
                                                       <tr>
                                                           <td class="modal-sm" style="text-align: right;">รหัสอู่ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtGarageIDE" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="#666666" Height="19px" ReadOnly="True" Text="-" type="text"></asp:TextBox>
                                                           </td>
                                                           <td>
                                                               <asp:HiddenField ID="HideGarageMode" runat="server" />
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="text-align: right;">ชื่ออู่ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtGarageNameE" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="250" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="text-align: right;">ที่อยู่ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtGarageAddrE" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="250" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">ติดต่อ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtGarageContE" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="250" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">โทรศัพท์ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtGarageTelE" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="150" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>
                                                               <asp:Button ID="CmdSaveGarageE" runat="server" Text="บันทึก" OnClick="CmdSaveGarageE_Click" />
                                                               <asp:Button ID="CmdClosePanel" runat="server" OnClick="CmdClosePanel_Click" Text="ปิด" />
                                                           </td>
                                                       </tr>
                                                   </table>
                                                   <br />
                                                   <br />
                                               </asp:Panel>


                                           </td>
                                       </tr>
                                       <tr>
                                           <td style="text-align:left; height: 18px;">&nbsp;</td>
                                           <td style="height: 18px"></td>
                                           <td style="text-align:right; height: 18px;"></td>
                                       </tr>
                                   </table>
                               </asp:View>
                              <asp:View ID="View8" runat="server">
                                   <table style="width:100%;">
                                       <tr>
                                            <td colspan="12" style="text-align:right">
                                                <asp:ImageButton ID="imgBtn8" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn8_Click" />
                                            </td>
                                        </tr>
                                       <tr>
                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;B.รายการยานพาหนะ : &nbsp; </td>
                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #000000;">ทะเบียน-เลขรถ :<asp:TextBox ID="TVehicleKey" runat="server"></asp:TextBox>
                                               <asp:Button ID="CmdSearchVehicle" runat="server" ForeColor="Black" Text="ค้นหา" OnClick="CmdSearchVehicle_Click"   />
                                               <asp:Button ID="CmdAddVehicle" runat="server" ForeColor="Black" Text="เพิ่มรถ .." OnClick="CmdAddVehicle_Click"    />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td colspan="3">
                                                                                                  <asp:GridView ID="GrdAssetVehSelector" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdAssetVehSelector_SelectedIndexChanged" Width="100%">
                                                       <Columns>
                                                           <asp:ButtonField ButtonType="Image" CommandName="Select" ImageUrl="~/App_Images/embedsemantic.png">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                           <ItemStyle HorizontalAlign="Center" Width="30px" BorderColor="#CCCCCC" />
                                                           </asp:ButtonField>
                                                           <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="รหัส (ID)">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="80px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <%------%>
                                                           <asp:BoundField DataField="VEH_TYPE_ID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" Width="30px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <%------%>
                                                           <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="85px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_BRAND" HeaderText="ยี่ห้อ">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_MODEL" HeaderText="รุ่น">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_FUEL_SPEC" HeaderText="เชื้อเพลิง">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_ST_USE_DTIME" HeaderText="ปีรถ" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText="-">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                       </Columns>
                                                   </asp:GridView>
                                               <asp:Panel ID="Panel4" runat="server" Visible="False">

                                                   <br />
                                                   <table style="width:100%;">
                                                       <tr>
                                                           <td class="modal-sm" style="text-align: right;">รหัส (ID) :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtVehID4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="#666666" Height="19px" ReadOnly="True" Text="-" type="text"></asp:TextBox>
                                                           </td>
                                                           <td>
                                                               <asp:HiddenField ID="HiddenVehMode" runat="server" />
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="text-align: right;">เลขรถ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtVehCode4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="10" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="text-align: right; height: 22px;">ทะเบียน :</td>
                                                           <td style="height: 22px">
                                                               <asp:TextBox ID="TxtVehLicense4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="10" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td style="height: 22px"></td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">ประเภท :</td>
                                                           <td BorderStyle="None">
                                                               <ajaxToolkit:ComboBox ID="CmbVehType" runat="server" BorderStyle="None"  DropDownStyle="DropDownList" Width="500px">
                                                               </ajaxToolkit:ComboBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">ยี่ห้อ :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtVehBrand4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="50" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">รุ่น :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtVehModel4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="50" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">เชื้อเพลิง :</td>
                                                           <td>
                                                               <asp:TextBox ID="TxtVehFuel4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="50" Text="-" type="text" Width="500px"></asp:TextBox>
                                                           </td>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="modal-sm" style="width: 80px; text-align: right;">ปีรถ :</td>
                                                           <td style="font-size: small; color: #C0C0C0">
                                                               <asp:TextBox ID="TxtVehYear4" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" MaxLength="10" type="text" Width="500px"></asp:TextBox>
                                                               &nbsp;Ex.15/09/2020 ค.ศ.</td>
                                                           <td>
                                                               <asp:Button ID="CmdSaveVehE" runat="server" Text="บันทึก" OnClick="CmdSaveVehE_Click" />
                                                               <asp:Button ID="CmdClosePanelVeh" runat="server" OnClick="CmdClosePanelVeh_Click" Text="ปิด" />
                                                           </td>
                                                       </tr>
                                                   </table>
                                                   <br />
                                                   <br />
                                               </asp:Panel>


                                           </td>
                                       </tr>
                                       <tr>
                                           <td style="text-align:left; height: 18px;">&nbsp;</td>
                                           <td style="height: 18px"></td>
                                           <td style="text-align:right; height: 18px;"></td>
                                       </tr>
                                   </table>

                              </asp:View>
                               <asp:View ID="View9" runat="server">
                                    <table style="width:100%;">
                                        
                                       <tr>
                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;C.รายการยานพาหนะ : &nbsp; </td>
                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #000000;">ทะเบียน-เลขรถ :<asp:TextBox ID="TVehicleKey2" runat="server"></asp:TextBox>
                                               <asp:Button ID="CmdSearchVehicle2" runat="server" ForeColor="Black" Text="ค้นหา" OnClick="CmdSearchVehicle2_Click"   />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td colspan="3">
                                                <asp:GridView ID="GrdAssetVehSelector2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdAssetVehSelector2_SelectedIndexChanged" Width="100%">
                                                       <Columns>
                                                           <asp:ButtonField ButtonType="Image" CommandName="Select" ImageUrl="~/App_Images/embedsemantic.png">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                           <ItemStyle HorizontalAlign="Center" Width="30px" BorderColor="#CCCCCC" />
                                                           </asp:ButtonField>
                                                           <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="รหัส (ID)">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="80px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_TYPE_ID">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" Width="30px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="85px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_BRAND" HeaderText="ยี่ห้อ">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_MODEL" HeaderText="รุ่น">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_FUEL_SPEC" HeaderText="เชื้อเพลิง">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                           <asp:BoundField DataField="VEH_ST_USE_DTIME" HeaderText="ปีรถ" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText="-">
                                                           <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                           <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" />
                                                           </asp:BoundField>
                                                       </Columns>
                                                   </asp:GridView>
                                               <asp:Panel ID="Panel5" runat="server" Visible="False">
                                                   <table style="width:100%;">
                                                       <tr>
                                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">รายการค่าซ่อม&nbsp; </td>
                                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">**&nbsp; &nbsp; </td>
                                                       </tr>
                                                       <tr>
                                                           <td colspan="3">
                                                               <asp:GridView ID="GrdRepairOrderAct5" runat="server" AutoGenerateColumns="False" CellSpacing="1" DataKeyNames="MNT_ORD_NO" Width="100%">
                                                                   <Columns>
                                                                       <asp:TemplateField HeaderText="ลำดับ">
                                                                           <ItemTemplate>
                                                                               <%# Container.DataItemIndex + 1 %>
                                                                           </ItemTemplate>
                                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                                       </asp:TemplateField>
                                                                       <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="85px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" วันที่">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="80px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="135px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_LINENO_DESC" HeaderText="รายการซ่อม">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_LINENO_PRICE" HeaderText="ค่าซ่อม" DataFormatString="{0:n2}">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Right" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Right" Width="100px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_LINENO_SERVICER" HeaderText="ผู้บริการ">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="VEH_AGE" HeaderText="อายุรถ">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Right" Width="40px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="ORD_VEH_MILEDGE" HeaderText="เลขไมล์" DataFormatString="{0:n2}">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Right" Width="40px" />
                                                                       </asp:BoundField>
                                                                   </Columns>
                                                               </asp:GridView>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="text-align:left; height: 18px;">&nbsp;</td>
                                                           <td style="height: 18px"></td>
                                                           <td style="text-align:right; height: 18px;"></td>
                                                       </tr>
                                                   </table>
                                                   <table style="width:100%;">
                                                       <tr>
                                                           <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;รายการเบิกอะไหล่</td>
                                                           <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">**&nbsp; &nbsp; </td>
                                                       </tr>
                                                       <tr>
                                                           <td colspan="3">
                                                               <asp:GridView ID="GrdRepairOrderAct6" runat="server" AutoGenerateColumns="False" CellSpacing="1" DataKeyNames="MNT_ORD_NO" Width="100%">
                                                                   <Columns>
                                                                       <asp:TemplateField HeaderText="ลำดับ">
                                                                           <ItemTemplate>
                                                                               <%# Container.DataItemIndex + 1 %>
                                                                           </ItemTemplate>
                                                                           <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                           <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                                       </asp:TemplateField>
                                                                       <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="70px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="85px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" วันที่">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="80px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Center" Width="135px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="MNT_LINENO_DESC">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField HeaderText="จำนวน" DataField="MNT_LINENO_AMT">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Right" Width="40px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="VEH_AGE" HeaderText="อายุรถ">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Right" Width="40px" />
                                                                       </asp:BoundField>
                                                                       <asp:BoundField DataField="ORD_VEH_MILEDGE" HeaderText="เลขไมล์">
                                                                       <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Left" />
                                                                       <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Right" Width="40px" />
                                                                       </asp:BoundField>
                                                                   </Columns>
                                                               </asp:GridView>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="text-align:left; height: 18px;">&nbsp;</td>
                                                           <td style="height: 18px"></td>
                                                           <td style="text-align:right; height: 18px;"></td>
                                                       </tr>
                                                   </table>
                                               </asp:Panel>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td style="text-align:left; height: 18px;">&nbsp;</td>
                                           <td style="height: 18px"></td>
                                           <td style="text-align:right; height: 18px;"></td>
                                       </tr>
                                   </table>
                               </asp:View>
                           </asp:MultiView>

                     </div>
                    </div>
                    <%---------------------RIGHT MENU------------------------------%>
                    <div class="col-sm-2">
			            <div class="panel panel-default">
				            <div class="panel-heading">
					            <h1 class="panel-title"><span class="glyphicon glyphicon-random"> </span> แฟ้มเอกสารใบแจ้งซ่อม </h1>        
				            </div>
				            <div class="list-group">
                                <a class="list-group-item">
                                    <asp:Button ID="CmdAct1" runat="server" BackColor="Transparent" BorderStyle="None"  Text="1.แจ้งซ่อมใหม่   " OnClick="CmdAct1_Click"/><span class="w3-badge w3-green"><asp:Label ID="LblAct1Amt" runat="server" Text="-"></asp:Label></span></a>
                                <a class="list-group-item">
                                    <asp:Button ID="CmdAct2" runat="server" BackColor="Transparent" BorderStyle="None"  Text="2.ขอรายละเอียดเพิ่มเติม " OnClick="CmdAct2_Click"/><span class="w3-badge w3-red"><asp:Label ID="LblAct2Amt" runat="server" Text="-"></asp:Label></span></a>
                                <a class="list-group-item">
                                    <asp:Button ID="CmdAct3" runat="server" BackColor="Transparent" BorderStyle="None"  Text="3.อยู่ระหว่างการซ่อม" OnClick="CmdAct3_Click"/><span class="w3-badge w3-red"><asp:Label ID="LblAct3Amt" runat="server" Text="-"></asp:Label></span></a>
                                <a class="list-group-item">
                                    <asp:Button ID="CmdAct4" runat="server" BackColor="Transparent" BorderStyle="None"  Text="4.ปิดงานซ่อมเรียบร้อยแล้ว " OnClick="CmdAct4_Click" /></a>
                                <a class="list-group-item">
                                    <asp:Button ID="CmdGarage" runat="server" BackColor="Transparent" BorderStyle="None"  Text="A.จัดการข้อมูลอู่ซ่อม " OnClick="CmdGarage_Click"  /></a>
                                <a class="list-group-item">
                                    <asp:Button ID="CmdVehicle" runat="server" BackColor="Transparent" BorderStyle="None"  Text="B.จัดการข้อมูลรถ " OnClick="CmdVehicle_Click"  /></a>
                               <a class="list-group-item">
                                    <asp:Button ID="CmdHistry" runat="server" BackColor="Transparent" BorderStyle="None"  Text="C.ประวัติการซ่อม " OnClick="CmdHistry_Click"   /></a>
				            </div>
			            </div>
                    </div>     
                    <%----------------------------------------------%>
                        <asp:Button ID="CmdOpenX" runat="server"  OnClick="CmdOpenX_Click" BorderStyle="None" BorderColor="White" Enabled="False" BackColor="White" />
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="CmdOpenX" PopupControlID="PanelHistryCollectionModal" CancelControlID="CmdClosePopup" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
		            <asp:Panel ID="PanelHistryCollectionModal" runat="server" BorderStyle="None" Width="80%" BackColor="Silver">
                        <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title"><strong>รายการ : ประวัติงานซ่อม</strong></h4>
                                </div>
                                <div class="panel-body" style="background-color:#FFFFFF"> 
                                    <asp:Panel ID="Panel2" runat="server" Height="650px" ScrollBars="Vertical" Width="100%" BackColor="#FFFFFF">

                                        <table class="w3-table w3-border">
                                            <tr style="background-color: #F0F0F0">
                                              <td style="text-align:left;">บริษัท ไทยพาร์เซิล จำกัด (มหาชน)</td>
                                              <td></td>
                                              <td style="text-align:right;" >    </td>
                            
                                            </tr>
                                            <tr>
                                              <td style="text-align:left;">วันที่แจ้งซ่อม :<asp:TextBox ID="TxtOrderDateR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Text="-" type="text" Width="100px" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox>
                                                </td>
                                              <td></td>
                                              <td style="text-align:right;" >เลขที่เอกสาร :<asp:TextBox ID="TxtOrderNoR"  class="w3-border-bottom" type="text"  runat="server"  BorderStyle="None" Text="-" Width="140px" Font-Size="Small" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                            
                                            </tr>
                                          </table>
                                          <table class="w3-table w3-border">
                                                  <tr>
                                                  <td style="text-align:left; font-size: small; ">รหัสรถยนต์<br><asp:TextBox ID="TxtVehCodeR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                                                  <td style="text-align:left; font-size: small;">ทะเบียน<br><asp:TextBox ID="TxtVehLicenseR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox>
                                                      <br>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; ">ยี่ห้อ<br><asp:TextBox ID="TxtVehBrandR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox>
                                                      <br></td>
                                                  <td style="text-align:left; font-size: small; ">รุ่นรถ<br><asp:TextBox ID="TxtVehModelR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; ">
                                                      &nbsp;</td>
                                                    <td style="text-align:left; font-size: small; "></td>
                                                    <td style="text-align:right; height: 25px;">
                                                        </td>
                                                </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">เลขไมล์ <br><asp:TextBox ID="TxtVehMiledgeR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" style="text-align:right;" Text="0.00" type="text" ForeColor="#0000CC"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">ประเภทรถ<br><asp:TextBox ID="TxtVehTypeR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">อายุรถ<br><asp:TextBox ID="TxtVehAgeR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" style="text-align:right;" Text="0" type="text" ForeColor="#0000CC"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">เชื่อเพลิง<br><asp:TextBox ID="TxtVehFuelR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="text-align:left; font-size: small; "></td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          &nbsp;</td>
                                                  </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">บริษัท/อู่ <br>
                                                         <asp:TextBox ID="TxtGarageNameR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; " colspan="2">ที่อยู่<br><asp:TextBox ID="TxtGarageAddrR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" Width="90%" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; ">ติดต่อ<br><asp:TextBox ID="TxtGarageContactR" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text"  ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          &nbsp;</td>
                                                  </tr>
                                         </table>
                                         <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td>รายการซ่อม :</td>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:right;vertical-align: top;" colspan="3">
                                                           <asp:GridView ID="GrdRepairDescR" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" OnSelectedIndexChanged="GrdRepairDesc_SelectedIndexChanged" Width="100%">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ" Visible="False">
                                                                   <HeaderStyle Width="20px" />
                                                                   <ItemStyle Font-Size="Small" />
                                                                   </asp:ButtonField>
                                                                   <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Width="35px" />
                                                                       <ItemStyle HorizontalAlign="Center" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" Visible="False">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="20px" />
                                                                   <ItemStyle HorizontalAlign="Right" Width="25px" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TxtDescription4" runat="server" BorderStyle="None" Text='<%# Bind("MnDesc") %>' Width="100%" ReadOnly="True"></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>&nbsp;</td>
                                                       <td style="text-align:right;">
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>

                                             <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td style="width:100px;">ระบบยาง :</td>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:left;vertical-align: top;" colspan="3">
                                                           <asp:ImageMap ID="ImageMap3" runat="server" HotSpotMode="PostBack" ImageUrl="~/App_Images/messageImage_1620980590191.jpg">
                                                           </asp:ImageMap>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="height: 6px; color: #C0C0C0;" colspan="2"><small>**Click เลือกที่ตำแหน่งยางเพื่อเพิ่มรายการ</small></td>
                                                       <td style="height: 6px"></td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="2">
                                                           <asp:GridView ID="GrdWheelPosR" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" Width="100%">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ" Visible="False">
                                                                   <HeaderStyle Width="25px" />
                                                                   <ItemStyle Font-Size="Small" VerticalAlign="Top" />
                                                                   </asp:ButtonField>
                                                                   <%--      <asp:BoundField DataField="IDx" HeaderText="ลำดับ">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="25px" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                                                   </asp:BoundField>--%>
                                                                   <asp:TemplateField HeaderText="ลำดับ">
                                                                       <ItemTemplate>
                                                                           <%# Container.DataItemIndex + 1 %>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" />
                                                                       <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="W_POS" HeaderText="ตำแหน่ง">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="30px" />
                                                                   <ItemStyle Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <table style="width:100%;">
                                                                               <tr>
                                                                                   <td style="width: 150px;text-align:right;">เหตุผลที่แจ้งซ่อม :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtWRepairReason0" runat="server" BorderStyle="None" class="w3-border-bottom" ForeColor="Black" Height="19px" ReadOnly="True" Text='<%# Bind("MnRemark") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">บริเวณความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageArea5" runat="server" Checked='<%# Bind("DamageArea1") %>' Enabled="False" Font-Bold="False" Font-Underline="False" Text="[หน้ายาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea6" runat="server" Checked='<%# Bind("DamageArea2") %>' Enabled="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Text="[ไหล่ยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea7" runat="server" Checked='<%# Bind("DamageArea3") %>' Enabled="False" Font-Bold="True" Font-Italic="False" Text="[ขอบยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea8" runat="server" Checked='<%# Bind("DamageArea4") %>' Font-Bold="False" Text="[แก้มยาง]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #CCCCCC; text-align:right;">ซีเรียล:</td>
                                                                                   <td style="border: 1px solid #CCCCCC">
                                                                                       <asp:TextBox ID="TxtSN0" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" ReadOnly="True" Text='<%# Bind("Serial") %>' type="text" Width="150px"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">อื่นๆ :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtDamageAreaOther0" runat="server" BorderStyle="None" class="w3-border-bottom" ForeColor="Black" Height="19px" ReadOnly="True" Text='<%# Bind("DamageAreaAno") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td style="border: 1px solid #CCCCCC; text-align:right;">มิลยาง :</td>
                                                                                   <td style="border: 1px solid #CCCCCC">
                                                                                       <asp:TextBox ID="TxtRubberMil0" runat="server" MaxLength="20" ReadOnly="True" Text='<%# Bind("RMile") %>' Width="50px"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">ลักษณะความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageType5" runat="server" Checked='<%# Bind("DamageType1") %>' Enabled="False" Font-Bold="False" Text="[รัั่ว]" />
                                                                                       <asp:CheckBox ID="ChkDamageType6" runat="server" Checked='<%# Bind("DamageType2") %>' Enabled="False" Font-Bold="False" Text="[หมดดอก]" />
                                                                                       <asp:CheckBox ID="ChkDamageType7" runat="server" Checked='<%# Bind("DamageType3") %>' Enabled="False" Font-Bold="False" Text="[แตก/ฉีก]" />
                                                                                       <asp:CheckBox ID="ChkDamageType8" runat="server" Checked='<%# Bind("DamageType4") %>' Enabled="False" Font-Bold="False" Text="[บวม]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #CCCCCC; text-align:right;">ขอบยาง :</td>
                                                                                   <td style="border: 1px solid #CCCCCC">
                                                                                       <asp:TextBox ID="TxtWhellSize0" runat="server" MaxLength="20" ReadOnly="True" Text='<%# Bind("WhlSize") %>' Width="50px"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">อื่นๆ :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtDamageTypeAno0" runat="server" BorderStyle="None" class="w3-border-bottom" ForeColor="Black" Height="19px" ReadOnly="True" Text='<%# Bind("DamageTypeAno") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                           </table>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" Visible="False">
                                                                   <HeaderStyle Width="25px" />
                                                                   </asp:BoundField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                             </table>
                                      <br />

                                    <table style="width:100%;" class="w3-table w3-border";>
                                                               <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">ประวัติการซ่อม (ส่วนกลาง)</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">&nbsp;</td>
                                                               </tr> 
                                                                  <tr style="background-color: #F0F0F0">
                                                                      <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายการซ่อม </td>
                                                                      <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                                  </tr>
                                                    
                                                               <tr>
                                                                        <td colspan="3">
                                                                            <asp:GridView ID="GridViewX1" runat="server" AutoGenerateColumns="False" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="MNT_ORD_LINENO" HeaderText="ลำดับ" >
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                        <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="30px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_LINENO_DESC" HeaderText="รายละเอียด" DataFormatString="{0:#,##0.00}" >
                                                                                    <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_LINENO_PRICE" HeaderText="ราคาซ่อม" DataFormatString="{0:#,##0.00}" >
                                                                                    <HeaderStyle Font-Size="Small" Font-Bold="False" HorizontalAlign="Right" />
                                                                                    <ItemStyle Font-Size="Small" Width="100px" HorizontalAlign="Right" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MNT_LINENO_SERVICER" HeaderText="ผู้บริการ" >
                                                                                    <HeaderStyle Font-Size="Small" Font-Bold="False" />
                                                                                    <ItemStyle Font-Size="Small" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                               </tr>
                                                               <tr>
                                                                   <td>&nbsp;</td>
                                                                   <td>ค่าซ่อมรวม :<asp:TextBox ID="TxtMntTotalPrice" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="Black" Height="19px" OnTextChanged="TxtTotalPrice_TextChanged" ReadOnly="True" style="text-align:right;" Text="0.00" type="text"></asp:TextBox>
                                                                       &nbsp;บาท&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                       </td>
                                                                   <td style="text-align:right; ">
                                                                       &nbsp;</td>
                                                                </tr>
                                                                  <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายการเบิกอะไหล่ :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td colspan="3">
                                                                          <asp:GridView ID="GridViewX2" runat="server" AutoGenerateColumns="False" Width="100%">
                                                                              <Columns>
                                                                                  <asp:BoundField DataField="MNT_ORD_LINENO" HeaderText="ลำดับ" >
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" Width="30px" />
                                                                                  <ItemStyle Font-Size="Small" />
                                                                                  </asp:BoundField>
                                                                                  <asp:BoundField DataField="MNT_LINENO_DESC" HeaderText="รายละเอียด/ชื่ออะไหล่" >
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                  <ItemStyle Font-Size="Small" />
                                                                                  </asp:BoundField>
                                                                                  <asp:BoundField DataField="MNT_LINENO_AMT" HeaderText="จำนวน" >
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Right" Width="100px" />
                                                                                  <ItemStyle Font-Size="Small" />
                                                                                  </asp:BoundField>
                                                                              </Columns>
                                                                          </asp:GridView>
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td>&nbsp;</td>
                                                                      <td>&nbsp;</td>
                                                                      <td style="text-align:right;">
                                                                          &nbsp;</td>
                                                                  </tr>
                                                                   <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายละเอียดงานซ่อม / ความเห็นช่าง :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                                  </tr>

                                                                  <tr>
                                                                      <td colspan="3">
                                                                          <asp:GridView ID="GridViewX3" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdRepairDetail_SelectedIndexChanged" Width="100%">
                                                                              <Columns>
                                                                                  <asp:BoundField DataField="MNT_ORD_LINENO" HeaderText="ลำดับ" >
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" Width="30px" />
                                                                                  <ItemStyle Font-Size="Small" HorizontalAlign="Right" />
                                                                                  </asp:BoundField>
                                                                                  <asp:BoundField DataField="MNT_LINENO_DESC" HeaderText="รายละเอียดงานซ่อม" >
                                                                                  <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                                  <ItemStyle Font-Size="Small" />
                                                                                  </asp:BoundField>
                                                                              </Columns>
                                                                          </asp:GridView>
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td>&nbsp;</td>
                                                                      <td>&nbsp;</td>
                                                                      <td style="text-align:right;">
                                                                          
                                                                      </td>
                                                               </tr>
                                                          </table>
                                    <br />
                                    </asp:Panel>
                                </div>
                                
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="background-color: #C0C0C0; ">&nbsp;</td>
                                        <td style="background-color: #C0C0C0; ">&nbsp;</td>
                                        <td style="text-align: right; background-color: #C0C0C0; margin-left: 120px;"><asp:Button ID="CmdClosePopup" runat="server" ForeColor="Black" OnClick="CmdSave_Click" Text="ปิด" Width="104px" /></td>

                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
		     </div>
		</div>
     </div>






</asp:Content>
