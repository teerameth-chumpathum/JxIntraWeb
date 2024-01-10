<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CR_MA_Req.aspx.cs" Inherits="JxIntraWeb.App_Pages.CR_MA_Req" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
      	<div class="panel panel-default">
			    <div class="panel-heading">
					<h4 class="panel-title">
						<strong>Infomation Technology Dept.</strong>                Maintainance Management System - แจ้งซ่อม
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
                                            <asp:ImageButton ID="imgBtn0" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn0_Click" />
                                        </td>
                                    </tr>
                                    <tr >
                                        <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;1.รายการเอกสารใบแจ้งซ่อม :<font color="#000080">เอกสารใหม่&nbsp;</font>
                                            </td>
                                        <td  style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color:black;">กรองข้อมูล เลขรถ|ทะเบียน|ใบแจ้งซ่อม |ขอซ่อม :<asp:TextBox ID="TxtKeyS1" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="" type="text"></asp:TextBox>
                                            <asp:ImageButton ID="ImbS1" runat="server" ImageUrl="~/App_Images/page_white_magnify.png" OnClick="ImbS1_Click" />
                                            <font color="#990000">** ยังไม่ส่งขออนุมัติ &nbsp;</font></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="GrdRepairOrderAct0" runat="server" AutoGenerateColumns="False" Width="100%" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct0_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
                                                    </asp:ButtonField>
                                                    <asp:TemplateField HeaderText="ลำดับ">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                            <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                        <ItemStyle Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="MNT_ORD_DATE" HeaderText=" วันที่" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="85px" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MNT_OWN_SITE" HeaderText="ศูนย์/สาขา" Visible="False">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" Width="85px" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="90px" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Left" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="135px" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="100px" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" Width="80px" VerticalAlign="Top" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="90px" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                    <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                    <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="90px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                    <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="REQ_INFO" HeaderText="ขอซ่อม">
                                                    <HeaderStyle BackColor="#F0F0F0" BorderWidth="1px" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Left" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                    </asp:BoundField>
                                                    <%--------------------------NEW------------------------------%>
                                                    <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="ทดสอบ">
                                                                                 
                                                                                 </asp:BoundField>
                                                    <%----------------------------NEW----------------------------%>
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
                                                                  <td style="height: 18px; width: 120px;"></td>
                                                                  <td style="text-align:right; height: 18px; font-size: x-small; color: #008080;">** CR : Corrective PM: Preventive&nbsp;&nbsp;&nbsp; </td>
                                                              </tr>
                                                      </table>
                               </asp:View>
                               <asp:View ID="View1x" runat="server">
                                  <table style="width:100%;">
                                      <tr>
                                        <td colspan="12" style="text-align:right">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                            <asp:ImageButton ID="imgBtn1" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn1_Click" />
                                        </td>
                                    </tr>

                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;2.รายการเอกสารใบแจ้งซ่อม :<font color="#000080">เอกสารรอพิจารณาอนุมัติ&nbsp;</font>  
                                                                      </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color:black;">
                                                                      กรองข้อมูล เลขรถ|ทะเบียน|ใบแจ้งซ่อม|ขอซ่อม :<asp:TextBox ID="TxtKeyS2" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="" type="text"></asp:TextBox>
                                                                      <asp:ImageButton ID="ImbS2" runat="server" ImageUrl="~/App_Images/page_white_magnify.png" OnClick="ImbS2_Click"  />
                                                                      <font color="#990000">** รอพิจารณาอนุมัติ &nbsp;</font> </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdRepairOrderAct1" runat="server" AutoGenerateColumns="False" Width="100%" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct1_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" />
                                                                              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
                                                                              </asp:ButtonField>
                                                                              <asp:TemplateField HeaderText="ลำดับ">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" />
                                                                              </asp:TemplateField>
                                                                              <asp:BoundField DataField="MNT_ORD_DATE" HeaderText=" วันที่" DataFormatString="{0:dd/MM/yyyy}">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_SITE" HeaderText="ศูนย์/สาขา" Visible="False">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="90px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Left" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="135px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="100px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Center" Width="85px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="REQ_INFO" HeaderText="ขอซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" />
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                    <%--------------------------NEW------------------------------%>
                                                    <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="ทดสอบ">
                                                                                 
                                                                                 </asp:BoundField>
                                                    <%----------------------------NEW----------------------------%>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                             <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                              </asp:BoundField>                                                                                                                                                   <asp:BoundField DataField="ORD_VEH_MILEDGE" DataFormatString="{0:N2}" HeaderText="เลขไมล์">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" />
                                                                              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" BorderColor="#CCCCCC" />
                                                                              </asp:BoundField>
                                                                          </Columns>
                                                                      </asp:GridView>
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                  <td style="text-align:left; height: 18px;">&nbsp;</td>
                                                                  <td style="height: 18px; width: 136px;"></td>
                                                                  <td style="text-align:right; height: 18px; font-size: x-small; color: #008080;">** CR : Corrective PM: Preventive&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                              </tr>
                                                      </table>  
                               </asp:View>
                               <asp:View ID="View2x" runat="server">
                                  <table style="width:100%;">
                                      <tr>
                                        <td colspan="12" style="text-align:right">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                            <asp:ImageButton ID="imgBtn2" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn2_Click" />
                                        </td>
                                    </tr>
                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;3.รายการเอกสารใบแจ้งซ่อม : <font color="#000080">รายการขอรายละเอียดเพิ่มเติม&nbsp;</font>  
                                                                      </td>
                                                                  <td style="border-left: 1px none #CCCCCC; border-right: 1px solid #CCCCCC; border-top: 1px solid #CCCCCC; border-bottom: 1px none #CCCCCC; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: 300; color: #990000;">**&nbsp;&nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdRepairOrderAct2" runat="server" AutoGenerateColumns="False" Width="100%" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct2_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" />
                                                                              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
                                                                              </asp:ButtonField>
                                                                              <asp:TemplateField HeaderText="ลำดับ">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" />
                                                                              </asp:TemplateField>
                                                                              <asp:BoundField DataField="MNT_ORD_DATE" HeaderText=" วันที่" DataFormatString="{0:dd/MM/yyyy}">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_SITE" HeaderText="ศูนย์/สาขา" Visible="False">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Left" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="135px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="REQ_INFO" HeaderText="ขอซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" />
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                    <%--------------------------NEW------------------------------%>
                                                    <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="ทดสอบ">
                                                                                 
                                                                                 </asp:BoundField>
                                                    <%----------------------------NEW----------------------------%>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                             <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Top" />
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
                                                                  <td style="text-align:left; height: 18px;width:50%"></td>
                                                                  <td style="text-align:right; height: 18px; font-size: x-small; color: #008080;" colspan="2">** CR : Corrective PM: Preventive&nbsp;</td>
                                                              </tr>
                                                      </table>
                               </asp:View>
                               <asp:View ID="View3x" runat="server">
                                  <table style="width:100%;">
                                      <tr>
                                        <td colspan="12" style="text-align:right">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                            <asp:ImageButton ID="imgBtn3" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn3_Click" />
                                        </td>
                                    </tr>
                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;4.รายการเอกสารใบแจ้งซ่อม : <font color="#000080">รายการไม่อนุมัติซ่อม&nbsp;</font>
                                                                      </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">&nbsp;**&nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdRepairOrderAct3" runat="server" AutoGenerateColumns="False" Width="100%" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct3_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" />
                                                                              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                              </asp:ButtonField>
                                                                              <asp:TemplateField HeaderText="ลำดับ">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" />
                                                                              </asp:TemplateField>
                                                                              <asp:BoundField DataField="MNT_ORD_DATE" HeaderText=" วันที่" DataFormatString="{0:dd/MM/yyyy}">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_SITE" HeaderText="ศูนย์/สาขา" Visible="False">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Left" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="135px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" Height="18px" Width="100px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                                                                                                            <asp:BoundField DataField="REQ_INFO" HeaderText="ขอซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" />
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                             <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Top" />
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
                                                                  <td style="text-align:left; height: 18px;"></td>
                                                                  <td style="height: 18px; text-align: right; font-size: x-small; color: #008080;" colspan="2">** CR : Corrective PM: Preventive&nbsp;</td>
                                                              </tr>
                                                      </table>
                               </asp:View>
                               <asp:View ID="View4x" runat="server">
                                  <table style="width:100%;">
                                      <tr>
                                        <td colspan="12" style="text-align:right">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                            <asp:ImageButton ID="imgBtn4" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn4_Click" />
                                        </td>
                                    </tr>

                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;5.รายการเอกสารใบแจ้งซ่อม : <font color="#000080">รายการอยู่ระหว่างซ่อม &nbsp;</font>
                                                                      </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">&nbsp;**&nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdRepairOrderAct4" runat="server" AutoGenerateColumns="False" Width="100%" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct4_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" />
                                                                              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                              </asp:ButtonField>
                                                                              <asp:TemplateField HeaderText="ลำดับ">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                        <HeaderStyle Font-Bold="False" Font-Size="Small" Width="35px" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                                    <ItemStyle Font-Size="Small" HorizontalAlign="Right" VerticalAlign="Top" />
                                                                              </asp:TemplateField>
                                                                              <asp:BoundField DataField="MNT_ORD_DATE" HeaderText=" วันที่" DataFormatString="{0:dd/MM/yyyy}">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_SITE" HeaderText="ศูนย์/สาขา" Visible="False">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Left" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="135px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" BorderColor="#CCCCCC" BorderWidth="1px" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="GARAGE_CONTACT" HeaderText="ติดต่อ(อู่)" Visible="False">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                              <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                                                                                                            <asp:BoundField DataField="REQ_INFO" HeaderText="ขอซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" />
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                    <%--------------------------NEW------------------------------%>
                                                    <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="ทดสอบ">
                                                                                 
                                                                                 </asp:BoundField>
                                                    <%----------------------------NEW----------------------------%>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                             <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Top" />
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
                                                                  <td style="text-align:left; height: 18px;"></td>
                                                                  <td style="height: 18px; text-align: right; font-size: x-small; color: #008080;" colspan="2">** CR : Corrective PM: Preventive&nbsp;</td>
                                                              </tr>
                                                      </table>
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
                                              <td style="text-align:left;">วันที่แจ้งซ่อม :<asp:TextBox ID="TxtOrderDate" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Text="-" type="text" Width="100px" MaxLength="10" OnTextChanged="TxtOrderDate_TextChanged"></asp:TextBox>
                                                  <ajaxToolkit:CalendarExtender ID="TxtOrderDate_CalendarExtender" runat="server" BehaviorID="TxtOrderDate_CalendarExtender" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate3" TargetControlID="TxtOrderDate" />
                                                  <asp:ImageButton ID="imgOrderDate3" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" OnClick="imgOrderDate3_Click" ToolTip="เลือกวันที่" Width="16px" />
                                                </td>
                                              <td></td>
                                              <td style="text-align:right;" >
                                                  <asp:RadioButton ID="RdoCR" runat="server" GroupName="string" Text="งานซ่อมทั่ว (CR)" Font-Bold="False" />
                                                  <asp:RadioButton ID="RdoPM" runat="server" GroupName="string" Text="PM" Font-Bold="False"  />
                                                  &nbsp; เลขที่เอกสาร :<asp:TextBox ID="TxtOrderNo"  class="w3-border-bottom" type="text"  runat="server"  BorderStyle="None" Text="-" Width="140px" Font-Size="Small" ReadOnly="True" ForeColor="#0000CC"></asp:TextBox></td>
                            
                                            </tr>
                                          </table>
                                        <table class="w3-table w3-border">
                                                  <tr>
                                                  <td style="text-align:left; font-size: small; ">รหัสรถยนต์<br><asp:TextBox ID="TxtVehCode" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox></td>
                                                  <td style="text-align:left; font-size: small;">ทะเบียน<br><asp:TextBox ID="TxtVehLicense" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      <br>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; ">ยี่ห้อ<br><asp:TextBox ID="TxtVehBrand" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      <br></td>
                                                  <td style="text-align:left; font-size: small; ">รุ่นรถ<br><asp:TextBox ID="TxtVehModel" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; width: 168px;">
                                                      <asp:HiddenField ID="HideVehID" runat="server" />
                                                      </td>
                                                    <td style="text-align:left; font-size: small; width: 97px;">&nbsp;</td>
                                                    <td style="text-align:right; height: 25px;">
                                                        </td>
                                                </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">เลขไมล์ <br><asp:TextBox ID="TxtVehMiledge" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" style="text-align:right;" Text="0.00" type="text"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">ประเภทรถ<br><asp:TextBox ID="TxtVehType" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">อายุรถ<br><asp:TextBox ID="TxtVehAge" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" style="text-align:right;" Text="0" type="text"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">เชื่อเพลิง<br><asp:TextBox ID="TxtVehFuel" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; width: 168px;">
                                                          <asp:HiddenField ID="HideGarageID" runat="server" />
                                                      </td>
                                                      <td style="text-align:left; font-size: small; width: 97px;"></td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          <asp:Button ID="CmdOpenVehCollection" runat="server" Text="เลือกรถ ..." Width="100px" OnClick="CmdOpenVehCollection_Click" />
                                                          <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="CmdCloseVehCollection" DropShadow="false" PopupControlID="PanelVehCollectionModal" TargetControlID="CmdOpenVehCollection">
                                                          </ajaxToolkit:ModalPopupExtender>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">บริษัท/อู่ <br>
                                                         <asp:TextBox ID="TxtGarageName" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; " colspan="2">ที่อยู่<br><asp:TextBox ID="TxtGarageAddr" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" Width="90%" ReadOnly="True"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; ">ติดต่อ<br><asp:TextBox ID="TxtGarageContact" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text"  ReadOnly="True"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; width: 168px;">
                                                          <asp:HiddenField ID="HideModeOperate" runat="server" />
                                                      </td>
                                                      <td style="text-align:left; font-size: small; width: 97px;">
                                                          <asp:HiddenField ID="HideRecRefNo" runat="server" />
                                                      </td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          <asp:Button ID="CmdOpenGarageCollection" runat="server" OnClick="CmdOpenGarageCollection_Click" Text="เลือกอู่..." Width="100px" />
                                                          <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" CancelControlID="CmdCloseGarageCollection" DropShadow="false" PopupControlID="PanelGarageCollectionModal" TargetControlID="CmdOpenGarageCollection">
                                                          </ajaxToolkit:ModalPopupExtender>
                                                      </td>
                                                  </tr>
                                         </table>
                                        <table style="width:100%;" class="w3-table w3-border";>
                                                   <tr style="background-color: #F0F0F0">
                                                       <td>รายการขอซ่อม :</td>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td style="text-align:right;vertical-align: top;" colspan="3">
                                                           <asp:GridView ID="GrdRepairDesc" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GrdRepairDesc_SelectedIndexChanged" Width="100%" DataKeyNames="IDx">
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
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx" >
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="2px" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Right" Width="2px" BackColor="WhiteSmoke" ForeColor="WhiteSmoke" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TxtDescription" runat="server" BorderStyle="None" Width="100%" Text='<%# Bind("MnDesc") %>'></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Font-Size="Small" />
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
                                                           <asp:Button ID="CmdAddDescLine" runat="server" Text="เพิ่มรายการ " Width="100px" OnClick="CmdAddDescLine_Click" />
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
                                                           <asp:GridView ID="GrdOrderImage" runat="server" AutoGenerateColumns="False" DataKeyNames="Image_ILx" Width="100%" OnSelectedIndexChanged="GrdOrderImage_SelectedIndexChanged">
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
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="Image_ILx" HeaderText="เลขระเบียน">
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
                                                                           <br />
                                                                           <asp:Image ID="Image2" runat="server" Height="202px" ImageUrl='<%# Bind("ImageURL") %>' Width="366px" />
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                 </tr>
                                                   <tr>
                                                       <td style="width: 388px">
                                                           &nbsp;</td>
                                                       <td style="width: 895px">&nbsp;</td>
                                                       <td>
                                                           <asp:Button ID="CmdAddImage" runat="server" OnClick="CmdAddImage_Click" Text="เพิ่มรูป" Width="100px" />
                                                       </td>
                                                   </tr>
                                                  <tr>
                                                       <td colspan="3">
                                                           <asp:Panel ID="PanelGetImage" runat="server" Visible="False" BackColor="#FFFF80">
                                                               <table style="width:100%;">
                                                                   <tr>
                                                                       <td style="width: 163px">ไฟล์รูปภาพ :</td>
                                                                       <td>
                                                                           <asp:FileUpload ID="FileSelector" runat="server" Width="441px" />
                                                                       </td>
                                                                       <td>&nbsp;</td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td style="width: 163px">รายละเอียด :</td>
                                                                       <td>
                                                                           <asp:TextBox ID="TxtImageNote" runat="server" Height="22px" MaxLength="300" Width="329px"></asp:TextBox>
                                                                       </td>
                                                                       <td>&nbsp;</td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td style="width: 163px">
                                                                           <asp:Button ID="CmdUpLoad" runat="server" OnClick="CmdUpLoad_Click" Text="บันทึกไฟล์รูป" />
                                                                           <asp:Button ID="CmdCloseImageSelector" runat="server" OnClick="CmdCloseImageSelector_Click" Text="ปิด" />
                                                                       </td>
                                                                       <td>
                                                                           &nbsp;</td>
                                                                       <td>&nbsp;</td>
                                                                   </tr>
                                                               </table>
                                                               &nbsp;<br />
                                                               <asp:Label ID="lblMessage" runat="server" />
                                                               <br />
                                                           </asp:Panel>
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
                                                           <asp:ImageMap ID="ImageMap1" runat="server" HotSpotMode="PostBack" ImageUrl="~/App_Images/messageImage_1620980590191.jpg" OnClick="ImageMap1_Click">
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="30" PostBackValue="2" Right="85" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" Left="30" PostBackValue="1" Right="85" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="125" PostBackValue="4" Right="180" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="125" PostBackValue="3" Right="180" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="220" PostBackValue="2" Right="290" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="220" PostBackValue="1" Right="290" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="327" PostBackValue="6" Right="400" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="327" PostBackValue="5" Right="400" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="327" PostBackValue="4" Right="400" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="327" PostBackValue="3" Right="400" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="410" PostBackValue="10" Right="482" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="410" PostBackValue="9" Right="482" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="410" PostBackValue="8" Right="482" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="410" PostBackValue="7" Right="482" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" HotSpotMode="PostBack" Left="625" PostBackValue="14" Right="697" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" HotSpotMode="PostBack" Left="625" PostBackValue="13" Right="697" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="625" PostBackValue="12" Right="697" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="625" PostBackValue="11" Right="697" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="25" Left="715" PostBackValue="18" Right="795" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="75" Left="715" PostBackValue="17" Right="795" Top="50" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="715" PostBackValue="16" Right="795" Top="110" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="715" PostBackValue="15" Right="795" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="175" HotSpotMode="PostBack" Left="45" PostBackValue="02" Right="145" Top="145" />
                                                               <asp:RectangleHotSpot Bottom="165" HotSpotMode="PostBack" Left="510" PostBackValue="04" Right="588" Top="140" />
                                                               <asp:RectangleHotSpot Bottom="135" HotSpotMode="PostBack" Left="510" PostBackValue="03" Right="588" Top="110" />
                                                           </asp:ImageMap>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="height: 6px; color: #C0C0C0;" colspan="2"><small>**Click เลือกที่ตำแหน่งยางเพื่อเพิ่มรายการ</small></td>
                                                       <td style="height: 6px"></td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="2">
                                                           <asp:GridView ID="GrdWheelPos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" Width="100%" DataKeyNames="IDx">
                                                               <Columns>
                                                                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="ลบ">
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
                                                                       <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="W_POS" HeaderText="ตำแหน่ง">
                                                                   <HeaderStyle Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="30px" />
                                                                   <ItemStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                   </asp:BoundField>
                                                                   <asp:TemplateField HeaderText="รายละเอียด">
                                                                       <ItemTemplate>
                                                                           <table style="width:100%;">
                                                                               <tr>
                                                                                   <td style="width: 150px;text-align:right;">เหตุผลที่แจ้งซ่อม :</td>
                                                                                   <td>
                                                                                       <asp:TextBox ID="TxtWRepairReason" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("MnRemark") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">บริเวณความเสียหาย :</td>
                                                                                   <td>
                                                                                       <asp:CheckBox ID="ChkDamageArea1" runat="server" Checked='<%# Bind("DamageArea1") %>' Font-Bold="False" Font-Underline="False" Text="[หน้ายาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea2" runat="server" Checked='<%# Bind("DamageArea2") %>' Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Text="[ไหล่ยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea3" runat="server" Checked='<%# Bind("DamageArea3") %>' Font-Bold="False" Font-Italic="False" Text="[ขอบยาง]" />
                                                                                       <asp:CheckBox ID="ChkDamageArea4" runat="server" Checked='<%# Bind("DamageArea4") %>' Font-Bold="False" Font-Italic="False" Text="[แก้มยาง]" />
                                                                                   </td>
                                                                                   <td style="border: 1px solid #C0C0C0;text-align:right;">ซีเรียล:</td>
                                                                                   <td style="border: 1px solid #C0C0C0" colspan="2">
                                                                                       <asp:TextBox ID="TxtSN" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text='<%# Bind("Serial") %>' type="text" Width="150px"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 150px ;text-align:right;">อื่นๆ :</td>
                                                                                   <td><asp:TextBox ID="TxtDamageAreaOther" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("DamageAreaAno") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td style="border: 1px solid #C0C0C0; text-align:right;">มิลยาง :</td>
                                                                                   <td style="border: 1px solid #C0C0C0" colspan="2">
                                                                                       <asp:TextBox ID="TxtRubberMil" runat="server" Width="50px" MaxLength="20" Text='<%# Bind("RMile") %>'></asp:TextBox>
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
                                                                                   <td style="border: 1px solid #C0C0C0; text-align:right;">ขอบยาง :</td>
                                                                                   <td style="border: 1px solid #C0C0C0" colspan="2">
                                                                                       <asp:TextBox ID="TxtWhellSize" runat="server" Width="50px" MaxLength="20" Text='<%# Bind("WhlSize") %>'></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                               <tr>
                                                                                   <td style="width: 145px;text-align:right;">อื่นๆ :</td>
                                                                                   <td><asp:TextBox ID="TxtDamageTypeAno" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text='<%# Bind("DamageTypeAno") %>' type="text" Width="100%"></asp:TextBox>
                                                                                   </td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                                   <td>&nbsp;</td>
                                                                               </tr>
                                                                           </table>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                                   <asp:BoundField DataField="IDx">
                                                                   <HeaderStyle Width="25px" />
                                                                   <ItemStyle Font-Size="XX-Small" HorizontalAlign="Right" VerticalAlign="Top" BackColor="WhiteSmoke" ForeColor="WhiteSmoke" />
                                                                   </asp:BoundField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                          <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">รายละเอียดงานซ่อม(ความเห็นช่าง) :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                                  </tr>
                                                          <tr>
                                                       <td colspan="2">
                                                                           <asp:GridView ID="GrdRepairDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" Width="100%" OnSelectedIndexChanged="GrdRepairDetail_SelectedIndexChanged">
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
                                                       <td>&nbsp;</td>
                                                   </tr>


                                            
                                            


                                                                     <tr>
                                                       <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; text-align: right">
                                                           <asp:Button ID="CmdDetail" runat="server" OnClick="CmdDetail_Click" Text="เพิ่มรายการ " Width="100px" />
                                                                         </td>
                                                       <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;">&nbsp;</td>
                                                   </tr>

                                            <%--------------------------------09-12-2023-New-----------------------------%>
                                            <tr style="background-color: #F0F0F0">
                                                                   <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">ประวัติการซ่อม :</td>
                                                                   <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0;">&nbsp;</td>
                                                                  </tr>
                                                          
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gridviewComment" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" OnSelectedIndexChanged="gridviewComment_SelectedIndexChanged">
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
                                                        <asp:TextBox ID="TxtMILEDGE_NOTE" runat="server" Text='<%# Bind("MILEDGE_NOTE") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Bold="False" Font-Size="Smaller" Width="80px" />
                                                    <ItemStyle Font-Size="Small" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ราคาซ่อม">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TxtPRICE_NOTE" runat="server" Text='<%# Bind("PRICE_NOTE") %>' Width="70px" style="text-align:right;" ></asp:TextBox>
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
                                            <%--------------------------------09-12-2023-New-----------------------------%>

                                                   <tr style="background-color: #F0F0F0">
                                                       <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0; ">รายการสั่งซื้ออะไหล่ :(ยังไม่เปิดใช้)</td>
                                                       <td style="border-top-style: solid; border-top-width: 1px; border-top-color: #C0C0C0; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0">&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="2" style="text-align: left">
                                                           <asp:GridView ID="GrdPartOrder" runat="server" AutoGenerateColumns="False" DataKeyNames="IDx" Width="100%" OnRowUpdating="GrdPartOrder_RowUpdating" Visible="False">
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
                                                                   <asp:TemplateField HeaderText="รายละเอียดอะไหล่">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TxtDescriptionDet0" runat="server" BorderStyle="None" ForeColor="Black" Text='<%# Bind("MnDesc") %>' Width="100%" OnTextChanged="TxtDescriptionDet0_TextChanged"></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Font-Size="Small" ForeColor="Black" />
                                                                   </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="ผู้จำหน่าย">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                   </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="จำนวน">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Width="100px" />
                                                                   </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="ราคา(บาท)">
                                                                       <ItemTemplate>
                                                                           <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                                       </ItemTemplate>
                                                                       <HeaderStyle Font-Bold="False" Font-Size="Small" />
                                                                       <ItemStyle Width="100px" />
                                                                   </asp:TemplateField>
                                                               </Columns>
                                                           </asp:GridView>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>






                                                   <tr>
                                                       <td colspan="2" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; text-align: right;">
                                                           <asp:Button ID="CmdAddDet1" runat="server"  Text="เพิ่มรายการ " Width="100px" Visible="False" />
                                                       </td>
                                                       <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;">&nbsp;</td>
                                                   </tr>
                                   

                                                   <tr>
                                                       <td colspan="2">พนักงานขับรถ&nbsp;&nbsp; :<asp:TextBox ID="TxtDrvName" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" MaxLength="150" Text="-" type="text"></asp:TextBox>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="2">เจ้าหน้าที่ สาขา :
                                                            <asp:TextBox ID="TxtSiteEmpName" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:TextBox ID="TxtMNHeadRem" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" ForeColor="#CC0000" Height="19px" ReadOnly="True" Text="-" type="text" Visible="False" Width="60%"></asp:TextBox>
                                                       </td>
                                                       <td>&nbsp;</td>
                                                   </tr>
                                               </table>
                                               <table style="width:100%;">
                                                        <tr style="background-color: #F0F0F0">
                                                           <td style="text-align:left;">
                                                               <asp:Button ID="CmdRollBackDoc" runat="server" Text="ดึงเอกสารกลับ" Width="110px" OnClick="CmdRollBackDoc_Click" /><asp:Button ID="CmdDeleteDoc" runat="server" Text="ลบเอกสาร" Width="110px" OnClick="CmdDeleteDoc_Click" />
                                                               <asp:Button ID="CmdPrint" runat="server" ForeColor="Black" Text="พิมพ์" Width="104px" OnClick="CmdPrint_Click" />
                                                           </td>
                                                           <td>&nbsp;</td>
                                                           <td style="text-align:right;">
                                                               <asp:Button ID="CmdSaveOrd" runat="server" OnClick="CmdSaveOrd_Click" Text="บันทึก" Width="60px" />&nbsp;<asp:Button ID="CmdReqApproveOrd" runat="server" Text="บันทึก - ส่งขออนุมัติซ่อม" Width="180px" OnClick="CmdReqApproveOrd_Click" />&nbsp;&nbsp;
                                                           </td>
                                                           </tr>
                                                                <tr>
                                                                       <td>&nbsp;</td>
                                                                       <td>&nbsp;</td>
                                                                       <td>&nbsp;</td>
                                                               </tr>
                                             </table>
                                                       
                                        <asp:Panel ID="PanelVehCollectionModal" runat="server" Height="400px" Width="60%" BorderStyle="None" ScrollBars="Auto" BackColor="#FFFF80">
        
                                                <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
      		                                    <div class="panel panel-default">
			                                        <div class="panel-heading">
					                                    <h4 class="panel-title">
						                                    <strong>รายการทรัพย์สิน หมวด : </strong> ยานพาหนะ
					                                    </h4>
				                                    </div>
                                                    <div class="panel-body">
                                                      <table style="width:100%;">
                                                              <tr>
                                                                  <td style="text-align:left;">&nbsp;ทะเบียน-เลขรถ :<asp:TextBox ID="TxtVehKeySearch" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="--" type="text"></asp:TextBox></td>
                                                                  <td>&nbsp;</td>
                                                                  <td style="text-align:right;">
                                                                      <asp:Button ID="CmdSearchAssetVeh" runat="server" OnClick="CmdSearchAssetVeh_Click" Text="ค้นหา" Width="70px" />
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                  <td colspan="3" style="height: 10px"></td>
                                                              </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdAssetVehSelector" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="GrdAssetVehSelector_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                              <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                                              </asp:ButtonField>
                                                                              <asp:BoundField DataField="VEH_ASSET_ID" HeaderText="รหัส (ID)">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="80px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="85px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_BRAND" HeaderText="ยี่ห้อ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_MODEL" HeaderText="รุ่น">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_FUEL_SPEC" HeaderText="เชื้อเพลิง">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="VEH_ST_USE_DTIME" DataFormatString="{0:yyyy}" HeaderText="ปีรถ">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" />
                                                                              <ItemStyle Font-Bold="False" Font-Size="Small" />
                                                                              </asp:BoundField>
                                                                          </Columns>
                                                                      </asp:GridView>
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                  <td colspan="3" style="height: 10px"></td>
                                                              </tr>
                                                              <tr>
                                                                  <td style="text-align:left;">&nbsp;</td>
                                                                  <td>&nbsp;</td>
                                                                  <td style="text-align:right;">&nbsp;<asp:Button ID="CmdCloseVehCollection" runat="server" Text="ปิด" Width="70px" /></td>
                                                              </tr>
                                                      </table>
		                                           </div>
		                                    </div>
                                             </div>
    </asp:Panel>
                                        <asp:Panel ID="PanelGarageCollectionModal" runat="server" Height="400px" Width="60%" BorderStyle="None" ScrollBars="Auto" BackColor="#FFFF80">
                                                <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
      		                                    <div class="panel panel-default">
			                                        <div class="panel-heading">
					                                    <h4 class="panel-title">
						                                    <strong>รายการ : </strong> อู่ซ่อม
					                                    </h4>
				                                    </div>
                                                    <div class="panel-body">
                                                      <table style="width:100%;">
                                                              <tr>
                                                                  <td style="text-align:left;">&nbsp;ชื่ออู่-เบอร์โทร :<asp:TextBox ID="TxtGarageKeySearch" runat="server" BorderStyle="None" class="w3-border-bottom" Height="19px" Text="--" type="text"></asp:TextBox></td>
                                                                  <td>&nbsp;</td>
                                                                  <td style="text-align:right;">
                                                                      <asp:Button ID="CmdSearchGarage" runat="server" OnClick="CmdSearchGarage_Click" Text="ค้นหา" Width="70px" />
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                  <td colspan="3" style="height: 10px"></td>
                                                              </tr>
                                                              <tr>
                                                                  <td colspan="3">
                                                                      <asp:GridView ID="GrdGarageSelector" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="GrdGarageSelector_SelectedIndexChanged">
                                                                          <Columns>
                                                                              <asp:ButtonField ButtonType="Image" ImageUrl="~/App_Images/embedsemantic.png" CommandName="Select">
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                              <ItemStyle HorizontalAlign="Center" Width="30px" />
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
                                                                  </td>
                                                              </tr>
                                                              <tr>
                                                                  <td colspan="3" style="height: 10px"></td>
                                                              </tr>
                                                              <tr>
                                                                  <td style="text-align:left;">&nbsp;</td>
                                                                  <td>&nbsp;</td>
                                                                  <td style="text-align:right;">&nbsp;<asp:Button ID="CmdCloseGarageCollection" runat="server" Text="ปิด" Width="70px" /></td>
                                                              </tr>
                                                      </table>
		                                           </div>
		                                    </div>
                                             </div>
                                        </asp:Panel>

   


                                    </div>
                              </asp:View>
                              <asp:View ID="View6x" runat="server">
                                  <table style="width:100%;">
                                       <tr>
                                        <td colspan="12" style="text-align:right">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                                            <asp:ImageButton ID="imgBtn6" runat="server" ImageUrl="../App_Images/xls.png" Width="3%" Height="3%" OnClick="imgBtn6_Click" />
                                        </td>
                                    </tr>
                                                                 <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0">&nbsp;6.รายการเอกสารใบแจ้งซ่อม :<font color="#000080">รายการปิดงานซ่อมแล้ว &nbsp;</font> </td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">&nbsp;**&nbsp; </td>
                                                                 </tr>
                                                              <tr>
                                                                  <td colspan="2" style="border-style: solid none none solid; border-width: 1px 1px 0px 1px; border-color: #CCCCCC; background-color: #F0F0F0; font-size: small;">
                                                                      &nbsp;จากวันที่ :<asp:TextBox ID="TxtSDate" runat="server" Width="100px"></asp:TextBox>
                                                                      <ajaxToolkit:CalendarExtender ID="TxtSDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate" TargetControlID="TxtSDate" />
                                                                      <asp:ImageButton ID="imgOrderDate" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" ToolTip="เลือกวันที่" Width="16px" />
                                                                      &nbsp; ถึงวันที่ :<asp:TextBox ID="TxtEDate" runat="server" Width="100px"></asp:TextBox>
                                                                      <ajaxToolkit:CalendarExtender ID="TxtEDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgOrderDate2" TargetControlID="TxtEDate" />
                                                                      <asp:ImageButton ID="imgOrderDate2" runat="server" Height="18px" ImageUrl="~/App_Images/Calendar_scheduleHS.png" ToolTip="เลือกวันที่" Width="16px" />
                                                                      &nbsp; ทะเบียนรถ :
                                                                      <asp:TextBox ID="TxtLicense" runat="server" BorderStyle="Solid" BorderWidth="1px" MaxLength="10" Width="90px"></asp:TextBox>
                                                                     
                                                                      &nbsp;</td>
                                                                  <td style="border-width: 1px; border-color: #CCCCCC; border-style: solid solid none none; text-align:right; height: 18px; background-color: #F0F0F0; font-size: small; font-weight: lighter; color: #990000;">
                                                                      <asp:Button ID="CmdSearchRQ" runat="server" ForeColor="Black" Text="ค้นหา" Width="70px" OnClick="CmdSearchRQ_Click"  />
                                                                  </td>
                                                              </tr>
                                                                 <tr>
                                                                     <td colspan="3">
                                                                         <asp:GridView ID="GrdRepairOrderAct6" runat="server" AutoGenerateColumns="False" CellSpacing="1" DataKeyNames="MNT_ORD_NO" OnSelectedIndexChanged="GrdRepairOrderAct6_SelectedIndexChanged" Width="100%">
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
                                                                                     <ItemStyle Font-Size="Small" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:TemplateField>
                                                                                 <asp:BoundField DataField="MNT_ORD_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" วันที่">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_OWN_SITE" HeaderText="ศูนย์/สาขา">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="80px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_ORD_NO" HeaderText="ใบแจ้งซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="135px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_CODE" HeaderText="เลขรถ">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_LICENSE" HeaderText="ทะเบียน">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="VEH_TYPE" HeaderText="ประเภท">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="GARAGE_NAME" HeaderText="อู่ซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" Width="120px" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="MNT_OWN_USR" HeaderText="ผู้แจ้งซ่อม">
                                                                                 <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                                 <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Small" Height="18px" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                 </asp:BoundField>
                                                                                 <asp:BoundField DataField="REQ_INFO" HeaderText="ขอซ่อม">
                                                                              <HeaderStyle BackColor="#F0F0F0" BorderColor="#CCCCCC" />
                                                                              <HeaderStyle BackColor="#F0F0F0" Font-Bold="False" Font-Size="Small" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                              </asp:BoundField>
                                                                              <asp:BoundField DataField="MNT_TYPE">
                                                                             <HeaderStyle Font-Bold="False" Font-Size="Small" BackColor="#F0F0F0" BorderColor="#CCCCCC" BorderWidth="1px" HorizontalAlign="Center" />
                                                                              <ItemStyle Font-Size="Small" BorderColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Top" />
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
                                                                  <td style="text-align:left; height: 18px;"></td>
                                                                  <td style="height: 18px; text-align: right; font-size: x-small; color: #008080;" colspan="2">** CR : Corrective PM: Preventive</td>
                                                              </tr>
                                                      </table>
                                  
                              </asp:View>
                               <asp:View ID="View7x" runat="server">
                                   Emply
                              </asp:View>
                           </asp:MultiView>
                     </div>
                    </div>
                    <div class="col-sm-2">
			        <div class="panel panel-default">
				        <div class="panel-heading">
					        <h1 class="panel-title"><span class="glyphicon glyphicon-random">&nbsp;</span> แฟ้มเอกสารใบแจ้งซ่อม</h1>  </div>
                             <a class="list-group-item">
                                <asp:Button ID="CmdAct1" runat="server" BackColor="Transparent" BorderStyle="None"  Text="1.เอกสารใหม่" OnClick="CmdAct1_Click" /><span class="w3-badge w3-green"><asp:Label ID="LblAct1Amt" runat="server" Text="-"></asp:Label></span></a>
                                 <a class="list-group-item">
                                <asp:Button ID="CmdAct2" runat="server" BackColor="Transparent" BorderStyle="None"  Text="2.เอกสารรออนุมัติ" OnClick="CmdAct2_Click" /><span class="w3-badge w3-green"><asp:Label ID="LblAct2Amt" runat="server" Text="-"></asp:Label></span></a>
                                 <a class="list-group-item">
                                <asp:Button ID="CmdAct3" runat="server" BackColor="Transparent" BorderStyle="None"  Text="3.ขอรายละเอียดเพิ่มเติม" OnClick="CmdAct3_Click" /><span class="w3-badge w3-red"><asp:Label ID="LblAct3Amt" runat="server" Text="-"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct4" runat="server" BackColor="Transparent" BorderStyle="None"  Text="4.รายการไม่อนุมัติซ่อม" OnClick="CmdAct4_Click" /><span class="w3-badge w3-red"><asp:Label ID="LblAct4Amt" runat="server" Text="-"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct5" runat="server" BackColor="Transparent" BorderStyle="None"  Text="5.รายการระหว่างซ่อม" OnClick="CmdAct5_Click2" /><span class="w3-badge w3-red"><asp:Label ID="LblAct5Amt" runat="server" Text="-"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct6" runat="server" BackColor="Transparent" BorderStyle="None"  Text="6.รายการปิดงานซ่อมแล้ว" OnClick="CmdAct6_Click" /></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct7" runat="server" BackColor="Transparent" BorderStyle="None"  Text="ออกใบแจ้งซ่อมใหม่ ..." OnClick="CmdAct7_Click"  /></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdHistry" runat="server" BackColor="Transparent" BorderStyle="None"  Text="A.ประวัติการซ่อม" OnClick="CmdHistry_Click"   /></a>
				        </div>
			        </div>
                    </div>
		        </div>
            </div>
</asp:Content>





