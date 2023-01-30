<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JxIntraWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TP Maintenance Management System->Authentication</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/> 
      <!-- Bootstrap Core CSS -->
        <link rel="stylesheet" href="/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="/App_Content/w3.css"/>
        <style>
            /*.w3-theme {color:#fff !important;background-color:#002efb !important}*/
            .w3-theme {color:#fff !important;background-color:#4CAF50 !important}
            .w3-btn {background-color:#4CAF50;margin-bottom:4px}
            .w3-code{border-left:4px solid #4CAF50}
            .auto-style1 {
                width: 58px;
                height: 33px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="w3-container w3-theme w3-leftbar w3-border-white w3-hover-border-red">
            <div class="w3-left"><img src="../App_Images/tplogistics_logo.png"  alt="JxIntraWeb" style="margin-top:5px;padding:0px;" class="auto-style1"/></div>
            <div class="w3-left"><strong> บริษัท ไทยพาร์เซิล จำกัด (มหาชน)</strong></div><br/>
            <div class="w3-left"  style="margin-left:10px;margin-top:-7px;" ><small><small> THAI PARCELS LOGISTICS CO,.LTD</small></small></div>
            <div class="w3-right" style="margin-top:3px;">ส่งพัสดุ ถึงบ้าน ทุกขนาด มีสาขาบริการทั่วประเทศ</div>
        </div>
        <div class="w3-main w3-container" style="margin-left:0px;margin-top:5px;">
      		<div class="panel panel-default">
			    <div class="panel-heading">
					<h4 class="panel-title">
						<strong>Infomation Technology Dept.</strong>  Transports Management System
					</h4>
				</div>
				<div class="panel-body">
                    <div class="col-sm-5">
                       <div class="w3-container w3-white w3-cell">
                       <p><strong>ข้ออกำหนดสำหรับบัญชีชื่อและรหัสผ่าน</strong></p>
                        <ul>
                              <li>เพื่อความปลอดภัย ท่านต้องเก็บรักษาบัญชีชื่อและรหัสผ่านเป็นความลับ,ห้ามใช้ร่วมกัน </li>
                              <li>รหัสผ่านควรเปลี่ยนทุกๆ 1 เดือนด้วยคำที่คาดเดายากและมีความยาวอย่างน้อย 6 ตัวอักษร</li>
                              <li>สงวนลิขสิทธิ์ &copy;2021 บริษัท ไทยพาร์เซิล จำกัด (มหาชน) </li>
                              <li><p><a href="#">Terms &amp; Conditions</a> | <a href="#">Privacy Policy</a> | <a href="#">Contact</a> | <a href="https://thaiparcels.com/">www.thaiparcels.com</a></p></li>
                        </ul>
                     </div>
                    </div>
                    <div class="col-sm-4">
                       <div class="w3-container w3-white w3-cell">
                          <p><strong>ระบัญชีชื่อและรหัสผ่าน</strong></p>
                          <ul>
                              <li>หากไม่สามารภเข้าระบบได้ ติดต่อ แผนก IT Support 081-4587858</li>
                              <li>หากไม่มีบัญชีผู้ใช้ ติดต่อ แผนก IT เพื่อลงทะเบียนเปิดบัญชีชื่อผู้ใช้ก่อน</li>
                         </ul>
                    </div>
                    </div>
                    <div class="col-sm-3">
                         <div class="w3-container w3-white w3-cell">
                             <p><strong>ยืนยันตัวตนเพื่อเข้าระบบ</strong></p>
						 <div class="form-group">
							 <asp:TextBox ID="TxtAccount"  class="w3-border-bottom" type="text" placeholder="บัญชีชื่อ" runat="server" Width="200px" BorderStyle="None" ></asp:TextBox>
						 </div>
						 <div class="form-group">
							<asp:TextBox ID="TxtPassword"  class="w3-border-bottom" type="text" placeholder="รหัสผ่าน" runat="server" TextMode="Password" Width="200px" BorderStyle="None" ></asp:TextBox>
						 </div>
                         <div class="form-group">
                             <asp:Label ID="LblLogInRet" runat="server" ForeColor="#990000"></asp:Label>
                         </div>
                         <div class="form-group">
                             <asp:Button ID="CmdLogIn" class="btn btn-default" runat="server" Text="เข้าระบบ" OnClick="CmdLogIn_Click" />
                         </div>
						 
				        </div>
                    </div>
		       </div>
		</div>
     </div>
    </form>
</body>
</html>
