<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Hotel_Management_System.Views.Admin.Categories" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@10/dist/sweetalert2.min.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10/dist/sweetalert2.all.min.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row"><div class ="col-md-5"></div><div class ="col-md-5"></div><div class ="col-md-2"><label id ="LogedUser" runat="server" class="text-success"></label></div></div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <h1 class="text-success text-center">Manage Categories</h1>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-md-3">  
                <div class="mb-3">
                    <label for="CatNameTb" class="form-label">Category Name</label>
                    <input type="text" class="form-control" id="CatNameTb" runat="server">
                </div>

                <div class="mb-3">
                    <label for="RemarkTb" class="form-label">Category Remarks</label>
                    <input type="text" class="form-control" id="RemarkTb" runat="server">
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

                <br />
            </div>
            <div class="col-md-6" style="margin-left:290px; margin-top:50px" >


                <asp:GridView ID="CategoriesGV" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="CategoriesGV_SelectedIndexChanged">
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
