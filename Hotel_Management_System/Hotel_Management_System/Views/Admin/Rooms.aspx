<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="Hotel_Management_System.Views.Admin.Rooms" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <h1 class="text-success text-center">Manage Rooms</h1>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <div class="mb-3">
                    <label for="RNameTb" class="form-label">Room Name</label>
                    <input type="text" class="form-control" id="RNameTb" name="RNameTb" runat="server" required="required">
                </div>
                <div class="mb-3">
                    <label for="CatCb" class="form-label">Categories</label>
                    <asp:DropDownList ID="CatCb" runat="server" class="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="LocationTb" class="form-label">Location</label>
                    <input type="text" class="form-control" id="LocationTb" name="LocationTb" runat="server" required="required">
                </div>
                <div class="mb-3">
                    <label for="CostTb" class="form-label">Room Cost</label>
                    <input type="text" class="form-control" id="CostTb" name="CostTb" runat="server" required="required">
                </div>
                <div class="mb-3">
                    <label for="RemarksTb" class="form-label">Remarks</label>
                    <input type="text" class="form-control" id="RemarksTb" name="RemarksTb" runat="server" required="required">
                </div>
                <div class="mb-3">
                    <label for="CatCb" class="form-label">Status</label>
                    <asp:DropDownList ID="StatusCb" runat="server" class="form-control">
                        <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Booked</asp:ListItem>
                    </asp:DropDownList>
                </div>
             
                <div class="row">
                    <div class="col d-grid">
                        <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-warning btn-block" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block" OnClick="DeleteBtn_Click" />
                    </div>
                        
                    </div>
                
                    <br />
               
                    <div class="d-grid">
                        <label id="ErrMsg" runat="server" class="text-danger"></label>

                        <asp:Button ID="SaveBtn" runat="server" Text="Save" class="btn btn-success" OnClick="SaveBtn_Click" />
                    </div>
                </div>

                    <br />
            
                <br />
                <div class="col-md-6" style="margin-left:290px; margin-top:50px" >


     <asp:GridView ID="RoomsGV" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged" >
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                     <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select">
            <img src="../../Assets/Images/Edit.png" alt="Edit Image" width="50" height="50"  />
                     </asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
 </div>
            
         
        </div>
        </div>

</asp:Content>
