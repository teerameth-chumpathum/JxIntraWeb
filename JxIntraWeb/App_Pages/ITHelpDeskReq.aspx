<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ITHelpDeskReq.aspx.cs" Inherits="JxIntraWeb.App_Pages.ITHelpDeskReq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<%--<div class="w3-container">
  <h2>Badges</h2>
  <p>You can use color classes to change the color of a badge:</p>
  <p>News <span class="w3-badge w3-green">6</span></p>
  <p>Comments <span class="w3-badge w3-red">8</span></p>
</div>--%>


        <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
      		<div class="panel panel-default">
			    <div class="panel-heading">
					<h4 class="panel-title">
						<strong>Infomation Technology Dept.</strong> HelpDesk Management System</h4>
				</div>
				<div class="panel-body">
                    <div class="col-sm-9">
                       <div class="w3-container w3-white w3-cell">
                  
                           <asp:MultiView ID="MultiView1" runat="server">
                               <asp:View ID="View0x" runat="server">
                                   v0x---Emply
                                       <p><strong>ข้ออกำหนดสำหรับบัญชีชื่อและรหัสผ่าน</strong></p>
                                        <ul>
                                              <li>เพื่อความปลอดภัย ท่านต้องเก็บรักษาบัญชีชื่อและรหัสผ่านเป็นความลับ,ห้ามใช้ร่วมกัน </li>
                                              <li>รหัสผ่านควรเปลี่ยนทุกๆ 1 เดือนด้วยคำที่คาดเดายากและมีความยาวอย่างน้อย 6 ตัวอักษร</li>
                                        </ul>
                               </asp:View>
                               <asp:View ID="View1x" runat="server">
                                   &nbsp;<div class="w3-container">
                                                <table class="w3-table w3-border">
                                            <tr style="background-color: #F0F0F0">
                                              <td style="text-align:left;">แบบฟอร์มเอกสารแจ้งซ่อมระบบ IT</td>
                                              <td></td>
                                              <td style="text-align:right;" >&nbsp;</td>
                            
                                            </tr>
                                            <tr>
                                              <td style="text-align:left;">วันที่แจ้งซ่อม :<asp:TextBox ID="TxtOrderDate" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Text="-" type="text" Width="100px" ReadOnly="True"></asp:TextBox>
                                                </td>
                                              <td></td>
                                              <td style="text-align:right;" >เลขที่เอกสาร :<asp:TextBox ID="TxtOrderNo"  class="w3-border-bottom" type="text"  runat="server"  BorderStyle="None" Text="-" Width="140px" Font-Size="Small" ReadOnly="True"></asp:TextBox></td>
                            
                                            </tr>
                                          </table>
                                        <table class="w3-table w3-border">
                                                  <tr>
                                                  <td style="text-align:left; font-size: small; ">รุ่นรถ<br><asp:TextBox ID="TxtVehModel" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                  <td style="text-align:left; font-size: small; ">
                                                      &nbsp;</td>
                                                    <td style="text-align:left; font-size: small; "></td>
                                                    <td style="text-align:right; height: 25px;">
                                                        </td>
                                                </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">เชื่อเพลิง<br><asp:TextBox ID="TxtVehFuel" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text" ReadOnly="True"></asp:TextBox>
                                                      </td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="text-align:left; font-size: small; "></td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          <asp:Button ID="CmdOpenVehCollection" runat="server" Text="..." Width="30px"  />
   
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td style="text-align:left; font-size: small; ">ติดต่อ<br><asp:TextBox ID="TxtGarageContact" runat="server" BorderStyle="None" class="w3-border-bottom" Font-Size="Small" Height="19px" Text="-" type="text"  ReadOnly="True"></asp:TextBox></td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="text-align:left; font-size: small; ">
                                                          &nbsp;</td>
                                                      <td style="text-align:right; font-size: small; ">
                                                          <asp:Button ID="CmdOpenGarageCollection" runat="server"  Text="..." Width="30px" />
                                                   
                                                      </td>
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
                                                           <asp:GridView ID="GrdRepairDesc" runat="server" AutoGenerateColumns="False"  Width="100%" DataKeyNames="IDx">
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
                                                           <asp:Button ID="CmdAddDescLine" runat="server" Text="เพิ่มรายการ " Width="100px"  />
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>

                                   </div>
                               </asp:View>
                               <asp:View ID="View2x" runat="server">
                                   <asp:GridView ID="GridView1" runat="server">
                                   </asp:GridView>
                                   3----------
                               </asp:View>
                               <asp:View ID="View3x" runat="server">
                                   <asp:GridView ID="GridView2" runat="server">
                                   </asp:GridView>
                               </asp:View>
                               <asp:View ID="View4x" runat="server">
                                   v4x
                               </asp:View>
                              <asp:View ID="View5x" runat="server">
                                   v5x
                               </asp:View>
                           </asp:MultiView>

                     </div>
                    </div>
                    <div class="col-sm-3">
			        <div class="panel panel-default">
				        <div class="panel-heading">
					        <h1 class="panel-title"><span class="glyphicon glyphicon-random"> </span> แฟ้มใบแจ้งปัญหา</h1>
				        </div>
				        <div class="list-group">
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct1" runat="server" BackColor="Transparent" BorderStyle="None"  Text="1.รายการใบแจ้งปัญหาใหม่   " OnClick="CmdAct1_Click"/><span class="w3-badge w3-black"><asp:Label ID="LblAct1Bal" runat="server" Text="6"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct1a" runat="server" BackColor="Transparent" BorderStyle="None"  Text="2.รายการรอ Staff รับงาน "/><span class="w3-badge w3-yellow"><asp:Label ID="LblAct1aBal" runat="server" Text="8"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct2" runat="server" BackColor="Transparent" BorderStyle="None"  Text="3.รายการขอรายละเอียดเพิ่มเติม "/><span class="w3-badge w3-red"><asp:Label ID="LblAct2Bal" runat="server" Text="8"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct3" runat="server" BackColor="Transparent" BorderStyle="None"  Text="4.รายการที่อยู่ระหว่างปฏิบัติงาน  " OnClick="CmdAct3_Click"/><span class="w3-badge w3-orange"><asp:Label ID="LblAct3Bal" runat="server" Text="9"></asp:Label></span></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct4" runat="server" BackColor="Transparent" BorderStyle="None"  Text="5.รายการที่ปิดงานเรียบร้อยแล้ว  " OnClick="CmdAct4_Click"/></a>
                            <a class="list-group-item">
                                <asp:Button ID="CmdAct5" runat="server" BackColor="Transparent" BorderStyle="None" OnClick="CmdAct5_Click" Text="6.ออกใบแจ้งปัญหาใหม่ ..." /></a>
				        </div>
			        </div>
                    </div>
		       </div>
		</div>
     </div>








</asp:Content>
