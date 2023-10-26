<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Hotel_Management_System.Views.Users.Booking" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col">
                        <div class="row">
                            <div class="col">
                                <div class="mb-3">
                                    <label for="RoomTb" class="form-label">Room</label>
                                    <input type="text" class="form-control" id="RoomTb" runat="server">
                                </div>
                                <div class="mb-3">
                                    <label for="DateInTb" class="form-label">Date In</label>
                                    <input type="date" class="form-control" id="DateInTb" runat="server">
                                </div>
                            </div>
                            <div class="col">
                                <div class="mb-3">
                                    <label for="DateOutTb" class="form-label">Date Out</label>
                                    <input type="date" class="form-control" id="DateOutTb" runat="server">
                                </div>
                                <div class="mb-3">
                                    <label for="AmountTb" class="form-label">Amount</label>
                                    <input type="text" class="form-control" id="AmountTb" runat="server">
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">

                                <div>
                                    <label id="ErrMsg" runat="server" class="text-danger"></label>

                                    <asp:Button ID="BookBtn" runat="server" Text="Book Room" class="btn btn-warning" OnClick="BookBtn_Click" />
                                    <asp:Button ID="ResetBtn" runat="server" Text="Reset" class="btn btn-danger" OnClick="ResetBtn_Click" />
                                </div>
                                <br />
                               

                            </div>
                        </div>

                    </div>
                </div>
                <h3 class="text-primary">Rooms</h3>



                <asp:GridView ID="RoomsGV" CellPadding="4" ForeColor="#333333" GridLines="None" runat="server" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged">
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
            <div class="col">
                <div class="row">
                    <div class="col"></div>
                    <div class="col"><h2 class ="text-primary">Pending Booking</h2></div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="BookingGV" CellPadding="4" ForeColor="#333333" GridLines="None" runat="server">
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
        </div>
    </div>
</asp:Content>
